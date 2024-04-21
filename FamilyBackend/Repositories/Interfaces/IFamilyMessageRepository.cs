using FamilyBackend.Models;

namespace FamilyBackend.Repositories.Interfaces
{
    public interface IFamilyMessageRepository
    {
        IEnumerable<FamilyMessage>? GetFamilyMessagesByFamilyId(long groupId);
        FamilyMessage? GetFamilyMessageById(long messageId);
        void AddFamilyMessage(FamilyMessage message);
        void UpdateFamilyMessage(FamilyMessage message);
        void DeleteFamilyMessage(long messageId);
    }
}
