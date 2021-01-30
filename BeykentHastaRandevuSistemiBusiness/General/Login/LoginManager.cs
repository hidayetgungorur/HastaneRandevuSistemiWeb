
using BeykentHastaRandevuSistemiBusiness.Enum;
using BeykentHastaRandevuSistemiBusiness.General.Kullanici;
using BeykentHastaRandevuSistemiBusiness.Service.General;
using BeykentHastaRandevuSistemiBusiness.Service.Login;
using BeykentHastaRandevuSistemiData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeykentHastaRandevuSistemiBusiness.General.Login
{
    public static class LoginManager
    {


        public static bool Login(string tc, string password, bool isDoctor)
        {
            KullaniciEntity ke = GetLoginInfo(tc, password, isDoctor);
            if (ke == null)
                return false;

            SessionManager.Kullanici = ke;
            return true;

        }

        private static KullaniciEntity LoginHasta(string tc, string password)
        {
            var db = Helper.CreateContext;
            var user = (from h in db.Hasta
                        join k in db.KullaniciBilgileri on h.KullaniciId equals k.RecId
                        where k.KimlikNumarasi == tc
                        && h.StatusTypeId == (int)StatusTypeEnum.Active
                        select new KullaniciEntity()
                        {
                            HastaId = h.RecId,
                            KullaniciId = k.RecId,
                            Adi = k.Adi,
                            Soyadi = k.Soyadi,
                            IsDoktor = false,
                            DogumTarihi = k.DogumTarihi,
                            Email = k.Email,
                            Cinsiyet = k.Cinsiyet,
                            Sifre = k.Sifre,
                            CepNumarasi = k.CepNumarasi,
                            KimlikNumarasi = k.KimlikNumarasi
                        }).FirstOrDefault();

            return user.KullaniciSifreKontrol(password);
        }

        public static KullaniciEntity KullaniciSifreKontrol(this KullaniciEntity kullanici, string password)
        {
            if (kullanici == null)
                return null;

            kullanici.Sifre = kullanici.Sifre.Coz();
            if (password != kullanici.Sifre)
                return null;
            return kullanici;
        }

        private static KullaniciEntity LoginDoktor(string tc, string password)
        {
            var db = Helper.CreateContext;
            var user = (from d in db.Doktor
                        join k in db.KullaniciBilgileri on d.KullaniciId equals k.RecId
                        where k.KimlikNumarasi == tc
                        && d.StatusTypeId == (int)StatusTypeEnum.Active
                        select new KullaniciEntity()
                        {
                            DoktorId = d.RecId,
                            KullaniciId = k.RecId,
                            Adi = k.Adi,
                            Soyadi = k.Soyadi,
                            IsDoktor = true,
                            DogumTarihi = k.DogumTarihi,
                            Email = k.Email,
                            Cinsiyet = k.Cinsiyet,
                            Sifre = k.Sifre,
                            CepNumarasi = k.CepNumarasi,
                            KimlikNumarasi = k.KimlikNumarasi
                        }).FirstOrDefault();

            return user.KullaniciSifreKontrol(password);
        }


        public static KullaniciEntity GetLoginInfo(string tc, string password, bool isDoctor)
        {
            try
            {
                if (string.IsNullOrEmpty(tc) || string.IsNullOrEmpty(password))
                    return null;
                return isDoctor ? LoginDoktor(tc, password) : LoginHasta(tc, password);
            }
            catch
            {
                return null;
            }
        }

        #region Service

        public static LoginResponse Login(LoginRequest request)
        {
            KullaniciEntity ke = GetLoginInfo(request.UserName, request.Password, request.IsDoctor);
            if (ke == null)
                throw new Exception("Geçersiz Kullanıcı Bilgileri ");

            LoginResponse response = new LoginResponse();
            response.FirstName = ke.Adi;
            response.LastName = ke.Soyadi;
            response.UserId = ke.KullaniciId.ToString();
            response.PatientId = ke.HastaId.ToString();
            response.DoctorId = ke.DoktorId.ToString();
            response.TC = ke.KimlikNumarasi;
            response.BirthDate = ke.DogumTarihi.ToString("dd/MM/yyyy");
            response.Phone = ke.CepNumarasi;
            response.Email = ke.Email;
            response.GenderType = ke.Cinsiyet;
            response.Password = ke.Sifre;
            return response;

        }


        #endregion

    }
}
