using FamilyBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyBackend.DatabaseContexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<FamilyMessage> FamilyMessage { get; set; }
        public DbSet<Family> Family { get; set; }
        public DbSet<FamilyMember> FamilyMember { get; set; }
        public DbSet<FamilyPost> FamilyPost { get; set; }
        public DbSet<DirectMessage> DirectMessage { get; set; }
        public DbSet<FamilyMembership> FamilyMembership { get; set; }   
        public DbSet<FamilyPostMessage> FamilyPostMessage { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FamilyMembership>()
                .HasKey(fm => new { fm.FamilyId, fm.FamilyMemberId });

            modelBuilder.Entity<FamilyMembership>()
                .HasOne(fm => fm.Family)
                .WithMany(f => f.FamilyMemberships)
                .HasForeignKey(fm => fm.FamilyId);

            modelBuilder.Entity<FamilyMembership>()
                .HasOne(fm => fm.FamilyMember)
                .WithMany(m => m.FamilyMemberships)
                .HasForeignKey(fm => fm.FamilyMemberId);

            modelBuilder.Entity<FamilyMessage>()
                .HasOne(fm => fm.Sender)
                .WithMany()
                .HasForeignKey(fm => fm.SenderId)
                .OnDelete(DeleteBehavior.NoAction); // Adjust the delete behavior as needed

            modelBuilder.Entity<FamilyMessage>()
                .HasOne(fm => fm.Recipient)
                .WithMany()
                .HasForeignKey(fm => fm.RecipientId)
                .OnDelete(DeleteBehavior.Cascade); // Adjust the delete behavior as needed

            modelBuilder.Entity<FamilyPost>()
                .HasOne(fp => fp.Author)
                .WithMany()
                .HasForeignKey(fp => fp.AuthorId)
                .OnDelete(DeleteBehavior.NoAction); // Adjust the delete behavior as needed

            modelBuilder.Entity<FamilyPost>()
                .HasOne(fp => fp.Family)
                .WithMany(f => f.FamilyPosts)
                .HasForeignKey(fp => fp.FamilyId)
                .OnDelete(DeleteBehavior.Cascade); // Adjust the delete behavior as needed

            modelBuilder.Entity<DirectMessage>()
                .HasOne(dm => dm.Recipient)
                .WithMany()
                .HasForeignKey(dm => dm.RecipientId)
                .OnDelete(DeleteBehavior.NoAction); // Change to Restrict or another suitable action

            modelBuilder.Entity<DirectMessage>()
                .HasOne(dm => dm.Author)
                .WithMany()
                .HasForeignKey(dm => dm.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FamilyPostMessage>()
                .HasOne(fpm => fpm.FamilyPost)
                .WithMany(fp => fp.PostMessages)
                .HasForeignKey(fpm => fpm.FamilyPostId)
                .OnDelete(DeleteBehavior.Cascade); 

        }

    }


}
