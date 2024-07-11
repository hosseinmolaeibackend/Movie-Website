﻿using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(150)]
        public string FullName { get; set; } = default!;
        [Required]
        [MaxLength(150)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = default!;
        [Required]
        [MaxLength(250)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;

        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }


        public ICollection<CommentModel> comments { get; set; } = default!;
        public ICollection<LikeModel> like { get; set; } = default!;
        public ICollection<NewsModel> news { get; set; }
    }
}
