using Abp.Application.Services;
using BusBoardingSystem.LocationAS.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoardingSystem.LocationAS 
{
    public interface ILocationAppService : IAsyncCrudAppService<LocationDto, int, PagedLocationResultRequestDto, CreateLocationDto, LocationDto>
    {
    }
}
