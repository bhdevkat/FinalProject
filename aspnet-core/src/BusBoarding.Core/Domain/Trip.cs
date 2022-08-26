using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;

namespace BusBoardingSystem.Domain
{
    public class Trip : FullAuditedEntity<int>, IMustHaveTenant
    {
        public int TenantId { get; set; }

        public int ScheduleId { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }
    }
}
