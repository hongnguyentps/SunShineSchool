using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication2.POCO;

namespace WebApplication2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Diem> Diems { get; set; }
        public DbSet<ApplicationUser> AppUsers { get; set; }
        public DbSet<Lop> Lops { get; set; }
        public DbSet<LopGV> LopGvs { get; set; }
        public DbSet<ViPham> ViPhams { get; set; }
        public DbSet<LoaiDiem> LoaiDiems { get; set; }
        public DbSet<MonHoc_User> MonHocUsers { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Diem>().HasKey(i =>i.DiemId);
            modelBuilder.Entity<Diem>().Property(f => f.DiemId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Diem>().HasOne(e => e.User).WithMany(c => c.DiemIds);

            modelBuilder.Entity<ViPham>().HasKey(i => i.Id);
            modelBuilder.Entity<ViPham>().Property(f => f.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<ViPham>().HasOne(m => m.User).WithMany(c => c.ViPhams);

            modelBuilder.Entity<LopGV>()
                .HasKey(b => new { b.LopId, b.UserId });

            modelBuilder.Entity<LopGV>()
                .HasOne(bc => bc.Lop)
                .WithMany(b => b.LopGvs)
                .HasForeignKey(bc => bc.LopId);

            modelBuilder.Entity<LopGV>()
                .HasOne(bc => bc.User)
                .WithMany(c => c.LopGvs)
                .HasForeignKey(bc => bc.UserId);

            modelBuilder.Entity<MonHoc_User>()
                .HasKey(b => new { b.IdMH, b.UserId });

            modelBuilder.Entity<MonHoc_User>()
                .HasOne(bc => bc.Subject)
                .WithMany(b => b.MonHocUsers)
                .HasForeignKey(bc => bc.IdMH);

            modelBuilder.Entity<MonHoc_User>()
                .HasOne(bc => bc.User)
                .WithMany(c =>  c.MonHocUsers)
                .HasForeignKey(bc => bc.UserId);

            modelBuilder.Entity<ApplicationUser>(b =>
            {
                // Primary key
                b.ToTable("AspNetUsers");
            });

        }
    }

    public class ApplicationUser : IdentityUser
    {
        public string Cmnd { get; set; }
        public string TonGiao { get; set; }
        public string DanToc { get; set; }
        public string GhiChu { get; set; }
        public ICollection<Diem> DiemIds { get; set; }
        public ICollection<ViPham> ViPhams { get; set; }
        public ICollection<LoaiDiem> LoaiDiems { get; set; }
        public ICollection<LopGV> LopGvs { get; set; }
        public ICollection<MonHoc_User> MonHocUsers { get; set; }
    }
}
