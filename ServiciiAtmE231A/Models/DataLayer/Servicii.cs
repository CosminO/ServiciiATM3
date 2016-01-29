using System;
using System.Collections.Generic;

namespace ServiciiAtmE231A.Models
{
    public partial class Servicii
    {
        public int ID_serv { get; set; }
        public int ID_ls { get; set; }
        public int ID_S { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
        public Nullable<bool> Check { get; set; }
        public virtual Lista_servicii Lista_servicii { get; set; }
        public virtual Studenti Studenti { get; set; }
    }
}
