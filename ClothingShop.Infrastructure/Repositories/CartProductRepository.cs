using ClothingShop.Infrastructure.IRepositories;
using ClothingShop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClothingShop.Infrastructure.Repositories
{
    public class CartProductRepository : ICartProductRepository
    {
        private readonly ClothingShopDbContext _context;
        public CartProductRepository(ClothingShopDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Check(int cartId, int productId)
        {
            var result = await _context.CartsProducts
                .FirstOrDefaultAsync(s => s.CartId ==  cartId && s.ProductId == productId); 
            if (result != null)
            {
                return true;
            }
            return false;
        }
    }
}
