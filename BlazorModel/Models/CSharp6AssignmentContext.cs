using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlazorModel.Models
{
    public partial class CSharp6AssignmentContext : DbContext
    {
        public CSharp6AssignmentContext()
        {
        }

        public CSharp6AssignmentContext(DbContextOptions<CSharp6AssignmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Diem> Diems { get; set; } = null!;
        public virtual DbSet<Lop> Lops { get; set; } = null!;
        public virtual DbSet<MonHoc> MonHocs { get; set; } = null!;
        public virtual DbSet<Nganh> Nganhs { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<SinhVien> SinhViens { get; set; } = null!;
        public virtual DbSet<Truong> Truongs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-QTCBJBH\\SQLEXPRESS;Database=CSharp6Assignment;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__Account__F3DBC573E0C5B7E0");

                entity.ToTable("Account");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");

                entity.Property(e => e.Password)
                    .HasMaxLength(15)
                    .HasColumnName("password");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Account__RoleID__36B12243");
            });

            modelBuilder.Entity<Diem>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Diem");

                entity.Property(e => e.MaMh)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MaMH");

                entity.Property(e => e.MaSv).HasColumnName("MaSV");

                entity.HasOne(d => d.MaMhNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaMh)
                    .HasConstraintName("FK__Diem__MaMH__31EC6D26");

                entity.HasOne(d => d.MaSvNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaSv)
                    .HasConstraintName("FK__Diem__MaSV__30F848ED");
            });

            modelBuilder.Entity<Lop>(entity =>
            {
                entity.HasKey(e => e.MaLop)
                    .HasName("PK__Lop__3B98D2739147FB5E");

                entity.ToTable("Lop");

                entity.Property(e => e.MaLop)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaMh)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MaMH");

                entity.HasOne(d => d.MaMhNavigation)
                    .WithMany(p => p.Lops)
                    .HasForeignKey(d => d.MaMh)
                    .HasConstraintName("FK__Lop__MaMH__2A4B4B5E");
            });

            modelBuilder.Entity<MonHoc>(entity =>
            {
                entity.HasKey(e => e.MaMh)
                    .HasName("PK__MonHoc__2725DFD930F0BAEF");

                entity.ToTable("MonHoc");

                entity.Property(e => e.MaMh)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MaMH");

                entity.Property(e => e.TenMh).HasColumnName("TenMH");
            });

            modelBuilder.Entity<Nganh>(entity =>
            {
                entity.HasKey(e => e.MaNganh)
                    .HasName("PK__Nganh__A2CEF50D32CD65A6");

                entity.ToTable("Nganh");

                entity.Property(e => e.MaNganh)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleName).HasMaxLength(20);
            });

            modelBuilder.Entity<SinhVien>(entity =>
            {
                entity.HasKey(e => e.MaSv)
                    .HasName("PK__SinhVien__2725081A45940602");

                entity.ToTable("SinhVien");

                entity.Property(e => e.MaSv).HasColumnName("MaSV");

                entity.Property(e => e.MaLop)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaNganh)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaTruong)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.TenSv).HasColumnName("TenSV");

                entity.HasOne(d => d.MaLopNavigation)
                    .WithMany(p => p.SinhViens)
                    .HasForeignKey(d => d.MaLop)
                    .HasConstraintName("FK__SinhVien__MaLop__2F10007B");

                entity.HasOne(d => d.MaNganhNavigation)
                    .WithMany(p => p.SinhViens)
                    .HasForeignKey(d => d.MaNganh)
                    .HasConstraintName("FK__SinhVien__MaNgan__2E1BDC42");

                entity.HasOne(d => d.MaTruongNavigation)
                    .WithMany(p => p.SinhViens)
                    .HasForeignKey(d => d.MaTruong)
                    .HasConstraintName("FK__SinhVien__MaTruo__2D27B809");
            });

            modelBuilder.Entity<Truong>(entity =>
            {
                entity.HasKey(e => e.MaTruong)
                    .HasName("PK__Truong__5ECEF88A3F7828CB");

                entity.ToTable("Truong");

                entity.Property(e => e.MaTruong)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
