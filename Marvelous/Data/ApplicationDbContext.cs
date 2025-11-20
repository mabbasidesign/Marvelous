using Marvelous.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Marvelous.Data
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<LocalUser> LocalUsers { get; set; }
        public DbSet<Villa> Villas { get; set; }
        public DbSet<VillaNumber> VillaNumbers { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Villa>(entity =>
            {
                entity.HasKey(v => v.Id);                 // تعیین کلید اصلی
                entity.Property(v => v.Name)
                      .IsRequired()                       // معادل [Required]
                      .HasMaxLength(100);                 // معادل [MaxLength(100)]

                entity.Property(v => v.Rate)
                      .HasPrecision(10, 2);               // دقت عددی برای decimal
            });

            // Fluent API برای تنظیم مدل Villa
            modelBuilder.Entity<Villa>(entity =>
            {
                entity.HasKey(v => v.Id); // کلید اصلی جدول

                entity.Property(v => v.Name)
                      .IsRequired()         // فیلد اجباری
                      .HasMaxLength(100);   // حداکثر طول 100 کاراکتر

                entity.Property(v => v.Rate)
                      .HasPrecision(10, 2); // تنظیم دقت عددی برای decimal (مثلاً 12345678.90)

                entity.Property(v => v.Details)
                      .HasMaxLength(500);   // محدود کردن توضیحات به 500 کاراکتر (اختیاری)

                entity.Property(v => v.ImageUrl)
                      .HasMaxLength(300);   // محدود کردن آدرس تصویر
            });


            modelBuilder.Entity<Villa>().HasData(
                new Villa
                {
                    Id = 1,
                    Name = "Royal Villa",
                    Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                    ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa3.jpg",
                    Occupancy = 4,
                    Rate = 200,
                    Sqft = 550,
                    Amenity = "",
                    CreatedDate = new DateTime(2025, 10, 23)
                },
              new Villa
              {
                  Id = 2,
                  Name = "Premium Pool Villa",
                  Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa1.jpg",
                  Occupancy = 4,
                  Rate = 300,
                  Sqft = 550,
                  Amenity = "",
                  CreatedDate = new DateTime(2025, 10, 23)
              },    
              new Villa
              {
                  Id = 3,
                  Name = "Luxury Pool Villa",
                  Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa4.jpg",
                  Occupancy = 4,
                  Rate = 400,
                  Sqft = 750,
                  Amenity = "",
                  CreatedDate = new DateTime(2025, 10, 23)
              },
              new Villa
              {
                  Id = 4,
                  Name = "Diamond Villa",
                  Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa5.jpg",
                  Occupancy = 4,
                  Rate = 550,
                  Sqft = 900,
                  Amenity = "",
                  CreatedDate = new DateTime(2025, 10, 23)
              },
              new Villa
              {
                  Id = 5,
                  Name = "Diamond Pool Villa",
                  Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa2.jpg",
                  Occupancy = 4,
                  Rate = 600,
                  Sqft = 1100,
                  Amenity = "",
                  CreatedDate = new DateTime(2025, 10, 23)
              });
        }
    }
}
