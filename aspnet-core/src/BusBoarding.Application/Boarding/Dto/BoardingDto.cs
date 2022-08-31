using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BusBoardingSystem.Domain;

namespace BusBoardingSystem.BoardingAS.Dto
{
    [AutoMapFrom(typeof(Boarding))]
    public class BoardingDto : EntityDto<int>
    {
        public string StudentStaffNumber { get; set; }

        public string Identity { get; set; }

        public string BoardingType { get; set; }

        public Person Person { get; set; }

        public Schedule Schedule { get; set; }

        public Bus Bus { get; set; }

        public Trip Trip { get; set; }

        public Location Location { get; set; }
    }
}
