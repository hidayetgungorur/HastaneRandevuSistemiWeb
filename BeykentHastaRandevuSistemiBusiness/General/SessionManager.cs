using BeykentHastaRandevuSistemiBusiness.General.Kullanici;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BeykentHastaRandevuSistemiBusiness.General
{
   public static class SessionManager
    {

        public static KullaniciEntity Kullanici
        {
            get
            {
                if (HttpContext.Current.Session["Kullanici"] != null)
                {
                    return HttpContext.Current.Session["Kullanici"] as KullaniciEntity;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Session["Kullanici"] = value;
            }
        }

    }
}
