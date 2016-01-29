using System;
using System.Collections.Generic;

namespace ServiciiAtmE231A.Models
{
    public partial class Studenti
    {
        public Studenti()
        {
            this.Invoire_apel = new List<Invoire_apel>();
            this.Serviciis = new List<Servicii>();
        }

        public int ID_S { get; set; }
        public int ID_C { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public string Nr_tel { get; set; }
        public string Grad_militar { get; set; }
        public Nullable<int> Camera { get; set; }
        public string Functie { get; set; }
        public virtual Companii Companii { get; set; }
        public virtual ICollection<Invoire_apel> Invoire_apel { get; set; }
        public virtual ICollection<Servicii> Serviciis { get; set; }
    }
}
