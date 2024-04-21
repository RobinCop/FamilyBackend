using System.Net.WebSockets;

namespace FamilyBackend.Models
{
    public class FamilyMessage
    {
        public int FamilyMessageId { get; set; }
        public string Content { get; set; }
        public byte[]? Image { get; set; }
        public DateTime Timestamp { get; set; }
        public int SenderId { get; set; }
        public FamilyMember Sender { get; set; }
        public int RecipientId { get; set; }
        public Family Recipient { get; set; }

        public FamilyMessage()
        {
        }

        public FamilyMessage(string content, DateTime timestamp, int senderId, int recipientId)
        {
            this.Content = content;
            Timestamp = timestamp;
            SenderId = senderId;
            RecipientId = recipientId;
        }

    }
}
