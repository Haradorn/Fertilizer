using Microsoft.EntityFrameworkCore;

namespace Fertilizer.Models
{
    public class MinFertilizerContext : DbContext
    {
        public DbSet<MinFertilizer> MinFertilizers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public MinFertilizerContext(DbContextOptions<MinFertilizerContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
