using System.Threading.Tasks;
using BusBoarding.Configuration.Dto;

namespace BusBoarding.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
