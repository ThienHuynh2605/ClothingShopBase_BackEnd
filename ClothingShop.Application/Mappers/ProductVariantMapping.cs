using AutoMapper;
using ClothingShop.Application.DTOs;
using ClothingShop.Application.DTOs.ProductDtos;
using ClothingShop.Core.Entities;

namespace ClothingShop.Application.Mappers
{
    public class ProductVariantMapping :Profile
    {
        public ProductVariantMapping()
        {
            CreateMap<ProductVariant, ProductVariantDto>().ReverseMap();
        }
    }
}
