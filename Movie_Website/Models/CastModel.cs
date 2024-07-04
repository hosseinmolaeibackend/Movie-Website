using System.ComponentModel.DataAnnotations;

namespace Movie_Website.Models
{
    public class CastModel
    {
        [Key]
        public int CastId { get; set; }
        [Required]
        public string Name { get; set; } = default!;
		[Required]
        public string Bio { get; set; } = default!;
		public int Age { get; set; }

        public string? ImageName {  get; set; }

        public ICollection<MovieMedCastModel> MovieMedCasts { get; set; } = default!;
    }
}
