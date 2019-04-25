using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class addColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HoTenCha",
                table: "NguoiDungs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HoTenMe",
                table: "NguoiDungs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiemCanDuoi",
                table: "HocLucs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiemCanTren",
                table: "HocLucs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiemKhongChe",
                table: "HocLucs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoTenCha",
                table: "NguoiDungs");

            migrationBuilder.DropColumn(
                name: "HoTenMe",
                table: "NguoiDungs");

            migrationBuilder.DropColumn(
                name: "DiemCanDuoi",
                table: "HocLucs");

            migrationBuilder.DropColumn(
                name: "DiemCanTren",
                table: "HocLucs");

            migrationBuilder.DropColumn(
                name: "DiemKhongChe",
                table: "HocLucs");
        }
    }
}
