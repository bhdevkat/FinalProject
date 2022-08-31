using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BusBoardingSystem.Domain;

namespace BusBoardingSystem.BoardingAS.Dto
{
    [AutoMapFrom(typeof(Boarding))]
    public class UpdateBoardingDto : EntityDto<int>
    {
        public int PersonId { get; set; }

        public int ScheduleId { get; set; }
    }
}
