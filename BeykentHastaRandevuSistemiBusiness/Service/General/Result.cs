using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BeykentHastaRandevuSistemiBusiness.Service.General
{

    [DataContract(Name = "ResultOf{0}")]
    public class Result<T> 
    {
        [DataMember]
        public bool HasError { get; set; }
        
        [DataMember]
        public string ErrorCode { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }
        
        [DataMember]
        public T Response { get; set; }
    }
}
