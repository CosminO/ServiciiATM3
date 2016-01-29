using System;
using System.Collections.Generic;

namespace ServiciiAtmE231A.Models
{
    public partial class Comandanti
    {
        public Comandanti()
        {
            this.Companiis = new List<Companii>();
        }

        public int ID_com { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Nr_tel { get; set; }
        public string Email { get; set; }
        public string Adresa { get; set; }
        public string Grad_militar { get; set; }
        public virtual ICollection<Companii> Companiis { get; set; }
    }
}
