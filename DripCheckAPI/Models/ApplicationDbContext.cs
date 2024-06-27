using Microsoft.EntityFrameworkCore;

namespace DripCheckAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
        }

        public DbSet<WarrantyDetail> WarrantyDetails { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Login> Logins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductDetail>()
                .HasKey(p => p.SerialNumber);

            modelBuilder.Entity<WarrantyDetail>()
                .HasOne(w => w.ProductDetail)
                .WithMany()
                .HasForeignKey(w => w.ProductSerialNumber)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }

}
