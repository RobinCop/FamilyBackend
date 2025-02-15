﻿using FamilyBackend.Models;

namespace FamilyBackend.Repositories.Interfaces
{
    public interface IFamilyRepository
    {
        void CreateFamily(Family newFamily);
        Family? GetFamilyById(int familyId);
        List<Family> GetAllFamilies();
        void UpdateFamily(int familyId, Family updatedFamily);
        void DeleteFamily(int familyId);
    }
}
