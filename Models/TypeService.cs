using System;
using System.Collections.Generic;

#nullable disable

namespace AutoServiceGeniralsMotors.Models
{
    public partial class TypeService
    {
        public TypeService()
        {
            ServiceMerges = new HashSet<ServiceMerge>();
        }

        public int Id { get; set; }
        public string ServiceName { get; set; }
        public double ServiceCost { get; set; }
        public double RiskCount { get; set; }

        public virtual ICollection<ServiceMerge> ServiceMerges { get; set; }
    }
}
