using FamilyBackend.Models;

namespace FamilyBackend.Services.Interfaces
{
    public interface IMessageService
    {
        IEnumerable<Message> GetMessagesByGroupId(long groupId);
    }
}
