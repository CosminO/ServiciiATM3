using System;
using System.Collections.Generic;

namespace ServiciiAtmE231A.Models
{
    public partial class Invoire_apel
    {
        public int ID_inv { get; set; }
        public int ID_S { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
        public Nullable<System.TimeSpan> Ora_plecare { get; set; }
        public Nullable<System.TimeSpan> Ora_sosire { get; set; }
        public virtual Studenti Studenti { get; set; }
    }
}
