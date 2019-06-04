using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class ThemTBGV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "SuKiens",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "YKien",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    NoiDung = table.Column<string>(nullable: true),
                    NgayTao = table.Column<DateTime>(nullable: false),
                    GhiChu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YKien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YKien_NguoiDungs_UserId",
                        column: x => x.UserId,
                        principalTable: "NguoiDungs",
                        principalColumn: "MaNgDung",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SuKiens_UserId",
                table: "SuKiens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_YKien_UserId",
                table: "YKien",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SuKiens_NguoiDungs_UserId",
                table: "SuKiens",
                column: "UserId",
                principalTable: "NguoiDungs",
                principalColumn: "MaNgDung",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuKiens_NguoiDungs_UserId",
                table: "SuKiens");

            migrationBuilder.DropTable(
                name: "YKien");

            migrationBuilder.DropIndex(
                name: "IX_SuKiens_UserId",
                table: "SuKiens");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SuKiens");
        }
    }
}
