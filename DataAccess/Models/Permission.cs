using K9.Base.DataAccessLayer.Attributes;
using K9.SharedLibrary.Authentication;
using K9.SharedLibrary.Models;

namespace K9.Base.DataAccessLayer.Models
{
    [DefaultPermissions(Role = RoleNames.Administrators)]
    public class Permission : ObjectBase, IPermission
	{
	}
}
