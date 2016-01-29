using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiciiAtmE231A.Models.PresentationLayer;

namespace ServiciiAtmE231A
{
    public partial class _Default : Page
    {
        public Presentation_Layer _pl = new Presentation_Layer();
        DateTime d = new DateTime(2011, 6, 10);
        
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView2.DataSource = _pl.Afisare_servicii(d);
            GridView2.DataBind();
        }
    }
}