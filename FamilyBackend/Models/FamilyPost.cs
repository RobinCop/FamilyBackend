namespace FamilyBackend.Models
{
    public class FamilyPost
    {
        public int FamilyPostId { get; set; }
        public string Content { get; set; }
        public byte[]? Image { get; set; }
        public ICollection<FamilyPostMessage>? PostMessages { get; set; }

        public DateTime Timestamp { get; set; }
        public int AuthorId { get; set; }
        public FamilyMember Author { get; set; }
        public int FamilyId { get; set; }
        public Family Family { get; set; }

        public FamilyPost()
        {
            PostMessages = new List<FamilyPostMessage>();
        }

        public FamilyPost(string content, DateTime timestamp, int authorId, int familyId, byte[]? image = null) : this()
        {
            Content = content;
            Timestamp = timestamp;
            AuthorId = authorId;
            FamilyId = familyId;
            Image = image;
        }
    }
}
