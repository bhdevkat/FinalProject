using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BusBoardingSystem.Domain;

namespace BusBoardingSystem.BusAS.Dto
{
    [AutoMapFrom(typeof(Bus))]
    public class CreateBusDto : EntityDto<int>
    {

    }
}
