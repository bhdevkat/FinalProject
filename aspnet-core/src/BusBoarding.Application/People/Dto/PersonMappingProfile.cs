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
            CreateMap<PersonDto, Person>();

            CreateMap<Person, PersonDto>();

            CreateMap<CreatePersonDto, Person>();

            CreateMap<CreatePersonDto, Person>();
        }
    }
}
