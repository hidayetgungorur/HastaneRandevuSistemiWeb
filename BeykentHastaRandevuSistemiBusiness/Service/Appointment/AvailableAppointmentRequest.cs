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
    public class AvailableAppointmentRequest
    {
        [DataMember]
        public HeaderRequest HeaderRequest { get; set; }

        [DataMember]
        public int DoctorId { get; set; }

        [DataMember]
        public int PoliklinikId { get; set; }

        [DataMember]
        public string Date { get; set; }


    }
}
