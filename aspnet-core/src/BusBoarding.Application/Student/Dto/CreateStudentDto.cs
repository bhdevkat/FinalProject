using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using BusBoardingSystem.Domain;
using BusBoardingSystem.PeopleAS.Dto;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace BusBoardingSystem.StudentAS.Dto
{
    [AutoMap(typeof(Student))]
    public class CreateStudentDto : EntityDto<int>,ICustomValidate
    {
        //Internal Date Time variable
        private DateTime _dateResult;

        public int TenantId { get; set; }

        public int TagId { get; set; }

        public int PersonId { get; set; }

        public string StudentNumber { get; set; }

        public CreatePersonDto Person { get; set; }

        public CreateStudentDto()
        {
            Person = new CreatePersonDto();
        }

        public void AddValidationErrors(CustomValidationContext context)
        {
            if(!DateTime.TryParse(Person.DateOfBirth, 
                CultureInfo.CreateSpecificCulture("en-US"), 
                DateTimeStyles.None, out _dateResult))
                    context.Results.Add(new ValidationResult("Value given for date of birth not a valid date!"));
        }
    }
}
