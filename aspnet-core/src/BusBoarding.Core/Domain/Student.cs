using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoardingSystem.Domain
{
    public class Student : FullAuditedEntity<int>, IMustHaveTenant
    {
        public int TenantId { get; set; }

        public int PersonId { get; set; }

        public int TagId { get; set; }

        public string StudentNumber { get; set; }
    }
}
