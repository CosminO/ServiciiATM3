using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciiAtmE231A.Models.PresentationLayer
{
    public class Presentation_Layer
    {
        public Business_Layer _bl = new Business_Layer();
        public IEnumerable<Object> Afisare_servicii(DateTime d)
        {
            return _bl.Print_Servicii_Data(d);
        }

        public IEnumerable<Apel_seara> showApel_Seara()
        {
            
            return _bl.showApel_Seara();
        }
        public IEnumerable<Servicii> showServici()
        {
          
            return _bl.showServicii();
        }
        public IEnumerable<Comandanti> showComandanti()
        {
            return _bl.showComandanti();
        }

    }
}