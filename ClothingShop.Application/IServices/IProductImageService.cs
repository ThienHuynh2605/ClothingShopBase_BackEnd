using ClothingShop.Application.DTOs;
using ClothingShop.Core;

namespace ClothingShop.Application.IServices
{
    public interface IProductImageService
    {
        Task<bool> CreateProductImageAsync(ProductImageDto productImageDto);
        Task<ProductImageDto> GetProductImageByIdAsync(int id);
        Task<Pagination<ProductImageDto>> GetProductImageAsync(int page, int pageSize);
        Task<bool> UpdateProductImageAsync(int id, ProductImageDto productImageDto);
        Task<bool> SoftDeleteProductImageAsync(int id);
        Task<bool> RestoreProductImageAsync(int id);
        Task<bool> DeleteProductImageAsync(int id);
    }
}
