using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BeykentHastaRandevuSistemiBusiness.Service.Appointment
{
    
        [DataContract]
        public class AppointmentListResponse
        {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
          public string DoctorName { get; set; }

        [DataMember]
        public string PoliklinikName { get; set; }

        [DataMember]
        public string Date { get; set; }

        [DataMember]
        public string Status { get; set; }
        
    }
}
