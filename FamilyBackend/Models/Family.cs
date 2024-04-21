namespace FamilyBackend.Models
{
    public class Family
    {
        public int FamilyId { get; set; }
        public required string FamilyName { get; set; }
        public byte[]? FamilyPicture { get; set; }
        public ICollection<FamilyMembership>? FamilyMemberships { get; set; }
        public ICollection<FamilyPost>? FamilyPosts { get; set; }
        public ICollection<FamilyMessage>? FamilyMessages { get; set; }

    }
}
