using System.Net.WebSockets;

namespace FamilyBackend.Models
{
    public class Message
    {
        public long MessageId { get; set; }
        public long FamiliyGroupId { get; set; }
        public string Content { get; set; }
        public string SenderId { get; set; }
        public string RecipientId { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; }

    }
}
