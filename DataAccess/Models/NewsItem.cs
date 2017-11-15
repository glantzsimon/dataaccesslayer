using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using K9.Base.DataAccessLayer.Attributes;
using K9.Base.DataAccessLayer.Enums;
using K9.Base.DataAccessLayer.Extensions;
using K9.Base.Globalisation;
using K9.SharedLibrary.Attributes;
using K9.SharedLibrary.Authentication;
using K9.SharedLibrary.Enums;
using K9.SharedLibrary.Models;

namespace K9.Base.DataAccessLayer.Models
{

	[AutoGenerateName]
	[Grammar(ResourceType = typeof(Dictionary), DefiniteArticleName = Strings.Grammar.FeminineDefiniteArticle, IndefiniteArticleName = Strings.Grammar.FeminineIndefiniteArticle)]
	[Name(ResourceType = typeof(Dictionary), Name = Strings.Names.NewsItem)]
	[DefaultPermissions(Role = RoleNames.DefaultUsers)]
    public class NewsItem : ObjectBase
	{
		
		[Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.PublishedOnLabel)]
		[Required(ErrorMessageResourceType = typeof(Dictionary), ErrorMessageResourceName = Strings.ErrorMessages.FieldIsRequired)]
		public DateTime PublishedOn { get; set; }

		[Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.PublishedByLabel)]
		public string PublishedBy { get; set; }

		[UIHint("Language")]
		[Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.LanguageLabel)]
		[Required(ErrorMessageResourceType = typeof(Dictionary), ErrorMessageResourceName = Strings.ErrorMessages.FieldIsRequired)]
		public ELanguage Language { get; set; }

		[Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.SubjectLabel)]
		[Required(ErrorMessageResourceType = typeof(Dictionary), ErrorMessageResourceName = Strings.ErrorMessages.FieldIsRequired)]
		[StringLength(256)]
		public string Subject { get; set; }
		
		[Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.BodyLabel)]
		[Required(ErrorMessageResourceType = typeof(Dictionary), ErrorMessageResourceName = Strings.ErrorMessages.FieldIsRequired)]
		[StringLength(Int32.MaxValue)]
		[DataType(DataType.Html)]
		[AllowHtml]
		public string Body { get; set; }

		[FileSourceInfo("Images/news/upload", Filter = EFilesSourceFilter.Images)]
		[Display(ResourceType = typeof(Dictionary), Name = Strings.Names.UploadImages)]
		public FileSource ImageFileSource { get; set; }

		[Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.LanguageLabel)]
		public string LanguageName => Language.GetLocalisedLanguageName();

	    public string LanguageCode => Language.GetLanguageCode();
	}
}
