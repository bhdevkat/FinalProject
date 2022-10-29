using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.MultiTenancy;
using BusBoarding.Domain;
using BusBoardingSystem.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusBoardingSystem.TapActivityAS.Dto
{
    [AutoMap(typeof(TapActivity))]
    public class TapActivityDto : EntityDto
    {
        public string Uid { get; set; }

        public bool IsAssigned { get; set; }
    }
}
