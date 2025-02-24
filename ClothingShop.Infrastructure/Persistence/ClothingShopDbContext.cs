using ClothingShop.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothingShop.Infrastructure.Persistence
{
    public class ClothingShopDbContext : DbContext
    {
        public ClothingShopDbContext(DbContextOptions<ClothingShopDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
