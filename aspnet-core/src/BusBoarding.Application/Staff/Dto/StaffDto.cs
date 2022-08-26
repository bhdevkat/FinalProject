using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BusBoardingSystem.Domain;
using BusBoardingSystem.PeopleAS.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoardingSystem.StaffAS.Dto
{
    [AutoMapFrom(typeof(Staff))]
    public class StaffDto : EntityDto<int>
    {
        public int TenantId { get; set; }

        public int PersonId { get; set; }

        public string StaffNumber { get; set; }

        public virtual Person Person { get; set; }
    }
}
