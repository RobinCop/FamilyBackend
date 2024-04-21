using FamilyBackend.Models;

namespace FamilyBackend.Services.Interfaces
{
    public interface IFamilyMessageService
    {
        IEnumerable<FamilyMessage>? GetFamilyMessagesByGroupId(long groupId);
        FamilyMessage? GetFamilyMessageById(long messageId);
        void AddFamilyMessage(FamilyMessage message);
        void UpdateFamilyMessage(FamilyMessage message);
        void DeleteFamilyMessage(long messageId);
    }
}
