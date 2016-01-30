using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServiciiAtmE231A
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Login_Click(object sender, EventArgs e)
        {
            if (TextBoxUserName.Text == "1@yahoo.com" && TextBoxPassword.Text == "2")
            {
                Session["new"] = TextBoxUserName.Text;
                Response.Write("Successfull logged in");
                Response.Redirect("~/Student/StudentPage.aspx");
                
                
            }
            else
            {
                Response.Write("Unsuccessfull log in");
            }
        }
    }
}