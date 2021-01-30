using BeykentHastaRandevuSistemiBusiness.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BeykentHastaRandevuSistemi
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                var kullanici = SessionManager.Kullanici;
                if(kullanici==null)
                    Response.Redirect("/Login.aspx", true);

                DoktorRandevu.Visible = false;
                HastaRandevu.Visible = false;
                if (kullanici.IsDoktor)
                {
                    DoktorRandevu.Visible = true;

                }

                else
                {
                    HastaRandevu.Visible = true;
                    HastaRandevu.LoadPoliklinikler();


                }
            }
        }
    }
}