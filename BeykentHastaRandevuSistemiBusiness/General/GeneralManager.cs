
using BeykentHastaRandevuSistemiBusiness.Enum;
using BeykentHastaRandevuSistemiBusiness.General.Kullanici;
using BeykentHastaRandevuSistemiBusiness.Service.Doctor;
using BeykentHastaRandevuSistemiBusiness.Service.Poliklinik;
using BeykentHastaRandevuSistemiData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeykentHastaRandevuSistemiBusiness.General
{
    public class GeneralManager
    {
        public static KullaniciBilgileriEntity GetBilgilerim()
        {

            if (SessionManager.Kullanici == null)
                return null;

            if (SessionManager.Kullanici.IsDoktor)
                return GetDoktor();
            else return GetHasta();
        }

      

        private static KullaniciBilgileriEntity GetHasta()
        {
            var db = Helper.CreateContext;

            var hasta = (from h in db.Hasta
                         join k in db.KullaniciBilgileri on h.KullaniciId equals k.RecId
                         where k.RecId == SessionManager.Kullanici.KullaniciId
                         select new KullaniciBilgileriEntity()
                         {
                             Adi = k.Adi,
                             Soyadi = k.Soyadi,
                             KimlikNo = k.KimlikNumarasi,
                             Cinsiyet = k.Cinsiyet,
                             DogumTarihi = k.DogumTarihi,
                             CepNumarasi = k.CepNumarasi,
                             Email = k.Email,
                             Sifre = k.Sifre
                         }).FirstOrDefault();

            if (hasta == null)
                return null;

            hasta.Sifre = hasta.Sifre.Coz();

            return hasta;

        }


        private static KullaniciBilgileriEntity GetDoktor()
        {
            var db = Helper.CreateContext;

            var doktor = (from d in db.Doktor
                          join k in db.KullaniciBilgileri on d.KullaniciId equals k.RecId
                          where k.RecId == SessionManager.Kullanici.KullaniciId
                          select new KullaniciBilgileriEntity()
                          {
                              Unvan = d.Unvan,
                              Adi = k.Adi,
                              Soyadi = k.Soyadi,
                              KimlikNo = k.KimlikNumarasi,
                              Cinsiyet = k.Cinsiyet,
                              DogumTarihi = k.DogumTarihi,
                              CepNumarasi = k.CepNumarasi,
                              Email = k.Email,
                              Sifre = k.Sifre
                          }).FirstOrDefault();

            if (doktor == null)
                return null;

            doktor.Sifre = doktor.Sifre.Coz();

            return doktor;
        }

        public static bool UpdateKullanici(KullaniciBilgileriEntity kb)
        {

            var db = Helper.CreateContext;

            var kullanici = db.KullaniciBilgileri.FirstOrDefault(t => t.RecId == SessionManager.Kullanici.KullaniciId);
            if (kullanici == null)
                return false;

            kullanici.Sifre = kb.Sifre.Sifrele();
            kullanici.Email = kb.Email;
            kullanici.CepNumarasi = kb.CepNumarasi;
            if (SessionManager.Kullanici.IsDoktor)
                kullanici.Doktor.First().Unvan = kb.Unvan;
            db.SaveChanges();
            return true;
        }


        public static List<KeyValuePair<string, string>> GetPoliklinikDropDownList()
        {
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();

            var db = Helper.CreateContext;

            var poliklinikler = (from p in db.Poliklinik
                                 where p.StatusTypeId == (int)StatusTypeEnum.Active
                                 select new
                                 {
                                     p.RecId,
                                     p.Adi
                                 }).ToList();

            foreach (var pol in poliklinikler)
            {
                list.Add(new KeyValuePair<string, string>(pol.RecId.ToString(), pol.Adi));
            }

            return list;
        }

        public static List<KeyValuePair<string, string>> GetDoktorPoliklinikDropDownList()
        {
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();

            var db = Helper.CreateContext;

            var poliklinikler = (from p in db.DoktorPoliklinik
                                 where
                                 p.DoktorId == SessionManager.Kullanici.DoktorId
                                 && p.StatusTypeId == (int)StatusTypeEnum.Active
                                 select new { p }).ToList();

            foreach (var pol in poliklinikler)
            {
                list.Add(new KeyValuePair<string, string>(pol.p.PoliklinikId.ToString(),pol.p.Poliklinik.Adi));
            }
            return list;
        }



        public static List<KeyValuePair<string, string>> GetPoliklinikDoktorlarıDropDownList(int polinikId)
        {
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();

            var db = Helper.CreateContext;

            var poliklinikler = (from p in db.DoktorPoliklinik
                                 where
                                 p.PoliklinikId == polinikId
                                 && p.StatusTypeId == (int)StatusTypeEnum.Active
                                 select new { p}).ToList();

            foreach (var pol in poliklinikler)
            {
                var p = pol.p.Doktor.KullaniciBilgileri;
                list.Add(new KeyValuePair<string, string>(pol.p.Doktor.RecId.ToString(), p.Adi + " " + p.Soyadi));
            }

            return list;
        }




        #region Service 


        public static List<PoliklinikResponse> GetPolikliniks()
        {
            List<PoliklinikResponse> list = new List<PoliklinikResponse>();

            var db = Helper.CreateContext;

            var polikliniks = (from p in db.Poliklinik
                                 where p.StatusTypeId == (int)StatusTypeEnum.Active
                                 select new
                                 {
                                     p.RecId,
                                     p.Adi
                                 }).ToList();

            foreach (var pol in polikliniks)
            {
                PoliklinikResponse pr = new PoliklinikResponse();
                pr.Id = pol.RecId;
                pr.Name = pol.Adi;
                list.Add(pr);
            }

            return list;
        }


        public static List<DoctorResponse> GetPoliklinikDoctors(DoctorRequest req)
        {
            List<DoctorResponse> list = new List<DoctorResponse>();

            var db = Helper.CreateContext;

            var polikliniks = (from p in db.DoktorPoliklinik
                                 where
                                 p.PoliklinikId == req.PoliklinikId
                                 && p.StatusTypeId == (int)StatusTypeEnum.Active
                                 select new { p }).ToList();

            foreach (var pol in polikliniks)
            {
                var p = pol.p.Doktor.KullaniciBilgileri;
                DoctorResponse dr = new DoctorResponse();
                dr.Id = pol.p.Doktor.RecId;
                dr.Name = p.Adi + " " + p.Soyadi;
                list.Add(dr);
            }

            return list;
        }


        #endregion

    }
}
