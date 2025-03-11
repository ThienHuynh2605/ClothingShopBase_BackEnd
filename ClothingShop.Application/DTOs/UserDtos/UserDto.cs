﻿using ClothingShop.Core.Enums;

namespace ClothingShop.Application.DTOs.UserDtos
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }
        public Role Role { get; set; }
    }
}
