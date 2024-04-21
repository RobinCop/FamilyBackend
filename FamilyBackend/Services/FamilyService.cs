using FamilyBackend.Models;
using FamilyBackend.Repositories.Interfaces;
using FamilyBackend.Services.Interfaces;

namespace FamilyBackend.Services
{
    public class FamilyService : IFamilyService
    {
        private readonly IFamilyRepository _familyRepository;
        private readonly ILogger<FamilyService> _logger;

        public FamilyService(IFamilyRepository familyRepository, ILogger<FamilyService> logger)
        {
            _familyRepository = familyRepository;
            _logger = logger;
        }

        public void CreateFamily(Family newFamily)
        {
            try
            {
                _familyRepository.CreateFamily(newFamily);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a new family.");
                throw;
            }
        }

        public void DeleteFamily(int familyId)
        {
            try
            {
                _familyRepository.DeleteFamily(familyId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting family with ID {familyId}.");
                throw;
            }
        }

        public List<Family> GetAllFamilies()
        {
            try
            {
                var families = _familyRepository.GetAllFamilies();
                return families;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving all families.");
                throw;
            }
        }

        public Family? GetFamilyById(int familyId)
        {
            try
            {
                var family = _familyRepository.GetFamilyById(familyId);
                return family;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving family with ID {familyId}.");
                throw;
            }
        }

        public void UpdateFamily(int familyId, Family updatedFamily)
        {
            try
            {
                _familyRepository.UpdateFamily(familyId, updatedFamily);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating family with ID {familyId}.");
                throw;
            }
        }
    }
}
