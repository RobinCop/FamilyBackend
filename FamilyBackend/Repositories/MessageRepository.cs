using FamilyBackend.DatabaseContexts;
using FamilyBackend.Models;
using FamilyBackend.Repositories.Interfaces;

namespace FamilyBackend.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly DatabaseContext _dbContext;

        public MessageRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<FamilyMessage> GetMessagesByFamilyId(long groupId)
        {
            // Assuming you have a DbSet<Message> in your DatabaseContext named Messages
            return _dbContext.FamilyMessage.Where(m => m.RecipientId == groupId).ToList();
        }

        public void AddMessage(FamilyMessage message)
        {
            // Assuming you have a DbSet<Message> in your DatabaseContext named Messages
            _dbContext.FamilyMessage.Add(message);
            _dbContext.SaveChanges();
        }
    }
}
