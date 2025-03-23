using AutoMapper;
using ClothingShop.Core.Entities;
using ClothingShop.Core.Exceptions;
using ClothingShop.Infrastructure.IRepositories;
using ClothingShop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClothingShop.Infrastructure.Repositories
{
    public class ProductImageRepository : IProductImageRepository
    {
        public readonly ClothingShopDbContext _context;
        public readonly IMapper _mapper;
        public ProductImageRepository(ClothingShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> CreateProductImageAsync(ProductImage productImage)
        {
            await _context.ProductImages.AddAsync(productImage);
            await _context.SaveChangesAsync();
            return true;
        }

      

       

        public async Task<ProductImage> GetProductImageByIdAsync(int id)
        {
            var productImage = await _context.ProductImages.Where(p => p.IsDeleted == false).FirstOrDefaultAsync(p => p.Id == id);
            if (productImage == null)
            {
                throw new NotFoundException("ProductImage is not found");
            }
            return productImage;
        }

        public async Task<(List<ProductImage> ProductImage, int total)> GetProductImageAsync(int page, int pageSize)
        {
            var productImages = await _context.ProductImages
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            var total = await _context.ProductVariants.CountAsync();
            if (total < 1)
                throw new NotFoundException("ProductImage is not Found");
            return (productImages, total);

        }

        public async Task<bool> UpdateProductImageAsync(int id, ProductImage productImage)
        {
            var existProductImage = await _context.ProductImages
                .Where(s => s.IsDeleted == false)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (existProductImage == null)
            {
                throw new NotFoundException("ProductImage is not found");
            }
            _mapper.Map(productImage, existProductImage);
            existProductImage.UpdateAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SoftDeleteProductImageAsync(int id)
        {
            var productImage = await GetProductImageByIdAsync(id);
            if (productImage != null)
            {
                productImage.IsDeleted = true;
                productImage.DeleteAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> RestoreProductImageAsync(int id)
        {
            var productVariant = await _context.ProductVariants.IgnoreQueryFilters().FirstOrDefaultAsync(s => s.Id == id);
            if (productVariant != null)
            {
                productVariant.IsDeleted = false;
                await _context.SaveChangesAsync();
            }
            return true;
        }

      

        
        public async Task<bool> DeleteProductImageAsync(int id)
        {
            var productImage = await GetProductImageByIdAsync(id);
            if (productImage != null)
            {
                _context.ProductImages.Remove(productImage);
                await _context.SaveChangesAsync();
            }
            return true;
        }
    }
}
