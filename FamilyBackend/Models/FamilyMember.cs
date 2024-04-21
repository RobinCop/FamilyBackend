namespace FamilyBackend.Models
{
    public class FamilyMember
    {
        public int FamilyMemberId { get; set; }
        public string Name { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public ICollection<FamilyMembership>? FamilyMemberships { get; set; }

        public FamilyMember()
        {
            FamilyMemberships = new List<FamilyMembership>();
        }

        public FamilyMember(string name, byte[]? profilePicture = null) : this()
        {
            Name = name;
            ProfilePicture = profilePicture;
        }

    }
}
