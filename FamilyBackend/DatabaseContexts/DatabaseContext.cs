using FamilyBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyBackend.DatabaseContexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<FamilyGroup> FamilyGroups { get; set; }
        public DbSet<FamilyMember> FamilyMembers { get; set; }
    }
}
