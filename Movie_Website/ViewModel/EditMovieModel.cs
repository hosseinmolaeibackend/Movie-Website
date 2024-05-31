﻿using System.ComponentModel.DataAnnotations;

namespace Movie_Website.ViewModel
{
    public class EditMovieModel
    {
        public int MovieId { get; set; }
        [Required]
        [MaxLength(255)]
        public string MovieTitle { get; set; } = default!;
        [Required]
        public string MovieDescription { get; set; } = default!;
        [Required]
        public string Author { get; set; } = default!;

        public string? Url { get; set; }
    }
}
