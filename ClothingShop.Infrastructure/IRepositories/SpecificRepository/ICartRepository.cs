using ClothingShop.Core.Entities;
using ClothingShop.Core.Relationship;
using ClothingShop.Infrastructure.IRepositories.GenericRepository;

namespace ClothingShop.Infrastructure.IRepositories.SpecificRepository
{
    public interface ICartRepository : IBaseRepository<Cart>
    {
        Task<bool> AddProductToCartAsync(int cartId, CartProduct product);
    }
}
