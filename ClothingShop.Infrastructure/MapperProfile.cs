using AutoMapper;
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

            CreateMap<UserAddress, UserAddress>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.UserId, opt => opt.Ignore())
            .ForAllMembers(opt => opt.Condition(
                (src, dest, srcMember) => srcMember != null));

            CreateMap<Product, Product>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForAllMembers(opt => opt.Condition(
                    (src, dest, srcMember) => srcMember != null));

            CreateMap<ProductVariant, ProductVariant>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForAllMembers(opt => opt.Condition(
                   (src, dest, srcMember) => srcMember != null));

            CreateMap<ProductImage, ProductImage>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForAllMembers(opt => opt.Condition(
                   (src, dest, srcMember) => srcMember != null));
        }

       
        }
}
