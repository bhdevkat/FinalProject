using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoardingSystem.TripAS.Dto
{
    public class PagedTripResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
