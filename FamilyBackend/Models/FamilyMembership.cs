namespace FamilyBackend.Models
{
    public class FamilyMembership
    {
        public int FamilyId { get; set; }
        public Family Family { get; set; }

        public int FamilyMemberId { get; set; }
        public FamilyMember FamilyMember { get; set; }

        public FamilyMembership()
        {
        }

        public FamilyMembership(int familyId, int familyMemberId)
        {
            FamilyId = familyId;
            FamilyMemberId = familyMemberId;
        }
    }
}
