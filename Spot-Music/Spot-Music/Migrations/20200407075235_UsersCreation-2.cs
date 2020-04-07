using Microsoft.EntityFrameworkCore.Migrations;

namespace Spot_Music.Migrations
{
    public partial class UsersCreation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users_Songs",
                table: "Users_Songs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users_Songs",
                table: "Users_Songs",
                columns: new[] { "Id", "SongId" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Songs_SongId",
                table: "Users_Songs",
                column: "SongId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users_Songs",
                table: "Users_Songs");

            migrationBuilder.DropIndex(
                name: "IX_Users_Songs_SongId",
                table: "Users_Songs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users_Songs",
                table: "Users_Songs",
                columns: new[] { "SongId", "Id" });
        }
    }
}
