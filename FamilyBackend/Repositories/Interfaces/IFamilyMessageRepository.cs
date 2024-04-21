using FamilyBackend.Models;

namespace FamilyBackend.Repositories.Interfaces
{
    public interface IFamilyMessageRepository
    {
        IEnumerable<FamilyMessage> GetMessagesByFamilyId(long groupId);
        void AddMessage(FamilyMessage message);
    }
}
