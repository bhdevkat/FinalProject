using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BusBoardingSystem.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoardingSystem.PeopleAS.Dto
{
    [AutoMap(typeof(Person))]
    public class PersonDto : EntityDto<int>
    {
        public int TenantId { get; set; }

        public string Firstname { get; set; }

        public string Surname { get; set; }

        public string DateOfBirth { get; set; }

        public string IdNumber { get; set; }

        [StringLength(100)]
        public string LogoImageType { get; set; }

        public byte[] LogoImage { get; set; }
    }
}
