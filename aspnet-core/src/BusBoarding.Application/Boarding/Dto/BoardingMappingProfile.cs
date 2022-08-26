using AutoMapper;
using BusBoardingSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoardingSystem.BoardingAS.Dto
{
    public class BoardingMappingProfile : Profile
    {
        public BoardingMappingProfile()
        {
            CreateMap<BoardingDto, Boarding>();

            CreateMap<CreateBoardingDto, Boarding>();
        }
    }
}
