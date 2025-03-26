using ClothingShop.Application.DTOs.CartDtos;
using ClothingShop.Application.DTOs.UserDtos;
using ClothingShop.Application.IServices;
using ClothingShop.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClothingShop.API.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCartAsync(CartDto cartDto)
        {
            var result = await _cartService.CreateCartAsync(cartDto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCartAsync(int pageNumber = 1, int pageSize = 5)
        {
            var result = await _cartService.GetAllCartAsync(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCartByIdAsync(int id)
        {
            var result = await _cartService.GetCartByIdAsync(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCartAsync(int id, CartDto cartDto)
        {
            var result = await _cartService.UpdateCartAsync(id, cartDto);
            return Ok(result);
        }

        [HttpPost("{id}/add-product")]
        public async Task<IActionResult> AddProductToCartAsync(int id, CartProductDto product)
        {
            var result = await _cartService.AddProductToCartAsync(id, product);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteCartAsync(int id)
        {
            var result = await _cartService.SoftDeleteCartAsync(id);
            return Ok(result);
        }
    }
}
