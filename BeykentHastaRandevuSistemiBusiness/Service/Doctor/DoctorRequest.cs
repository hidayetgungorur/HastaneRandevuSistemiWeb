using BeykentHastaRandevuSistemiBusiness.Service.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BeykentHastaRandevuSistemiBusiness.Service.Doctor
{

        [DataContract]
        public class DoctorRequest
        {
            [DataMember]
            public HeaderRequest HeaderRequest { get; set; }

        [DataMember]
        public int PoliklinikId { get; set; }

    }
}
