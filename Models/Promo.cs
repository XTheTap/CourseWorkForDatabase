using System;
using System.Collections.Generic;

#nullable disable

namespace AutoServiceGeniralsMotors.Models
{
    public partial class Promo
    {
        public int Id { get; set; }
        public byte[] PromoNumber { get; set; }
        public double ProcentDiscount { get; set; }
    }
}
