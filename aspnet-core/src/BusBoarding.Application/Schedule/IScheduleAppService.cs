using Abp.Application.Services;
using BusBoardingSystem.ScheduleAS.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoardingSystem.ScheduleAS
{
    public interface IScheduleAppService : IAsyncCrudAppService<ScheduleDto, int, PagedScheduleResultRequestDto, CreateScheduleDto, ScheduleDto>
    {
    }
}
