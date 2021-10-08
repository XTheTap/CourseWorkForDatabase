using System;
using System.Collections.Generic;

#nullable disable

namespace AutoServiceGeniralsMotors.Models
{
    public partial class AutoMark
    {
        public AutoMark()
        {
            Automobiles = new HashSet<Automobile>();
        }

        public int Id { get; set; }
        public string MarkName { get; set; }

        public virtual ICollection<Automobile> Automobiles { get; set; }
    }
}
