using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
	[Name(ResourceType = typeof(Dictionary), Name = Strings.Names.ArchiveItem)]
	[DefaultPermissions(Role = RoleNames.PowerUsers)]
    public class ArchiveItem : ObjectBase
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

		[Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.TitleLabel)]
		[Required(ErrorMessageResourceType = typeof(Dictionary), ErrorMessageResourceName = Strings.ErrorMessages.FieldIsRequired)]
		[StringLength(256)]
		public string Title { get; set; }

	    public virtual ArchiveCategory ArchiveCategory { get; set; }

        [ForeignKey("ArchiveCategory")]
	    [UIHint("ArchiveCategory")]
	    [Display(ResourceType = typeof(Dictionary), Name = Strings.Names.Category)]
	    [Required(ErrorMessageResourceType = typeof(Dictionary), ErrorMessageResourceName = Strings.ErrorMessages.FieldIsRequired)]
	    public int CategoryId { get; set; }

        [Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.DescriptionLabel)]
		[Required(ErrorMessageResourceType = typeof(Dictionary), ErrorMessageResourceName = Strings.ErrorMessages.FieldIsRequired)]
		[StringLength(Int32.MaxValue)]
		[DataType(DataType.Html)]
		[AllowHtml]
		public string DescriptionText { get; set; }

		[FileSourceInfo("Images/archive/upload", Filter = EFilesSourceFilter.Unspecified)]
		[Display(ResourceType = typeof(Dictionary), Name = Strings.Names.UploadFiles)]
		public FileSource FileSource { get; set; }

		[Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.LanguageLabel)]
		public string LanguageName => Language.GetLocalisedLanguageName();

	    public string LanguageCode => Language.GetLanguageCode();

	    [LinkedColumn(LinkedTableName = "ArchiveCategory", LinkedColumnName = "Name", ForeignKey = "CategoryId")]
	    [Display(ResourceType = typeof(Dictionary), Name = Strings.Names.Category)]
	    public string Category { get; set; }
    }
}
