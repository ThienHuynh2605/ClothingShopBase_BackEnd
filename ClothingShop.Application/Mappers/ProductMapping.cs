
using AutoMapper;
using ClothingShop.Application.DTOs.ProductDtos;
using ClothingShop.Core.Entities;

namespace ClothingShop.Application.Mappers
{
    public class ProductMapping :Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
