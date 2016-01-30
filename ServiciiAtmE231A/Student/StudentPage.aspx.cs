using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiciiAtmE231A.Models;
namespace ServiciiAtmE231A.Student
{
    
    public partial class StudentPage : System.Web.UI.Page
    {
        public Business_Layer _bal = new Business_Layer();
       
        protected void Page_Load(object sender, EventArgs e)
        {

            



        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
        }

        protected void Button_Afisare_Click(object sender, EventArgs e)
        {
            
            int x;
            Int32.TryParse(DropDownList1.SelectedItem.ToString(), out x);
            GridView1.DataSource = _bal.GetServiciiComp(x);
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void Btn_Incarca_Click(object sender, EventArgs e)
        {
           
                foreach (var y in _bal._dal.Companii())
                {
                    DropDownList1.Items.Add(y.ID_C.ToString());
                }
                DropDownList2.Items.Insert(0, "I");
                DropDownList2.Items.Insert(1, "II");
                DropDownList2.Items.Insert(2, "III");
                DropDownList2.Items.Insert(3, "IV");


        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridView2.DataSource = _bal.GetListaServiciiByAn(DropDownList2.SelectedItem.ToString());
            GridView2.DataBind();
        }
    }
}