using AutoMapper;
using BusBoardingSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoardingSystem.PeopleAS.Dto
{
    public class PersonMappingProfile : Profile
    {
        public PersonMappingProfile()
        {
            CreateMap<PersonDto, Person>()
                 .ForMember(r => r.DateOfBirth, opt => opt.MapFrom(e => DateTime.Parse(e.DateOfBirth)));

            CreateMap<Person, PersonDto>()
                .ForMember(r => r.DateOfBirth, opt => opt.MapFrom(e => e.DateOfBirth.ToString("yyyy-MM-dd")));

            CreateMap<CreatePersonDto, Person>()
                .ForMember(r => r.DateOfBirth, opt => opt.MapFrom(e => DateTime.Parse(e.DateOfBirth)));

            CreateMap<Person, CreatePersonDto> ()
                .ForMember(r => r.DateOfBirth, opt => opt.MapFrom(e => e.DateOfBirth.ToString("yyyy-MM-dd")));
        }
    }
}
