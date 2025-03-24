using ClothingShop.Application.DTOs.UserAddressDtos;
using ClothingShop.Application.DTOs.UserDtos;
using ClothingShop.Application.IServices;
using ClothingShop.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ClothingShop.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(CreateUserDto userDto)
        {
            var result = await _userService.CreateUserAsync(userDto);
            return Ok(result);   
        }

        [HttpPost("address")]
        public async Task<IActionResult> CreateAddressAsync(CreateUserAddressDto createUserAddressDto)
        {
            var result = await _userService.CreateAddressAsync(createUserAddressDto);
            return Ok(result);
        }

        [HttpGet("{id}")]        
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return Ok(user);
        }

        [HttpGet] 
        public async Task<IActionResult> GetUserAsync(int page = 1, int pageSize = 5)
        {
            var user = await _userService.GetUserAsync(page, pageSize);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAsync(int id,[FromBody] UserDto userDto)
        {
            var result = await _userService.UpdateUserAsync(id, userDto);
            return Ok(result);
        }

        [HttpPut("address/{id}")]
        public async Task<IActionResult> UpdateAddressAsync(int id, [FromBody] UserAddressDto addressDto)
        {
            var result = await _userService.UpdateAddressAsync(id, addressDto);
            return Ok(result);
        }

        [HttpDelete("soft-delete/{id}")]
        public async Task<IActionResult> SoftDeleteUserAsync(int id)
        {
            var result = await _userService.SoftDeleteUserAsync(id);
            return Ok(result);
        }

        [HttpDelete("soft-delete/address/{id}")]
        public async Task<IActionResult> SoftDeleteAddressAsync(int id)
        {
            var result = await _userService.SoftDeleteAddressAsync(id);
            return Ok(result);
        }


        [HttpPost("restore/{id}")]
        public async Task<IActionResult> RestoreUserAsync(int id)
        {
            var result = await _userService.RestoreUserAsync(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            var result = await _userService.DeleteUserAsync(id);
            return Ok(result);
        }
    }
}
