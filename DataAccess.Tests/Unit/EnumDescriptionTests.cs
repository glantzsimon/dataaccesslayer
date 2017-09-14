using System.Globalization;
using System.Threading;
using K9.Base.DataAccessLayer.Enums;
using K9.Base.DataAccessLayer.Extensions;
using Xunit;

namespace K9.DataAccessLayer.Tests.Unit
{
	public class EnumDescriptionTests
	{

		[Fact]
		public void ELanguage_GetLanguageDescription_ShouldReturnCorrectLanguage()
		{
		    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");

            var english = ELanguage.English.GetLocalisedLanguageName();
			var french = ELanguage.French.GetLocalisedLanguageName();

			Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr");
			var anglais = ELanguage.English.GetLocalisedLanguageName();
			var francais = ELanguage.French.GetLocalisedLanguageName();
			
			Assert.Equal("English", english);
			Assert.Equal("Anglais", anglais);
			Assert.Equal("French", french);
			Assert.Equal("Français", francais);
		}

	    [Fact]
        public void ELanguage_GetLanguageCode_ShouldReturnCorrectLanguageCode()
		{
			var languageCode = ELanguage.English.GetLanguageCode();
			var languageCodeFr = ELanguage.French.GetLanguageCode();
			
			Assert.Equal("en-GB", languageCode);
			Assert.Equal("fr", languageCodeFr);
		}

	}
}
