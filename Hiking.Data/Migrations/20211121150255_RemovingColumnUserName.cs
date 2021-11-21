using Microsoft.EntityFrameworkCore.Migrations;

namespace Hiking.Data.Migrations
{
    public partial class RemovingColumnUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hikes_AspNetUsers_UserName",
                table: "Hikes");

            migrationBuilder.DropIndex(
                name: "IX_Hikes_UserName",
                table: "Hikes");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Hikes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Hikes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hikes_UserName",
                table: "Hikes",
                column: "UserName");

            migrationBuilder.AddForeignKey(
                name: "FK_Hikes_AspNetUsers_UserName",
                table: "Hikes",
                column: "UserName",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
