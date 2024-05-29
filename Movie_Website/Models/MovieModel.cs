using System.ComponentModel.DataAnnotations;

namespace Movie_Website.Models
{
    public class MovieModel
    {
        [Key]
        public int MovieId { get; set; }
        [Required]
        [MaxLength(255)]
        public string MovieTitle { get; set; }
        [Required]
        public string MovieDescription { get; set; }
        [Required]
        public string Author { get; set; }
        public string Url { get; set; }


        ICollection<MovieMedCastModel> MovieMedCasts { get; set; }
    }
}
