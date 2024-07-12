using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dto
{
	public class MovieDto
	{
		
		public int MovieId { get; set; }
	
		public string MovieTitle { get; set; } = default!;
		
		public string MovieDescription { get; set; } = default!;
		
		public string Author { get; set; } = default!;
		public string? Url { get; set; }

		public string? ImageName { get; set; }

		public string VideoName { get; set; } = default!;
	}
}
