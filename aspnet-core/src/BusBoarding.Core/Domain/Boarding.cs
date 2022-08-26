using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoardingSystem.Domain
{
    public class Boarding : FullAuditedEntity<int>, IMustHaveTenant
    {
        public int TenantId { get; set; }

        public int PersonId { get; set; }

        public int ScheduleId { get; set; }
    }
}
