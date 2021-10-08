using System;
using System.Collections.Generic;

#nullable disable

namespace AutoServiceGeniralsMotors.Models
{
    public partial class ImageOfCar
    {
        public int Id { get; set; }
        public int? AutoId { get; set; }
        public byte[] AutoImage { get; set; }

        public virtual ServiceMerge Auto { get; set; }
    }
}
