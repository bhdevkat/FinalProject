using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using BusBoarding.Configuration.Dto;

namespace BusBoarding.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : BusBoardingAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
