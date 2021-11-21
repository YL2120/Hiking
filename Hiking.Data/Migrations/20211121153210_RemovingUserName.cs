using Microsoft.EntityFrameworkCore.Migrations;

namespace Hiking.Data.Migrations
{
    public partial class RemovingUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Hikes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Hikes",
                type: "varchar(256)",
                nullable: true);
        }
    }
}
