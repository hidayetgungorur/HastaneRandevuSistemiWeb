using BeykentHastaRandevuSistemiBusiness.Service.Account;
using BeykentHastaRandevuSistemiBusiness.Service.Appointment;
using BeykentHastaRandevuSistemiBusiness.Service.Doctor;
using BeykentHastaRandevuSistemiBusiness.Service.General;
using BeykentHastaRandevuSistemiBusiness.Service.Login;
using BeykentHastaRandevuSistemiBusiness.Service.Poliklinik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BHRSWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBHRSService" in both code and config file together.
    [ServiceContract]
    public interface IBHRSService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Login")]
        Result<LoginResponse> Login(LoginRequest request);


        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "CreateAccount")]
        Result<AccountResponse> CreateAccount(AccountRequest request);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateAccount")]
        Result<AccountResponse> UpdateAccount(AccountRequest request);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetAppointmentList")]
        Result<List<AppointmentListResponse>> GetAppointmentList(AppointmentListRequest request);


        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "CancelAppointment")]
        Result<bool> CancelAppointment(AppointmentListRequest request);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetPolikliniks")]
        Result<List<PoliklinikResponse>> GetPolikliniks(PoliklinikRequest request);


        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetPoliklinikDoctors")]
        Result<List<DoctorResponse>> GetPoliklinikDoctors(DoctorRequest request);


        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetAvailableAppointments")]
        Result<List<AvailableAppointmentResponse>> GetAvailableAppointments(AvailableAppointmentRequest request);


        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "CreateAppointment")]
        Result<CreateAppointmentResponse> CreateAppointment(CreateAppointmentRequest request);
    }
}
