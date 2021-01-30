using BeykentHastaRandevuSistemiBusiness.Service.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BeykentHastaRandevuSistemiBusiness.Service.Account
{

    [DataContract]
    public class AccountRequest
    {
        [DataMember]
        public HeaderRequest HeaderRequest { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string TC { get; set; }
        
        [DataMember]
        public string BirthDate { get; set; }
        
        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public int GenderType { get; set; }

        [DataMember]
        public string Password { get; set; }

    }
}
