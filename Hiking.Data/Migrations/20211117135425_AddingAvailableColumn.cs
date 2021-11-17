using Microsoft.EntityFrameworkCore.Migrations;

namespace Hiking.Data.Migrations
{
    public partial class AddingAvailableColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Available",
                table: "Hikes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "Hikes");
        }
    }
}
