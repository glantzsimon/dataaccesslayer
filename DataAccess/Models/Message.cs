using K9.Base.DataAccessLayer.Attributes;
using K9.Base.Globalisation;
using K9.SharedLibrary.Attributes;
using K9.SharedLibrary.Authentication;
using K9.SharedLibrary.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace K9.Base.DataAccessLayer.Models
{

    public enum EMessageDirection
	{
		Inbound,
		Outbound
	}

	[AutoGenerateName]
	[Grammar(ResourceType = typeof(Dictionary), DefiniteArticleName = Strings.Grammar.MasculineDefiniteArticle, IndefiniteArticleName = Strings.Grammar.MasculineIndefiniteArticle)]
	[Name(ResourceType = typeof(Dictionary), Name = Strings.Names.Message)]
    [DefaultPermissions(Role = RoleNames.DefaultUsers)]
	public class Message : ObjectBase, IUserData
	{
		
		[ForeignKey("User")]
		[UIHint("User")]
		[Display(ResourceType = typeof(Dictionary), Name = Strings.Names.User)]
		[Required(ErrorMessageResourceType = typeof(Dictionary), ErrorMessageResourceName = Strings.ErrorMessages.FieldIsRequired)]
		public int UserId { get; set; }

		[ForeignKey("SentByUser")]
		[UIHint("User")]
		[Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.SentByUserLabel)]
		[Required(ErrorMessageResourceType = typeof(Dictionary), ErrorMessageResourceName = Strings.ErrorMessages.FieldIsRequired)]
		public int SentByUserId { get; set; }

		[ForeignKey("SentToUser")]
		[UIHint("User")]
		[Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.SentToUserLabel)]
		[Required(ErrorMessageResourceType = typeof(Dictionary), ErrorMessageResourceName = Strings.ErrorMessages.FieldIsRequired)]
		public int SentToUserId { get; set; }

		[Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.SentOnLabel)]
		[Required(ErrorMessageResourceType = typeof(Dictionary), ErrorMessageResourceName = Strings.ErrorMessages.FieldIsRequired)]
		public DateTime SentOn { get; set; }

		[Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.MessageDirectionLabel)]
		[Required(ErrorMessageResourceType = typeof(Dictionary), ErrorMessageResourceName = Strings.ErrorMessages.FieldIsRequired)]
		public EMessageDirection MessageDirection { get; set; }

		[Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.SubjectLabel)]
		[StringLength(256)]
		public string Subject { get; set; }

		[Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.BodyLabel)]
		[StringLength(Int32.MaxValue)]
		public string Body { get; set; }

		public virtual User User { get; set; }

		public virtual User SentByUser { get; set; }

		public virtual User SentToUser { get; set; }

		[LinkedColumn(LinkedTableName = "User", LinkedColumnName = "Name", ForeignKey = "SentToUserId")]
		[Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.SentToUserLabel)]
		public string SentToUserName { get; set; }

		[LinkedColumn(LinkedTableName = "User", LinkedColumnName = "Name", ForeignKey = "SentByUserId")]
		[Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.SentByUserLabel)]
		public string SentByUserName { get; set; }

		[LinkedColumn(LinkedTableName = "User", LinkedColumnName = "Name", ForeignKey = "UserId")]
		[Display(ResourceType = typeof(Dictionary), Name = Strings.Names.User)]
		public string UserName { get; set; }

	}
}
