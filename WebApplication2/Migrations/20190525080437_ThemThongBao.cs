using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class ThemThongBao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "KetQuas");

            migrationBuilder.CreateTable(
                name: "SuKiens",
                columns: table => new
                {
                    SuKienId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LoaiSK = table.Column<string>(nullable: true),
                    TieuDe = table.Column<string>(nullable: true),
                    NoiDung = table.Column<string>(nullable: true),
                    NgayTao = table.Column<DateTime>(nullable: false),
                    GhiChu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuKiens", x => x.SuKienId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SuKiens");

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "KetQuas",
                nullable: true);
        }
    }
}
