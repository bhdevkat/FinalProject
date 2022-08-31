using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using BusBoarding.Authorization;
using BusBoardingSystem.BusAS.Dto;
using BusBoardingSystem.Domain;
using BusBoardingSystem.ScheduleAS.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoardingSystem.ScheduleAS
{
    [AbpAuthorize(PermissionNames.Pages_Schedules)]
    public class ScheduleAppService : AsyncCrudAppService<Schedule, ScheduleDto, int, PagedScheduleResultRequestDto, CreateScheduleDto, ScheduleDto>, IScheduleAppService
    {            
        public ScheduleAppService(IRepository<Schedule, int> repository) : base(repository)
        {
        }
    }
}
