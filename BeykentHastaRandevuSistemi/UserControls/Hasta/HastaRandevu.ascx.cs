using BeykentHastaRandevuSistemiBusiness.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BeykentHastaRandevuSistemi.UserControls.Hasta
{
    public partial class HastaRandevu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadPoliklinikler()
        {
            var sonuc = GeneralManager.GetPoliklinikDropDownList();
            if (sonuc.Count > 0)
            {
                drpPoliklinik.DataSource = sonuc;
                drpPoliklinik.DataBind();
                LoadPoliklinikDoktorları();
            }
        }


        public void LoadPoliklinikDoktorları()
        {
            if (string.IsNullOrEmpty(drpPoliklinik.SelectedValue))
                return;

            var sonuc = GeneralManager.GetPoliklinikDoktorlarıDropDownList(drpPoliklinik.SelectedValue.ToInt(0));
            drpDoktor.DataSource = sonuc;
            drpDoktor.DataBind();

        }

        protected void drpPoliklinik_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPoliklinikDoktorları();
        }

        protected void lnkSearch_Click(object sender, EventArgs e)
        {
            var sonuc = RandevuManager.GetMusaitRandevu(drpPoliklinik.SelectedValue.ToInt(0), drpDoktor.SelectedValue.ToInt(0), Calendar1.SelectedDate);
            dvRandevuBulunamadi.Visible = sonuc.Count() <= 0;
            btnRandevuKaydet.Visible = sonuc.Count() > 0;

            rptHeader.DataSource = sonuc;
            rptHeader.DataBind();

            rptList.DataSource = sonuc;
            rptList.DataBind();


        }


        public int? GetRandevuId()
        {
            foreach (RepeaterItem item in rptList.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                   
                    Repeater rptListItem = item.FindControl("rptListItem") as Repeater;

                    foreach (RepeaterItem it in rptListItem.Items)
                    {
                        if (it.ItemType == ListItemType.Item || it.ItemType == ListItemType.AlternatingItem)
                        {
                            HiddenField hdnRecId = it.FindControl("hdnRecId") as HiddenField;
                            CheckBox chbselect = it.FindControl("chbselect") as CheckBox;

                            if (!chbselect.Checked || !chbselect.Enabled)
                                continue;

                            return hdnRecId.Value.ToInt(0);
                            
                        }
                    }
                }
            }
            return null;
        }


        protected void btnRandevuKaydet_Click(object sender, EventArgs e)
        {
            dvRandevuBasarili.Visible = false;
            dvRandevuHata.Visible = false;

            var sonuc = RandevuManager.SaveRandevu(GetRandevuId());
            if(sonuc)
                dvRandevuBasarili.Visible = true;
            else dvRandevuHata.Visible = true;
        }
    }
}