namespace Movie_Website.Presentation.ViewModels
{
	public class UserHelperViewModel
	{
		public string Fullname { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public List<CommentViewModel>? comment { get; set; }
		//public List<T> Like { get; set; }
	}
}
