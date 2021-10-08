using System;
using System.Collections.Generic;

#nullable disable

namespace AutoServiceGeniralsMotors.Models
{
    public partial class Automobile
    {
        public Automobile()
        {
            ServiceMerges = new HashSet<ServiceMerge>();
        }

        public int Id { get; set; }
        public int? Mark { get; set; }
        public int? Body { get; set; }
        public string IdentityUser { get; set; }
        public string NumberAuto { get; set; }

        public virtual BodyType BodyNavigation { get; set; }
        public virtual AspNetUser IdentityUserNavigation { get; set; }
        public virtual AutoMark MarkNavigation { get; set; }
        public virtual ICollection<ServiceMerge> ServiceMerges { get; set; }
    }
}
