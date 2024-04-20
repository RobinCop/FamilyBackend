namespace FamilyBackend.Models
{
    public class FamilyGroup
    {
        public int FamilyGroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<FamilyMember> FamilyMembers { get; set; }
        public List<Message> Messages { get; set; }

      
        
    }
}
