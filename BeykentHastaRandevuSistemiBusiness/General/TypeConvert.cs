using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeykentHastaRandevuSistemiBusiness.General
{
  public static  class TypeConvert
    {
        private static DateTimeFormatInfo DateTimeFormat = new CultureInfo("tr-TR").DateTimeFormat;
        private static string decsprt = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        /// <summary>
        /// Istenilen veriyi Datetime  çevirir ,eğer null ise default olarak TypeConvert.DateTimeNowUtc  dondurur.
        /// </summary>
        /// <param name="value">Datetime çevrilecek  veri</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this object value)
        {
            try
            {
                if (value == null || string.IsNullOrEmpty(value.ToString()))
                    return DateTime.Now;

                return Convert.ToDateTime(value, DateTimeFormat);
            }
            catch
            {
                return DateTime.Now;
            }
        }

        public static string Date7(this DateTime dt)
        {
            return dt.ToString("dd.MM.yyyy");
        }
        public static string Date10(this DateTime dt)
        {
            return dt.ToString("dd.MM.yyyy HH:mm");
        }

        /// <summary>
        /// Istenilen verinin int a çevirir
        /// </summary>
        /// <param name="value">Int a çevrilecek  veri </param>
        /// <param name="defaultvalue">Çevrilecek veri null ise otomatik olarak dönecek sonuç  </param>
        /// <returns></returns>
        public static int ToInt(this object value, int defaultvalue)
        {
            try
            {
                if (value == null || string.IsNullOrEmpty(value.ToString()))
                    return defaultvalue;

                value = value.ToString().Replace(".", decsprt).Replace(",", decsprt);

                return Convert.ToInt32(value);
            }
            catch
            {
                return defaultvalue;
            }
            
        }
        
    }
}
