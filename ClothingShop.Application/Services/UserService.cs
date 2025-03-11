using AutoMapper;
using ClothingShop.Application.DTOs.UserDtos;
using ClothingShop.Application.IServices;
using ClothingShop.Core;
using ClothingShop.Core.Entities;
using ClothingShop.Core.Exceptions;
using ClothingShop.Infrastructure.Repositories;

namespace ClothingShop.Application.Services
{
    /// <summary>
    /// Service class responsible for handling business logic related to users.
    /// </summary>
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        public readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="mapper">The AutoMapper instance.</param>
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new user asynchronously.
        /// </summary>
        /// <param name="userDto">The user DTO containing user details.</param>
        /// <returns>True if the operation is successful.</returns>
        public async Task<bool> CreateUserAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            return await _userRepository.CreateUserAsync(user);
        }

        /// <summary>
        /// Retrieves a user by Id.
        /// </summary>
        /// <param name="id">The user Id.</param>
        /// <returns>A DTO containing user details.</returns>
        public async Task<GetUserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            var getUser = _mapper.Map<GetUserDto>(user);
            return getUser;
        }

        /// <summary>
        /// Retrieves a paginated list of users.
        /// </summary>
        /// <param name="page">The page numer (must be >= 1).</param>
        /// <param name="pageSize">The number of users per page (must be >= 1).</param>
        /// <returns>A paginated result of users.</returns>
        /// <exception cref="ArgumentException">Thrown if page or pageSize is invalid.</exception>
        public async Task<Pagination<GetUserDto>> GetUserAsync(int page, int pageSize)
        {
            if (page < 1)
            {
                throw new ArgumentException("Page must be greater than or equal to 1.");
            }

            if (pageSize < 1)
            {
                throw new ArgumentException("Page size must be greater than or equal to 1.");
            }

            var (users, totalUser) = await _userRepository.GetUserAsync(page, pageSize);
            var totalPage = (int)Math.Ceiling((decimal)totalUser / pageSize);
            var userDtos = _mapper.Map<List<GetUserDto>>(users);

            return new Pagination<GetUserDto>
            {
                Total = totalUser,
                TotalPages = totalPage,
                CurrentPage = page,
                PageSize = pageSize,
                Item = userDtos
            };
        }

        /// <summary>
        /// Updates an existing user's details.
        /// </summary>
        /// <param name="id">The user Id.</param>
        /// <param name="userDto">The updated user detail.</param>
        /// <returns>True if the update is successful.</returns>
        public async Task<bool> UpdateUserAsync(int id, UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            return await _userRepository.UpdateUserAsync(id, user);
        }

        /// <summary>
        /// Soft deletes a user by setting the IsDeleted flag.
        /// </summary>
        /// <param name="id">The user Id.</param>
        /// <returns>True if the soft delete is successful.</returns>
        public async Task<bool> SoftDeleteUserAsync(int id)
        {
            return await _userRepository.SoftDeleteUserAsync(id);
        }

        /// <summary>
        /// Restores a soft-deleted user.
        /// </summary>
        /// <param name="id">The user Id.</param>
        /// <returns>True if the restore is successful.</returns>
        public async Task<bool> RestoreUserAsync(int id)
        {
            return await _userRepository.RestoreUserAsync(id);
        }

        /// <summary>
        /// Permanently deletes a user from the database.
        /// </summary>
        /// <param name="id">The user Id.</param>
        /// <returns>True if the delete operation is successful.</returns>
        public async Task<bool> DeleteUserAsync(int id)
        {
            return await _userRepository.DeleteUserAsync(id);
        }
    }
}
