using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BusBoardingSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoardingSystem.BusAS.Dto
{
    [AutoMapFrom(typeof(Bus))]
    public class BusDto : EntityDto<int>
    {
        public string RegistrationNumber { get; set; }

        public int InitialMillage { get; set; }
    }
}
