using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeykentHastaRandevuSistemiData
{
    public static class Helper
    {
        /// <summary>
        /// Db ile Connection oluşturur 
        /// </summary>
        public static BHRSEntities CreateContext
        {
            get
            {

                return new BHRSEntities();
            }
        }


    }
}
