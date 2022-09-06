using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BusBoardingSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoardingSystem.ScheduleAS.Dto
{
    [AutoMapFrom(typeof(Schedule))]
    public class ScheduleDto : EntityDto<int>
    {
        public int TenantId { get; set; }

        public int BusId { get; set; }

        //Staff Id of 
        public int AssignedById { get; set; }

        //Staff Id of driver
        public int DriverId { get; set; }

        //Departure location
        public int DepartureId { get; set; }

        //Destination location
        public int DestinationId { get; set; }

        public string BusReg { get; set; }

        //Staff Id of 
        public string AssignedByName { get; set; }

        //Staff Id of driver
        public string DriverName { get; set; }

        //Departure location
        public string DepartureName { get; set; }

        //Destination location
        public string DestinationName { get; set; }

        public string ExpectedDepartureTime { get; set; }
    }
}
