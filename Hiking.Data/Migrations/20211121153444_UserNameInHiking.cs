using Microsoft.EntityFrameworkCore.Migrations;

namespace Hiking.Data.Migrations
{
    public partial class UserNameInHiking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Hikes",
                type: "nvarchar(256)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Hikes");
        }
    }
}
