using AutoMapper;
using BusBoardingSystem.Domain;

namespace BusBoardingSystem.TapActivityAS.Dto
{
    public class TapActivityMappingProfile : Profile
    {
        public TapActivityMappingProfile()
        {
            CreateMap<TapActivityDto, Tag>();

            CreateMap<Tag, TapActivityDto>();
        }
    }
}
