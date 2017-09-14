using K9.Base.DataAccessLayer.Attributes;
using K9.Base.Globalisation;

namespace K9.Base.DataAccessLayer.Enums
{
	public enum ELanguage
	{
		[EnumDescription(ResourceType = typeof(Dictionary), LanguageCode = Strings.LanguageCodes.En, Name = Strings.Names.English)]
		English,
		[EnumDescription(ResourceType = typeof(Dictionary), LanguageCode = Strings.LanguageCodes.Fr, Name = Strings.Names.French)]
		French
	}
}
