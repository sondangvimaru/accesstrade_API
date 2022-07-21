using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Entity
{
    public class Accesstradecontext:DbContext
    {

        public Accesstradecontext(DbContextOptions options):base(options)
        {

        }

        #region DbSet

        public DbSet<User>? Users { get; set; }
        public DbSet<Oder>? Oders { get; set; }
        public DbSet<Camps>? Camps { get; set; }
        public DbSet<Click>? Clicks { get; set; }
        public DbSet<Category>? Categories { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.HasKey(e => e.UserID);
                entity.HasIndex(e => e.Username).IsUnique();
                entity.Property(e => e.Username).HasMaxLength(150);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(150);
                entity.Property(e => e.HoTen).IsRequired().HasMaxLength(150);
                entity.Property(e => e.gender).IsRequired();
                entity.Property(e => e.NgaySinh);
                entity.Property(e => e.SoDienThoai).HasMaxLength(11);
                entity.Property(e => e.Email).HasMaxLength(500);
                entity.Property(e => e.SoTaiKhoan).HasMaxLength(22);
                entity.Property(e => e.ChuTaiKhoan).HasMaxLength(150);
                entity.Property(e =>e.NganHang).HasMaxLength(22);
                entity.Property(e => e.Avatar);
                entity.Property(e => e.Status).IsRequired();
                entity.Property(e => e.IsAdmin).IsRequired();

            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");
                entity.HasKey(e => e.CategoryId);
                entity.Property(e => e.CategoryName).HasMaxLength(50);                
            });

            modelBuilder.Entity<Camps>(entity =>
            {
                entity.ToTable("Camps");
                entity.HasKey(e => e.Camp_Id);
                entity.HasOne(e => e.Category).WithMany(e => e.Camps).HasForeignKey(e => e.CategoryId).HasConstraintName("FK_Category");
                entity.Property(e => e.Camp_Name).HasMaxLength(200);
                entity.Property(e => e.Type).HasMaxLength(200);
                entity.Property(e => e.Price).HasMaxLength(100);
                entity.Property(e => e.Camps_Image);
                entity.Property(e => e.Created).HasDefaultValueSql("getutcdate()");
                entity.Property(e => e.Description);
            });

            modelBuilder.Entity<Click>(entity =>
            {
                entity.ToTable("Click");
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.User).WithMany(e => e.Clicks).HasForeignKey(e => e.UserID).HasConstraintName("FK_User_Click");
                entity.HasOne(e => e.Camps).WithMany(e => e.Clicks).HasForeignKey(e => e.Camp_Id).HasConstraintName("FK_User_Camps");
                entity.Property(e => e.Click_Time).HasDefaultValueSql("getutcdate()");
                entity.Property(e => e.Ip_Adds).HasMaxLength(100);


            });

            modelBuilder.Entity<Oder>(entity =>
            {
                entity.ToTable("Oder");
                entity.HasKey(e => e.Oder_Id);
                entity.Property(e => e.Device_Type).HasMaxLength(100);
                entity.Property(e => e.Click_Time);
                entity.Property(e => e.Confirmed_Time);
                entity.HasOne(e => e.User).WithMany(e => e.Oders).HasPrincipalKey(e => e.UserID).HasConstraintName("FK_User_Oder");
                
            });
        }
    }
}
