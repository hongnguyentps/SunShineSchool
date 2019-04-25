using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HanhKiems",
                columns: table => new
                {
                    MaHK = table.Column<string>(nullable: false),
                    TenHK = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HanhKiems", x => x.MaHK);
                });

            migrationBuilder.CreateTable(
                name: "HocKys",
                columns: table => new
                {
                    MaHKy = table.Column<string>(nullable: false),
                    TenHKy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocKys", x => x.MaHKy);
                });

            migrationBuilder.CreateTable(
                name: "HocLucs",
                columns: table => new
                {
                    MaHL = table.Column<string>(nullable: false),
                    TenHL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocLucs", x => x.MaHL);
                });

            migrationBuilder.CreateTable(
                name: "Khois",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    TenKhoi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khois", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiDiems",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    TenLoai = table.Column<int>(nullable: false),
                    HeSo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiDiems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonHocs",
                columns: table => new
                {
                    MaMH = table.Column<string>(nullable: false),
                    TenMonHoc = table.Column<string>(nullable: true),
                    SoTiet = table.Column<int>(nullable: false),
                    MoTa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonHocs", x => x.MaMH);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDungs",
                columns: table => new
                {
                    MaNgDung = table.Column<string>(nullable: false),
                    Ho = table.Column<string>(nullable: true),
                    Ten = table.Column<string>(nullable: true),
                    GioiTinh = table.Column<string>(nullable: true),
                    isGV = table.Column<bool>(nullable: false),
                    NgaySinh = table.Column<DateTime>(nullable: false),
                    NoiSinh = table.Column<string>(nullable: true),
                    DanToc = table.Column<string>(nullable: true),
                    TonGiao = table.Column<string>(nullable: true),
                    Cmnd = table.Column<int>(nullable: false),
                    SDT = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    HinhThe = table.Column<string>(nullable: true),
                    GhiChu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDungs", x => x.MaNgDung);
                });

            migrationBuilder.CreateTable(
                name: "NienKhoas",
                columns: table => new
                {
                    NienKhoaId = table.Column<string>(nullable: false),
                    TenNK = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NienKhoas", x => x.NienKhoaId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    NguoiDungId = table.Column<string>(nullable: true),
                    MaLoai = table.Column<int>(nullable: false),
                    Ho = table.Column<string>(nullable: true),
                    Ten = table.Column<string>(nullable: true),
                    GhiChu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_NguoiDungs_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "NguoiDungs",
                        principalColumn: "MaNgDung",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ViPhams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    TenLoi = table.Column<string>(nullable: true),
                    TenDiem = table.Column<string>(nullable: true),
                    GhiChu = table.Column<string>(nullable: true),
                    MaHSMaNgDung = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViPhams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ViPhams_NguoiDungs_MaHSMaNgDung",
                        column: x => x.MaHSMaNgDung,
                        principalTable: "NguoiDungs",
                        principalColumn: "MaNgDung",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lops",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    TenLop = table.Column<string>(nullable: true),
                    GVCNId = table.Column<string>(nullable: true),
                    KhoiId = table.Column<string>(nullable: true),
                    NienKhoaId = table.Column<string>(nullable: true),
                    Ghichu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lops_NguoiDungs_GVCNId",
                        column: x => x.GVCNId,
                        principalTable: "NguoiDungs",
                        principalColumn: "MaNgDung",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lops_Khois_KhoiId",
                        column: x => x.KhoiId,
                        principalTable: "Khois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lops_NienKhoas_NienKhoaId",
                        column: x => x.NienKhoaId,
                        principalTable: "NienKhoas",
                        principalColumn: "NienKhoaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diems",
                columns: table => new
                {
                    DiemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiemSo = table.Column<double>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    LopId = table.Column<string>(nullable: true),
                    MonHocMaMH = table.Column<string>(nullable: true),
                    HocKyMaHKy = table.Column<string>(nullable: true),
                    LoaiDiemId = table.Column<string>(nullable: true),
                    GhiChu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diems", x => x.DiemId);
                    table.ForeignKey(
                        name: "FK_Diems_HocKys_HocKyMaHKy",
                        column: x => x.HocKyMaHKy,
                        principalTable: "HocKys",
                        principalColumn: "MaHKy",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diems_LoaiDiems_LoaiDiemId",
                        column: x => x.LoaiDiemId,
                        principalTable: "LoaiDiems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diems_Lops_LopId",
                        column: x => x.LopId,
                        principalTable: "Lops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diems_MonHocs_MonHocMaMH",
                        column: x => x.MonHocMaMH,
                        principalTable: "MonHocs",
                        principalColumn: "MaMH",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diems_NguoiDungs_UserId",
                        column: x => x.UserId,
                        principalTable: "NguoiDungs",
                        principalColumn: "MaNgDung",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KetQuas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaHSMaNgDung = table.Column<string>(nullable: true),
                    LopId = table.Column<string>(nullable: true),
                    HocLucMaHL = table.Column<string>(nullable: true),
                    HanhKiemMaHK = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KetQuas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KetQuas_HanhKiems_HanhKiemMaHK",
                        column: x => x.HanhKiemMaHK,
                        principalTable: "HanhKiems",
                        principalColumn: "MaHK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KetQuas_HocLucs_HocLucMaHL",
                        column: x => x.HocLucMaHL,
                        principalTable: "HocLucs",
                        principalColumn: "MaHL",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KetQuas_Lops_LopId",
                        column: x => x.LopId,
                        principalTable: "Lops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KetQuas_NguoiDungs_MaHSMaNgDung",
                        column: x => x.MaHSMaNgDung,
                        principalTable: "NguoiDungs",
                        principalColumn: "MaNgDung",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LopGvs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LopId = table.Column<string>(nullable: true),
                    MonHocId = table.Column<string>(nullable: true),
                    GVBMId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopGvs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LopGvs_NguoiDungs_GVBMId",
                        column: x => x.GVBMId,
                        principalTable: "NguoiDungs",
                        principalColumn: "MaNgDung",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LopGvs_Lops_LopId",
                        column: x => x.LopId,
                        principalTable: "Lops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LopGvs_MonHocs_MonHocId",
                        column: x => x.MonHocId,
                        principalTable: "MonHocs",
                        principalColumn: "MaMH",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LopHss",
                columns: table => new
                {
                    LopId = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHss", x => new { x.LopId, x.UserId });
                    table.ForeignKey(
                        name: "FK_LopHss_Lops_LopId",
                        column: x => x.LopId,
                        principalTable: "Lops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LopHss_NguoiDungs_UserId",
                        column: x => x.UserId,
                        principalTable: "NguoiDungs",
                        principalColumn: "MaNgDung",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_NguoiDungId",
                table: "AspNetUsers",
                column: "NguoiDungId",
                unique: true,
                filter: "[NguoiDungId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Diems_HocKyMaHKy",
                table: "Diems",
                column: "HocKyMaHKy");

            migrationBuilder.CreateIndex(
                name: "IX_Diems_LoaiDiemId",
                table: "Diems",
                column: "LoaiDiemId");

            migrationBuilder.CreateIndex(
                name: "IX_Diems_LopId",
                table: "Diems",
                column: "LopId");

            migrationBuilder.CreateIndex(
                name: "IX_Diems_MonHocMaMH",
                table: "Diems",
                column: "MonHocMaMH");

            migrationBuilder.CreateIndex(
                name: "IX_Diems_UserId",
                table: "Diems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_KetQuas_HanhKiemMaHK",
                table: "KetQuas",
                column: "HanhKiemMaHK");

            migrationBuilder.CreateIndex(
                name: "IX_KetQuas_HocLucMaHL",
                table: "KetQuas",
                column: "HocLucMaHL");

            migrationBuilder.CreateIndex(
                name: "IX_KetQuas_LopId",
                table: "KetQuas",
                column: "LopId");

            migrationBuilder.CreateIndex(
                name: "IX_KetQuas_MaHSMaNgDung",
                table: "KetQuas",
                column: "MaHSMaNgDung");

            migrationBuilder.CreateIndex(
                name: "IX_LopGvs_GVBMId",
                table: "LopGvs",
                column: "GVBMId");

            migrationBuilder.CreateIndex(
                name: "IX_LopGvs_LopId",
                table: "LopGvs",
                column: "LopId");

            migrationBuilder.CreateIndex(
                name: "IX_LopGvs_MonHocId",
                table: "LopGvs",
                column: "MonHocId");

            migrationBuilder.CreateIndex(
                name: "IX_LopHss_UserId",
                table: "LopHss",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Lops_GVCNId",
                table: "Lops",
                column: "GVCNId");

            migrationBuilder.CreateIndex(
                name: "IX_Lops_KhoiId",
                table: "Lops",
                column: "KhoiId");

            migrationBuilder.CreateIndex(
                name: "IX_Lops_NienKhoaId",
                table: "Lops",
                column: "NienKhoaId");

            migrationBuilder.CreateIndex(
                name: "IX_ViPhams_MaHSMaNgDung",
                table: "ViPhams",
                column: "MaHSMaNgDung");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Diems");

            migrationBuilder.DropTable(
                name: "KetQuas");

            migrationBuilder.DropTable(
                name: "LopGvs");

            migrationBuilder.DropTable(
                name: "LopHss");

            migrationBuilder.DropTable(
                name: "ViPhams");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "HocKys");

            migrationBuilder.DropTable(
                name: "LoaiDiems");

            migrationBuilder.DropTable(
                name: "HanhKiems");

            migrationBuilder.DropTable(
                name: "HocLucs");

            migrationBuilder.DropTable(
                name: "MonHocs");

            migrationBuilder.DropTable(
                name: "Lops");

            migrationBuilder.DropTable(
                name: "NguoiDungs");

            migrationBuilder.DropTable(
                name: "Khois");

            migrationBuilder.DropTable(
                name: "NienKhoas");
        }
    }
}
