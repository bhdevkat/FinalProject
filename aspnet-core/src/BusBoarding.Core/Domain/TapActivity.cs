using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoarding.Domain
{
    public class TapActivity : FullAuditedEntity<int>
    {
        public string Uid { get; set; }
    }
}
