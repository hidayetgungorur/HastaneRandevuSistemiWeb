using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BeykentHastaRandevuSistemiBusiness.Service.Login
{
    
    [DataContract]
    public class LoginResponse 
    {
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string DoctorId { get; set; }

        [DataMember]
        public string PatientId { get; set; }

        [DataMember]
        public string UserId { get; set; }

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
