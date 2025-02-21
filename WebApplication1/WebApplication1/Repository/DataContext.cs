using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Repository
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Models.Product> Product { get; set; }
        public DbSet<Models.ProductCategory> ProductCategory { get; set; }
    }
}
