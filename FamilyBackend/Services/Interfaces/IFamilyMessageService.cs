using FamilyBackend.Models;

namespace FamilyBackend.Services.Interfaces
{
    public interface IFamilyMessageService
    {
        IEnumerable<FamilyMessage> GetMessagesByGroupId(long groupId);
    }
}
