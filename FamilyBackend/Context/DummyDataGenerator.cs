using FamilyBackend.DatabaseContexts;
using FamilyBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FamilyBackend.Context
{
    public class DummyDataGenerator
    {
        private readonly DatabaseContext _context;

        public DummyDataGenerator(DatabaseContext context)
        {
            _context = context;
        }

        public void GenerateDummyData()
        {
            // Generate dummy families
            var families = new List<Family>
            {
                new Family { FamilyName = "Family Scheire" },
                new Family { FamilyName = "Family Coppens" },
            };
            _context.Family.AddRange(families);
            _context.SaveChanges();

            // Generate dummy family members
            var familyMembers = new List<FamilyMember>
            {
                new FamilyMember { Name = "Robin Coppens" },
                new FamilyMember { Name = "Lore Scheire" },
            };
            _context.FamilyMember.AddRange(familyMembers);
            _context.SaveChanges();

            // Generate dummy family memberships
            // Generate dummy family memberships
            var familyMemberships = new List<FamilyMembership>();
            foreach (var family in families)
            {
                foreach (var member in familyMembers)
                {
                    familyMemberships.Add(new FamilyMembership
                    {
                        Family = family,
                        FamilyMember = member
                    });
                }
            }

            _context.FamilyMembership.AddRange(familyMemberships);
            _context.SaveChanges();

            // Generate dummy family messages
            var familyMessages = new List<FamilyMessage>();
            foreach (var family in families)
            {
                foreach (var member in familyMembers)
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        familyMessages.Add(new FamilyMessage
                        {
                            Content = $"Family message {i}",
                            Timestamp = DateTime.Now,
                            SenderId = member.FamilyMemberId,
                            RecipientId = family.FamilyId
                        });
                    }
                }
            }
            _context.FamilyMessage.AddRange(familyMessages);
            _context.SaveChanges();
            // Generate dummy family posts
            var familyPosts = new List<FamilyPost>();
            foreach (var family in families)
            {
                foreach (var member in familyMembers)
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        familyPosts.Add(new FamilyPost
                        {
                            Content = $"Family post {i}",
                            Timestamp = DateTime.Now,
                            AuthorId = member.FamilyMemberId,
                            FamilyId = family.FamilyId
                        });
                    }
                }
            }
            _context.FamilyPost.AddRange(familyPosts);
            _context.SaveChanges();
            // Generate dummy family post messages
            var familyPostMessages = new List<FamilyPostMessage>();
            foreach (var post in familyPosts)
            {
                foreach (var member in familyMembers)
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        familyPostMessages.Add(new FamilyPostMessage
                        {
                            Content = $"Family post message {i}",
                            Timestamp = DateTime.Now,
                            AuthorId = member.FamilyMemberId,
                            FamilyPostId = post.FamilyPostId
                        });
                    }
                }
            }
            _context.FamilyPostMessage.AddRange(familyPostMessages);
            _context.SaveChanges();
        }

        public void DeleteItemsInDatabase()
        {
            _context.Family.RemoveRange(_context.Family);
            _context.FamilyMessage.RemoveRange(_context.FamilyMessage);
            _context.FamilyMember.RemoveRange(_context.FamilyMember);
            _context.FamilyPost.RemoveRange(_context.FamilyPost);
            _context.DirectMessage.RemoveRange(_context.DirectMessage);
            _context.FamilyMembership.RemoveRange(_context.FamilyMembership);
            _context.FamilyPostMessage.RemoveRange(_context.FamilyPostMessage);
            ResetIdentityColumns();
            _context.SaveChanges();

        }
        public void ResetIdentityColumns()
        {
            // Reset identity column value
            _context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('[FamilyBackend].[dbo].[Family]', RESEED, 0)");
            _context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('[FamilyBackend].[dbo].[FamilyMessage]', RESEED, 0)");
            _context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('[FamilyBackend].[dbo].[FamilyMember]', RESEED, 0)");
            _context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('[FamilyBackend].[dbo].[FamilyPost]', RESEED, 0)");
            _context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('[FamilyBackend].[dbo].[DirectMessage]', RESEED, 0)");
            _context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('[FamilyBackend].[dbo].[FamilyPostMessage]', RESEED, 0)");
        }

    }
}
