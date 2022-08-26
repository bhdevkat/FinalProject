using AutoMapper;
using BusBoardingSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoardingSystem.TripAS.Dto
{
    public class TripMappingProfile : Profile
    {
        public TripMappingProfile()
        {
            CreateMap<TripDto, Trip>();

            CreateMap<CreateTripDto, Trip>();
        }
    }
}
