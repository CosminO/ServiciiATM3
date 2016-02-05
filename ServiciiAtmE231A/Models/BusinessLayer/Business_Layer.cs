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

        public void Email_to_single(string to, string from, string subject, string message, string password)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(from);
            msg.To.Add(new MailAddress(to));
            msg.Subject = subject;
            msg.Body = message;
            msg.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";

            System.Net.NetworkCredential Network_Cred = new System.Net.NetworkCredential();
            Network_Cred.UserName = from;
            Network_Cred.Password = password;

            smtp.UseDefaultCredentials = true;
            smtp.Credentials = Network_Cred;
            smtp.Port = 587;
            smtp.EnableSsl = true;
            //smtp.Send(msg);

        }

        public void Email_to_all(List<string> emails, string from, string subject, string message, string password)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            System.Net.NetworkCredential Network_Cred = new System.Net.NetworkCredential();
            Network_Cred.UserName = from;
            Network_Cred.Password = password;

            smtp.UseDefaultCredentials = true;
            smtp.Credentials = Network_Cred;
            smtp.Port = 587;
            smtp.EnableSsl = true;

            foreach (var email_adress in emails)
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(from);
                msg.To.Add(new MailAddress(email_adress));
                msg.Subject = subject;
                msg.Body = message;
                msg.IsBodyHtml = true;
                //smtp.Send(msg);

            }

        }

        //adauga un student la invoire apel
        public void Insert_invoire_apel(int id_s, DateTime data, TimeSpan ora_plecare, TimeSpan ora_sosire, int code)
        {
            try
            {
                _dal.InsertInvoireSeara(id_s, data, ora_plecare, ora_sosire, code);
            }
            catch(Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
        //adauga un serviciu
        public void Insert_lista_servicii(string nume, int nr_comp, string an, int code)
        {
            try
            {
                _dal.InsertListaServicii(nume,nr_comp,an,code);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
        //adauga un student
        public void Insert_Studenti(int id_c, string nume, string prenume, string mail, string tel, string grad, int camera, string functie, int code)
        {
            try
            {
                _dal.InsertStudenti(id_c, nume, prenume, mail, tel, grad, camera, functie, code);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

        }
        //adauga un student la un anumit serviciu.
        public void Insert_Servicii(int id_l, int id_s, DateTime data, bool check, int code)
        {
            try
            {
                _dal.InsertServicii(id_l,id_s,data,check,code);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
        //adaga efectivele pe companii.
        public void Insert_Efective_Apel_seara(int id_c, int efc, int efp, int efa, DateTime data, int code)
        {
            try
            {
                _dal.InsertApelSeara(id_c,efc,efp,efa,data,code);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
        //adauga comandant de cp.
        public void Insert_Comandanti(string name, string lastname, string tel, string mail, string adr, string gm, int code)
        {
            try
            {
                _dal.InsertComandanti(name,lastname,tel,mail,adr,gm,code);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
        //adauga companie.
        public void Insert_Companii(int id_com, string an_studiu, int code)
        {
            try
            {
                _dal.InsertCompanii(id_com,an_studiu,code);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }

        //sterge un apel de seara.
        public void Delete_apel_seara(DateTime data)
        {
            try
            {
                _dal.DeleteApelSeara(data);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
        //sterge servicii.
        public void Delete_lista_servicii(string name)
        {
            try
            {
                _dal.DeleteListaServicii(name);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
        //sterge o companie in functie de anul de studiu.
        public void Delete_Companii(string an)
        {
            try
            {
                _dal.DeleteCompanii(an);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
        //sterge un student.
        public void Delete_student(string name, string lastname)
        {
            try
            {
                _dal.DeleteStudent(name, lastname);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
        //sterge un serviciu al unui student in functie de data.
        public void Delete_servicii(DateTime time)
        {
            try
            {
                _dal.DeleteServicii(time);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

        }
        //sterge un comandant de cp.
        public void Delete_comandanti(string nume, string prenume)
        {
            try
            {
                _dal.DeleteComandanti(nume, prenume);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
        //sterge o invoire de la apel in functie de data.
        public void Delete_invoire_apel(DateTime dt)
        {
            try
            {
                _dal.DeleteInvApel(dt);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }

        //update invoire apel
        public void Update_invoire_apel(int id_s, DateTime data, TimeSpan ora_plecare, TimeSpan ora_sosire, int code)
        {
            try
            {
                _dal.UpdateInvoireApel(id_s,data,ora_plecare,ora_sosire,code);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

        }
        //update lista servicii
        public void Update_lista_servicii(string nume, int nr, string an, int code)
        {
            try
            {
                _dal.UpdateListaServicii(nume,nr,an,code);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

        }
        //update student
        public void Update_student(int id_c, string name, string prenume, string email, string tel, string grad, int camera, string functie, int code)
        {
            try
            {
                _dal.UpdateStudenti(id_c, name, prenume, email, tel, grad, camera, functie, code);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

        }
        //update apel seara
        public void Update_apel_seara(int id_c, int efc, int efp, int efa, DateTime data, int code)
        {
            try
            {
                _dal.UpdateApelSeara(id_c,efc,efp,efa,data,code);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
        //update comandanti companie
        public void Update_comandanti_cp(string name, string lastname, string tel, string mail, string adr, string gm, int code)
        {
            try
            {
                _dal.UpdateComandanti(name,lastname,tel,mail,adr,gm,code);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
        //update companie
        public void Update_Companii(int id_com, string an_studiu, int code)
        {
            try
            {
                _dal.UpdateCompanii(id_com, an_studiu, code);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
        //update servicii
        public void Update_servicii(int id_l, int id_s, DateTime data, bool check, int code)
        {
            try
            {
                _dal.UpdServicii(id_l,id_s,data,check,code);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
    }
}