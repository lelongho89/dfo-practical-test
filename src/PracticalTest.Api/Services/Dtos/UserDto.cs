﻿using System.ComponentModel.DataAnnotations;

namespace PracticalTestApi.Services.Dtos
{
    public class UserDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [MaxLength(50)]
        public string Address { get; set; }
    }
}
