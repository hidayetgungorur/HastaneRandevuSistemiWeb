
using BeykentHastaRandevuSistemiBusiness.Enum;
using BeykentHastaRandevuSistemiBusiness.General;
using BeykentHastaRandevuSistemiBusiness.Service.Account;
using BeykentHastaRandevuSistemiData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeykentHastaRandevuSistemiBusiness.Hasta
{
    public class HastaManager
    {
        public static bool SaveHasta(HastaEntity he)
        {

            if (string.IsNullOrEmpty(he.Adi) || string.IsNullOrEmpty(he.Soyadi) || string.IsNullOrEmpty(he.KimlikNo) || !he.Cinsiyet.HasValue || !he.DogumTarihi.HasValue || string.IsNullOrEmpty(he.CepNumarasi) || string.IsNullOrEmpty(he.Sifre) || string.IsNullOrEmpty(he.Email))
                return false;

            var db = Helper.CreateContext;

            var kullanici = db.KullaniciBilgileri.FirstOrDefault(t => t.KimlikNumarasi == he.KimlikNo);
            if (kullanici != null)
                return false;


            BeykentHastaRandevuSistemiData.Hasta h = new BeykentHastaRandevuSistemiData.Hasta();
            h.StatusTypeId = StatusTypeEnum.Active.GetHashCode();
            h.KullaniciBilgileri = new KullaniciBilgileri();
            h.KullaniciBilgileri.Adi = he.Adi;
            h.KullaniciBilgileri.Soyadi = he.Soyadi;
            h.KullaniciBilgileri.KimlikNumarasi = he.KimlikNo;
            h.KullaniciBilgileri.Cinsiyet = he.Cinsiyet.Value;
            h.KullaniciBilgileri.DogumTarihi = he.DogumTarihi.Value;
            h.KullaniciBilgileri.CepNumarasi = he.CepNumarasi;
            h.KullaniciBilgileri.Email = he.Email;
            h.KullaniciBilgileri.Sifre = he.Sifre.Sifrele();
            db.Hasta.Add(h);
            db.SaveChanges();
            return true;
        }

        #region Service

        public static AccountResponse CreateAccount(AccountRequest req)
        {

            if (string.IsNullOrEmpty(req.FirstName) || string.IsNullOrEmpty(req.LastName) || string.IsNullOrEmpty(req.TC) || string.IsNullOrEmpty(req.BirthDate) || string.IsNullOrEmpty(req.Phone) || string.IsNullOrEmpty(req.Password) || string.IsNullOrEmpty(req.Email))
                throw new Exception("Bilgileri eksiksiz girin");


            var db = Helper.CreateContext;

            var kullanici = db.KullaniciBilgileri.FirstOrDefault(t => t.KimlikNumarasi == req.TC);
            if (kullanici != null)
                throw new Exception("Girilen bilgilerde daha önce kayıtlı kişi var");

            BeykentHastaRandevuSistemiData.Hasta h = new BeykentHastaRandevuSistemiData.Hasta();
            h.StatusTypeId = StatusTypeEnum.Active.GetHashCode();
            h.KullaniciBilgileri = new KullaniciBilgileri();
            h.KullaniciBilgileri.Adi = req.FirstName;
            h.KullaniciBilgileri.Soyadi = req.LastName;
            h.KullaniciBilgileri.KimlikNumarasi = req.TC;
            h.KullaniciBilgileri.Cinsiyet = req.GenderType;
            h.KullaniciBilgileri.DogumTarihi = Convert.ToDateTime(req.BirthDate);
            h.KullaniciBilgileri.CepNumarasi = req.Phone;
            h.KullaniciBilgileri.Email = req.Email;
            h.KullaniciBilgileri.Sifre = req.Password.Sifrele();
            db.Hasta.Add(h);
            db.SaveChanges();

            AccountResponse response = new AccountResponse();
            response.FirstName = req.FirstName;
            response.LastName = req.LastName;
            return response;
        }

        public static AccountResponse UpdateAccount(AccountRequest req)
        {

            if (string.IsNullOrEmpty(req.Phone) || string.IsNullOrEmpty(req.Email) || string.IsNullOrEmpty(req.Password))
                throw new Exception("Bilgileri eksiksiz girin");


            var db = Helper.CreateContext;

            var kullanici = db.KullaniciBilgileri.FirstOrDefault(t => t.RecId == req.UserId);
            if (kullanici == null)
                throw new Exception("Kayıtlı kullanıcı bulunamadı.");

            kullanici.CepNumarasi = req.Phone;
            kullanici.Email = req.Email;
            kullanici.Sifre = req.Password.Sifrele();
            db.SaveChanges();

            AccountResponse response = new AccountResponse();
            response.FirstName = kullanici.Adi;
            response.LastName = kullanici.Soyadi;
            response.UserId = kullanici.RecId.ToString();
            response.PatientId = kullanici.Hasta.First().RecId.ToString();
            response.TC = kullanici.KimlikNumarasi;
            response.BirthDate = kullanici.DogumTarihi.ToString();
            response.Phone = kullanici.CepNumarasi;
            response.Email = kullanici.Email;
            response.GenderType = kullanici.Cinsiyet;
            response.Password = kullanici.Sifre;
            return response;
        }


        #endregion



    }
}
