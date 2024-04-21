using System.Net.WebSockets;

namespace FamilyBackend.Models
{
    public class FamilyMessage
    {
        public int FamilyMessageId { get; set; }
        public required string Content { get; set; }
        public byte[]? Image { get; set; }
        public DateTime Timestamp { get; set; }
        public int SenderId { get; set; }
        public required FamilyMember Sender { get; set; }
        public int RecipientId { get; set; }
        public required Family Recipient { get; set; }

    }
}
