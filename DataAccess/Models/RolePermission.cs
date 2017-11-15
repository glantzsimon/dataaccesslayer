using K9.Base.DataAccessLayer.Attributes;
using K9.Base.Globalisation;
using K9.SharedLibrary.Attributes;
using K9.SharedLibrary.Authentication;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace K9.Base.DataAccessLayer.Models
{
    [AutoGenerateName]
	[DefaultPermissions(Role = RoleNames.Administrators)]
    [Grammar(ResourceType = typeof(Dictionary), DefiniteArticleName = Strings.Grammar.FeminineDefiniteArticle, IndefiniteArticleName = Strings.Grammar.FeminineIndefiniteArticle)]
    [Name(ResourceType = typeof(Dictionary), Name = Strings.Names.RolePermission, PluralName = Strings.Names.RolePermissions)]
    public class RolePermission : ObjectBase
	{
		[ForeignKey("Role")]
		[UIHint("Role")]
		[Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.RoleLabel)]
		public int RoleId { get; set; }

		[ForeignKey("Permission")]
		[UIHint("Permission")]
		[Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.PermissionLabel)]
		public int PermissionId { get; set; }

		public virtual Role Role { get; set; }

		public virtual Permission Permission { get; set; }

		[LinkedColumn(LinkedTableName = "Role", LinkedColumnName = "Name")]
		[Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.RoleLabel)]
		public string RoleName { get; set; }

		[LinkedColumn(LinkedTableName = "Permission", LinkedColumnName = "Name")]
		[Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.PermissionLabel)]
		public string PermissionName { get; set; }
	}
}
