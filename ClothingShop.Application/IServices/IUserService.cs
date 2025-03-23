using ClothingShop.Application.DTOs.UserDtos;
using ClothingShop.Core;
using ClothingShop.Core.Entities;

namespace ClothingShop.Application.IServices
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(CreateUserDto userDto);
        Task<GetUserByIdDto> GetUserByIdAsync(int id);
        Task<Pagination<GetUserDto>> GetUserAsync(int page, int pageSize);
        Task<bool> UpdateUserAsync(int id, UserDto userDto); 
        Task<bool> SoftDeleteUserAsync(int id);
        Task<bool> RestoreUserAsync(int id);   
        Task<bool> DeleteUserAsync(int id);
    }
}
