using AutoMapper;
using ClothingShop.Application.DTOs.CartDtos;
using ClothingShop.Application.DTOs.UserDtos;
using ClothingShop.Core.Entities;
using ClothingShop.Core.Relationship;

namespace ClothingShop.Application.Mappers
{
    public class CartMapping : Profile
    {
        public CartMapping()
        {
            CreateMap<Cart, CartDto>().ReverseMap();
            CreateMap<CartProduct, CartProductDto>().ReverseMap();
        }
    }
}
