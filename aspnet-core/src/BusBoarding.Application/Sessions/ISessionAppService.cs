using System.Threading.Tasks;
using Abp.Application.Services;
using BusBoarding.Sessions.Dto;

namespace BusBoarding.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
