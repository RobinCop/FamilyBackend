using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyBackend.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFamilyGroupToGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMembers_FamilyGroups_FamilyGroupId",
                table: "FamilyMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_FamilyGroups_FamilyGroupId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "FamilyGroupId",
                table: "Messages",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_FamilyGroupId",
                table: "Messages",
                newName: "IX_Messages_GroupId");

            migrationBuilder.RenameColumn(
                name: "FamilyGroupId",
                table: "FamilyMembers",
                newName: "FamilyGroupGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_FamilyMembers_FamilyGroupId",
                table: "FamilyMembers",
                newName: "IX_FamilyMembers_FamilyGroupGroupId");

            migrationBuilder.RenameColumn(
                name: "FamilyGroupId",
                table: "FamilyGroups",
                newName: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMembers_FamilyGroups_FamilyGroupGroupId",
                table: "FamilyMembers",
                column: "FamilyGroupGroupId",
                principalTable: "FamilyGroups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_FamilyGroups_GroupId",
                table: "Messages",
                column: "GroupId",
                principalTable: "FamilyGroups",
                principalColumn: "GroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMembers_FamilyGroups_FamilyGroupGroupId",
                table: "FamilyMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_FamilyGroups_GroupId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Messages",
                newName: "FamilyGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_GroupId",
                table: "Messages",
                newName: "IX_Messages_FamilyGroupId");

            migrationBuilder.RenameColumn(
                name: "FamilyGroupGroupId",
                table: "FamilyMembers",
                newName: "FamilyGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_FamilyMembers_FamilyGroupGroupId",
                table: "FamilyMembers",
                newName: "IX_FamilyMembers_FamilyGroupId");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "FamilyGroups",
                newName: "FamilyGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMembers_FamilyGroups_FamilyGroupId",
                table: "FamilyMembers",
                column: "FamilyGroupId",
                principalTable: "FamilyGroups",
                principalColumn: "FamilyGroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_FamilyGroups_FamilyGroupId",
                table: "Messages",
                column: "FamilyGroupId",
                principalTable: "FamilyGroups",
                principalColumn: "FamilyGroupId");
        }
    }
}
