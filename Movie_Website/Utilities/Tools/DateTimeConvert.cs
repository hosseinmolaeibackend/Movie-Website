namespace Movie_Website.Utilities.Tools
{
	public class DateTimeConvert
	{
		public static string MonthToString(DateTime dateTime)
		{
			string date = "Jan";

			switch (dateTime.Month)
			{
				case 1:
					return date = "Jan";
				case 2:
					return date = "Feb";
				case 3:
					return date = "Mar";
				case 4:
					return date = "Apr";
				case 5:
					return date = "May";
				case 6:
					return date = "Jun";
				case 7:
					return date = "Jul";
				case 8:
					return date = "Aug";
				case 9:
					return date = "Sep";
				case 10:
					return date = "Oct";
				case 11:
					return date = "Nov";
				case 12:
					return date = "Dec";
			}
			return date;
		}
	}
}
