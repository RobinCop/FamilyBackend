namespace FamilyBackend.Models
{
    public class FamilyMember
    {
        public int FamilyMemberId { get; set; }
        public required string Name { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public ICollection<FamilyMembership>? FamilyMemberships { get; set; }

    }
}
