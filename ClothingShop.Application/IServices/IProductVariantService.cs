using ClothingShop.Application.DTOs;
using ClothingShop.Core;

namespace ClothingShop.Application.IServices
{
    public interface IProductVariantService
    {
        Task<bool> CreateProductVariantAsync(ProductVariantDto productVariantDto);
        Task<ProductVariantDto> GetProductVariantByIdAsync(int id);
        Task<Pagination<ProductVariantDto>> GetProductVariantAsync(int page, int pageSize);
        Task<bool> UpdateProductVariantAsync(int id, ProductVariantDto productVariantDto);
        Task<bool> SoftDeleteProductVariantAsync(int id);
        Task<bool> RestoreProductVariantAsync(int id);
        Task<bool> DeleteProductVariantAsync(int id);
    }
}
