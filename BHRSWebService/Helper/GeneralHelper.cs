using BeykentHastaRandevuSistemiBusiness.Service.Account;
using BeykentHastaRandevuSistemiBusiness.Service.Appointment;
using BeykentHastaRandevuSistemiBusiness.Service.Doctor;
using BeykentHastaRandevuSistemiBusiness.Service.General;
using BeykentHastaRandevuSistemiBusiness.Service.Login;
using BeykentHastaRandevuSistemiBusiness.Service.Poliklinik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BHRSWebService.Helper
{
    public static class GeneralHelper
    {
        public static void CheckRequest(this HeaderRequest request)
        {
            if (request == null)
                throw new Exception("Geçersiz HeaderRequest");


            if (request.ChannelCode != "BHRSWeb" || request.ChannelPassword != "SHFYM2020")
                 throw new Exception("Geçersiz Channel Bilgileri.");
        }


        public static void CheckLoginRequest(this LoginRequest request)
        {
            if (request == null)
                throw new Exception("Geçersiz Request");

            request.HeaderRequest.CheckRequest();
        }

        public static void CheckAccountRequest(this AccountRequest request)
        {
            if (request == null)
                throw new Exception("Geçersiz Request");

            request.HeaderRequest.CheckRequest();
        }
        public static void CheckAppointmentListRequest(this AppointmentListRequest request)
        {
            if (request == null)
                throw new Exception("Geçersiz Request");

            request.HeaderRequest.CheckRequest();
        }


        public static void CheckDoctorRequest(this DoctorRequest request)
        {
            if (request == null)
                throw new Exception("Geçersiz Request");

            request.HeaderRequest.CheckRequest();
        }

        public static void CheckPoliklinikRequest(this PoliklinikRequest request)
        {
            if (request == null)
                throw new Exception("Geçersiz Request");

            request.HeaderRequest.CheckRequest();
        }

        public static void CheckAvailableAppointmentRequest(this AvailableAppointmentRequest request)
        {
            if (request == null)
                throw new Exception("Geçersiz Request");

            request.HeaderRequest.CheckRequest();
        }
        public static void CheckCreateAppointmentRequest(this CreateAppointmentRequest request)
        {
            if (request == null)
                throw new Exception("Geçersiz Request");

            request.HeaderRequest.CheckRequest();
        }

    }
}