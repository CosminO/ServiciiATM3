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
        public static Database_Access_Layer _dal = new Database_Access_Layer();
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

                                 select new { c.Nume_serviciu, c.Nr_componenta, r.Nume, r.Prenume, c.An_studiu };

            return lista_servicii;

        }

        //print servicii dintr-o data
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

        //meteoda sa afiseze serviciile dintr-o companie
        public IEnumerable<Object> GetServiciiComp(int Companie)
        {
            var lista = from stud in _dal.Studenti()
                        from lst in _dal.Lista_servicii()
                        from serv in _dal.Servicii()
                        where stud.ID_C == Companie
                        where lst.ID_ls == serv.ID_ls
                        where serv.ID_S == stud.ID_S
                        select new { stud.Nume, stud.Prenume, serv.Data, lst.Nume_serviciu, stud.ID_C };
            return lista;

        }

        //afisare servicii a unui student
        public IEnumerable<Object> GetServStudent(string Nume, string Prenume)
        {
            var lista = from stud in _dal.Studenti()
                        from lst in _dal.Lista_servicii()
                        from serv in _dal.Servicii()
                        where stud.Nume == Nume
                        where stud.Prenume == Prenume
                        where lst.ID_ls == serv.ID_ls
                        where serv.ID_S == stud.ID_S
                        select new { stud.Nume, stud.Prenume, lst.Nume_serviciu, serv.Data, serv.Check };
            return lista;
        }

        //o metoda pentru afisarea servicilor din tabela Lista_servicii in functie de numar componența
        public IEnumerable<object> GetListaServiciiByNrComponenta(int nrComponenta)
        {
            var lista_nr = from c in _dal.Lista_servicii()
                           from x in _dal.Companii()
                           where c.Nr_componenta == nrComponenta
                           orderby c.Nume_serviciu

                           select new { c.Nume_serviciu, c.Nr_componenta, c.An_studiu };

            return lista_nr;
        }

        public List<LoginComandanti_table> GetUaP()
        {
            List<LoginComandanti_table> LoginCmd = new List<LoginComandanti_table>();
            var lgi = context.LoginComandanti_table;
            foreach (var com in lgi)
            {
                LoginCmd.Add(com);
            }
            return LoginCmd;
        }

        public IEnumerable<object> GetUser(string user, string pass)
        {
            var y = from com in _dal.Comandanti()
                    from tbl in _dal.GetUaP()
                    where (com.ID_com == tbl.Id_C && com.Nume == user && tbl.Parola == pass)
                    select new { com.Nume, tbl.Parola };
            return y;

        }

        public IEnumerable<object> GetEmail(string email)
        {
            var y = from com in _dal.Comandanti()
                    from tbl in _dal.GetUaP()
                    where (com.ID_com == tbl.Id_C && com.Email == email)
                    select com.Email;
            return y;

        }

        public IEnumerable<object> GetPass(string pas)
        {
            var y = from com in _dal.Comandanti()
                    from tbl in _dal.GetUaP()
                    where (com.ID_com == tbl.Id_C && tbl.Parola == pas)
                    select tbl.Parola;
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

        public bool InsertApelSeara(int id_c, int efc, int efp, int efa, DateTime data, int code)
        {
            if (code == 0)
                return false;
            using (var context = new ServiciiATMContext())
            {
                var apel = new Apel_seara
                {
                    ID_C = id_c,
                    Efectiv_control = efc,
                    Efectiv_prezenti = efp,
                    Efectiv_absenti = efa,
                    Data = data,

                };
                context.Apel_seara.Add(apel);
                context.Entry(apel).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();

                return true;
            }

        }

        public bool InsertComandanti(string name, string lastname, string tel, string mail, string adr, string gm, int code)
        {
            if (code == 0)
                return false;
            using (var context = new ServiciiATMContext())
            {
                var com = new Comandanti
                {
                    Nume = name,
                    Prenume = lastname,
                    Nr_tel = tel,
                    Email = mail,
                    Adresa = adr,
                    Grad_militar = gm

                };
                context.Comandantis.Add(com);
                context.Entry(com).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();

                return true;
            }

        }

        public bool InsertCompanii(int id_com, string an_studiu, int code)
        {
            if (code == 0)
                return false;
            using (var context = new ServiciiATMContext())
            {
                var com = new Companii
                {
                    ID_com = id_com,
                    An_studii = an_studiu,
                };
                context.Companiis.Add(com);
                context.Entry(com).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();

                return true;
            }

        }

        public void DeleteApelSeara(DateTime data)
        {
            using (var context = new ServiciiATMContext())
            {
                var std = context.Apel_seara.Where(n => n.Data == data).ToList<Apel_seara>().FirstOrDefault();
                if (std != null)
                {
                    context.Apel_seara.Attach(std);
                    context.Apel_seara.Remove(std);
                    context.Entry(std).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();
                }

            }
        }

        public void DeleteListaServicii(string name)
        {
            using (var context = new ServiciiATMContext())
            {
                var std = context.Lista_servicii.Where(n => n.Nume_serviciu == name).ToList<Lista_servicii>().FirstOrDefault();
                if (std != null)
                {
                    context.Lista_servicii.Attach(std);
                    context.Lista_servicii.Remove(std);
                    context.Entry(std).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();
                }

            }
        }


        public void DeleteCompanii(string an)
        {
            using (var context = new ServiciiATMContext())
            {
                var std = context.Companiis.Where(n => n.An_studii == an).ToList<Companii>().FirstOrDefault();
                if (std != null)
                {
                    context.Companiis.Attach(std);
                    context.Companiis.Remove(std);
                    context.Entry(std).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteStudent(string name, string lastname)
        {
            using (var context = new ServiciiATMContext())
            {
                var std = context.Studentis.Where(n => n.Nume == name && n.Prenume == lastname).ToList<Studenti>().FirstOrDefault();
                if (std != null)
                {
                    context.Studentis.Attach(std);
                    context.Studentis.Remove(std);
                    context.Entry(std).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();
                }

            }
        }

        //Merge
        public void DeleteServicii(DateTime time)
        {
            using (var context = new ServiciiATMContext())
            {
                var serv = context.Serviciis.Where(n => n.Data == time && n.Data < DateTime.Now).ToList<Servicii>().FirstOrDefault();
                if (serv != null)
                {
                    context.Serviciis.Attach(serv);
                    context.Serviciis.Remove(serv);
                    context.Entry(serv).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();
                }

            }
        }


        public void DeleteComandanti(string nume, string prenume)
        {
            using (var context = new ServiciiATMContext())
            {
                var cdt = context.Comandantis.Where(n => n.Nume == nume && n.Prenume == prenume).ToList<Comandanti>().FirstOrDefault();
                if (cdt != null)
                {
                    context.Comandantis.Attach(cdt);
                    context.Comandantis.Remove(cdt);
                    context.Entry(cdt).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChangesAsync();
                }

            }
        }

        public void DeleteInvApel(DateTime dt)
        {
            using (var context = new ServiciiATMContext())
            {
                var std = context.Apel_seara.Where(n => n.Data == dt).ToList<Apel_seara>().FirstOrDefault();
                if (std != null)
                {
                    context.Apel_seara.Attach(std);
                    context.Apel_seara.Remove(std);
                    context.Entry(std).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();
                }

            }
        }

        public bool UpdateInvoireApel(int id_s, DateTime data, TimeSpan ora_plecare, TimeSpan ora_sosire, int code)
        {
            if (code == 0)
                return false;

            using (var context = new ServiciiATMContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var serv = new Invoire_apel
                        {
                            ID_S = id_s,
                            Data = data,
                            Ora_plecare = ora_plecare,
                            Ora_sosire = ora_sosire

                        };
                        context.Invoire_apel.Add(serv);
                        context.Entry(serv).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool UpdateListaServicii(string nume, int nr, string an, int code)
        {
            if (code == 0)
                return false;

            using (var context = new ServiciiATMContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var serv = new Lista_servicii
                        {
                            Nume_serviciu = nume,
                            Nr_componenta = nr,
                            An_studiu = an,

                        };
                        context.Lista_servicii.Add(serv);
                        context.Entry(serv).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool UpdateStudenti(int id_c, string name, string prenume, string email, string tel, string grad, int camera, string functie, int code)
        {
            if (code == 0)
                return false;

            using (var context = new ServiciiATMContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var serv = new Studenti
                        {
                            ID_C = id_c,
                            Nume = name,
                            Prenume = prenume,
                            Email = email,
                            Nr_tel = tel,
                            Grad_militar = grad,
                            Camera = camera,
                            Functie = functie

                        };
                        context.Studentis.Add(serv);
                        context.Entry(serv).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool UpdateApelSeara(int id_c, int efc, int efp, int efa, DateTime data, int code)
        {
            if (code == 0)
                return false;

            using (var context = new ServiciiATMContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var apel = new Apel_seara
                        {
                            ID_C = id_c
                        };

                        context.Apel_seara.Attach(apel);
                        context.Entry(apel).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                        transaction.Commit();
                        return true;

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }

        }

        public bool UpdateComandanti(string name, string lastname, string tel, string mail, string adr, string gm, int code)
        {
            if (code == 0)
                return false;
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var com = new Comandanti
                    {
                        Nume = name,
                        Prenume = lastname,

                    };
                    context.Comandantis.Attach(com);
                    context.Entry(com).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    transaction.Commit();
                    return true;

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public bool UpdateCompanii(int id_com, string an_studiu, int code)
        {
            if (code == 0)
                return false;
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var c = new Companii
                    {
                        ID_com = id_com,
                        An_studii = an_studiu,
                    };
                    context.Companiis.Attach(c);
                    context.Entry(c).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    transaction.Commit();
                    return true;

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
        public bool UpdServicii(int id_l, int id_s, DateTime data, bool check, int code)
        {
            if (code == 0)
                return false;

            using (var context = new ServiciiATMContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var serv = new Servicii
                        {
                            ID_ls = id_l,
                            ID_S = id_s,

                        };
                        context.Serviciis.Add(serv);
                        context.Entry(serv).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }
    }
}