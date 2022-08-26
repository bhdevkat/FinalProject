using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoardingSystem.Domain
{
    public class Schedule : FullAuditedEntity<int>, IMustHaveTenant
    {
        public int TenantId { get; set; }

        public int BusId { get; set; }

        //Staff Id of 
        public int AssignedById { get; set; }

        //Staff Id of driver
        public int DriverId { get; set; }

        //Departure location
        public int DepartureId { get; set; }

        //Destination location
        public int DestinationId { get; set; }

        public string ExpectedDepartureTime { get; set; }
    }
}
