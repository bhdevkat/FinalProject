using Abp.Authorization;
using BusBoarding.Authorization.Roles;
using BusBoarding.Authorization.Users;

namespace BusBoarding.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
