using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoardingSystem.ScheduleAS.Dto
{
    public class PagedScheduleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
