using BeykentHastaRandevuSistemiBusiness.General;
using BeykentHastaRandevuSistemiBusiness.General.Login;
using BeykentHastaRandevuSistemiBusiness.Hasta;
using BeykentHastaRandevuSistemiBusiness.Service.Account;
using BeykentHastaRandevuSistemiBusiness.Service.Appointment;
using BeykentHastaRandevuSistemiBusiness.Service.Doctor;
using BeykentHastaRandevuSistemiBusiness.Service.General;
using BeykentHastaRandevuSistemiBusiness.Service.Login;
using BeykentHastaRandevuSistemiBusiness.Service.Poliklinik;
using BHRSWebService.Error;
using BHRSWebService.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Web.Services;

namespace BHRSWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BHRSService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BHRSService.svc or BHRSService.svc.cs at the Solution Explorer and start debugging.
    [GlobalErrorBehaviorAttribute(typeof(GlobalErrorHandler))]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class BHRSService : IBHRSService
    {
        [WebMethod]
        public Result<LoginResponse> Login(LoginRequest request)
        {
            Result<LoginResponse> result = new Result<LoginResponse>();
            try
            {
                request.CheckLoginRequest();
                result.Response = LoginManager.Login(request);
            }
            catch (Exception ex)
            {
                result.ErrorCode = "SE";
                result.ErrorMessage = ex.Message;
                result.HasError = true;
            }
            return result;
        }

        [WebMethod]
        public Result<AccountResponse> CreateAccount(AccountRequest request)
        {
            Result<AccountResponse> result = new Result<AccountResponse>();
            try
            {
                request.CheckAccountRequest();
                result.Response = HastaManager.CreateAccount(request);
            }
            catch (Exception ex)
            {
                result.ErrorCode = "SE";
                result.ErrorMessage = ex.Message;
                result.HasError = true;
            }
            return result;
        }


        [WebMethod]
        public Result<AccountResponse> UpdateAccount(AccountRequest request)
        {
            Result<AccountResponse> result = new Result<AccountResponse>();
            try
            {
                request.CheckAccountRequest();
                result.Response = HastaManager.UpdateAccount(request);
            }
            catch (Exception ex)
            {
                result.ErrorCode = "SE";
                result.ErrorMessage = ex.Message;
                result.HasError = true;
            }
            return result;
        }


        [WebMethod]
        public Result<List<AppointmentListResponse>> GetAppointmentList(AppointmentListRequest request)
        {
            Result<List<AppointmentListResponse>> result = new Result<List<AppointmentListResponse>>();
            try
            {
                request.CheckAppointmentListRequest();
                result.Response = RandevuManager.GetAppointmentList(request);
            }
            catch (Exception ex)
            {
                result.ErrorCode = "SE";
                result.ErrorMessage = ex.Message;
                result.HasError = true;
            }
            return result;
        }

        [WebMethod]
        public Result<bool> CancelAppointment(AppointmentListRequest request)
        {
            Result<bool> result = new Result<bool>();
            try
            {
                request.CheckAppointmentListRequest();
                result.Response = RandevuManager.CancelAppointment(request);
            }
            catch (Exception ex)
            {
                result.ErrorCode = "SE";
                result.ErrorMessage = ex.Message;
                result.HasError = true;
            }
            return result;
        }

        
        [WebMethod]
        public Result<List<PoliklinikResponse>> GetPolikliniks(PoliklinikRequest request)
        {
            Result<List<PoliklinikResponse>> result = new Result<List<PoliklinikResponse>>();
            try
            {
                request.CheckPoliklinikRequest();
                result.Response = GeneralManager.GetPolikliniks();
            }
            catch (Exception ex)
            {
                result.ErrorCode = "SE";
                result.ErrorMessage = ex.Message;
                result.HasError = true;
            }
            return result;
        }

        [WebMethod]
        public Result<List<DoctorResponse>> GetPoliklinikDoctors(DoctorRequest request)
        {
            Result<List<DoctorResponse>> result = new Result<List<DoctorResponse>>();
            try
            {
                request.CheckDoctorRequest();
                result.Response = GeneralManager.GetPoliklinikDoctors(request);
            }
            catch (Exception ex)
            {
                result.ErrorCode = "SE";
                result.ErrorMessage = ex.Message;
                result.HasError = true;
            }
            return result;
        }


        [WebMethod]
        public Result<List<AvailableAppointmentResponse>> GetAvailableAppointments(AvailableAppointmentRequest request)
        {
            Result<List<AvailableAppointmentResponse>> result = new Result<List<AvailableAppointmentResponse>>();
            try
            {
                request.CheckAvailableAppointmentRequest();
                result.Response = RandevuManager.GetAvailableAppointments(request);
            }
            catch (Exception ex)
            {
                result.ErrorCode = "SE";
                result.ErrorMessage = ex.Message;
                result.HasError = true;
            }
            return result;
        }

        [WebMethod]
        public Result<CreateAppointmentResponse> CreateAppointment(CreateAppointmentRequest request)
        {
            Result<CreateAppointmentResponse> result = new Result<CreateAppointmentResponse>();
            try
            {
                request.CheckCreateAppointmentRequest();
                result.Response = RandevuManager.CreateAppointment(request);
            }
            catch (Exception ex)
            {
                result.ErrorCode = "SE";
                result.ErrorMessage = ex.Message;
                result.HasError = true;
            }
            return result;
        }



    }
}
