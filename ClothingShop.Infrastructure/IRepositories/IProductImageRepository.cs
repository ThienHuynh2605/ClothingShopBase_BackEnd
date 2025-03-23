using ClothingShop.Core.Entities;

namespace ClothingShop.Infrastructure.IRepositories
{
    public interface IProductImageRepository
    {
        Task<bool> CreateProductImageAsync(ProductImage productImage);
        Task<ProductImage> GetProductImageByIdAsync(int id);
        Task<(List<ProductImage> ProductImage, int total)> GetProductImageAsync(int page, int pageSize);
        Task<bool> UpdateProductImageAsync(int id, ProductImage productImage);
        Task<bool> SoftDeleteProductImageAsync(int id);
        Task<bool> RestoreProductImageAsync(int id);
        Task<bool> DeleteProductImageAsync(int id);
    }
}
