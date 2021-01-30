using BeykentHastaRandevuSistemiBusiness.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BeykentHastaRandevuSistemi.Hasta
{
    public partial class Randevularim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRandevularim();
            }
        }

        private void LoadRandevularim()
        {
            var sonuc = RandevuManager.GetRandevularim();
            rptRandevularim.DataSource = sonuc;
            rptRandevularim.DataBind();

        }

        protected void lbDeleteRandevu_Click(object sender, EventArgs e)
        {

            LinkButton lbDeleteRandevu = sender as LinkButton;
            HiddenField hdnRecId = lbDeleteRandevu.FindControl("hdnRecId") as HiddenField;
            var sonuc = RandevuManager.RandevuIptal(hdnRecId.Value.ToInt(0));
            if(sonuc)
                LoadRandevularim();
        }
    }
}