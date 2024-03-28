using System;
using System.Collections.Generic;

namespace EF6SQLWebApplication.Models
{
    public partial class Cargo
    {
        public Cargo()
        {
            Shipments = new HashSet<Shipment>();
        }

        public int Id { get; set; }
        public decimal? Volume { get; set; }
        public decimal? Weight { get; set; }
        public int? RouteId { get; set; }
        public int? SenderContactId { get; set; }
        public int? RecipientContactId { get; set; }

        public virtual Contact? RecipientContact { get; set; }
        public virtual Route? Route { get; set; }
        public virtual Contact? SenderContact { get; set; }
        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}
