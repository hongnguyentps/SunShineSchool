using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class XemLichSu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LichSus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiemId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    LopId = table.Column<string>(nullable: true),
                    MaMH = table.Column<string>(nullable: true),
                    MaHKy = table.Column<string>(nullable: true),
                    LoaiDiemId = table.Column<string>(nullable: true),
                    DiemTruoc = table.Column<double>(nullable: false),
                    DiemSau = table.Column<double>(nullable: false),
                    ThoiGian = table.Column<DateTime>(nullable: false),
                    LyDo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichSus", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LichSus");
        }
    }
}
