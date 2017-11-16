using K9.Base.DataAccessLayer.Attributes;
using K9.Base.Globalisation;
using K9.SharedLibrary.Authentication;
using K9.SharedLibrary.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebMatrix.WebData;

namespace K9.Base.DataAccessLayer.Models
{
    [AutoGenerateName]
    [Grammar(ResourceType = typeof(Dictionary), DefiniteArticleName = Strings.Grammar.DefiniteArticleWithApostrophe, IndefiniteArticleName = Strings.Grammar.MasculineIndefiniteArticle, OfPrepositionName = Strings.Grammar.OfPrepositionWithApostrophe)]
    [Name(ResourceType = typeof(Dictionary), Name = Strings.Names.User, DefaultNameExpression = "FullName")]
    [Description(DescriptionField = "FullName")]
    [DefaultPermissions(Role = RoleNames.Administrators)]
    public class User : ObjectBase, IUser
    {

        [StringLength(128)]
        [Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.NameLabel)]
        public string FullName { get; set; }

        [StringLength(56)]
        [Required(ErrorMessageResourceType = typeof(Dictionary), ErrorMessageResourceName = Strings.ErrorMessages.FieldIsRequired)]
        [Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.UserNameLabel)]
        public string Username { get; set; }

        [Required(ErrorMessageResourceType = typeof(Dictionary), ErrorMessageResourceName = Strings.ErrorMessages.FieldIsRequired)]
        [Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.FirstNameLabel)]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Dictionary), ErrorMessageResourceName = Strings.ErrorMessages.FieldIsRequired)]
        [Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.LastNameLabel)]
        public string LastName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Dictionary), ErrorMessageResourceName = Strings.ErrorMessages.FieldIsRequired)]
        [DataType(DataType.EmailAddress, ErrorMessageResourceType = typeof(Dictionary), ErrorMessageResourceName = Strings.ErrorMessages.InvalidEmailAddress)]
        [EmailAddress(ErrorMessageResourceType = typeof(Dictionary), ErrorMessageResourceName = Strings.ErrorMessages.InvalidEmailAddress)]
        [Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.EmailAddressLabel)]
        [StringLength(255)]
        public string EmailAddress { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.PhoneNumberLabel)]
        [StringLength(255)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Dictionary), ErrorMessageResourceName = Strings.ErrorMessages.InvalidDate)]
        [Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.BirthDateLabel)]
        [Required(ErrorMessageResourceType = typeof(Dictionary), ErrorMessageResourceName = Strings.ErrorMessages.FieldIsRequired)]
        public DateTime BirthDate { get; set; }

        [Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.IsUnsubscribedLabel)]
        public bool IsUnsubscribed { get; set; }

        [NotMapped]
        [Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.AccountActivated)]
        public bool AccountActivated { get; set; }

        [Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.AccountActivated)]
        public bool IsActivated => !string.IsNullOrEmpty(Username) && WebSecurity.Initialized && WebSecurity.IsConfirmed(Username);

        public override void Validated()
        {
            FullName = $"{FirstName} {LastName}";
        }
    }
}
