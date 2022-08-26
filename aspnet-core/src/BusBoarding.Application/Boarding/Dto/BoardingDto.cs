using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BusBoardingSystem.Domain;

namespace BusBoardingSystem.BoardingAS.Dto
{
    [AutoMapFrom(typeof(Boarding))]
    public class BoardingDto : EntityDto<int>
    {

    }
}
