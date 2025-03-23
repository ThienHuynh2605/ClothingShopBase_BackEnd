using ClothingShop.Application.DTOs.UserAccountDtos;

namespace ClothingShop.Application.DTOs.UserDtos
{
    public class CreateUserDto : UserDto
    {
        public UserAccountDto Account { get; set; }
    }
}
