﻿using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "User name is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
