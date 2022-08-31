using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BusBoardingSystem.Domain;

namespace BusBoardingSystem.ScheduleAS.Dto
{
    [AutoMapFrom(typeof(Schedule))]
    public class CreateScheduleDto : EntityDto<int>
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

        public string ExpectedDepartureTime { get; set; }
    }
}
