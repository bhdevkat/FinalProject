using System.Threading.Tasks;
using Abp.Application.Services;
using BusBoarding.Authorization.Accounts.Dto;

namespace BusBoarding.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
