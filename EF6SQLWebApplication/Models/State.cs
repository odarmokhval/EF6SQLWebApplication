using System;
using System.Collections.Generic;

namespace EF6SQLWebApplication.Models
{
    public partial class State
    {
        public State()
        {
            Places = new HashSet<Place>();
        }

        public int Id { get; set; }
        public string StateName { get; set; } = null!;

        public virtual ICollection<Place> Places { get; set; }
    }
}
