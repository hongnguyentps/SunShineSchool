using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class ThemNgayKetThucHK2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HocKyNienKhoas",
                columns: table => new
                {
                    HocKyId = table.Column<string>(nullable: false),
                    NienKhoaId = table.Column<string>(nullable: false),
                    NgayKetThuc = table.Column<DateTime>(nullable: false),
                    GhiChu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocKyNienKhoas", x => new { x.HocKyId, x.NienKhoaId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HocKyNienKhoas");
        }
    }
}
