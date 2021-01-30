using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeykentHastaRandevuSistemiBusiness.General.Doktor
{
   public class MusaitRandevuEntity
    {
        public int? RecId { get; set; }
        public DateTime Tarih { get; set; }
        public int PoliklinikId { get; set; }
        public string Saat { get; set; }

    }
}
