using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BusBoardingSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoardingSystem.LocationAS.Dto
{
    [AutoMapFrom(typeof(Location))]
    public class LocationDto : EntityDto<int>
    {
        public int TenantId { get; set; }
        public string Name { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}
