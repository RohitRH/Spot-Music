using Microsoft.EntityFrameworkCore.Migrations;

namespace Spot_Music.Migrations
{
    public partial class UsersCreation6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Songs_Users_UsersUserId",
                table: "Users_Songs");

            migrationBuilder.DropIndex(
                name: "IX_Users_Songs_UsersUserId",
                table: "Users_Songs");

            migrationBuilder.DropColumn(
                name: "UsersUserId",
                table: "Users_Songs");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Songs_Users_UserId",
                table: "Users_Songs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Songs_Users_UserId",
                table: "Users_Songs");

            migrationBuilder.AddColumn<int>(
                name: "UsersUserId",
                table: "Users_Songs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Songs_UsersUserId",
                table: "Users_Songs",
                column: "UsersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Songs_Users_UsersUserId",
                table: "Users_Songs",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
