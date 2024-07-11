using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class MovieModel
    {
        [Key]
        public int MovieId { get; set; }
        [Required]
        [MaxLength(255)]
        public string MovieTitle { get; set; } = default!;
		[Required]
        public string MovieDescription { get; set; } = default!;
        [Required]
        public string Author { get; set; } = default!;
		public string? Url { get; set; }

        public string? ImageName { get; set; }

        [Required]
        public string VideoName { get; set; }=default!;

        public ICollection<CommentModel> comments { get; set; } = default!;
        public ICollection<GenerModel> generators { get; set; } = default!;
		public ICollection<MovieMedCastModel> MovieMedCasts { get; set; } = default!;
        public ICollection<LikeModel> LikeModels { get; set; } = default!;
	}
}
