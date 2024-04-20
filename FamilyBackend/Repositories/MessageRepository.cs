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

        public IEnumerable<Message> GetMessagesByGroupId(long groupId)
        {
            // Assuming you have a DbSet<Message> in your DatabaseContext named Messages
            return _dbContext.Messages.Where(m => m.FamiliyGroupId == groupId).ToList();
        }

        public void AddMessage(Message message)
        {
            // Assuming you have a DbSet<Message> in your DatabaseContext named Messages
            _dbContext.Messages.Add(message);
            _dbContext.SaveChanges();
        }
    }
}
