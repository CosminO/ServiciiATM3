using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using ServiciiAtmE231A.Models;
using System.Web.Security;

namespace ServiciiAtmE231A.Account
{
    public partial class Login : Page
    {
     

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if(Email.Text=="1@yahoo.com")
                {
                    Response.Redirect("~/Comandanti.aspx");
                   
                }
                if(Email.Text=="2@yahoo.com")
                {
                    Response.Redirect("~/Studenti.aspx");
                }
                if ((RememberMe.Checked == true))
                {
                    HttpCookie mycookie = new HttpCookie("LoginDetail");
                    mycookie.Values.Add(Email.Text.Trim(), "Username");
                    mycookie.Values.Add(Password.Text.Trim(),"Password");
                  
                    mycookie.Expires = System.DateTime.Now.AddDays(1);

                    Response.Cookies.Add(mycookie);
                }
            }
        }
    }
}