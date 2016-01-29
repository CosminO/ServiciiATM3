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
            _pl._bl.Email_to_single("popamadalin5@gmail.com", "serviciiatm@gmail.com", "Functie_single", "asta e functia pentru un singur email", "paul1994");
            _pl._bl.Email_to_single("urianpaul94@yahoo.com", "serviciiatm@gmail.com", "Functie_single", "asta e functia pentru un singur email", "paul1994");
            _pl._bl.Email_to_single("arsene.diana.andreea@gmail.com", "serviciiatm@gmail.com", "Functie_single", "asta e functia pentru un singur email", "paul1994");

            List<string> l = new List<string>();
            l.Add("popamadalin5@gmail.com");
            l.Add("arsene.diana.andreea@gmail.com");
            l.Add("urianpaul94@yahoo.com");
            _pl._bl.Email_to_all(l, "serviciiatm@gmail.com", "Functie_to_all", "asta e functia pentru toate emailurile.", "paul1994");
           
            GridView2.DataSource = _pl.Afisare_servicii(d);
            GridView2.DataBind();
        }
    }
}