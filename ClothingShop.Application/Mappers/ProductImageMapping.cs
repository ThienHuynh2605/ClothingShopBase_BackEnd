using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClothingShop.Application.DTOs;
using ClothingShop.Core.Entities;

namespace ClothingShop.Application.Mappers
{
    public class ProductImageMapping:Profile
    {
        public ProductImageMapping()
        {
            CreateMap<ProductImage, ProductImageDto>().ReverseMap();
        }
    }
}
