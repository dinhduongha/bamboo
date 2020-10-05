using Abp.Authorization;
using Bamboo.Authorization.Roles;
using Bamboo.Authorization.Users;

namespace Bamboo.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
