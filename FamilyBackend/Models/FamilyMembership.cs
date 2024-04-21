namespace FamilyBackend.Models
{
    public class FamilyMembership
    {
        public int FamilyId { get; set; }
        public required Family Family { get; set; }

        public int FamilyMemberId { get; set; }
        public required FamilyMember FamilyMember { get; set; }
    }
}
