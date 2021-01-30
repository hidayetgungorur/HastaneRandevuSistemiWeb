using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeykentHastaRandevuSistemiBusiness.Hasta
{
  public  class RandevularimEntity
    {
        public int RecId { get; set; }
        public DateTime Tarih { get; set; }

        public string DoktorAdi { get; set; }

        public string PoliklinikAdi { get; set; }

        public string Durum { get; set; }
    }
}
