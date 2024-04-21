using FamilyBackend.DatabaseContexts;
using FamilyBackend.Models;
using FamilyBackend.Repositories.Interfaces;

namespace FamilyBackend.Repositories
{
    public class FamilyMessageRepository : IFamilyMessageRepository
    {
        private readonly DatabaseContext _dbContext;

        public FamilyMessageRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<FamilyMessage> GetMessagesByFamilyId(long groupId)
        {
            return _dbContext.FamilyMessage.Where(m => m.RecipientId == groupId).ToList();
        }

        public void AddMessage(FamilyMessage message)
        {
            _dbContext.FamilyMessage.Add(message);
            _dbContext.SaveChanges();
        }
    }
}
