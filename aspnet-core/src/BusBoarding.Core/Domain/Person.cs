using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoardingSystem.Domain
{
    public class Person : FullAuditedEntity<int>, IMustHaveTenant
    {
        public int TenantId { get; set; }

        public int TagId { get; set; }

        public string Firstname { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string IdNumber { get; set; }

        [StringLength(100)]
        public string LogoImageType { get; set; }

        public byte[] LogoImage { get; set; }
    }
}
