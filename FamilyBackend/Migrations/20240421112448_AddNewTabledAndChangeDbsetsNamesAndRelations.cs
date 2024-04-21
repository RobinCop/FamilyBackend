using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTabledAndChangeDbsetsNamesAndRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMembers_FamilyGroups_FamilyGroupGroupId",
                table: "FamilyMembers");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "FamilyGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FamilyMembers",
                table: "FamilyMembers");

            migrationBuilder.DropIndex(
                name: "IX_FamilyMembers_FamilyGroupGroupId",
                table: "FamilyMembers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "FamilyMembers");

            migrationBuilder.DropColumn(
                name: "FamilyGroupGroupId",
                table: "FamilyMembers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "FamilyMembers");

            migrationBuilder.RenameTable(
                name: "FamilyMembers",
                newName: "FamilyMember");

            migrationBuilder.AlterColumn<int>(
                name: "FamilyMemberId",
                table: "FamilyMember",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "FamilyMember",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FamilyMember",
                table: "FamilyMember",
                column: "FamilyMemberId");

            migrationBuilder.CreateTable(
                name: "DirectMessage",
                columns: table => new
                {
                    DirectMessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    RecipientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectMessage", x => x.DirectMessageId);
                    table.ForeignKey(
                        name: "FK_DirectMessage_FamilyMember_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "FamilyMember",
                        principalColumn: "FamilyMemberId");
                    table.ForeignKey(
                        name: "FK_DirectMessage_FamilyMember_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "FamilyMember",
                        principalColumn: "FamilyMemberId");
                });

            migrationBuilder.CreateTable(
                name: "Family",
                columns: table => new
                {
                    FamilyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamilyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FamilyPicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Family", x => x.FamilyId);
                });

            migrationBuilder.CreateTable(
                name: "FamilyMembership",
                columns: table => new
                {
                    FamilyId = table.Column<int>(type: "int", nullable: false),
                    FamilyMemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMembership", x => new { x.FamilyId, x.FamilyMemberId });
                    table.ForeignKey(
                        name: "FK_FamilyMembership_FamilyMember_FamilyMemberId",
                        column: x => x.FamilyMemberId,
                        principalTable: "FamilyMember",
                        principalColumn: "FamilyMemberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FamilyMembership_Family_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Family",
                        principalColumn: "FamilyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FamilyMessage",
                columns: table => new
                {
                    FamilyMessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    RecipientId = table.Column<int>(type: "int", nullable: false),
                    FamilyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMessage", x => x.FamilyMessageId);
                    table.ForeignKey(
                        name: "FK_FamilyMessage_FamilyMember_SenderId",
                        column: x => x.SenderId,
                        principalTable: "FamilyMember",
                        principalColumn: "FamilyMemberId");
                    table.ForeignKey(
                        name: "FK_FamilyMessage_Family_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Family",
                        principalColumn: "FamilyId");
                    table.ForeignKey(
                        name: "FK_FamilyMessage_Family_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Family",
                        principalColumn: "FamilyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FamilyPost",
                columns: table => new
                {
                    FamilyPostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    FamilyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyPost", x => x.FamilyPostId);
                    table.ForeignKey(
                        name: "FK_FamilyPost_FamilyMember_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "FamilyMember",
                        principalColumn: "FamilyMemberId");
                    table.ForeignKey(
                        name: "FK_FamilyPost_Family_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Family",
                        principalColumn: "FamilyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DirectMessage_AuthorId",
                table: "DirectMessage",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_DirectMessage_RecipientId",
                table: "DirectMessage",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMembership_FamilyMemberId",
                table: "FamilyMembership",
                column: "FamilyMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMessage_FamilyId",
                table: "FamilyMessage",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMessage_RecipientId",
                table: "FamilyMessage",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMessage_SenderId",
                table: "FamilyMessage",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyPost_AuthorId",
                table: "FamilyPost",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyPost_FamilyId",
                table: "FamilyPost",
                column: "FamilyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DirectMessage");

            migrationBuilder.DropTable(
                name: "FamilyMembership");

            migrationBuilder.DropTable(
                name: "FamilyMessage");

            migrationBuilder.DropTable(
                name: "FamilyPost");

            migrationBuilder.DropTable(
                name: "Family");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FamilyMember",
                table: "FamilyMember");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "FamilyMember");

            migrationBuilder.RenameTable(
                name: "FamilyMember",
                newName: "FamilyMembers");

            migrationBuilder.AlterColumn<long>(
                name: "FamilyMemberId",
                table: "FamilyMembers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "FamilyMembers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FamilyGroupGroupId",
                table: "FamilyMembers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "FamilyMembers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FamilyMembers",
                table: "FamilyMembers",
                column: "FamilyMemberId");

            migrationBuilder.CreateTable(
                name: "FamilyGroups",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyGroups", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FamiliyGroupId = table.Column<long>(type: "bigint", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    RecipientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_FamilyGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "FamilyGroups",
                        principalColumn: "GroupId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMembers_FamilyGroupGroupId",
                table: "FamilyMembers",
                column: "FamilyGroupGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_GroupId",
                table: "Messages",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMembers_FamilyGroups_FamilyGroupGroupId",
                table: "FamilyMembers",
                column: "FamilyGroupGroupId",
                principalTable: "FamilyGroups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
