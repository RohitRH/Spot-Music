using Microsoft.EntityFrameworkCore.Migrations;

namespace Spot_Music.Migrations
{
    public partial class AddNumberOfRatingsColmn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfRatings",
                table: "Songs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfRatings",
                table: "Songs");
        }
    }
}
