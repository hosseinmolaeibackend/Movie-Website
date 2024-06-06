using System.ComponentModel.DataAnnotations;

namespace Movie_Website.ViewModel
{
    public class MovieMedCastViewModel
    {
        [Required]
        public int MovieId { get; set; }
        [Required]
        public int CastId { get; set; }
    }
}
