using FamilyBackend.Models;
using FamilyBackend.Repositories.Interfaces;
using FamilyBackend.Services.Interfaces;

namespace FamilyBackend.Services
{
    public class FamilyMessageService : IFamilyMessageService
    {
        private readonly IFamilyMessageRepository _familyMessageRepository;
        private readonly ILogger<FamilyMessageService> _logger;

        public FamilyMessageService(IFamilyMessageRepository familyMessageRepository, ILogger<FamilyMessageService> logger)
        {
            _familyMessageRepository = familyMessageRepository;
            _logger = logger;
        }

        public IEnumerable<FamilyMessage>? GetFamilyMessagesByFamilyId(long familyId)
        {
            try
            {
                var messages = _familyMessageRepository.GetFamilyMessagesByFamilyId(familyId);
                return messages;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving family messages for Group ID {familyId}.");
                throw;
            }
        }

        public FamilyMessage? GetFamilyMessageById(long familyMessageId)
        {
            try
            {
                var message = _familyMessageRepository.GetFamilyMessageById(familyMessageId);
                return message;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving family message with ID {familyMessageId}.");
                throw;
            }
        }

        public void AddFamilyMessage(FamilyMessage message)
        {
            try
            {
                _familyMessageRepository.AddFamilyMessage(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding a new family message.");
                throw;
            }
        }

        public void DeleteFamilyMessage(long familymessageId)
        {
            try
            {
                _familyMessageRepository.DeleteFamilyMessage(familymessageId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting family message with ID {familymessageId}.");
                throw;
            }
        }

        public void UpdateFamilyMessage(FamilyMessage message)
        {
            try
            {
                _familyMessageRepository.UpdateFamilyMessage(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating family message with ID {message.FamilyMessageId}.");
                throw;
            }
        }
    }
}
