using System.ComponentModel.DataAnnotations;

namespace Movie_Website.Models
{
    public class GenerModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int MovieId{ get; set; }
        [Required]
        public int CategoryId { get; set; }


        public CategoryModel Category { get; set; } = default!;
		public MovieModel Movie { get; set; } = default!;
	}
}
