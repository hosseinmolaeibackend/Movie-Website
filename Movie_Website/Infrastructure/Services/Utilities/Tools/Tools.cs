namespace Movie_Website.Infrastructure.Services.Utilities.Tools
{
	public class Tools
	{
		public static void DeleteFile(string OriginPath, string fileName)
		{
			if (!string.IsNullOrEmpty(fileName))
			{
				if (File.Exists(OriginPath + fileName))
				{
					File.Delete(OriginPath + fileName);
				}
			}
		}
	}
}
