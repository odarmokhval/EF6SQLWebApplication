using System;
using System.Collections.Generic;

namespace EF6SQLWebApplication.Models
{
    public partial class Place
    {
        public Place()
        {
            Warehouses = new HashSet<Warehouse>();
        }

        public int Id { get; set; }
        public string PlaceName { get; set; } = null!;
        public int StateId { get; set; }
        public int PlaceCode { get; set; }

        public virtual State State { get; set; } = null!;
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
