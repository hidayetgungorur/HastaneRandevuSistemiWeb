using BeykentHastaRandevuSistemiBusiness.General;
using BeykentHastaRandevuSistemiBusiness.General.Doktor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BeykentHastaRandevuSistemi.UserControls.Doktor
{
    public partial class DoktorRandevu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPoliklinikler();
            }
        }

        public void LoadPoliklinikler()
        {
            var sonuc = GeneralManager.GetDoktorPoliklinikDropDownList();
            if (sonuc.Count > 0)
            {
                drpPoliklinik.DataSource = sonuc;
                drpPoliklinik.DataBind();
                LoadRandevular();
            }
        }



        private void LoadRandevular()
        {
            dvRandevuBulunamadi.Visible = false;
            dvRandevular.Visible = false;
            var sonuc = RandevuManager.DoktorRandevulari(drpPoliklinik.SelectedValue.ToInt(0));
            if (sonuc.Count > 0)
            {
                dvRandevular.Visible = true;
                rptRandevular.DataSource = sonuc;
                rptRandevular.DataBind();
            }
            else dvRandevuBulunamadi.Visible = true;
        }

        protected void lnkCreateDate_Click(object sender, EventArgs e)
        {
            var sonuc = RandevuManager.DoktorRandevuSaatleriOlustur(Calendar1.SelectedDate, drpPoliklinik.SelectedValue.ToInt(0));
            rptRandevuTarihleri.DataSource = sonuc;
            rptRandevuTarihleri.DataBind();
        }

        protected void drpPoliklinik_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRandevular();
        }

        protected void btnRandevuOlustur_Click(object sender, EventArgs e)
        {
            var sonuc = RandevuManager.DoktorRandevuOlustur(GetRandevuOlustur());
            LoadPoliklinikler();
        }


        public List<MusaitRandevuEntity> GetRandevuOlustur()
        {
            List<MusaitRandevuEntity> list = new List<MusaitRandevuEntity>();
            foreach (RepeaterItem it in rptRandevuTarihleri.Items)
            {
                if (it.ItemType == ListItemType.Item || it.ItemType == ListItemType.AlternatingItem)
                {
                    HiddenField hdnRecId = it.FindControl("hdnRecId") as HiddenField;
                    HiddenField hdnPoliklinikId = it.FindControl("hdnPoliklinikId") as HiddenField;
                    HiddenField hdnTarih = it.FindControl("hdnTarih") as HiddenField;
                    CheckBox chbselect = it.FindControl("chbselect") as CheckBox;

                    if (!chbselect.Checked || !chbselect.Enabled)
                        continue;

                    MusaitRandevuEntity mre = new MusaitRandevuEntity();
                    mre.Tarih = hdnTarih.Value.ToDateTime();
                    mre.PoliklinikId = hdnPoliklinikId.Value.ToInt(0);
                    list.Add(mre);
                }
            }

            return list;
        }

    }
}