using ClothingShop.Application.DTOs.UserAccountDtos;
using ClothingShop.Application.DTOs.UserAddressDtos;

namespace ClothingShop.Application.DTOs.UserDtos
{
    public class CreateUserDto : UserDto
    {
        public UserAccountDto Account { get; set; }
        public List<UserAddressDto> Addresses { get; set; }
    }
}
