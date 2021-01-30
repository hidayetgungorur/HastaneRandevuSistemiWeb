using BeykentHastaRandevuSistemiBusiness.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BeykentHastaRandevuSistemi
{
    public partial class Default : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                var kullanici = SessionManager.Kullanici;

                if (kullanici == null)
                     Response.Redirect("/Login.aspx", true);
                liRandevularim.Visible = !kullanici.IsDoktor;
                lblKullanici.Text = kullanici.Adi + " " + kullanici.Soyadi;
            }
        }

        protected void btnCikisYap_ServerClick(object sender, EventArgs e)
        {
            SessionManager.Kullanici = null;
            Response.Redirect("/Login.aspx", true);
        }
    }
}