using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using BusBoardingSystem.Domain;
using BusBoardingSystem.PeopleAS.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoardingSystem.StaffAS.Dto
{
    [AutoMapFrom(typeof(Staff))]
    public class StaffDto : EntityDto<int>,ICustomValidate
    {
        //Internal Date Time variable
        private DateTime _dateResult;

        public int TenantId { get; set; }

        public int PersonId { get; set; }

        public string StaffNumber { get; set; }

        public virtual PersonDto Person { get; set; }

        public StaffDto()
        {
            Person = new PersonDto();
        }
        public void AddValidationErrors(CustomValidationContext context)
        {
            if (!DateTime.TryParse(Person.DateOfBirth,
                CultureInfo.CreateSpecificCulture("en-US"),
                DateTimeStyles.None, out _dateResult))
                context.Results.Add(new ValidationResult("Value given for date of birth not a valid date!"));
        }
    }
}
