using BeykentHastaRandevuSistemiBusiness.Service.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BeykentHastaRandevuSistemiBusiness.Service.Poliklinik
{
  
        [DataContract]
        public class PoliklinikRequest
        {
            [DataMember]
            public HeaderRequest HeaderRequest { get; set; }
        }
}
