using FamilyBackend.DatabaseContexts;
using FamilyBackend.Models;
using FamilyBackend.Repositories.Interfaces;

namespace FamilyBackend.Repositories
{
    public class FamilyRepository : IFamilyRepository
    {
        private readonly ILogger<FamilyRepository> _logger;
        private readonly DatabaseContext _dbContext;

        public FamilyRepository(ILogger<FamilyRepository> logger, DatabaseContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public void CreateFamily(Family newFamily)
        {
            try
            {
                _dbContext.Family.Add(newFamily);
                _dbContext.SaveChanges();
                _logger.LogInformation("New family created successfully.");
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
                var familyToDelete = _dbContext.Family.Find(familyId);
                if(familyToDelete == null)
                {
                    _logger.LogInformation($"No family found with ID {familyId}.");
                    return;
                }
                _dbContext.Family.Remove(familyToDelete);
                _dbContext.SaveChanges();
                _logger.LogInformation($"Family with ID {familyId} deleted successfully.");
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
                var allFamilies = _dbContext.Family.ToList();
                if(allFamilies.Count > 0)
                {
                    _logger.LogInformation("Retrieved all families successfully.");
                    return allFamilies;
                }
                return new List<Family>(); 
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
                var family = _dbContext.Family.Find(familyId);
                if(family == null)
                    _logger.LogInformation($"No family found with ID {familyId}.");
                else
                _logger.LogInformation($"Retrieved family with ID {familyId} successfully.");
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
                if (updatedFamily.FamilyId != familyId)
                    throw new ArgumentException("Family ID does not match the ID of the family to update.");

                var oldFamily = GetFamilyById(familyId);
                if (oldFamily != null)
                    _dbContext.Family.Update(updatedFamily);

                _dbContext.SaveChanges();
                _logger.LogInformation($"Family with ID {familyId} updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating family with ID {familyId}.");
                throw;
            }
        }
    }
}
