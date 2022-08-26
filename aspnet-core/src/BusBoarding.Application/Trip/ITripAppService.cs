using Abp.Application.Services;
using BusBoardingSystem.TripAS.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoardingSystem.TripAS
{
    public interface ITripAppService : IAsyncCrudAppService<TripDto, int, PagedTripResultRequestDto, CreateTripDto, TripDto>
    {
    }
}
