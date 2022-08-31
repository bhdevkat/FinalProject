using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BusBoardingSystem.Domain;

namespace BusBoardingSystem.LocationAS.Dto
{
    [AutoMapFrom(typeof(Location))]
    public class CreateLocationDto : EntityDto<int>
    {
        public int TenantId { get; set; }
        public string Name { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}
