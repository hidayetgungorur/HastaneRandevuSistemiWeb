using BeykentHastaRandevuSistemiBusiness.General;
using BeykentHastaRandevuSistemiBusiness.General.Login;
using BeykentHastaRandevuSistemiBusiness.Hasta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BeykentHastaRandevuSistemi
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                for (int i = 1; i <= 25; i++)
                {

                    string mesaj = SezarHelper.Coz("UCUHVKHCGRVURKAYINJUHKAVKJKAJUPUHYDGYUHYUVKJKAKYUMKR", i);
                        }
                if (SessionManager.Kullanici != null)
                    Response.Redirect("/Home.aspx", true);
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var sonuc = LoginManager.Login(txtGirisKimlikNo.Text, txtGirisSifre.Text, chbDoktor.Checked);
            if (sonuc)
                Response.Redirect("/Home.aspx", true);
            else dvGirisBilgisiHatalı.Visible = true;
        }

        protected void btnSendPassword_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            HastaEntity he = new HastaEntity();
            he.Adi = txtAdi.Text;
            he.Soyadi = txtSoyadi.Text;
            he.KimlikNo = txtKimlikNo.Text;
            he.CepNumarasi = txtTelefonNo.Text;
            he.Cinsiyet = drpCinsiyet.SelectedValue.ToInt(0);
            he.Email = txtEmail.Text;
            he.Sifre = txtSifre.Text;
            he.DogumTarihi = txtDogumTarihi.Text.ToDateTime();
            var sonuç = HastaManager.SaveHasta(he);
            if (!sonuç)
                dvHesapBilgileriHata.Visible = true;
            else
            {
                dvHesapBilgileriForm.Visible = false;
                dvGirişBilgileriForm.Visible = true;
            }

        }

        protected void btnSaveBack_Click(object sender, EventArgs e)
        {
            dvHesapBilgileriForm.Visible = false;
            dvGirişBilgileriForm.Visible = true;
        }

        protected void btnHesapOlustur_Click(object sender, EventArgs e)
        {
            dvHesapBilgileriForm.Visible = true;
            dvGirişBilgileriForm.Visible = false;
        }

        protected void btnSifremiUnuttum_Click(object sender, EventArgs e)
        {
            dvGirişBilgileriForm.Visible = false;
            dvSifremiUnuttumForm.Visible = true;
        }

        protected void btnSifremiUnuttumGeri_Click(object sender, EventArgs e)
        {
            dvGirişBilgileriForm.Visible = true;
            dvSifremiUnuttumForm.Visible = false;
        }
    }
}