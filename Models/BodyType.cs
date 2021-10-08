using System;
using System.Collections.Generic;

#nullable disable

namespace AutoServiceGeniralsMotors.Models
{
    public partial class BodyType
    {
        public BodyType()
        {
            Automobiles = new HashSet<Automobile>();
        }

        public int Id { get; set; }
        public string BodyName { get; set; }

        public virtual ICollection<Automobile> Automobiles { get; set; }
    }
}
