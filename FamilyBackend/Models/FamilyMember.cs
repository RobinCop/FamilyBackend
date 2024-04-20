namespace FamilyBackend.Models
{
    public class FamilyMember
    {
        public long FamilyMemberId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public FamilyGroup FamilyGroup { get; set; }

    }
}
