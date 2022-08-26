using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BusBoardingSystem.Domain;
using BusBoardingSystem.PeopleAS.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoardingSystem.StudentAS.Dto
{
    [AutoMap(typeof(Student))]
    public class StudentDto : EntityDto<int>
    {       
        public int Id { get; set; }

        public int TenantId { get; set; }

        public int PersonId { get; set; }

        public string StudentNumber { get; set; }

        public PersonDto Person { get; set; }
    }
}
