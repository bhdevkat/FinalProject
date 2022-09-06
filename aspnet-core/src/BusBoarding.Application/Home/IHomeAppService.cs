using Abp.Application.Services;
using BusBoardingSystem.HomeAS.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBoardingSystem.HomeAS
{
    public interface IHomeAppService : IApplicationService
    {
        Task<HomeDto> GetStatisticalData();
    }
}
