using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class AddLichSu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LoaiViPham",
                table: "ViPhams",
                newName: "NoiDungViPham");

            migrationBuilder.RenameColumn(
                name: "MaMH",
                table: "LichSus",
                newName: "MHId");

            migrationBuilder.AddColumn<string>(
                name: "MaHK",
                table: "ViPhams",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "LichSus",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LoaiDiemId",
                table: "LichSus",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "DiemTruoc",
                table: "LichSus",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "DiemSau",
                table: "LichSus",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "MHId",
                table: "LichSus",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LichSus_LoaiDiemId",
                table: "LichSus",
                column: "LoaiDiemId");

            migrationBuilder.CreateIndex(
                name: "IX_LichSus_MHId",
                table: "LichSus",
                column: "MHId");

            migrationBuilder.CreateIndex(
                name: "IX_LichSus_UserId",
                table: "LichSus",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LichSus_LoaiDiems_LoaiDiemId",
                table: "LichSus",
                column: "LoaiDiemId",
                principalTable: "LoaiDiems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LichSus_MonHocs_MHId",
                table: "LichSus",
                column: "MHId",
                principalTable: "MonHocs",
                principalColumn: "MaMH",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LichSus_NguoiDungs_UserId",
                table: "LichSus",
                column: "UserId",
                principalTable: "NguoiDungs",
                principalColumn: "MaNgDung",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LichSus_LoaiDiems_LoaiDiemId",
                table: "LichSus");

            migrationBuilder.DropForeignKey(
                name: "FK_LichSus_MonHocs_MHId",
                table: "LichSus");

            migrationBuilder.DropForeignKey(
                name: "FK_LichSus_NguoiDungs_UserId",
                table: "LichSus");

            migrationBuilder.DropIndex(
                name: "IX_LichSus_LoaiDiemId",
                table: "LichSus");

            migrationBuilder.DropIndex(
                name: "IX_LichSus_MHId",
                table: "LichSus");

            migrationBuilder.DropIndex(
                name: "IX_LichSus_UserId",
                table: "LichSus");

            migrationBuilder.DropColumn(
                name: "MaHK",
                table: "ViPhams");

            migrationBuilder.RenameColumn(
                name: "NoiDungViPham",
                table: "ViPhams",
                newName: "LoaiViPham");

            migrationBuilder.RenameColumn(
                name: "MHId",
                table: "LichSus",
                newName: "MaMH");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "LichSus",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LoaiDiemId",
                table: "LichSus",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "DiemTruoc",
                table: "LichSus",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "DiemSau",
                table: "LichSus",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaMH",
                table: "LichSus",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
