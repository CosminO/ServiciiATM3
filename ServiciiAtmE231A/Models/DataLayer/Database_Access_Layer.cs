using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace ServiciiAtmE231A.Models
{
    
    public class Database_Access_Layer
    {
        public static dbConnection con = new dbConnection();
        public static Database_Access_Layer _dal=new Database_Access_Layer();
        public readonly ServiciiATMContext context = new ServiciiATMContext();
        public List<Comandanti> Comandanti()
        {
            List<Comandanti> Comandanti = new List<Comandanti>();
            var comandanti = context.Comandantis;
            foreach (var com in comandanti)
            {
                Comandanti.Add(com);
            }
            return Comandanti;
        }


        public List<Studenti> Studenti()
        {
            List<Studenti> Studenti = new List<Studenti>();
            var studenti = context.Studentis;
            foreach (var com in studenti)
            {
                Studenti.Add(com);
            }
            return Studenti;
        }


        public List<Companii> Companii()
        {
            List<Companii> Companii = new List<Companii>();
            var companii = context.Companiis;
            foreach (var com in companii)
            {
                Companii.Add(com);
            }
            return Companii;
        }



        public List<Invoire_apel> Invoire_apel()
        {
            List<Invoire_apel> Invoire_apel = new List<Invoire_apel>();
            var invoire_apel = context.Invoire_apel;
            foreach (var com in invoire_apel)
            {
                Invoire_apel.Add(com);
            }
            return Invoire_apel;
        }



        public List<Apel_seara> Apel_seara()
        {
            List<Apel_seara> Apel_seara = new List<Apel_seara>();
            var apel_seara = context.Apel_seara;
            foreach (var com in apel_seara)
            {
                Apel_seara.Add(com);
            }
            return Apel_seara;
        }

        public List<Lista_servicii> Lista_servicii()
        {
            List<Lista_servicii> Lista_servicii = new List<Lista_servicii>();
            var lista_servicii = context.Lista_servicii;
            foreach (var com in lista_servicii)
            {
                Lista_servicii.Add(com);
            }
            return Lista_servicii;
        }


        public List<Servicii> Servicii()
        {
            List<Servicii> Servicii = new List<Servicii>();
            var servicii = context.Serviciis;
            foreach (var com in servicii)
            {
                Servicii.Add(com);
            }
            return Servicii;
        }

        //metoda pentru afisarea servicilor din tabela Lista_servicii in functie de an de studiu
        public IEnumerable<object> GetListaServiciiByAn(string an)
        {
            var lista_servicii = from c in _dal.Lista_servicii()
                                 from r in _dal.Studenti()
                                 from u in _dal.Servicii()
                                 from x in _dal.Companii()

                                 where r.ID_S == u.ID_S
                                 where u.ID_ls == c.ID_ls
                                 where x.ID_C == r.ID_C
                                 where c.An_studiu == an

                                 orderby c.An_studiu
                              
            select new { c.Nume_serviciu,c.Nr_componenta,r.Nume, r.Prenume,c.An_studiu };

            return lista_servicii;

        }

        //o metoda pentru afisarea servicilor din tabela Lista_servicii in functie de numar componența
       public IEnumerable<object> GetListaServiciiByNrComponenta(int nrComponenta)
        {
            var lista_nr = from c in _dal.Lista_servicii()
                           from x in _dal.Companii()
                           where c.Nr_componenta==nrComponenta
                           orderby c.Nume_serviciu

                           select new { c.Nume_serviciu, c.Nr_componenta, c.An_studiu };

            return lista_nr;
        }

        public DataTable GetAllServices()
        {
            var query = string.Format("select * from Lista_servicii");
            var sqlParameters = new SqlParameter[1];
            return con.executeSelectQuery(query, sqlParameters);

        }
        public List<LoginComandanti_table>GetUaP()
        {
            List<LoginComandanti_table> LoginCmd = new List<LoginComandanti_table>();
            var lgi = context.LoginComandanti_table;
            foreach (var com in lgi)
            {
               LoginCmd.Add(com);
            }
            return LoginCmd;
        }
        public IEnumerable<object> GetUser(string user,string pass)
        {
            var y = from com in _dal.Comandanti()
                    from tbl in _dal.GetUaP()
                    where (com.ID_com == tbl.Id_C && com.Nume==user && tbl.Parola==pass)
                    select new  { com.Nume,tbl.Parola};
            return y;

        }
        public IEnumerable<object> GetEmail(string email)
        {
            var y = from com in _dal.Comandanti()
                    from tbl in _dal.GetUaP()
                    where (com.ID_com == tbl.Id_C && com.Email==email)
                    select  com.Email ;
            return y;

        }
        public IEnumerable<object>GetPass(string pas)
        {
            var y = from com in _dal.Comandanti()
                    from tbl in _dal.GetUaP()
                    where (com.ID_com == tbl.Id_C && tbl.Parola==pas)
                    select  tbl.Parola ;
            return y;
        }

        public bool InsertInvoireSeara(int id_s, DateTime data, TimeSpan ora_plecare, TimeSpan ora_sosire, int code)
        {
            if (code == 0)
                return false;
            using (var context = new ServiciiATMContext())
            {
                var invoire = new Invoire_apel
                {
                    ID_S = id_s,
                    Ora_plecare = ora_plecare,
                    Ora_sosire = ora_sosire,
                    Data = data,

                };
                context.Invoire_apel.Add(invoire);
                context.Entry(invoire).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();

                return true;
            }

        }
        public bool InsertListaServicii(string nume, int nr_comp, string an, int code)
        {
            if (code == 0)
                return false;
            using (var context = new ServiciiATMContext())
            {
                var lista = new Lista_servicii
                {
                    Nume_serviciu = nume,
                    Nr_componenta = nr_comp,
                    An_studiu = an,
                };
                context.Lista_servicii.Add(lista);
                context.Entry(lista).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();

                return true;
            }

        }
        public bool InsertStudenti(int id_c, string nume, string prenume, string mail, string tel, string grad, int camera, string functie, int code)
        {
            if (code == 0)
                return false;
            using (var context = new ServiciiATMContext())
            {
                var student = new Studenti
                {
                    ID_C = id_c,
                    Nume = nume,
                    Prenume = prenume,
                    Email = mail,
                    Nr_tel = tel,
                    Grad_militar = grad,
                    Camera = camera,
                    Functie = functie,

                };
                context.Studentis.Add(student);
                context.Entry(student).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();

                return true;
            }

        }

        public bool InsertServicii(int id_l, int id_s, DateTime data, bool check, int code)
        {
            if (code == 0)
                return false;
            using (var context = new ServiciiATMContext())
            {
                var serv = new Servicii
                {
                    ID_ls = id_l,
                    ID_S = id_s,
                    Data = data,
                    Check = check
                };
                context.Serviciis.Add(serv);
                context.Entry(serv).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();

                return true;
            }
        }




    }
}