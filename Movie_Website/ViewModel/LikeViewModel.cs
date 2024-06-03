using System.ComponentModel.DataAnnotations;

namespace Movie_Website.ViewModel
{
    public class LikeViewModel
    {
        [Required]
        public int MovieId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
