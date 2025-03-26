using ClothingShop.Core.Entities;
using ClothingShop.Core.Relationship;
using ClothingShop.Infrastructure.IRepositories.SpecificRepository;
using ClothingShop.Infrastructure.Persistence;
using ClothingShop.Infrastructure.Repositories.GenericRepository;

namespace ClothingShop.Infrastructure.Repositories.SpecificRepository
{
    public class CartRepository : BaseRepository<Cart>, ICartRepository
    {
        public CartRepository(ClothingShopDbContext context) : base(context) { }

        public async Task<bool> AddProductToCartAsync(int cartId, CartProduct product)
        {
            var cartProduct = new CartProduct
            {
                CartId = cartId,
                ProductId = product.ProductId
            };

            await _context.CartsProducts.AddAsync(cartProduct);
            return true;
        }
    }
}
