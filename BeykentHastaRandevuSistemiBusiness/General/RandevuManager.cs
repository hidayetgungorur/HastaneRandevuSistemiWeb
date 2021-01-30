
using BeykentHastaRandevuSistemiBusiness.Enum;
using BeykentHastaRandevuSistemiBusiness.General.Doktor;
using BeykentHastaRandevuSistemiBusiness.Hasta;
using BeykentHastaRandevuSistemiBusiness.Service.Appointment;
using BeykentHastaRandevuSistemiData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeykentHastaRandevuSistemiBusiness.General
{
    public class RandevuManager
    {
        public static List<RandevuMusaitEntity> GetMusaitRandevu(int poliklinikId, int doktorId, DateTime date1)
        {
            List<RandevuMusaitEntity> list = new List<RandevuMusaitEntity>();

            var db = Helper.CreateContext;

            DateTime date2 = date1.AddDays(5).AddHours(23).AddMinutes(59).AddSeconds(59);

            var randevular = (from h in db.HastaRandevu
                              where h.PoliklinikId == poliklinikId
                              && h.DoktorId == doktorId
                              && h.StatusTypeId == (int)StatusTypeEnum.Active
                              && h.Tarih >= date1
                              && h.Tarih <= date2
                              select new
                              {
                                  h.RecId,
                                  h.Tarih,
                                  h.StatusTypeId,
                                  h.HastaId
                              }).ToList();



            for (DateTime d = date1; d < date2;)
            {
                DateTime d2 = d.AddHours(23).AddMinutes(59).AddSeconds(59);

                var items = randevular.Where(t => t.Tarih >= d && t.Tarih <= d2).OrderBy(t => t.Tarih);
                if (items.Count() > 0)
                {
                    RandevuMusaitEntity rm = new RandevuMusaitEntity();
                    rm.Tarih = d;
                    rm.Items = new List<RandevuMusaitItemEntity>();
                    foreach (var item in items)
                    {
                        RandevuMusaitItemEntity it = new RandevuMusaitItemEntity();
                        it.StatusType = (StatusTypeEnum)item.StatusTypeId;
                        it.RecId = item.RecId;
                        it.Saat = item.Tarih.ToString("HH:mm");
                        it.HastaId = item.HastaId.ToInt(0);
                        rm.Items.Add(it);
                    }
                    list.Add(rm);
                }
                d = d.AddDays(1);
            }





            return list;
        }



        public static bool SaveRandevu(int? randevuId)
        {
            if (!randevuId.HasValue)
                return false;

            var db = Helper.CreateContext;

            var randevu = db.HastaRandevu.FirstOrDefault(t => t.RecId == randevuId && !t.HastaId.HasValue);
            if (randevu == null)
                return false;

            randevu.HastaId = SessionManager.Kullanici.HastaId;
            db.SaveChanges();

            return true;
        }


        public static List<RandevularimEntity> GetRandevularim()
        {
            List<RandevularimEntity> list = new List<RandevularimEntity>();


            var db = Helper.CreateContext;

            var randevularim = db.HastaRandevu.Where(t => t.HastaId == SessionManager.Kullanici.HastaId);
            foreach (var ran in randevularim)
            {
                RandevularimEntity re = new RandevularimEntity();
                re.RecId = ran.RecId;
                var doktor = ran.Doktor.KullaniciBilgileri;
                re.DoktorAdi = doktor.Adi + " " + doktor.Soyadi;
                re.PoliklinikAdi = ran.Poliklinik.Adi;
                re.Tarih = ran.Tarih;
                if (ran.StatusTypeId == (int)StatusTypeEnum.Delete)
                    re.Durum = "Silinmiş";
                else if (ran.Tarih < DateTime.Now)
                    re.Durum = "Geçmiş";
                else re.Durum = "Aktif";
                list.Add(re);
            }
            return list;
        }

        public static bool RandevuIptal(int randevuId)
        {
            var db = Helper.CreateContext;

            var randevu = db.HastaRandevu.FirstOrDefault(t => t.RecId == randevuId);
            if (randevu == null)
                return false;

            randevu.StatusTypeId = StatusTypeEnum.Delete.GetHashCode();

            HastaRandevu hr = new HastaRandevu();
            hr.Tarih = randevu.Tarih;
            hr.DoktorId = randevu.DoktorId;
            hr.PoliklinikId = randevu.PoliklinikId;
            hr.StatusTypeId = StatusTypeEnum.Active.GetHashCode();
            db.HastaRandevu.Add(hr);

            db.SaveChanges();

            return true;
        }



        public static List<RandevuEntity> DoktorRandevulari(int poliklinikId)
        {
            List<RandevuEntity> list = new List<RandevuEntity>();

            DateTime date1 = DateTime.Now;
            DateTime date2 = DateTime.Now.AddHours(23).AddMinutes(59).AddSeconds(59);

            var db = Helper.CreateContext;

            var randevular = db.HastaRandevu.Where(t => t.PoliklinikId == poliklinikId && t.DoktorId == SessionManager.Kullanici.DoktorId && t.HastaId.HasValue && t.Tarih >= date1 && t.Tarih <= date2).ToList();
            if (randevular.Count <= 0)
                return list;

            foreach (var randevu in randevular.OrderBy(t => t.Tarih))
            {
                RandevuEntity re = new RandevuEntity();
                re.Tarih = randevu.Tarih;
                var hasta = randevu.Hasta.KullaniciBilgileri;
                re.HastaAdi = hasta.Adi + " " + hasta.Soyadi;
                list.Add(re);
            }
            return list;
        }

        public static List<MusaitRandevuEntity> DoktorRandevuSaatleriOlustur(DateTime date1, int poliklinikId)
        {
            List<MusaitRandevuEntity> list = new List<MusaitRandevuEntity>();

            var db = Helper.CreateContext;



            DateTime date2 = date1.AddHours(17);
            date1 = date1.AddHours(09);

            var randevular = (from h in db.HastaRandevu
                              where h.DoktorId == SessionManager.Kullanici.DoktorId
                              && h.PoliklinikId == poliklinikId
                              && h.StatusTypeId == (int)StatusTypeEnum.Active
                              && h.Tarih >= date1
                              && h.Tarih <= date2
                              select new
                              {
                                  h.RecId,
                                  h.Tarih,
                                  h.StatusTypeId,
                                  h.HastaId
                              }).ToList();


            for (DateTime d = date1; d < date2;)
            {
                var item = randevular.FirstOrDefault(t => t.Tarih == d);
                MusaitRandevuEntity mre = new MusaitRandevuEntity();
                mre.PoliklinikId = poliklinikId;
                mre.Saat = d.ToString("HH:mm");
                mre.Tarih = d;
                mre.RecId = item != null ? item.RecId : 0;
                list.Add(mre);
                d = d.AddMinutes(20);
            }
            return list;

        }

        public static bool DoktorRandevuOlustur(List<MusaitRandevuEntity> list)
        {
            var db = Helper.CreateContext;


            foreach (var ran in list)
            {
                var randevu = db.HastaRandevu.FirstOrDefault(t => t.PoliklinikId == ran.PoliklinikId && t.Tarih == ran.Tarih && t.DoktorId == SessionManager.Kullanici.DoktorId);
                if (randevu != null)
                    continue;

                randevu = new HastaRandevu();
                randevu.DoktorId = SessionManager.Kullanici.DoktorId.Value;
                randevu.PoliklinikId = ran.PoliklinikId;
                randevu.Tarih = ran.Tarih;
                randevu.StatusTypeId = StatusTypeEnum.Active.GetHashCode();
                db.HastaRandevu.Add(randevu);


            }
            db.SaveChanges();

            return true;

        }

        #region Service


        public static List<AppointmentListResponse> GetAppointmentList(AppointmentListRequest req)
        {
            List<AppointmentListResponse> list = new List<AppointmentListResponse>();

            var db = Helper.CreateContext;

            var appointments = db.HastaRandevu.Where(t => t.HastaId == req.Id);

            foreach (var ran in appointments)
            {
                AppointmentListResponse re = new AppointmentListResponse();
                re.Id = ran.RecId;
                var doktor = ran.Doktor.KullaniciBilgileri;
                re.DoctorName = doktor.Adi + " " + doktor.Soyadi;
                re.PoliklinikName = ran.Poliklinik.Adi;
                re.Date = ran.Tarih.ToString("dd/MM/yyyy HH:mm");
                if (ran.StatusTypeId == (int)StatusTypeEnum.Delete)
                    re.Status = "Silinmiş";
                else if (ran.Tarih < DateTime.Now)
                    re.Status = "Geçmiş";
                else re.Status = "Aktif";
                list.Add(re);
            }
            return list;
        }


        public static bool CancelAppointment(AppointmentListRequest req)
        {
            var db = Helper.CreateContext;

            var randevu = db.HastaRandevu.FirstOrDefault(t => t.RecId == req.Id && t.StatusTypeId == (int)StatusTypeEnum.Active);
            if (randevu == null)
                return false;

            randevu.StatusTypeId = StatusTypeEnum.Delete.GetHashCode();

            HastaRandevu hr = new HastaRandevu();
            hr.Tarih = randevu.Tarih;
            hr.DoktorId = randevu.DoktorId;
            hr.PoliklinikId = randevu.PoliklinikId;
            hr.StatusTypeId = StatusTypeEnum.Active.GetHashCode();
            db.HastaRandevu.Add(hr);

            db.SaveChanges();

            return true;
        }


        public static List<AvailableAppointmentResponse> GetAvailableAppointments(AvailableAppointmentRequest request)
        {
            List<AvailableAppointmentResponse> list = new List<AvailableAppointmentResponse>();

            var db = Helper.CreateContext;

            DateTime date1 = request.Date.ToDateTime().Date7().ToDateTime();
            DateTime date2 = date1.AddDays(1).AddSeconds(-1);

            var appointments = (from h in db.HastaRandevu
                                where h.PoliklinikId == request.PoliklinikId
                                && h.DoktorId == request.DoctorId
                                && h.StatusTypeId == (int)StatusTypeEnum.Active
                                && !h.HastaId.HasValue
                               && h.Tarih >= date1
                               && h.Tarih <= date2
                                select new
                                {
                                    h.RecId,
                                    h.Tarih,
                                    h.StatusTypeId,
                                    h.HastaId
                                }).ToList();
            foreach (var item in appointments)
            {
                AvailableAppointmentResponse ap = new AvailableAppointmentResponse();
                ap.Id = item.RecId;
                ap.Date = item.Tarih.Date10();
                list.Add(ap);

            }
            return list;
        }


        public static CreateAppointmentResponse CreateAppointment(CreateAppointmentRequest req)
        {

            var db = Helper.CreateContext;

            var randevu = db.HastaRandevu.FirstOrDefault(t => t.RecId == req.Id && !t.HastaId.HasValue);
            if (randevu == null)
                throw new Exception("Başka hasta tarfından alındı.");

            randevu.HastaId = req.PatientId;
            db.SaveChanges();

            CreateAppointmentResponse ca = new CreateAppointmentResponse();
            ca.Id = randevu.RecId;
            ca.Date = randevu.Tarih.ToString("dd/MM/yyyy HH:mm");
            return ca;
        }

        #endregion






    }
}
