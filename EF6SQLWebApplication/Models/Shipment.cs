using System;
using System.Collections.Generic;

namespace EF6SQLWebApplication.Models
{
    public partial class Shipment
    {
        public int Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public int? RouteId { get; set; }
        public int? DriverTruckId { get; set; }
        public int? CargoId { get; set; }

        public virtual Cargo? Cargo { get; set; }
        public virtual DriverTruck? DriverTruck { get; set; }
        public virtual Route? Route { get; set; }
    }
}
