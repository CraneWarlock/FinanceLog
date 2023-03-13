using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceLog.Migrations
{
    /// <inheritdoc />
    public partial class UserLogRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_FinanceLogs_UserId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "FinanceLogsUser",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    UsersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceLogsUser", x => new { x.UserId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_FinanceLogsUser_FinanceLogs_UserId",
                        column: x => x.UserId,
                        principalTable: "FinanceLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinanceLogsUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinanceLogsUser_UsersId",
                table: "FinanceLogsUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinanceLogsUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_FinanceLogs_UserId",
                table: "Users",
                column: "UserId",
                principalTable: "FinanceLogs",
                principalColumn: "Id");
        }
    }
}
