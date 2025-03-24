using ClothingShop.Application.DTOs.UserAccountDtos;
using ClothingShop.Application.DTOs.UserAddressDtos;

namespace ClothingShop.Application.DTOs.UserDtos
{
    public class GetUserByIdDto : GetUserDto
    {
        public UserAccountDto Account { get; set; }
        public List<GetUserAddressDto> Addresses { get; set; }
    }
}
