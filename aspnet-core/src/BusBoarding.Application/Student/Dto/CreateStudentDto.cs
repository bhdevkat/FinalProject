using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BusBoardingSystem.Domain;
using BusBoardingSystem.PeopleAS.Dto;
using System;

namespace BusBoardingSystem.StudentAS.Dto
{
    [AutoMap(typeof(Student))]
    public class CreateStudentDto : EntityDto<int>
    {
        public int Id { get; set; }

        public int TenantId { get; set; }

        public int PersonId { get; set; }

        public string StudentNumber { get; set; }

        public CreatePersonDto Person { get; set; }
    }
}
