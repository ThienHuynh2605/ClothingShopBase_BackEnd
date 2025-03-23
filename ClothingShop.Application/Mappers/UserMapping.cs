using AutoMapper;
using ClothingShop.Application.DTOs.UserAccountDtos;
using ClothingShop.Application.DTOs.UserDtos;
using ClothingShop.Core.Entities;

namespace ClothingShop.Application.Mappers
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, GetUserByIdDto>().ReverseMap();
            CreateMap<User, GetUserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();

            CreateMap<UserAccount, UserAccountDto>().ReverseMap();
        }
    }
}
