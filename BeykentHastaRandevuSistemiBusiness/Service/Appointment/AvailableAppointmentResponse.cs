using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BeykentHastaRandevuSistemiBusiness.Service.Appointment
{
    [DataContract]
    public class AvailableAppointmentResponse
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Date { get; set; }
        
    }
}
