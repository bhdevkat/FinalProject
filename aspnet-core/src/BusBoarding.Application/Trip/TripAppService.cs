using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using BusBoarding.Authorization;
using BusBoardingSystem.Domain;
using BusBoardingSystem.TripAS.Dto;

namespace BusBoardingSystem.TripAS
{
    [AbpAuthorize(PermissionNames.Pages_Trips)]
    public class TripAppService : AsyncCrudAppService<Trip, TripDto, int, PagedTripResultRequestDto, CreateTripDto, TripDto>, ITripAppService
    {   
        public TripAppService(IRepository<Trip, int> repository) : base(repository)
        {
        }
    }
}
