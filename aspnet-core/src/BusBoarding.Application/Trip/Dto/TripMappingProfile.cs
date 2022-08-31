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
            CreateMap<TripDto, Trip>()
                .ForMember(r => r.DepartureTime, opt => opt.MapFrom(e => DateTime.Parse(e.DepartureTime)))
                .ForMember(r => r.ArrivalTime, opt => opt.MapFrom(e => DateTime.Parse(e.ArrivalTime)));

            CreateMap<CreateTripDto, Trip>()
                .ForMember(r => r.ArrivalTime, opt => opt.MapFrom(e => DateTime.Parse(e.ArrivalTime)))
                .ForMember(r => r.DepartureTime, opt => opt.MapFrom(e => DateTime.Parse(e.DepartureTime)));

            CreateMap<Trip, TripDto>()
                .ForMember(r => r.DepartureTime, opt => opt.MapFrom(e => e.ArrivalTime.ToString("yyyy-MM-dd")))
                .ForMember(r => r.ArrivalTime, opt => opt.MapFrom(e => e.ArrivalTime.ToString("yyyy-MM-dd")));

            CreateMap<Trip, CreateTripDto>()
                .ForMember(r => r.ArrivalTime, opt => opt.MapFrom(e => e.ArrivalTime.ToString("yyyy-MM-dd")))
                .ForMember(r => r.DepartureTime, opt => opt.MapFrom(e => e.DepartureTime.ToString("yyyy-MM-dd")));

        }
    }
}
