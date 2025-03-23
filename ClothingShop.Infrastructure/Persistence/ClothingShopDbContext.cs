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
        public DbSet<UserAccount> UsersAccounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(s => s.Account)
                .WithOne(s => s.User)
                .HasForeignKey<UserAccount>(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
