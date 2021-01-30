using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeykentHastaRandevuSistemiBusiness.General.Kullanici
{
    public  class KullaniciEntity
    {
        public int KullaniciId { get; set; }
        public int? HastaId { get; set; }
        public int? DoktorId { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public bool IsDoktor { get; set; }
        public string KimlikNumarasi { get; set; }
        public int Cinsiyet { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string CepNumarasi { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }


    }
}
