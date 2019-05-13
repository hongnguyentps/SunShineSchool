using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class XoaDuThua : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ViPhams_NguoiDungs_MaHSMaNgDung",
                table: "ViPhams");

            migrationBuilder.DropIndex(
                name: "IX_ViPhams_MaHSMaNgDung",
                table: "ViPhams");

            migrationBuilder.DropColumn(
                name: "MaHSMaNgDung",
                table: "ViPhams");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ViPhams",
                newName: "HsId");

            migrationBuilder.AlterColumn<string>(
                name: "HsId",
                table: "ViPhams",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ViPhams_HsId",
                table: "ViPhams",
                column: "HsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ViPhams_NguoiDungs_HsId",
                table: "ViPhams",
                column: "HsId",
                principalTable: "NguoiDungs",
                principalColumn: "MaNgDung",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ViPhams_NguoiDungs_HsId",
                table: "ViPhams");

            migrationBuilder.DropIndex(
                name: "IX_ViPhams_HsId",
                table: "ViPhams");

            migrationBuilder.RenameColumn(
                name: "HsId",
                table: "ViPhams",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ViPhams",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaHSMaNgDung",
                table: "ViPhams",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ViPhams_MaHSMaNgDung",
                table: "ViPhams",
                column: "MaHSMaNgDung");

            migrationBuilder.AddForeignKey(
                name: "FK_ViPhams_NguoiDungs_MaHSMaNgDung",
                table: "ViPhams",
                column: "MaHSMaNgDung",
                principalTable: "NguoiDungs",
                principalColumn: "MaNgDung",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
