using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace ServiciiAtmE231A.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int ID_C { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string GradMilitar { get; set; }
        public int Camera { get; set; }
        public string Functie { get; set; }
    }
}
