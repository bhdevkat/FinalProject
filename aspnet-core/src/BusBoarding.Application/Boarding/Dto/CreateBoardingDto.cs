using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BusBoardingSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoardingSystem.BoardingAS.Dto
{
    [AutoMapFrom(typeof(Boarding))]
    public class CreateBoardingDto : EntityDto<int>
    {
        public int PersonId { get; set; }

        public int ScheduleId { get; set; }
    }
}
