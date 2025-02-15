﻿// <auto-generated />
using System;
using FamilyBackend.DatabaseContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FamilyBackend.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240421153948_RemoveRequired")]
    partial class RemoveRequired
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FamilyBackend.Models.DirectMessage", b =>
                {
                    b.Property<int>("DirectMessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DirectMessageId"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("RecipientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("DirectMessageId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("RecipientId");

                    b.ToTable("DirectMessage");
                });

            modelBuilder.Entity("FamilyBackend.Models.Family", b =>
                {
                    b.Property<int>("FamilyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FamilyId"));

                    b.Property<string>("FamilyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("FamilyPicture")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("FamilyId");

                    b.ToTable("Family");
                });

            modelBuilder.Entity("FamilyBackend.Models.FamilyMember", b =>
                {
                    b.Property<int>("FamilyMemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FamilyMemberId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ProfilePicture")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("FamilyMemberId");

                    b.ToTable("FamilyMember");
                });

            modelBuilder.Entity("FamilyBackend.Models.FamilyMembership", b =>
                {
                    b.Property<int>("FamilyId")
                        .HasColumnType("int");

                    b.Property<int>("FamilyMemberId")
                        .HasColumnType("int");

                    b.HasKey("FamilyId", "FamilyMemberId");

                    b.HasIndex("FamilyMemberId");

                    b.ToTable("FamilyMembership");
                });

            modelBuilder.Entity("FamilyBackend.Models.FamilyMessage", b =>
                {
                    b.Property<int>("FamilyMessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FamilyMessageId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FamilyId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("RecipientId")
                        .HasColumnType("int");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("FamilyMessageId");

                    b.HasIndex("FamilyId");

                    b.HasIndex("RecipientId");

                    b.HasIndex("SenderId");

                    b.ToTable("FamilyMessage");
                });

            modelBuilder.Entity("FamilyBackend.Models.FamilyPost", b =>
                {
                    b.Property<int>("FamilyPostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FamilyPostId"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FamilyId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("FamilyPostId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("FamilyId");

                    b.ToTable("FamilyPost");
                });

            modelBuilder.Entity("FamilyBackend.Models.FamilyPostMessage", b =>
                {
                    b.Property<int>("FamilyPostMessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FamilyPostMessageId"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FamilyPostId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("FamilyPostMessageId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("FamilyPostId");

                    b.ToTable("FamilyPostMessage");
                });

            modelBuilder.Entity("FamilyBackend.Models.DirectMessage", b =>
                {
                    b.HasOne("FamilyBackend.Models.FamilyMember", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FamilyBackend.Models.FamilyMember", "Recipient")
                        .WithMany()
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Recipient");
                });

            modelBuilder.Entity("FamilyBackend.Models.FamilyMembership", b =>
                {
                    b.HasOne("FamilyBackend.Models.Family", "Family")
                        .WithMany("FamilyMemberships")
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FamilyBackend.Models.FamilyMember", "FamilyMember")
                        .WithMany("FamilyMemberships")
                        .HasForeignKey("FamilyMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Family");

                    b.Navigation("FamilyMember");
                });

            modelBuilder.Entity("FamilyBackend.Models.FamilyMessage", b =>
                {
                    b.HasOne("FamilyBackend.Models.Family", null)
                        .WithMany("FamilyMessages")
                        .HasForeignKey("FamilyId");

                    b.HasOne("FamilyBackend.Models.Family", "Recipient")
                        .WithMany()
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FamilyBackend.Models.FamilyMember", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Recipient");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("FamilyBackend.Models.FamilyPost", b =>
                {
                    b.HasOne("FamilyBackend.Models.FamilyMember", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FamilyBackend.Models.Family", "Family")
                        .WithMany("FamilyPosts")
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Family");
                });

            modelBuilder.Entity("FamilyBackend.Models.FamilyPostMessage", b =>
                {
                    b.HasOne("FamilyBackend.Models.FamilyMember", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FamilyBackend.Models.FamilyPost", "FamilyPost")
                        .WithMany("PostMessages")
                        .HasForeignKey("FamilyPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("FamilyPost");
                });

            modelBuilder.Entity("FamilyBackend.Models.Family", b =>
                {
                    b.Navigation("FamilyMemberships");

                    b.Navigation("FamilyMessages");

                    b.Navigation("FamilyPosts");
                });

            modelBuilder.Entity("FamilyBackend.Models.FamilyMember", b =>
                {
                    b.Navigation("FamilyMemberships");
                });

            modelBuilder.Entity("FamilyBackend.Models.FamilyPost", b =>
                {
                    b.Navigation("PostMessages");
                });
#pragma warning restore 612, 618
        }
    }
}
