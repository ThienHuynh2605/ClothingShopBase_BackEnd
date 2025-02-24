using ClothingShop.Core.Entities;

namespace ClothingShop.Core.IRepositories
{
    public interface IProductRepository
    {
        Task CreateProductAsync(Product input);
        Task<Product> GetProductByIdAsync(int id);
    }
}
