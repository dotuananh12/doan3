namespace project3.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<AdminCP> AdminCPs { get; set; }
        public virtual DbSet<ChiTietHoSo> ChiTietHoSoes { get; set; }
        public virtual DbSet<FileHoSo> FileHoSoes { get; set; }
        public virtual DbSet<HoSo> HoSoes { get; set; }
        public virtual DbSet<nguoidung> nguoidungs { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<shareFile> shareFiles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<thongbao> thongbaos { get; set; }
        public virtual DbSet<yeucaudoiMK> yeucaudoiMKs { get; set; }
        public virtual DbSet<yeucauShare> yeucauShares { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminCP>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<AdminCP>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<AdminCP>()
                .HasMany(e => e.HoSoes)
                .WithOptional(e => e.AdminCP)
                .HasForeignKey(e => e.idadmincp);

            modelBuilder.Entity<ChiTietHoSo>()
                .Property(e => e.updateby)
                .IsUnicode(false);

            modelBuilder.Entity<FileHoSo>()
                .Property(e => e.filelink)
                .IsUnicode(false);

            modelBuilder.Entity<FileHoSo>()
                .Property(e => e.createBy)
                .IsUnicode(false);

            modelBuilder.Entity<HoSo>()
                .HasMany(e => e.shareFiles)
                .WithOptional(e => e.HoSo)
                .HasForeignKey(e => e.hosoID);

            modelBuilder.Entity<nguoidung>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<nguoidung>()
                .Property(e => e.phonenumber)
                .IsUnicode(false);

            modelBuilder.Entity<nguoidung>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<shareFile>()
                .Property(e => e.codeShare)
                .IsUnicode(false);

            modelBuilder.Entity<shareFile>()
                .Property(e => e.codeTake)
                .IsUnicode(false);

            modelBuilder.Entity<shareFile>()
                .Property(e => e.noidung)
                .IsUnicode(false);

            modelBuilder.Entity<shareFile>()
                .Property(e => e.creatBy)
                .IsUnicode(false);

            modelBuilder.Entity<shareFile>()
                .Property(e => e.updateBy)
                .IsUnicode(false);

            modelBuilder.Entity<thongbao>()
                .Property(e => e.noidung)
                .IsUnicode(false);

            modelBuilder.Entity<thongbao>()
                .Property(e => e.usecode)
                .IsUnicode(false);

            modelBuilder.Entity<yeucaudoiMK>()
                .Property(e => e.OTP)
                .IsUnicode(false);

            modelBuilder.Entity<yeucaudoiMK>()
                .Property(e => e.useCode)
                .IsUnicode(false);

            modelBuilder.Entity<yeucauShare>()
                .Property(e => e.otp)
                .IsUnicode(false);
        }
    }
}
