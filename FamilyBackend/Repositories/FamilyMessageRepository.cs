using FamilyBackend.DatabaseContexts;
using FamilyBackend.Models;
using FamilyBackend.Repositories.Interfaces;

namespace FamilyBackend.Repositories
{
    public class FamilyMessageRepository : IFamilyMessageRepository
    {
        private readonly DatabaseContext _dbContext;
        private readonly ILogger<FamilyMessageRepository> _logger;


        public FamilyMessageRepository(ILogger<FamilyMessageRepository> logger , DatabaseContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IEnumerable<FamilyMessage> GetMessagesByFamilyId(long groupId)
        {
            try
            {
                return _dbContext.FamilyMessage.Where(m => m.RecipientId == groupId).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while retrieving messages for family with ID {groupId}: {ex.Message}");
                return Enumerable.Empty<FamilyMessage>();
            }
        }

        public void AddMessage(FamilyMessage message)
        {
            try
            {
                _dbContext.FamilyMessage.Add(message);
                _dbContext.SaveChanges();
                _logger.LogInformation("Message added successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while adding message: {ex.Message}");
            }
        }

        public void UpdateMessage(FamilyMessage message)
        {
            try
            {
                _dbContext.FamilyMessage.Update(message);
                _dbContext.SaveChanges();
                _logger.LogInformation($"Message with ID {message.FamilyMessageId} updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while updating message with ID {message.FamilyMessageId}: {ex.Message}");
            }
        }

        public void DeleteMessage(long messageId)
        {
            var message = _dbContext.FamilyMessage.Find(messageId);
            if (message == null)
            {
                _logger.LogWarning($"Message with ID {messageId} not found.");
                return;
            }

            try
            {
                _dbContext.FamilyMessage.Remove(message);
                _dbContext.SaveChanges();
                _logger.LogInformation($"Message with ID {messageId} deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while deleting message with ID {messageId}: {ex.Message}");
            }
        }
    }
}
