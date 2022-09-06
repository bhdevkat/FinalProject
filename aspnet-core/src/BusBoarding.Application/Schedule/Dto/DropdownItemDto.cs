using Abp.Application.Services.Dto;
using BusBoardingSystem.BusAS.Dto;
using BusBoardingSystem.LocationAS.Dto;
using BusBoardingSystem.StaffAS.Dto;
using System;
using System.Collections.Generic;

namespace BusBoardingSystem.ScheduleAS.Dto
{
    public class DropdownItemDto
    {
        public List<StaffDto> Staff { get; set; }

        public List<BusDto> Buses { get; set; }

        public List<LocationDto> Locations { get; set; }

        public DropdownItemDto()
        {
            Staff = new List<StaffDto>();
            Buses = new List<BusDto>();
            Locations = new List<LocationDto>();          
        }
    }
}
