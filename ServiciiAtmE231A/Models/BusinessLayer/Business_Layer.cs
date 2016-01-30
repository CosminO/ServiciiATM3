using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;

namespace ServiciiAtmE231A.Models
{
    public class Business_Layer
    {
        public Database_Access_Layer _dal;
        public Business_Layer()
        {

            _dal = new Database_Access_Layer();
        }
        public IEnumerable<Object> GetListaServiciiByAn(string an)
        {
            return _dal.GetListaServiciiByAn(an);
        }

        public IEnumerable<Object> Print_Servicii_Data(DateTime d)
        {
            return _dal.Print_Servicii_Data(d);
        }

        public IEnumerable<Object> GetListaServiciiByNrComponenta(int nrComponenta)
        {
            return _dal.GetListaServiciiByNrComponenta(nrComponenta);
        }

        public IEnumerable<Object> GetServiciiComp(int Companie)
        {
            return _dal.GetServiciiComp(Companie);
        }

        public IEnumerable<Object> GetServStudent(string Nume, string Prenume)
        {
            return _dal.GetServStudent(Nume, Prenume);
        }

        // returneaza numele sau prenumele cautat in functie de Email , pt cod 1 returneaza numele , pt cod 2 returneaza prenumele
        public string GetNumePrenumeforEmai(string Email, int cod)
        {
            string a = "";
            foreach (var v in _dal.Studenti())
            {
                if (v.Email == Email && cod == 0)
                {
                    a = v.Nume;
                }
                if (v.Email == Email && cod == 1)
                {
                    a = v.Prenume;
                }
            }
            foreach (var v in _dal.Comandanti())
            {
                if (v.Email == Email && cod == 0)
                {
                    a = v.Nume;
                }
                if (v.Email == Email && cod == 1)
                {
                    a = v.Prenume;
                }
            }
            return a;
        }

        // userului i se va seta prioritatea in functie de nume prenume si email
        public int GetPrioAfterName(string nume, string prenume, string Email)
        {
            int prio = -1;
            foreach (var v in _dal.Studenti())
            {
                if (v.Email == Email && v.Nume == nume && v.Prenume == prenume)
                {
                    prio = 0; ;
                }
            }


            foreach (var v in _dal.Comandanti())
            {
                if (v.Email == Email && v.Nume == nume && v.Prenume == prenume)
                {
                    prio = 1; ;
                }
            }

            return prio;
        }

        //Userul va inregistra Email-ul de pe care este conectat
        public void setEmailUser(string Email)
        {
            //_user.email = Email;

        }

        // parametrii de intrare -> datele comandantului , si se va return o lista cu studentii care nu si-au vizualizat serviciile de ziua urmatoare
        //EmailSauNumPre =0  return Email , EmailSauNumPre =1 return nume prenume
        public List<String> listOfUncheckedStud(string NumeC, string PrenumeC, int EmailSauNumPre)
        {
            List<String> i = new List<String>();
            List<int> id_s = new List<int>();
            int IDcom = new int();
            int ID_C = new int();
            string Stud;
            foreach (var v in _dal.Comandanti())
            {
                if (v.Nume == NumeC && v.Prenume == PrenumeC)
                {
                    IDcom = v.ID_com;
                }
            }

            foreach (var v in _dal.Companii())
            {
                if (v.ID_com == IDcom)
                {
                    ID_C = v.ID_C;
                }
            }

            foreach (var v in _dal.Servicii())
            {
                if (v.Data.Value.Day == DateTime.Now.Day + 1)
                {
                    id_s.Add(v.ID_S);
                }
            }

            foreach (var v in _dal.Studenti())
            {
                foreach (var s in id_s)
                {
                    if (EmailSauNumPre == 1)
                    {
                        if (v.ID_C == ID_C && s == v.ID_S)
                        {
                            Stud = "Nume: ";
                            Stud += v.Nume;
                            Stud += " Prenume: ";
                            Stud += v.Prenume;
                            i.Add(Stud);
                        }
                    }
                    else
                    {
                        if (EmailSauNumPre == 0)
                        {
                            if (v.ID_C == ID_C && s == v.ID_S)
                            {
                                i.Add(v.Email);
                            }
                        }
                    }
                }
            }
            return i;
        }

        //in functie de numele si prenumele unui student se va returna o lista cu serviciile pe care nu le-a vizualizat
        public List<String> listOfServicesStud(string Nume, string Prenume)
        {
            List<String> i = new List<String>();
            String info;
            int ID_S = new int();

            foreach (var v in _dal.Studenti())
            {
                if (v.Nume == Nume && v.Prenume == Prenume)
                {
                    ID_S = v.ID_S;
                }
            }
            foreach (var v in _dal.Servicii())
            {
                foreach (var vv in _dal.Lista_servicii())
                {
                    if (v.ID_S == ID_S && v.ID_ls == vv.ID_ls && v.Check == false)
                    {
                        info = vv.Nume_serviciu;
                        info += v.Data;
                        i.Add(info);
                    }
                }
            }



            return i;
        }

        //returneaza Email-ul unui student in functie de nume si prenume
        public string GetEmailOFStud(string Nume, string Prenume)
        {
            string Email = "";
            foreach (var v in _dal.Studenti())
            {
                if (v.Nume == Nume && v.Prenume == Prenume)
                {
                    Email = v.Email;
                }
            }
            return Email;
        }

        //returneaza Lista email-urilor in functie de Companie
        public List<String> listOfEmailsCompanie(int ID_C)
        {
            List<String> i = new List<string>();

            foreach (var v in _dal.Studenti())
            {
                if (v.ID_C == ID_C)
                {
                    i.Add(v.Email);
                }
            }

            return i;
        }





    }
}