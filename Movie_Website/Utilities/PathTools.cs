namespace Movie_Website.Utilities
{
	public class PathTools
	{
		#region Cast image
		public static string CastImage = "/content/images/cast/image/";
		public static string CastImageServerPath
			= Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/cast/image/");
		public static string CastImageThumb = "/content/images/cast/thumb/";
		public static string CastImageThumbServerPath
			= Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/cast/thumb/");
        #endregion

        #region News image
        public static string NewsImage = "/content/images/news/image/";
        public static string NewsImageServerPath
            = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/news/image/");
        public static string NewsImageThumb = "/content/images/news/thumb/";
        public static string NewsImageThumbServerPath
            = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/news/thumb/");
        #endregion

        #region Videos
        public static string MovieImage = "/content/images/movie/image/";
        public static string MovieImageServerPath
            = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/movie/image/");

        public static string MovieImageThumb = "/content/images/movie/thumb/";
        public static string MovieImageThumbServerPath
            = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/movie/thumb/");

        public static string MovieVideo = "/content/images/movie/video/";
        public static string MovieVideoServerPath
            = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/movie/video/");
        #endregion
    }
}
