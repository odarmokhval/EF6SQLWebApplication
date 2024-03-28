using System;
using System.Collections.Generic;

namespace EF6SQLWebApplication.Models
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            RouteDestinationWaterhouses = new HashSet<Route>();
            RouteOriginWaterhouses = new HashSet<Route>();
        }

        public int Id { get; set; }
        public int? PlaceId { get; set; }
        public string CityName { get; set; } = null!;
        public string StateName { get; set; } = null!;

        public virtual Place? Place { get; set; }
        public virtual ICollection<Route> RouteDestinationWaterhouses { get; set; }
        public virtual ICollection<Route> RouteOriginWaterhouses { get; set; }
    }
}
