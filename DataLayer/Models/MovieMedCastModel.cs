using System.ComponentModel.DataAnnotations;

namespace Movie_Website.Models
{
    public class MovieMedCastModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int MovieId{ get; set; }
        [Required]
        public int CastId { get; set; }


        public CastModel CastModel { get; set; } = default!;
		public MovieModel MovieModel { get; set; } = default!;

	}
}
