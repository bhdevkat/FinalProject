using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using BusBoardingSystem.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoardingSystem.TripAS.Dto
{
    [AutoMapFrom(typeof(Trip))]
    public class CreateTripDto : EntityDto<int>,ICustomValidate
    {
        //Internal Date Time variable
        private DateTime _dateResult;

        public int TenantId { get; set; }

        public int ScheduleId { get; set; }

        public string DepartureTime { get; set; }

        public string ArrivalTime { get; set; }

        public void AddValidationErrors(CustomValidationContext context)
        {
            if (!DateTime.TryParse(DepartureTime,
                CultureInfo.CreateSpecificCulture("en-US"),
                DateTimeStyles.None, out _dateResult))
                context.Results.Add(new ValidationResult("Value given for departure not a valid date!"));

            if (!DateTime.TryParse(ArrivalTime,
                CultureInfo.CreateSpecificCulture("en-US"),
                DateTimeStyles.None, out _dateResult))
                context.Results.Add(new ValidationResult("Value given for arrival time not a valid date!"));
        }
    }
}
