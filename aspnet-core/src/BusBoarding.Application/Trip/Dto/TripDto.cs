using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BusBoardingSystem.Domain;

namespace BusBoardingSystem.TripAS.Dto
{
    [AutoMapFrom(typeof(Trip))]
    public class TripDto : EntityDto<int>
    {
        public int TenantId { get; set; }

        public int ScheduleId { get; set; }

        public string DepartureTime { get; set; }

        public string ArrivalTime { get; set; }
    }
}
