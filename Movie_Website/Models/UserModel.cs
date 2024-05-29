﻿using System.ComponentModel.DataAnnotations;

namespace Movie_Website.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(150)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(150)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [MaxLength(250)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }




    }
}