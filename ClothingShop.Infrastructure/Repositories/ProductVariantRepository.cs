using AutoMapper;
using ClothingShop.Core.Entities;
using ClothingShop.Core.Exceptions;
using ClothingShop.Infrastructure.IRepositories;
using ClothingShop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClothingShop.Infrastructure.Repositories
{
    public class ProductVariantRepository : IProductVariantRepository
    {
        public readonly ClothingShopDbContext _context;
        public readonly IMapper _mapper;
        public ProductVariantRepository(ClothingShopDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> CreateProductVariantAsync(ProductVariant productVariant)
        {
            await _context.ProductVariants.AddAsync(productVariant );
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ProductVariant> GetProductVariantByIdAsync(int id)
        {
            var productVariant = await _context.ProductVariants.Where(p => p.IsDeleted == false).FirstOrDefaultAsync(p => p.Id == id);
            if (productVariant == null)
            {
                throw new NotFoundException("ProductVariant is not found");
            }
            return productVariant;
        }


        public async Task<(List<ProductVariant> ProductVariant, int total)> GetProductVariantAsync(int page, int pageSize)
        {
            var productVariants = await _context.ProductVariants
                 .Skip((page - 1) * pageSize)
                 .Take(pageSize)
                 .ToListAsync();
            var total = await _context.ProductVariants.CountAsync();
            if (total < 1)
                throw new NotFoundException("Product is not Found");
            return (productVariants, total);
        }


        public async Task<bool> UpdateProductVariantAsync(int id, ProductVariant productVariant)
        {

            var existingProductVariant = await _context.ProductVariants
                .Where(s => s.IsDeleted == false)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (existingProductVariant == null)
            {
                throw new NotFoundException("ProductVariant is not found");
            }
            _mapper.Map(productVariant, existingProductVariant);
            existingProductVariant.UpdateAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }



        public async Task<bool> SoftDeleteProductVariantAsync(int id)
        {
            var productVariant = await GetProductVariantByIdAsync(id);
            if (productVariant != null)
            {
                productVariant.IsDeleted = true;
                productVariant.DeleteAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> RestoreProductVariantAsync(int id)
        {
            var productVariant = await _context.ProductVariants.IgnoreQueryFilters().FirstOrDefaultAsync(s => s.Id == id);
            if (productVariant != null)
            {
                productVariant.IsDeleted = false;
                await _context.SaveChangesAsync();
            }
            return true;

        }



        public async Task<bool> DeleteProductVariantAsync(int id)
        {
            var productVariant = await GetProductVariantByIdAsync(id);
            if (productVariant != null)
            {
                _context.ProductVariants.Remove(productVariant);
                await _context.SaveChangesAsync();
            }
            return true;
        }

     
    }
}
