using System;
using System.Collections.Generic;

namespace ServiciiAtmE231A.Models
{
    public partial class Apel_seara
    {
        public int ID_as { get; set; }
        public int ID_C { get; set; }
        public Nullable<int> Efectiv_control { get; set; }
        public Nullable<int> Efectiv_prezenti { get; set; }
        public Nullable<int> Efectiv_absenti { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
        public virtual Companii Companii { get; set; }
    }
}
