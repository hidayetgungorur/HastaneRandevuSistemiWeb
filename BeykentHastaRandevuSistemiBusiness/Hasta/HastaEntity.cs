using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeykentHastaRandevuSistemiBusiness.Hasta
{
   public class HastaEntity
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string KimlikNo { get; set; }
        public int? Cinsiyet { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public string CepNumarasi { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
    }
}
