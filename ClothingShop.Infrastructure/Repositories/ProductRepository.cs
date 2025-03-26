
using AutoMapper;
using ClothingShop.Core.Entities;
using ClothingShop.Core.Exceptions;
using ClothingShop.Infrastructure.IRepositories;
using ClothingShop.Infrastructure.Persistence;
using ClothingShop.Infrastructure.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace ClothingShop.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>,IProductRepository
    {
        public ProductRepository(ClothingShopDbContext context) : base(context) { }

        public async Task<bool> CreateProductAsync(Product product)
        {
            await _context.Products.AddAsync( product );
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _context.Products.Where(p => p.IsDeleted == false).FirstOrDefaultAsync(p => p.Id == id);
            if(product==null)
            {
                throw new NotFoundException("Product is not found");
            }
            return product;

        }

        public async Task<(List<Product> product, int total)> GetProductAsync(int page, int pageSize)
        {
            var products = await _context.Products
                .Skip((page-1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            var total = await _context.Products.CountAsync();
            if (total < 1)
                throw new NotFoundException("Product is not Found");
            return (products, total);
        }

        public async Task<bool> SoftDeleteProductAsync(int id)
        {
            var product = await GetProductByIdAsync(id);
            if(product != null)
            {
                product.IsDeleted = true;
                product.DeleteAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return true;
        }


        public async Task<bool> RestoreProductAsync(int id)
        {
            var product = await _context.Products.IgnoreQueryFilters().FirstOrDefaultAsync(s => s.Id == id);
            if(product != null)
            {
                product.IsDeleted = false;
                await _context.SaveChangesAsync();
            }
            return true;

        }


        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await GetProductByIdAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            return true;
        }













    }
}
