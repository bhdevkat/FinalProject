using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BusBoardingSystem.Domain;

namespace BusBoardingSystem.BoardingAS.Dto
{
    [AutoMapFrom(typeof(Boarding))]
    public class PersonOnBoardDto : EntityDto<int>
    {
        public string StudentStaffNumber { get; set; }

        public string Identity { get; set; }

        public string BoardingType { get; set; }

        public Person Person { get; set; }
    }
}
