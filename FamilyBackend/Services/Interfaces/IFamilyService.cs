using FamilyBackend.Models;

namespace FamilyBackend.Services.Interfaces
{
    public interface IFamilyService
    {
        void CreateFamily(Family newFamily);
        Family? GetFamilyById(int familyId);
        List<Family> GetAllFamilies();
        void UpdateFamily(int familyId, Family updatedFamily);
        void DeleteFamily(int familyId);
    }
}
