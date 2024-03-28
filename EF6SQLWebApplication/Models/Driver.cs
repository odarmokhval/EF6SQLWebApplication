using System;
using System.Collections.Generic;

namespace EF6SQLWebApplication.Models
{
    public partial class Driver
    {
        public Driver()
        {
            DriverTrucks = new HashSet<DriverTruck>();
        }

        public int Id { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public DateTime Birthdate { get; set; }

        public virtual ICollection<DriverTruck> DriverTrucks { get; set; }
    }
}
