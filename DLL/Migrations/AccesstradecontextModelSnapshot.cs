﻿// <auto-generated />
using System;
using DLL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DLL.Migrations
{
    [DbContext(typeof(Accesstradecontext))]
    partial class AccesstradecontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DLL.Entity.Camps", b =>
                {
                    b.Property<Guid>("Camp_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Camp_Name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Camps_Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Type")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Camp_Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Camps", (string)null);
                });

            modelBuilder.Entity("DLL.Entity.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("DLL.Entity.Click", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("Camp_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Click_Time")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Ip_Adds")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Camp_Id");

                    b.HasIndex("UserID");

                    b.ToTable("Click", (string)null);
                });

            modelBuilder.Entity("DLL.Entity.Oder", b =>
                {
                    b.Property<string>("Oder_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("Click_Time")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Confirmed_Time")
                        .HasColumnType("datetime2");

                    b.Property<string>("Device_Type")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Oder_status")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("Oder_Id");

                    b.HasIndex("UserID");

                    b.ToTable("Oder", (string)null);
                });

            modelBuilder.Entity("DLL.Entity.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"), 1L, 1);

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChuTaiKhoan")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Email")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("IsAdmin")
                        .HasColumnType("int");

                    b.Property<string>("NganHang")
                        .HasMaxLength(22)
                        .HasColumnType("nvarchar(22)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("SoDienThoai")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("SoTaiKhoan")
                        .HasMaxLength(22)
                        .HasColumnType("nvarchar(22)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("gender")
                        .HasColumnType("int");

                    b.HasKey("UserID");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("DLL.Entity.Camps", b =>
                {
                    b.HasOne("DLL.Entity.Category", "Category")
                        .WithMany("Camps")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Category");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("DLL.Entity.Click", b =>
                {
                    b.HasOne("DLL.Entity.Camps", "Camps")
                        .WithMany("Clicks")
                        .HasForeignKey("Camp_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_User_Camps");

                    b.HasOne("DLL.Entity.User", "User")
                        .WithMany("Clicks")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_User_Click");

                    b.Navigation("Camps");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DLL.Entity.Oder", b =>
                {
                    b.HasOne("DLL.Entity.User", "User")
                        .WithMany("Oders")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_User_Oder");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DLL.Entity.Camps", b =>
                {
                    b.Navigation("Clicks");
                });

            modelBuilder.Entity("DLL.Entity.Category", b =>
                {
                    b.Navigation("Camps");
                });

            modelBuilder.Entity("DLL.Entity.User", b =>
                {
                    b.Navigation("Clicks");

                    b.Navigation("Oders");
                });
#pragma warning restore 612, 618
        }
    }
}
