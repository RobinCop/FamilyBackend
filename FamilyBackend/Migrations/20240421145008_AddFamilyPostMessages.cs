using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddFamilyPostMessages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FamilyPostMessage",
                columns: table => new
                {
                    FamilyPostMessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    FamilyPostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyPostMessage", x => x.FamilyPostMessageId);
                    table.ForeignKey(
                        name: "FK_FamilyPostMessage_FamilyMember_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "FamilyMember",
                        principalColumn: "FamilyMemberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FamilyPostMessage_FamilyPost_FamilyPostId",
                        column: x => x.FamilyPostId,
                        principalTable: "FamilyPost",
                        principalColumn: "FamilyPostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FamilyPostMessage_AuthorId",
                table: "FamilyPostMessage",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyPostMessage_FamilyPostId",
                table: "FamilyPostMessage",
                column: "FamilyPostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FamilyPostMessage");
        }
    }
}
