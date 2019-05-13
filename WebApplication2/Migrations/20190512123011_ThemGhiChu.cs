using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class ThemGhiChu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenDiem",
                table: "ViPhams");

            migrationBuilder.RenameColumn(
                name: "TenLoi",
                table: "ViPhams",
                newName: "LoaiViPham");

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayViPham",
                table: "ViPhams",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "NienKhoas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "MonHocs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "LopHss",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "LopGvs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "LoaiDiems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "Khois",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "KetQuas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "HanhKiems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NgayViPham",
                table: "ViPhams");

            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "NienKhoas");

            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "MonHocs");

            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "LopHss");

            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "LopGvs");

            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "LoaiDiems");

            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "Khois");

            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "KetQuas");

            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "HanhKiems");

            migrationBuilder.RenameColumn(
                name: "LoaiViPham",
                table: "ViPhams",
                newName: "TenLoi");

            migrationBuilder.AddColumn<string>(
                name: "TenDiem",
                table: "ViPhams",
                nullable: true);
        }
    }
}
