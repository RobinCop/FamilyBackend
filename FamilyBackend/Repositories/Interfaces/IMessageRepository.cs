using FamilyBackend.Models;

namespace FamilyBackend.Repositories.Interfaces
{
    public interface IMessageRepository
    {
        IEnumerable<Message> GetMessagesByGroupId(long groupId);
        void AddMessage(Message message);
    }
}
