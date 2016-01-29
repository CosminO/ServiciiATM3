using System;
using System.Collections.Generic;

namespace ServiciiAtmE231A.Models
{
    public partial class Companii
    {
        public Companii()
        {
            this.Apel_seara = new List<Apel_seara>();
            this.Studentis = new List<Studenti>();
        }

        public int ID_C { get; set; }
        public Nullable<int> ID_com { get; set; }
        public string An_studii { get; set; }
        public virtual ICollection<Apel_seara> Apel_seara { get; set; }
        public virtual Comandanti Comandanti { get; set; }
        public virtual ICollection<Studenti> Studentis { get; set; }
    }
}
