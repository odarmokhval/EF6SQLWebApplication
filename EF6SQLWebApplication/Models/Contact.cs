using System;
using System.Collections.Generic;

namespace EF6SQLWebApplication.Models
{
    public partial class Contact
    {
        public Contact()
        {
            CargoRecipientContacts = new HashSet<Cargo>();
            CargoSenderContacts = new HashSet<Cargo>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string CellPhone { get; set; } = null!;

        public virtual ICollection<Cargo> CargoRecipientContacts { get; set; }
        public virtual ICollection<Cargo> CargoSenderContacts { get; set; }
    }
}
