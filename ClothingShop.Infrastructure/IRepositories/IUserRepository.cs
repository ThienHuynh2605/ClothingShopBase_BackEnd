using ClothingShop.Core.Entities;

namespace ClothingShop.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<bool> CreateUserAsync(User user);
        Task<User> GetUserByIdAsync(int id);
        Task<(List<User> users, int total)> GetUserAsync(int page, int pageSize);
        Task<bool> UpdateUserAsync(int  id, User user);  
        Task<bool> SoftDeleteUserAsync(int id);
        Task<bool> RestoreUserAsync(int id);
        Task<bool> DeleteUserAsync(int id);
    }
}