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
        public DbSet<ProductOwner> ProductOwners { get; set; }
        public DbSet<ProductSerialNumber> ProductSerialNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductOwner>()
                .HasOne(po => po.ProductDetail)
                .WithMany(pd => pd.ProductOwners)
                .HasForeignKey(po => po.ProductDetailId);

            modelBuilder.Entity<ProductOwner>()
                .HasOne(po => po.WarrantyDetail)
                .WithOne(w => w.ProductOwner)
                .HasForeignKey<ProductOwner>(po => po.WarrantyDetailId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductSerialNumber>()
                .HasOne(sl => sl.ProductDetail)
                .WithMany(pd => pd.ProductSerialNumbers)
                .HasForeignKey(po => po.ProductDetailId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductOwner>()
                .HasOne(po => po.Login)
                .WithMany(l => l.ProductOwners)
                .HasForeignKey(po => po.LoginId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductOwner>()
                .HasOne(po => po.ProductSerialNumber)
                .WithOne(psn => psn.ProductOwner)
                .HasForeignKey<ProductOwner>(po => po.ProductSerialNumberId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

    }

}
