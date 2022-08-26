using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace BusBoarding.Authorization
{
    public class BusBoardingAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_Boardings, L("Boardings"));
            context.CreatePermission(PermissionNames.Pages_Buses, L("Buses"));
            context.CreatePermission(PermissionNames.Pages_Locations, L("Locations"));
            context.CreatePermission(PermissionNames.Pages_People, L("People"));
            context.CreatePermission(PermissionNames.Pages_Schedules, L("Schedules"));
            context.CreatePermission(PermissionNames.Pages_Staff, L("Staff"));
            context.CreatePermission(PermissionNames.Pages_Students, L("Students"));
            context.CreatePermission(PermissionNames.Pages_Trips, L("Trips"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, BusBoardingConsts.LocalizationSourceName);
        }
    }
}
