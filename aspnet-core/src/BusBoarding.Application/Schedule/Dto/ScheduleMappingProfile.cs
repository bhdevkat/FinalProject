using AutoMapper;
using BusBoardingSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoardingSystem.ScheduleAS.Dto
{
    public class ScheduleMappingProfile : Profile
    {
        public ScheduleMappingProfile()
        {
            CreateMap<ScheduleDto, Schedule>();

            CreateMap<CreateScheduleDto, Schedule>();
        }
    }
}
