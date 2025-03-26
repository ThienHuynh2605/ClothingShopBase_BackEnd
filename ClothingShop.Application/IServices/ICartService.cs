using ClothingShop.Application.DTOs.CartDtos;
using ClothingShop.Core.Relationship;

namespace ClothingShop.Application.IServices
{
    public interface ICartService
    {
        Task<bool> CreateCartAsync(CartDto cartDto);
        Task<List<CartDto>> GetAllCartAsync(int pageNumber, int pageSize);
        Task<CartDto> GetCartByIdAsync(int id);
        Task<bool> UpdateCartAsync(int id, CartDto cartDto);
        Task<bool> AddProductToCartAsync(int Id, CartProductDto product);
        Task<bool> SoftDeleteCartAsync(int id);
    }
}
