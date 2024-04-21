namespace FamilyBackend.Models
{
    public class FamilyPostMessage
    {
        public int FamilyPostMessageId { get; set; }
        public string Content { get; set; }
        public byte[]? Image { get; set; }
        public DateTime Timestamp { get; set; }
        public int AuthorId { get; set; }
        public FamilyMember Author { get; set; }
        public int FamilyPostId { get; set; }

        public FamilyPost FamilyPost { get; set; }

        public FamilyPostMessage()
        {
        }

        public FamilyPostMessage(string content, DateTime timestamp, int authorId, int familyPostId, byte[]? image = null)
        {
            Content = content;
            Timestamp = timestamp;
            AuthorId = authorId;
            FamilyPostId = familyPostId;
            Image = image;
        }
    }
}
