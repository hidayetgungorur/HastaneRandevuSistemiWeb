using BeykentHastaRandevuSistemiBusiness.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeykentHastaRandevuSistemiBusiness.General
{
   public class RandevuMusaitEntity
    {
        public DateTime Tarih { get; set; }
        public List<RandevuMusaitItemEntity> Items { get; set; }


    }

    public class RandevuMusaitItemEntity
    {
        public int RecId { get; set; }
        public string Saat { get; set; }
        public int HastaId { get; set; }
        public StatusTypeEnum StatusType { get; set; }
    }
}
