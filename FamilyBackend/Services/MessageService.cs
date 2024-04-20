using FamilyBackend.Models;
using FamilyBackend.Repositories.Interfaces;
using FamilyBackend.Services.Interfaces;

namespace FamilyBackend.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public IEnumerable<Message> GetMessagesByGroupId(long groupId)
        {
            return _messageRepository.GetMessagesByGroupId(groupId);
        }
    }
}
