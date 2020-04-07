using Microsoft.EntityFrameworkCore.Migrations;

namespace Spot_Music.Migrations
{
    public partial class UsersCreation4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Songs_Users_UsersId",
                table: "Users_Songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users_Songs",
                table: "Users_Songs");

            migrationBuilder.DropIndex(
                name: "IX_Users_Songs_UsersId",
                table: "Users_Songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Users_Songs");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Users_Songs");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Users_Songs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsersUserId",
                table: "Users_Songs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Users",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users_Songs",
                table: "Users_Songs",
                columns: new[] { "UserId", "SongId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Songs_Users_UsersUserId",
                table: "Users_Songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users_Songs",
                table: "Users_Songs");

            migrationBuilder.DropIndex(
                name: "IX_Users_Songs_UsersUserId",
                table: "Users_Songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Users_Songs");

            migrationBuilder.DropColumn(
                name: "UsersUserId",
                table: "Users_Songs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Users_Songs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "Users_Songs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users_Songs",
                table: "Users_Songs",
                columns: new[] { "Id", "SongId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Songs_UsersId",
                table: "Users_Songs",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Songs_Users_UsersId",
                table: "Users_Songs",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
