using FamilyBackend.DatabaseContexts;
using FamilyBackend.Models;
using FamilyBackend.Repositories.Interfaces;

namespace FamilyBackend.Repositories
{
    public class FamilyMessageRepository : IFamilyMessageRepository
    {
        private readonly ILogger<FamilyMessageRepository> _logger;
        private readonly DatabaseContext _dbContext;

        public FamilyMessageRepository(ILogger<FamilyMessageRepository> logger , DatabaseContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IEnumerable<FamilyMessage>? GetFamilyMessagesByFamilyId(long groupId)
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

        public FamilyMessage? GetFamilyMessageById(long messageId)
        {
            try
            {
                var famMessage = _dbContext.FamilyMessage.Find(messageId);
                if (famMessage == null)
                    return null;
                return famMessage;
            }
            catch(Exception ex)
            {
                _logger.LogError($"An error occurred while retrieving message with ID {messageId}: {ex.Message}");
                return null;
            }
        }

        public void AddFamilyMessage(FamilyMessage message)
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

        public void UpdateFamilyMessage(FamilyMessage message)
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

        public void DeleteFamilyMessage(long messageId)
        {
            try
            {
                var message = _dbContext.FamilyMessage.Find(messageId);
                if (message == null)
                {
                    _logger.LogWarning($"Message with ID {messageId} not found.");
                    return;
                }

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
