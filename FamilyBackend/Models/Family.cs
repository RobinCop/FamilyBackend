namespace FamilyBackend.Models
{
    public class Family
    {
        public int FamilyId { get; set; }
        public string FamilyName { get; set; }
        public byte[]? FamilyPicture { get; set; }
        public ICollection<FamilyMembership>? FamilyMemberships { get; set; }
        public ICollection<FamilyPost>? FamilyPosts { get; set; }
        public ICollection<FamilyMessage>? FamilyMessages { get; set; }

        public Family()
        {
            FamilyMemberships = new List<FamilyMembership>();
            FamilyPosts = new List<FamilyPost>();
            FamilyMessages = new List<FamilyMessage>();
        }

        public Family(string familyName, byte[]? familyPicture = null) : this()
        {
            FamilyName = familyName;
            FamilyPicture = familyPicture;
        }

    }
}
