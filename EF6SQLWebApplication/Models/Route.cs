using System;
using System.Collections.Generic;

namespace EF6SQLWebApplication.Models
{
    public partial class Route
    {
        public Route()
        {
            Cargos = new HashSet<Cargo>();
            Shipments = new HashSet<Shipment>();
        }

        public int Id { get; set; }
        public int? OriginalStateId { get; set; }
        public int? OriginWaterhouseId { get; set; }
        public double Distance { get; set; }
        public int? DestinationStateId { get; set; }
        public int? DestinationWaterhouseId { get; set; }

        public virtual Warehouse? DestinationWaterhouse { get; set; }
        public virtual Warehouse? OriginWaterhouse { get; set; }
        public virtual ICollection<Cargo> Cargos { get; set; }
        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}
