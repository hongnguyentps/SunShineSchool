using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Data.Migrations
{
    public partial class customuser1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Diems",
                table: "Diems");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Diems",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "DiemId",
                table: "Diems",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<double>(
                name: "DiemSo",
                table: "Diems",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diems",
                table: "Diems",
                column: "DiemId");

            migrationBuilder.CreateIndex(
                name: "IX_Diems_UserId",
                table: "Diems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diems_AspNetUsers_UserId",
                table: "Diems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diems_AspNetUsers_UserId",
                table: "Diems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Diems",
                table: "Diems");

            migrationBuilder.DropIndex(
                name: "IX_Diems_UserId",
                table: "Diems");

            migrationBuilder.DropColumn(
                name: "DiemId",
                table: "Diems");

            migrationBuilder.DropColumn(
                name: "DiemSo",
                table: "Diems");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Diems",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diems",
                table: "Diems",
                columns: new[] { "IdMH", "UserId" });
        }
    }
}
