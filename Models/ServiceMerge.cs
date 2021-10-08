using System;
using System.Collections.Generic;

#nullable disable

namespace AutoServiceGeniralsMotors.Models
{
    public partial class ServiceMerge
    {
        public ServiceMerge()
        {
            ImageOfCars = new HashSet<ImageOfCar>();
        }

        public int Id { get; set; }
        public int? Automobile { get; set; }
        public int? TypeService { get; set; }
        public bool? ServiceStatus { get; set; }

        public virtual Automobile AutomobileNavigation { get; set; }
        public virtual TypeService TypeServiceNavigation { get; set; }
        public virtual ICollection<ImageOfCar> ImageOfCars { get; set; }
    }
}
