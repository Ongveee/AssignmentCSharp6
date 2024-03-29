﻿// <auto-generated />
using System;
using BlazorModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorModel.Migrations
{
    [DbContext(typeof(CSharp6AssignmentContext))]
    partial class CSharp6AssignmentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BlazorModel.Models.Account", b =>
                {
                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("username");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("password");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    b.HasKey("Username")
                        .HasName("PK__Account__F3DBC573E0C5B7E0");

                    b.HasIndex("RoleId");

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("BlazorModel.Models.Diem", b =>
                {
                    b.Property<double>("DiemDoc")
                        .HasColumnType("float");

                    b.Property<double>("DiemPresentation")
                        .HasColumnType("float");

                    b.Property<string>("MaMh")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("MaMH");

                    b.Property<int?>("MaSv")
                        .HasColumnType("int")
                        .HasColumnName("MaSV");

                    b.HasIndex("MaMh");

                    b.HasIndex("MaSv");

                    b.ToTable("Diem", (string)null);
                });

            modelBuilder.Entity("BlazorModel.Models.Lop", b =>
                {
                    b.Property<string>("MaLop")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("MaMh")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("MaMH");

                    b.Property<string>("TenLop")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaLop")
                        .HasName("PK__Lop__3B98D2739147FB5E");

                    b.HasIndex("MaMh");

                    b.ToTable("Lop", (string)null);
                });

            modelBuilder.Entity("BlazorModel.Models.MonHoc", b =>
                {
                    b.Property<string>("MaMh")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("MaMH");

                    b.Property<string>("TenMh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TenMH");

                    b.HasKey("MaMh")
                        .HasName("PK__MonHoc__2725DFD930F0BAEF");

                    b.ToTable("MonHoc", (string)null);
                });

            modelBuilder.Entity("BlazorModel.Models.Nganh", b =>
                {
                    b.Property<string>("MaNganh")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("TenNganh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaNganh")
                        .HasName("PK__Nganh__A2CEF50D32CD65A6");

                    b.ToTable("Nganh", (string)null);
                });

            modelBuilder.Entity("BlazorModel.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BlazorModel.Models.SinhVien", b =>
                {
                    b.Property<int>("MaSv")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MaSV");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaSv"), 1L, 1);

                    b.Property<byte[]>("Anh")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("GioiTinh")
                        .HasColumnType("bit");

                    b.Property<string>("MaLop")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("MaNganh")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("MaTruong")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("date");

                    b.Property<string>("TenSv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TenSV");

                    b.HasKey("MaSv")
                        .HasName("PK__SinhVien__2725081A45940602");

                    b.HasIndex("MaLop");

                    b.HasIndex("MaNganh");

                    b.HasIndex("MaTruong");

                    b.ToTable("SinhVien", (string)null);
                });

            modelBuilder.Entity("BlazorModel.Models.Truong", b =>
                {
                    b.Property<string>("MaTruong")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("TenTruong")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaTruong")
                        .HasName("PK__Truong__5ECEF88A3F7828CB");

                    b.ToTable("Truong", (string)null);
                });

            modelBuilder.Entity("BlazorModel.Models.Account", b =>
                {
                    b.HasOne("BlazorModel.Models.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK__Account__RoleID__36B12243");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BlazorModel.Models.Diem", b =>
                {
                    b.HasOne("BlazorModel.Models.MonHoc", "MaMhNavigation")
                        .WithMany()
                        .HasForeignKey("MaMh")
                        .HasConstraintName("FK__Diem__MaMH__31EC6D26");

                    b.HasOne("BlazorModel.Models.SinhVien", "MaSvNavigation")
                        .WithMany()
                        .HasForeignKey("MaSv")
                        .HasConstraintName("FK__Diem__MaSV__30F848ED");

                    b.Navigation("MaMhNavigation");

                    b.Navigation("MaSvNavigation");
                });

            modelBuilder.Entity("BlazorModel.Models.Lop", b =>
                {
                    b.HasOne("BlazorModel.Models.MonHoc", "MaMhNavigation")
                        .WithMany("Lops")
                        .HasForeignKey("MaMh")
                        .HasConstraintName("FK__Lop__MaMH__2A4B4B5E");

                    b.Navigation("MaMhNavigation");
                });

            modelBuilder.Entity("BlazorModel.Models.SinhVien", b =>
                {
                    b.HasOne("BlazorModel.Models.Lop", "MaLopNavigation")
                        .WithMany("SinhViens")
                        .HasForeignKey("MaLop")
                        .HasConstraintName("FK__SinhVien__MaLop__2F10007B");

                    b.HasOne("BlazorModel.Models.Nganh", "MaNganhNavigation")
                        .WithMany("SinhViens")
                        .HasForeignKey("MaNganh")
                        .HasConstraintName("FK__SinhVien__MaNgan__2E1BDC42");

                    b.HasOne("BlazorModel.Models.Truong", "MaTruongNavigation")
                        .WithMany("SinhViens")
                        .HasForeignKey("MaTruong")
                        .HasConstraintName("FK__SinhVien__MaTruo__2D27B809");

                    b.Navigation("MaLopNavigation");

                    b.Navigation("MaNganhNavigation");

                    b.Navigation("MaTruongNavigation");
                });

            modelBuilder.Entity("BlazorModel.Models.Lop", b =>
                {
                    b.Navigation("SinhViens");
                });

            modelBuilder.Entity("BlazorModel.Models.MonHoc", b =>
                {
                    b.Navigation("Lops");
                });

            modelBuilder.Entity("BlazorModel.Models.Nganh", b =>
                {
                    b.Navigation("SinhViens");
                });

            modelBuilder.Entity("BlazorModel.Models.Role", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("BlazorModel.Models.Truong", b =>
                {
                    b.Navigation("SinhViens");
                });
#pragma warning restore 612, 618
        }
    }
}
