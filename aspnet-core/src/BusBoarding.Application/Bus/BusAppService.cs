using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using BusBoarding.Authorization;
using BusBoardingSystem.BusAS.Dto;
using BusBoardingSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoardingSystem.BusAS
{
    [AbpAuthorize(PermissionNames.Pages_Buses)]
    public class BusAppService : AsyncCrudAppService<Bus, BusDto, int, PagedBusResultRequestDto, CreateBusDto, BusDto>, IBusAppService
    {            
        public BusAppService(IRepository<Bus, int> repository) : base(repository)
        {
        }
    }
}
