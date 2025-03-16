
using ClothingShop.Core.Entities;

namespace ClothingShop.Infrastructure.IRepositories
{
    public interface IProductRepository
    {
        Task<bool> CreateProductAsync(Product product);
        Task<Product> GetProductByIdAsync(int id);
        Task<(List<Product> product, int total)> GetProductAsync(int page, int pageSize);
        Task<bool> UpdateProductAsync(int id, Product product);
        Task<bool> SoftDeleteProductAsync(int id);
        Task<bool> RestoreProductAsync(int id);
        Task<bool> DeleteProductAsync(int id);
    }
}
