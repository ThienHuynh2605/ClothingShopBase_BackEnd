using ClothingShop.Application.DTOs;

namespace ClothingShop.Application.IServices
{
    public interface IProductService
    {
        Task<ProductDto> CreateProductAsyn(ProductDto input);
        Task<ProductDto> GetProductByIdAsync(int id);
    }
}
