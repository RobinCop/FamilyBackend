using FamilyBackend.Models;

namespace FamilyBackend.Repositories.Interfaces
{
    public interface IMessageRepository
    {
        IEnumerable<FamilyMessage> GetMessagesByFamilyId(long groupId);
        void AddMessage(FamilyMessage message);
    }
}
