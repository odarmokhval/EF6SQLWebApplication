using System;
using System.Collections.Generic;

namespace EF6SQLWebApplication.Models
{
    public partial class DriverTruck
    {
        public DriverTruck()
        {
            Shipments = new HashSet<Shipment>();
        }

        public int Id { get; set; }
        public int DriverId { get; set; }
        public int TruckId { get; set; }

        public virtual Driver Driver { get; set; } = null!;
        public virtual Truck Truck { get; set; } = null!;
        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}
