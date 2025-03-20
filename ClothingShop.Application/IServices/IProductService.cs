
using ClothingShop.Application.DTOs.ProductDtos;
using ClothingShop.Core;

namespace ClothingShop.Application.IServices
{
    public interface IProductService
    {
        Task<bool> CreateProductAsync(ProductDto productDto);
        Task<ProductDto> GetProductByIdAsync(int id);
        Task<Pagination<ProductDto>> GetProductAsync(int page, int pageSize);
        Task<bool> UpdateProductAsync(int id, ProductDto productDto);
        Task<bool> SoftDeleteProductAsync(int id);
        Task<bool> RestoreProductAsync(int id);
        Task<bool> DeleteProductAsync(int id);
    }
}
