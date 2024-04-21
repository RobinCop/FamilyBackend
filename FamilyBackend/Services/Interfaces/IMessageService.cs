using FamilyBackend.Models;

namespace FamilyBackend.Services.Interfaces
{
    public interface IMessageService
    {
        IEnumerable<FamilyMessage> GetMessagesByGroupId(long groupId);
    }
}
