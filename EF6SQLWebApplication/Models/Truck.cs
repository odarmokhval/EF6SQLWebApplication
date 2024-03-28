using System;
using System.Collections.Generic;

namespace EF6SQLWebApplication.Models
{
    public partial class Truck
    {
        public Truck()
        {
            DriverTrucks = new HashSet<DriverTruck>();
        }

        public int Id { get; set; }
        public string Brand { get; set; } = null!;
        public string RegistrationNumber { get; set; } = null!;
        public DateTime Year { get; set; }
        public double Payload { get; set; }
        public double FuelConsumption { get; set; }
        public double VolumeCargo { get; set; }

        public virtual ICollection<DriverTruck> DriverTrucks { get; set; }
    }
}
