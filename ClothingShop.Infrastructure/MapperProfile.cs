﻿using AutoMapper;
using ClothingShop.Core.Entities;

namespace ClothingShop.Infrastructure
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForAllMembers(opt => opt.Condition(
                (src, dest, srcMember) => srcMember != null));

            CreateMap<Product, Product>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
