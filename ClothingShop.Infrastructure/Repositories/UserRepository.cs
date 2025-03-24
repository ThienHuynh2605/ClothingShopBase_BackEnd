using System.Net;
using AutoMapper;
using ClothingShop.Core.Entities;
using ClothingShop.Core.Exceptions;
using ClothingShop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClothingShop.Infrastructure.Repositories
{
    /// <summary>
    /// Repository class for handling User-related database operations.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        public readonly ClothingShopDbContext _context;
        public readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <param name="mapper">The AutoMapper instance.</param>
        public UserRepository(ClothingShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new user asynchronously.
        /// </summary>
        /// <param name="user">The user entity to add.</param>
        /// <returns>True if the operation is successful.</returns>
        public async Task<bool> CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CreateAddressAsync(UserAddress address)
        {
            await _context.UsersAddresses.AddAsync(address);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Retrieves a user by Id, ensuring it is not soft-deleted.
        /// </summary>
        /// <param name="id">The user Id.</param>
        /// <returns>The user entity.</returns>
        /// <exception cref="NotFoundException">Thrown if the user is not found.</exception>
        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _context.Users
                .Include(u => u.Account)
                .Include(s => s.Addresses)
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
            if (user == null)
            {
                throw new NotFoundException("User is not found.");
            }
            return user;
        }

        /// <summary>
        /// Retrieves a paginated list of users.
        /// </summary>
        /// <param name="page">The paging number.</param>
        /// <param name="pageSize">The number of users per page.</param>
        /// <returns>A tuple containing the list of users and the total count.</returns>
        public async Task<(List<User> users, int total)> GetUserAsync(int page, int pageSize)
        {
            var users = await _context.Users
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            var total = await _context.Users.CountAsync();
            return (users, total);
        }

        /// <summary>
        /// Updates an existing user's detail.
        /// </summary>
        /// <param name="id">The name user id.</param>
        /// <param name="user">The updated user entity.</param>
        /// <returns>True if the update is successful.</returns>
        /// <exception cref="NotFoundException">Thrown if the user is not found.</exception>
        public async Task<bool> UpdateUserAsync(int id, User user)
        {
            var existingUser = await _context.Users
                .Where(s => s.IsDeleted == false)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (existingUser == null)
            {
                throw new NotFoundException("User is not found.");
            }
            _mapper.Map(user, existingUser);
            existingUser.UpdateAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAddressAsync(int id, UserAddress address)
        {
            var existingAddress = await _context.UsersAddresses
                .Where(s => s.IsDeleted == false)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (existingAddress == null)
            {
                throw new NotFoundException("User address is not found.");
            }
            _mapper.Map(address, existingAddress);
            existingAddress.UpdateAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Soft deletes a user by setting the IsDeleted flag.
        /// </summary>
        /// <param name="id">The user Id</param>
        /// <returns>True if the soft delete is successful</returns>
        public async Task<bool> SoftDeleteUserAsync(int id)
        {
            var user = await GetUserByIdAsync(id);
            if (user != null)
            {
                user.IsDeleted = true;
                user.DeleteAt = DateTime.Now;

                if(user.Account != null)
                {
                    user.Account.IsDeleted = true;
                    user.Account.DeleteAt = DateTime.Now;
                }

                if (user.Addresses != null)
                {
                    user.Addresses.ForEach(s => s.IsDeleted = true);
                    user.Addresses.ForEach(s => s.DeleteAt = DateTime.Now);
                }
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SoftDeleteAddressAsync(int id)
        {
            var address = await _context.UsersAddresses
                .Where(s => s.IsDeleted == false)
                .FirstOrDefaultAsync (s => s.Id == id);

            if (address != null)
            {
                address.IsDeleted = true;
                address.DeleteAt = DateTime.Now;
            }
            else throw new NotFoundException("Address is not found.");
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Restores a soft-deleted user.
        /// </summary>
        /// <param name="id">The user Id.</param>
        /// <returns>True if the restore is successful.</returns>
        public async Task<bool> RestoreUserAsync(int id)
        {
            var user = await _context.Users.IgnoreQueryFilters()
                .FirstOrDefaultAsync(s => s.Id == id);
            if(user != null)
            {
                user.IsDeleted = false;
            }
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Permanently deletes a user from the database.
        /// </summary>
        /// <param name="id">The user Id.</param>
        /// <returns>True if the delete operation is successful.</returns>
        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users
                .Include(u => u.Account)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                throw new NotFoundException("User is not found.");
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
