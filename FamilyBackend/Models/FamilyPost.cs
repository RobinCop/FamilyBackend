namespace FamilyBackend.Models
{
    public class FamilyPost
    {
        public int FamilyPostId { get; set; }
        public required string Content { get; set; }
        public byte[]? Image { get; set; }
        public DateTime Timestamp { get; set; }
        public int AuthorId { get; set; }
        public required FamilyMember Author { get; set; }
        public int FamilyId { get; set; }
        public required Family Family { get; set; }
    }
}
