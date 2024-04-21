using FamilyBackend.Models;
using FamilyBackend.Repositories.Interfaces;
using FamilyBackend.Services.Interfaces;

namespace FamilyBackend.Services
{
    public class FamilyMessageService : IFamilyMessageService
    {
        private readonly IFamilyMessageRepository _familyMessageRepository;

        public FamilyMessageService(IFamilyMessageRepository familyMessageRepository)
        {
            _familyMessageRepository = familyMessageRepository;
        }

        public IEnumerable<FamilyMessage>? GetFamilyMessagesByGroupId(long groupId)
        {
            return _familyMessageRepository.GetFamilyMessagesByFamilyId(groupId);
        }

        public FamilyMessage? GetFamilyMessageById(long messageId)
        {
            return _familyMessageRepository.GetFamilyMessageById(messageId);
        }

        public void AddFamilyMessage(FamilyMessage message)
        {
            _familyMessageRepository.AddFamilyMessage(message);
        }

        public void DeleteFamilyMessage(long messageId)
        {
            _familyMessageRepository.DeleteFamilyMessage(messageId);
        }

        public void UpdateFamilyMessage(FamilyMessage message)
        {
            _familyMessageRepository.UpdateFamilyMessage(message);
        }
    }
}
