using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoardingSystem.BusAS.Dto
{
    public class PagedBusResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
