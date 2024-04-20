using FamilyBackend.Models;
using FamilyBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FamilyBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly ILogger<MessageController> _logger;
        private readonly IMessageService _messageService;


        public MessageController(ILogger<MessageController> logger, IMessageService messageService)
        {
            _logger = logger;
            _messageService = messageService;
        }

        [HttpGet("{groupId}", Name = "GetMessageByGroupId")]
        public ActionResult<IEnumerable<Message>> GetMessagesByGroupId(long groupId)
        {
            try
            {
                // Assuming GetMessageById method fetches messages from some data source
                var messages = _messageService.GetMessagesByGroupId(groupId);

                if (messages == null || !messages.Any())
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching messages.");
                return StatusCode(500, "An error occurred while fetching messages.");
            }
        }


    }
}
