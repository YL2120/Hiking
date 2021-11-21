using Microsoft.EntityFrameworkCore.Migrations;

namespace Hiking.Data.Migrations
{
    public partial class RemovingColumnUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hikes_AspNetUsers_UserId",
                table: "Hikes");

            migrationBuilder.DropIndex(
                name: "IX_Hikes_UserId",
                table: "Hikes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Hikes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Hikes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hikes_UserId",
                table: "Hikes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hikes_AspNetUsers_UserId",
                table: "Hikes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
