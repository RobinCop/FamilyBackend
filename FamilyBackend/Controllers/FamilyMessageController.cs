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

        [HttpGet("{familyId}", Name = "GetMessagesByFamilyId")]
        public ActionResult<IEnumerable<FamilyMessage>> GetMessagesByFamilyId(long familyId)
        {
            try
            {
                var messages = _familyMessageService.GetFamilyMessagesByFamilyId(familyId);

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
