using K9.DataAccessLayer.Attributes;
using K9.Globalisation;
using K9.SharedLibrary.Models;

namespace K9.DataAccessLayer.Models
{
	[Grammar(ResourceType = typeof(Dictionary), DefiniteArticleName = Strings.Grammar.MasculineDefiniteArticle, IndefiniteArticleName = Strings.Grammar.MasculineIndefiniteArticle)]
	[Name(ResourceType = typeof(Dictionary), Name = Strings.Names.Role)]
	public class Role : ObjectBase, IRole
	{
		

	}
}
