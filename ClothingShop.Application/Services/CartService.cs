using AutoMapper;
using Azure;
using ClothingShop.Application.DTOs.CartDtos;
using ClothingShop.Application.IServices;
using ClothingShop.Core.Entities;
using ClothingShop.Core.Exceptions;
using ClothingShop.Core.Relationship;
using ClothingShop.Infrastructure.IRepositories.UnitOfWork;

namespace ClothingShop.Application.Services
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CartService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateCartAsync(CartDto cartDto)
        {
            var cart = _mapper.Map<Cart>(cartDto);
            await _unitOfWork.Carts.CreateAsync(cart);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddProductToCartAsync(int Id, CartProductDto product)
        {
            var cart = await _unitOfWork.Carts.GetByIdAsync(Id);
            if(cart == null)
            {
                throw new NotFoundException("Cart is not found.");
            }

            var productAdd = await _unitOfWork.Products.GetProductByIdAsync(product.ProductId);
            if(productAdd == null)
            {
                throw new NotFoundException("Product is not found.");
            }

            var check = await _unitOfWork.CartsProducts.Check(Id, product.ProductId);
            if(check == true)
            {
                throw new ArgumentException("Product was added to Cart.");
            }
            var productDto = _mapper.Map<CartProduct>(product);
            var result = await _unitOfWork.Carts.AddProductToCartAsync(Id, productDto);
            await _unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<List<CartDto>> GetAllCartAsync(int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
            {
                throw new ArgumentException("Page must be greater than or equal to 1.");
            }

            if (pageSize < 1)
            {
                throw new ArgumentException("Page size must be greater than or equal to 1.");
            }
            var carts = await _unitOfWork.Carts.GetPagedResponseAsync(pageNumber, pageSize);
            var result = _mapper.Map<List<CartDto>>(carts);
            return result;
        }

        public async Task<CartDto> GetCartByIdAsync(int id)
        {
            var cart = await _unitOfWork.Carts.GetByIdAsync(id);
            if(cart == null)
            {
                throw new NotFoundException("Cart is not found.");
            }
            var result = _mapper.Map<CartDto>(cart);
            return result;
        }

        public async Task<bool> UpdateCartAsync(int id, CartDto cartDto)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(cartDto.UserId);
            if (user == null)
            {
                throw new NotFoundException("User is not found.");
            }

            var cart = await _unitOfWork.Carts.GetByIdAsync(id);
            if(cart == null)
            {
                throw new NotFoundException("Cart is not found.");
            }
            _mapper.Map(cartDto, cart);
            await _unitOfWork.Carts.UpdateAsync(cart);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SoftDeleteCartAsync(int id)
        {
            var cart = await _unitOfWork.Carts.GetByIdAsync(id);
            if (cart == null)
            {
                throw new NotFoundException("Cart is not found.");
            }
            await _unitOfWork.Carts.SoftDeleteAsync(cart);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
