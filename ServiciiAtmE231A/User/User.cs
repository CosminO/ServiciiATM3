using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiciiAtmE231A.Models;
namespace ServiciiAtmE231A.Users
{
    public class User
    {
        private Business_Layer A;
        User()
        { }
        User(string _Email)
        {
            A = new Business_Layer();
            email = _Email;
            nume = A.GetNumePrenumeforEmai(email, 0);
            prenume = A.GetNumePrenumeforEmai(email, 1);
            prioritate = A.GetPrioAfterName(nume, prenume, email);
        }
        public string nume { get; set; }
        public string prenume { get; set; }
        public string email { get; set; }
        public int prioritate { get; set; }
    }
}