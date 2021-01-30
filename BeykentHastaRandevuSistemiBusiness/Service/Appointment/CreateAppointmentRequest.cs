using BeykentHastaRandevuSistemiBusiness.Service.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BeykentHastaRandevuSistemiBusiness.Service.Appointment
{
   
    [DataContract]
    public class CreateAppointmentRequest
    {
        [DataMember]
        public HeaderRequest HeaderRequest { get; set; }

        [DataMember]
        public int PatientId { get; set; }
        
        [DataMember]
        public int Id { get; set; }


    }
}
