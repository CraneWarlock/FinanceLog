using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceLog.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_FinanceLogs_FinanceLogsId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_GroupMembers_GroupMembersId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_FinanceLogs_FinanceLogsId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_GroupMembers_GroupMembersId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_FinanceLogsId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Groups_FinanceLogsId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "FinanceLogsId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FinanceLogsId",
                table: "Groups");

            migrationBuilder.RenameColumn(
                name: "GroupMembersId",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_GroupMembersId",
                table: "Users",
                newName: "IX_Users_UserId");

            migrationBuilder.RenameColumn(
                name: "GroupMembersId",
                table: "Groups",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_GroupMembersId",
                table: "Groups",
                newName: "IX_Groups_GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_FinanceLogs_GroupId",
                table: "Groups",
                column: "GroupId",
                principalTable: "FinanceLogs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_GroupMembers_GroupId",
                table: "Groups",
                column: "GroupId",
                principalTable: "GroupMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_FinanceLogs_UserId",
                table: "Users",
                column: "UserId",
                principalTable: "FinanceLogs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_GroupMembers_UserId",
                table: "Users",
                column: "UserId",
                principalTable: "GroupMembers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_FinanceLogs_GroupId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_GroupMembers_GroupId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_FinanceLogs_UserId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_GroupMembers_UserId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "GroupMembersId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserId",
                table: "Users",
                newName: "IX_Users_GroupMembersId");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Groups",
                newName: "GroupMembersId");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_GroupId",
                table: "Groups",
                newName: "IX_Groups_GroupMembersId");

            migrationBuilder.AddColumn<int>(
                name: "FinanceLogsId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FinanceLogsId",
                table: "Groups",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_FinanceLogsId",
                table: "Users",
                column: "FinanceLogsId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_FinanceLogsId",
                table: "Groups",
                column: "FinanceLogsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_FinanceLogs_FinanceLogsId",
                table: "Groups",
                column: "FinanceLogsId",
                principalTable: "FinanceLogs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_GroupMembers_GroupMembersId",
                table: "Groups",
                column: "GroupMembersId",
                principalTable: "GroupMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_FinanceLogs_FinanceLogsId",
                table: "Users",
                column: "FinanceLogsId",
                principalTable: "FinanceLogs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_GroupMembers_GroupMembersId",
                table: "Users",
                column: "GroupMembersId",
                principalTable: "GroupMembers",
                principalColumn: "Id");
        }
    }
}
