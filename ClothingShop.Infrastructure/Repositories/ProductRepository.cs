using ClothingShop.Core.Entities;
using ClothingShop.Core.IRepositories;
using ClothingShop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClothingShop.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ClothingShopDbContext _context;
        public ProductRepository(ClothingShopDbContext context)
        {
            _context = context;
        }

        public async Task CreateProductAsync(Product input)
        {
            _context.Products.Add(input);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
