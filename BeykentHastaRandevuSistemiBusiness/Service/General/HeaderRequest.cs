using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BeykentHastaRandevuSistemiBusiness.Service.General
{
    [DataContract]
    public class HeaderRequest
    {
        [DataMember]
        public string ChannelCode { get; set; }

        [DataMember]
        public string ChannelPassword { get; set; }

    }
}
