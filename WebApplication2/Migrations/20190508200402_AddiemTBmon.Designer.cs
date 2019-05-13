﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication2.Data;

namespace WebApplication2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190508200402_AddiemTBmon")]
    partial class AddiemTBmon
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WebApplication2.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("GhiChu");

                    b.Property<string>("Ho");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NguoiDungId");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Ten");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NguoiDungId")
                        .IsUnique()
                        .HasFilter("[NguoiDungId] IS NOT NULL");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("WebApplication2.POCO.Diem", b =>
                {
                    b.Property<int>("DiemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("DiemSo");

                    b.Property<double>("DiemTB");

                    b.Property<string>("GhiChu");

                    b.Property<string>("HocKyMaHKy");

                    b.Property<string>("LoaiDiemId");

                    b.Property<string>("LopId");

                    b.Property<string>("MonHocMaMH");

                    b.Property<string>("UserId");

                    b.HasKey("DiemId");

                    b.HasIndex("HocKyMaHKy");

                    b.HasIndex("LoaiDiemId");

                    b.HasIndex("LopId");

                    b.HasIndex("MonHocMaMH");

                    b.HasIndex("UserId");

                    b.ToTable("Diems");
                });

            modelBuilder.Entity("WebApplication2.POCO.HanhKiem", b =>
                {
                    b.Property<string>("MaHK")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TenHK");

                    b.HasKey("MaHK");

                    b.ToTable("HanhKiems");
                });

            modelBuilder.Entity("WebApplication2.POCO.HocKy", b =>
                {
                    b.Property<string>("MaHKy")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TenHKy");

                    b.HasKey("MaHKy");

                    b.ToTable("HocKys");
                });

            modelBuilder.Entity("WebApplication2.POCO.HocLuc", b =>
                {
                    b.Property<string>("MaHL")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DiemCanDuoi");

                    b.Property<string>("DiemCanTren");

                    b.Property<string>("DiemKhongChe");

                    b.Property<string>("TenHL");

                    b.HasKey("MaHL");

                    b.ToTable("HocLucs");
                });

            modelBuilder.Entity("WebApplication2.POCO.KetQua", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HanhKiemMaHK");

                    b.Property<string>("HocLucMaHL");

                    b.Property<string>("LopId");

                    b.Property<string>("MaHSMaNgDung");

                    b.HasKey("Id");

                    b.HasIndex("HanhKiemMaHK");

                    b.HasIndex("HocLucMaHL");

                    b.HasIndex("LopId");

                    b.HasIndex("MaHSMaNgDung");

                    b.ToTable("KetQuas");
                });

            modelBuilder.Entity("WebApplication2.POCO.Khoi", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TenKhoi");

                    b.HasKey("Id");

                    b.ToTable("Khois");
                });

            modelBuilder.Entity("WebApplication2.POCO.LoaiDiem", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("HeSo");

                    b.Property<string>("TenLoai");

                    b.HasKey("Id");

                    b.ToTable("LoaiDiems");
                });

            modelBuilder.Entity("WebApplication2.POCO.Lop", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GVCNId");

                    b.Property<string>("Ghichu");

                    b.Property<string>("KhoiId");

                    b.Property<string>("NienKhoaId");

                    b.Property<string>("TenLop");

                    b.HasKey("Id");

                    b.HasIndex("GVCNId");

                    b.HasIndex("KhoiId");

                    b.HasIndex("NienKhoaId");

                    b.ToTable("Lops");
                });

            modelBuilder.Entity("WebApplication2.POCO.LopGV", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GVBMId");

                    b.Property<string>("LopId");

                    b.Property<string>("MonHocId");

                    b.HasKey("Id");

                    b.HasIndex("GVBMId");

                    b.HasIndex("LopId");

                    b.HasIndex("MonHocId");

                    b.ToTable("LopGvs");
                });

            modelBuilder.Entity("WebApplication2.POCO.LopHS", b =>
                {
                    b.Property<string>("LopId");

                    b.Property<string>("UserId");

                    b.HasKey("LopId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("LopHss");
                });

            modelBuilder.Entity("WebApplication2.POCO.MonHoc", b =>
                {
                    b.Property<string>("MaMH")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MoTa");

                    b.Property<int>("SoTiet");

                    b.Property<string>("TenMonHoc");

                    b.HasKey("MaMH");

                    b.ToTable("MonHocs");
                });

            modelBuilder.Entity("WebApplication2.POCO.NguoiDung", b =>
                {
                    b.Property<string>("MaNgDung")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Cmnd");

                    b.Property<string>("DanToc");

                    b.Property<string>("Email");

                    b.Property<string>("GhiChu");

                    b.Property<string>("GioiTinh");

                    b.Property<string>("HinhThe");

                    b.Property<string>("Ho");

                    b.Property<string>("HoTenCha");

                    b.Property<string>("HoTenMe");

                    b.Property<DateTime>("NgaySinh");

                    b.Property<string>("NoiSinh");

                    b.Property<int>("SDT");

                    b.Property<string>("Ten");

                    b.Property<string>("TonGiao");

                    b.Property<bool>("isGV");

                    b.HasKey("MaNgDung");

                    b.ToTable("NguoiDungs");
                });

            modelBuilder.Entity("WebApplication2.POCO.NienKhoa", b =>
                {
                    b.Property<string>("NienKhoaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TenNK");

                    b.HasKey("NienKhoaId");

                    b.ToTable("NienKhoas");
                });

            modelBuilder.Entity("WebApplication2.POCO.ViPham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GhiChu");

                    b.Property<string>("MaHSMaNgDung");

                    b.Property<string>("TenDiem");

                    b.Property<string>("TenLoi");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("MaHSMaNgDung");

                    b.ToTable("ViPhams");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WebApplication2.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebApplication2.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication2.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WebApplication2.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication2.Data.ApplicationUser", b =>
                {
                    b.HasOne("WebApplication2.POCO.NguoiDung", "NguoiDung")
                        .WithOne("Account")
                        .HasForeignKey("WebApplication2.Data.ApplicationUser", "NguoiDungId");
                });

            modelBuilder.Entity("WebApplication2.POCO.Diem", b =>
                {
                    b.HasOne("WebApplication2.POCO.HocKy", "HocKy")
                        .WithMany("Diems")
                        .HasForeignKey("HocKyMaHKy");

                    b.HasOne("WebApplication2.POCO.LoaiDiem", "LoaiDiem")
                        .WithMany("Diems")
                        .HasForeignKey("LoaiDiemId");

                    b.HasOne("WebApplication2.POCO.Lop", "Lop")
                        .WithMany("Diems")
                        .HasForeignKey("LopId");

                    b.HasOne("WebApplication2.POCO.MonHoc", "MonHoc")
                        .WithMany("Diems")
                        .HasForeignKey("MonHocMaMH");

                    b.HasOne("WebApplication2.POCO.NguoiDung", "User")
                        .WithMany("DiemIds")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("WebApplication2.POCO.KetQua", b =>
                {
                    b.HasOne("WebApplication2.POCO.HanhKiem", "HanhKiem")
                        .WithMany("KetQuas")
                        .HasForeignKey("HanhKiemMaHK");

                    b.HasOne("WebApplication2.POCO.HocLuc", "HocLuc")
                        .WithMany("KetQuas")
                        .HasForeignKey("HocLucMaHL");

                    b.HasOne("WebApplication2.POCO.Lop", "Lop")
                        .WithMany("KetQuas")
                        .HasForeignKey("LopId");

                    b.HasOne("WebApplication2.POCO.NguoiDung", "MaHS")
                        .WithMany("KetQuas")
                        .HasForeignKey("MaHSMaNgDung");
                });

            modelBuilder.Entity("WebApplication2.POCO.Lop", b =>
                {
                    b.HasOne("WebApplication2.POCO.NguoiDung", "GVCN")
                        .WithMany("Lops")
                        .HasForeignKey("GVCNId");

                    b.HasOne("WebApplication2.POCO.Khoi", "Khoi")
                        .WithMany("Lops")
                        .HasForeignKey("KhoiId");

                    b.HasOne("WebApplication2.POCO.NienKhoa", "NienKhoa")
                        .WithMany("Lops")
                        .HasForeignKey("NienKhoaId");
                });

            modelBuilder.Entity("WebApplication2.POCO.LopGV", b =>
                {
                    b.HasOne("WebApplication2.POCO.NguoiDung", "GVBM")
                        .WithMany("LopGvs")
                        .HasForeignKey("GVBMId");

                    b.HasOne("WebApplication2.POCO.Lop", "Lop")
                        .WithMany("LopGVs")
                        .HasForeignKey("LopId");

                    b.HasOne("WebApplication2.POCO.MonHoc", "MonHoc")
                        .WithMany()
                        .HasForeignKey("MonHocId");
                });

            modelBuilder.Entity("WebApplication2.POCO.LopHS", b =>
                {
                    b.HasOne("WebApplication2.POCO.Lop", "Lop")
                        .WithMany("LopHss")
                        .HasForeignKey("LopId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication2.POCO.NguoiDung", "User")
                        .WithMany("LopHss")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication2.POCO.ViPham", b =>
                {
                    b.HasOne("WebApplication2.POCO.NguoiDung", "MaHS")
                        .WithMany("ViPhams")
                        .HasForeignKey("MaHSMaNgDung");
                });
#pragma warning restore 612, 618
        }
    }
}
