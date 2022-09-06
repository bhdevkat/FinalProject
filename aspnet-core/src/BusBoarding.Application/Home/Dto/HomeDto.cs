using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.MultiTenancy;
using BusBoardingSystem.Domain;
using BusBoardingSystem.ScheduleAS.Dto;
using BusBoardingSystem.TripAS.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusBoardingSystem.HomeAS.Dto
{   
    public class HomeDto : EntityDto
    {
        public int UserCount { get; set; }

        public int StaffCount { get; set; }

        public int StudentCount { get; set; }

        public int RoleCount { get; set; }

        public int BusCount { get; set; }

        public int DestinationCount { get; set; }

        public int ScheduleCount { get; set; }

        public int TripCount { get; set; }

        public List<ScheduleDto> Schedules { get; set; }

        public List<TripDto> Trips { get; set; }
    }
}
