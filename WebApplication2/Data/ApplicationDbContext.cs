using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication2.POCO;

namespace WebApplication2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> AppUsers { get; set; }
        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<Lop> Lops { get; set; }
        public DbSet<LopHS> LopHss { get; set; }
        public DbSet<LopGV> LopGvs { get; set; }
        public DbSet<ViPham> ViPhams { get; set; }
        public DbSet<LoaiDiem> LoaiDiems { get; set; }
        public DbSet<Diem> Diems { get; set; }
        public DbSet<MonHoc> MonHocs { get; set; }
        public DbSet<NienKhoa> NienKhoas { get; set; }
        public DbSet<Khoi> Khois { get; set; }
        public DbSet<HocKy> HocKys { get; set; }
        public DbSet<KetQua> KetQuas { get; set; }
        public DbSet<HanhKiem> HanhKiems { get; set; }
        public DbSet<HocLuc> HocLucs { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>(b =>
            {
                // Primary key
                b.ToTable("AspNetUsers");
            });

            modelBuilder.Entity<NguoiDung>().HasKey(i => i.MaNgDung);
            modelBuilder.Entity<Khoi>().HasKey(e => e.Id);
            modelBuilder.Entity<NienKhoa>().HasKey(i => i.NienKhoaId);
            modelBuilder.Entity<Lop>().HasKey(i => i.Id);
            modelBuilder.Entity<KetQua>().HasKey(i => i.Id);
            modelBuilder.Entity<LopHS>().HasKey(bc => new { bc.LopId, bc.UserId });
            modelBuilder.Entity<LopGV>().HasKey(b => b.Id);
            modelBuilder.Entity<HocKy>().HasKey(i => i.MaHKy);
            modelBuilder.Entity<MonHoc>().HasKey(i => i.MaMH);
            modelBuilder.Entity<LoaiDiem>().HasKey(i => i.Id);
            modelBuilder.Entity<Diem>().HasKey(i => i.DiemId);
            modelBuilder.Entity<Diem>().Property(f => f.DiemId).ValueGeneratedOnAdd();
            modelBuilder.Entity<ViPham>().HasKey(i => i.Id);
            modelBuilder.Entity<ViPham>().Property(f => f.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<HanhKiem>().HasKey(i => i.MaHK);
            modelBuilder.Entity<HocLuc>().HasKey(i => i.MaHL);

            modelBuilder.Entity<NguoiDung>()
                .HasOne(a => a.Account)
                .WithOne(b => b.NguoiDung)
                .HasForeignKey<ApplicationUser>(b => b.NguoiDungId);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(a => a.KetQuas)
                .WithOne(b => b.User);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(a => a.ViPhams)
                .WithOne(b => b.Hs).HasForeignKey(c => c.HsId);

            modelBuilder.Entity<Lop>()
                .HasOne(a => a.NienKhoa)
                .WithMany(b => b.Lops)
                .HasForeignKey(d => d.NienKhoaId);

            modelBuilder.Entity<Lop>()
                .HasOne(a => a.GVCN)
                .WithMany(b => b.Lops)
                .HasForeignKey(d => d.GVCNId);

            modelBuilder.Entity<Lop>()
               .HasOne(bc => bc.Khoi)
               .WithMany(c => c.Lops)
               .HasForeignKey(d => d.KhoiId);

            modelBuilder.Entity<Lop>()
                .HasMany(c => c.KetQuas)
                .WithOne(e => e.Lop);

            modelBuilder.Entity<LopHS>()
                .HasOne(bc => bc.Lop)
                .WithMany(b => b.LopHss)
                .HasForeignKey(bc => bc.LopId);

            modelBuilder.Entity<LopHS>()
                .HasOne(bc => bc.User)
                .WithMany(c => c.LopHss)
                .HasForeignKey(bc => bc.UserId);

            modelBuilder.Entity<LopGV>()
                .HasOne(bc => bc.GVBM)
                .WithMany(c => c.LopGvs)
                .HasForeignKey(bc => bc.GVBMId);

            modelBuilder.Entity<LopGV>()
                .HasOne(bc => bc.Lop)
                .WithMany(c => c.LopGVs)
                .HasForeignKey(bc => bc.LopId);

            modelBuilder.Entity<HocKy>()
                .HasMany(a => a.Diems)
                .WithOne(b => b.HocKy).HasForeignKey(x => x.HocKyMaHKy);

            modelBuilder.Entity<LoaiDiem>()
                .HasMany(a => a.Diems)
                .WithOne(b => b.LoaiDiem).HasForeignKey(x => x.LoaiDiemId);

            modelBuilder.Entity<MonHoc>()
                .HasMany(a => a.Diems)
                .WithOne(b => b.MonHoc).HasForeignKey(x => x.MonHocMaMH);

            modelBuilder.Entity<Lop>()
                .HasMany(a => a.Diems)
                .WithOne(b => b.Lop).HasForeignKey(x => x.LopId);

            modelBuilder.Entity<Diem>()
                .HasOne(e => e.User)
                .WithMany(c => c.DiemIds);

            modelBuilder.Entity<KetQua>()
                .HasOne(e => e.HanhKiem)
                .WithMany(c => c.KetQuas);

            modelBuilder.Entity<KetQua>()
                .HasOne(e => e.HocLuc)
                .WithMany(c => c.KetQuas);

        }
    }

    public class 
        ApplicationUser : IdentityUser
    {
        public string NguoiDungId { get; set; }

        [NotMapped]
        public string Role { get; set; }

        public string Ho { get; set; }

        public string Ten { get; set; }

        public string GhiChu { get; set; }

        public NguoiDung NguoiDung { get; set; }
    }
}
