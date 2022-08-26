using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace BusBoarding.Controllers
{
    public abstract class BusBoardingControllerBase: AbpController
    {
        protected BusBoardingControllerBase()
        {
            LocalizationSourceName = BusBoardingConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
