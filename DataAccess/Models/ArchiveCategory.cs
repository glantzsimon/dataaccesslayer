using System;
using K9.Base.DataAccessLayer.Attributes;
using K9.Base.Globalisation;
using K9.SharedLibrary.Authentication;

namespace K9.Base.DataAccessLayer.Models
{
    [Grammar(ResourceType = typeof(Dictionary), DefiniteArticleName = Strings.Grammar.FeminineDefiniteArticle, IndefiniteArticleName = Strings.Grammar.FeminineDefiniteArticle)]
	[Name(ResourceType = typeof(Dictionary), Name = Strings.Names.ArchiveCategory, PluralName = Strings.Names.ArchiveCategories)]
    [Description(UseLocalisedString = true)]
	[DefaultPermissions(Role = RoleNames.PowerUsers)]
    public class ArchiveCategory : ObjectBase
	{

	}
}
