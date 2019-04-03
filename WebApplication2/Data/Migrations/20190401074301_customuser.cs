using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Data.Migrations
{
    public partial class customuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cmnd",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DanToc",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TonGiao",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cmnd",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DanToc",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TonGiao",
                table: "AspNetUsers");
        }
    }
}
