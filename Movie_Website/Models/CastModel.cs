using System.ComponentModel.DataAnnotations;

namespace Movie_Website.Models
{
    public class CastModel
    {
        [Key]
        public int CastId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Bio { get; set; }
        public int Age { get; set; }

        ICollection<MovieMedCastModel> Medies { get; set; }
    }
}
