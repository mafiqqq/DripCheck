using Microsoft.EntityFrameworkCore;

namespace DripCheckAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
        }

        public DbSet<WarrantyDetail> WarrantyDetails { get; set; }
        public DbSet<SerialDetail> SerialDetails { get; set; }
    }

}
