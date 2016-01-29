using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ServiciiAtmE231A.Models
{
    public class Business_Layer
    {
        public Database_Access_Layer _dal;
        public Business_Layer()
        {

            _dal = new Database_Access_Layer();
        }
        public IEnumerable<Apel_seara> showApel_Seara()
        {
            
          
             var y = from a in _dal.Apel_seara()
                        select a ;
            
            return y;
        }
        public IEnumerable<Servicii>showServicii()
        {


            var y = from a in _dal.Servicii()
                    select a;

            return y;
        }
        public IEnumerable<Comandanti> showComandanti()
        {
            var y = from a in _dal.Comandanti()
                    select a;
            return y;
        }

        public IEnumerable<Object> Print_Servicii_Data(DateTime d)
        {
            var v =
                from r in _dal.Studenti()
                from u in _dal.Servicii()
                from s in _dal.Lista_servicii()
                from x in _dal.Companii()

                where r.ID_S == u.ID_S
                where u.ID_ls == s.ID_ls
                where x.ID_C == r.ID_C
                where u.Data == d
                orderby u.Data

                select new { r.Nume, r.Prenume, s.Nume_serviciu, u.Data, x.ID_com };
            

                return v;


        }
       


          
    }
}