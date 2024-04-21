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

        public IEnumerable<FamilyMessage> GetMessagesByGroupId(long groupId)
        {
            return _familyMessageRepository.GetMessagesByFamilyId(groupId);
        }
    }
}
