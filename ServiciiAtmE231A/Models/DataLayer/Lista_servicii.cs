using System;
using System.Collections.Generic;

namespace ServiciiAtmE231A.Models
{
    public partial class Lista_servicii
    {
        public Lista_servicii()
        {
            this.Serviciis = new List<Servicii>();
        }

        public int ID_ls { get; set; }
        public string Nume_serviciu { get; set; }
        public Nullable<int> Nr_componenta { get; set; }
        public string An_studiu { get; set; }
        public virtual ICollection<Servicii> Serviciis { get; set; }
    }
}
