using AutoMapper;
using BusBoardingSystem.Domain;

namespace BusBoardingSystem.TagAS.Dto
{
    public class TagMappingProfile : Profile
    {
        public TagMappingProfile()
        {
            CreateMap<TagDto, Tag>();

            CreateMap<Tag, TagDto>();
        }
    }
}
