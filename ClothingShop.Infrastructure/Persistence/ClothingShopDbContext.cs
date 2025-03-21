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

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        
    }
}
