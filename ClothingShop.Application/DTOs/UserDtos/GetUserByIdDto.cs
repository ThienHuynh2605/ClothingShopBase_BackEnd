using ClothingShop.Application.DTOs.UserAccountDtos;

namespace ClothingShop.Application.DTOs.UserDtos
{
    public class GetUserByIdDto : GetUserDto
    {
        public UserAccountDto Account { get; set; }
    }
}
