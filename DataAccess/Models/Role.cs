﻿using K9.Base.DataAccessLayer.Attributes;
using K9.Base.Globalisation;
using K9.SharedLibrary.Models;

namespace K9.Base.DataAccessLayer.Models
{
	[Grammar(ResourceType = typeof(Dictionary), DefiniteArticleName = Strings.Grammar.MasculineDefiniteArticle, IndefiniteArticleName = Strings.Grammar.MasculineIndefiniteArticle)]
	[Name(ResourceType = typeof(Dictionary), Name = Strings.Names.Role)]
    [Description(UseLocalisedString = true)]
	public class Role : ObjectBase, IRole
	{
	}
}
