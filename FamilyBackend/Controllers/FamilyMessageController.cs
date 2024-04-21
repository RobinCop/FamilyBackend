using FamilyBackend.Models;
using FamilyBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FamilyBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamilyMessageController : ControllerBase
    {
        private readonly ILogger<FamilyMessageController> _logger;
        private readonly IFamilyMessageService _familyMessageService;


        public FamilyMessageController(ILogger<FamilyMessageController> logger, IFamilyMessageService familiMessageService)
        {
            _logger = logger;
            _familyMessageService = familiMessageService;
        }

        [HttpGet("{groupId}", Name = "GetMessageByGroupId")]
        public ActionResult<IEnumerable<FamilyMessage>> GetMessagesByGroupId(long groupId)
        {
            try
            {
                var messages = _familyMessageService.GetMessagesByGroupId(groupId);

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
