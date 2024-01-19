using System.Globalization;

namespace SchoolProject.Data.Commons
{
	public class GeneralLocalizableEntity
	{
		public string Localize(string textAr, string textEN)
		{
			CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
			if (cultureInfo.TwoLetterISOLanguageName.ToLower().Equals("ar"))
				return textAr;
			return textEN;
		}
	}
}
