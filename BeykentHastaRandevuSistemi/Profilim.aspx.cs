using BeykentHastaRandevuSistemiBusiness.General;
using BeykentHastaRandevuSistemiBusiness.General.Kullanici;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BeykentHastaRandevuSistemi
{
    public partial class Profilim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               

                LoadBilgilerim();
            }
        }

        private void LoadBilgilerim()
        {
            var sonuc = GeneralManager.GetBilgilerim();
            if (sonuc != null)
            {
                dvUnvan.Visible = SessionManager.Kullanici.IsDoktor;
                txtUnvan.Text = sonuc.Unvan;
                txtAdi.Text = sonuc.Adi;
                txtSoyadi.Text = sonuc.Soyadi;
                txtKimlikNo.Text = sonuc.KimlikNo;
                txtDogumTarihi.Text = sonuc.DogumTarihi.ToString();
                txtEmail.Text = sonuc.Email;
                drpCinsiyet.SelectedValue = sonuc.Cinsiyet.ToString();
                txtSifre.Text = sonuc.Sifre;
                txtTelefon.Text = sonuc.CepNumarasi;
            }
            else Response.Redirect("/Home.aspx", true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            dvBasarili.Visible = false;
            dvHata.Visible = false;

            KullaniciBilgileriEntity kb = new KullaniciBilgileriEntity();
            kb.Unvan= txtUnvan.Text;
            kb.Email= txtEmail.Text;
            kb.Sifre= txtSifre.Text;
            kb.CepNumarasi = txtTelefon.Text;
            var sonuc = GeneralManager.UpdateKullanici(kb);
            if(sonuc)
                dvBasarili.Visible = true;
            else  dvHata.Visible = true;
        }
    }
}