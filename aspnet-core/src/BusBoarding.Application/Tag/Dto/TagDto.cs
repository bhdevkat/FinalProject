using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.MultiTenancy;
using BusBoardingSystem.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusBoardingSystem.TagAS.Dto
{
    [AutoMap(typeof(Tag))]
    public class TagDto : EntityDto
    {
        public string Uid { get; set; }

        public bool IsAssigned { get; set; }
    }
}
