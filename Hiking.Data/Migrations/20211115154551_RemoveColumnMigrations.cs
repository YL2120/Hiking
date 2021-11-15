using Microsoft.EntityFrameworkCore.Migrations;

namespace Hiking.Data.Migrations
{
    public partial class RemoveColumnMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Hours & Minutes",
                table: "Hikes",
                newName: "Duration");

            migrationBuilder.RenameColumn(
                name: "Height difference",
                table: "Hikes",
                newName: "Height_difference");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Height_difference",
                table: "Hikes",
                newName: "Height difference");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Hikes",
                newName: "Hours & Minutes");
        }
    }
}
