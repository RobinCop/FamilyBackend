namespace FamilyBackend.Models
{
    public class DirectMessage
    {
        public int DirectMessageId { get; set; }
        public required string Content { get; set; }
        public byte[]? Image { get; set; }
        public DateTime Timestamp { get; set; }
        public int AuthorId { get; set; }
        public required FamilyMember Author { get; set; }
        public int RecipientId { get; set; }
        public required FamilyMember Recipient { get; set; }
    }
}
