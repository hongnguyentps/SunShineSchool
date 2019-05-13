using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class AddiemTBCN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KetQuas_HanhKiems_HanhKiemMaHK",
                table: "KetQuas");

            migrationBuilder.DropForeignKey(
                name: "FK_KetQuas_HocLucs_HocLucMaHL",
                table: "KetQuas");

            migrationBuilder.DropForeignKey(
                name: "FK_KetQuas_NguoiDungs_MaHSMaNgDung",
                table: "KetQuas");

            migrationBuilder.DropIndex(
                name: "IX_KetQuas_HocLucMaHL",
                table: "KetQuas");

            migrationBuilder.DropColumn(
                name: "DiemTB",
                table: "Diems");

            migrationBuilder.RenameColumn(
                name: "MaHSMaNgDung",
                table: "KetQuas",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "HocLucMaHL",
                table: "KetQuas",
                newName: "TrangThai");

            migrationBuilder.RenameColumn(
                name: "HanhKiemMaHK",
                table: "KetQuas",
                newName: "HocLucId");

            migrationBuilder.RenameIndex(
                name: "IX_KetQuas_MaHSMaNgDung",
                table: "KetQuas",
                newName: "IX_KetQuas_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_KetQuas_HanhKiemMaHK",
                table: "KetQuas",
                newName: "IX_KetQuas_HocLucId");

            migrationBuilder.AlterColumn<string>(
                name: "TrangThai",
                table: "KetQuas",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HanhKiemId",
                table: "KetQuas",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "diemTBCN",
                table: "KetQuas",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_KetQuas_HanhKiemId",
                table: "KetQuas",
                column: "HanhKiemId");

            migrationBuilder.AddForeignKey(
                name: "FK_KetQuas_HanhKiems_HanhKiemId",
                table: "KetQuas",
                column: "HanhKiemId",
                principalTable: "HanhKiems",
                principalColumn: "MaHK",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KetQuas_HocLucs_HocLucId",
                table: "KetQuas",
                column: "HocLucId",
                principalTable: "HocLucs",
                principalColumn: "MaHL",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KetQuas_NguoiDungs_UserId",
                table: "KetQuas",
                column: "UserId",
                principalTable: "NguoiDungs",
                principalColumn: "MaNgDung",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KetQuas_HanhKiems_HanhKiemId",
                table: "KetQuas");

            migrationBuilder.DropForeignKey(
                name: "FK_KetQuas_HocLucs_HocLucId",
                table: "KetQuas");

            migrationBuilder.DropForeignKey(
                name: "FK_KetQuas_NguoiDungs_UserId",
                table: "KetQuas");

            migrationBuilder.DropIndex(
                name: "IX_KetQuas_HanhKiemId",
                table: "KetQuas");

            migrationBuilder.DropColumn(
                name: "HanhKiemId",
                table: "KetQuas");

            migrationBuilder.DropColumn(
                name: "diemTBCN",
                table: "KetQuas");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "KetQuas",
                newName: "MaHSMaNgDung");

            migrationBuilder.RenameColumn(
                name: "TrangThai",
                table: "KetQuas",
                newName: "HocLucMaHL");

            migrationBuilder.RenameColumn(
                name: "HocLucId",
                table: "KetQuas",
                newName: "HanhKiemMaHK");

            migrationBuilder.RenameIndex(
                name: "IX_KetQuas_UserId",
                table: "KetQuas",
                newName: "IX_KetQuas_MaHSMaNgDung");

            migrationBuilder.RenameIndex(
                name: "IX_KetQuas_HocLucId",
                table: "KetQuas",
                newName: "IX_KetQuas_HanhKiemMaHK");

            migrationBuilder.AlterColumn<string>(
                name: "HocLucMaHL",
                table: "KetQuas",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DiemTB",
                table: "Diems",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_KetQuas_HocLucMaHL",
                table: "KetQuas",
                column: "HocLucMaHL");

            migrationBuilder.AddForeignKey(
                name: "FK_KetQuas_HanhKiems_HanhKiemMaHK",
                table: "KetQuas",
                column: "HanhKiemMaHK",
                principalTable: "HanhKiems",
                principalColumn: "MaHK",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KetQuas_HocLucs_HocLucMaHL",
                table: "KetQuas",
                column: "HocLucMaHL",
                principalTable: "HocLucs",
                principalColumn: "MaHL",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KetQuas_NguoiDungs_MaHSMaNgDung",
                table: "KetQuas",
                column: "MaHSMaNgDung",
                principalTable: "NguoiDungs",
                principalColumn: "MaNgDung",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
