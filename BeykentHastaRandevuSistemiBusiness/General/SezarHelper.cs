using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeykentHastaRandevuSistemiBusiness.General
{
    public static class SezarHelper
    {


        private static bool TurkceMi(char harf)
        {
            return harf == 'ç' || harf == 'Ç' || harf == 'ğ' || harf == 'Ğ' || harf == 'ı' || harf == 'İ' || harf == 'ö' || harf == 'Ö' || harf == 'ş' || harf == 'Ş' || harf == 'ü' || harf == 'Ü';
        }

        private static char Sifrele(char harf, int atlamasayisi)
        {
            if (!char.IsLetter(harf) || TurkceMi(harf))// Eğer karakterler harf değilse ve Türkçe ise, olduğu gibi sifre_yazi değişkenine aktarılıyor
                return harf;

            int basladecId = char.IsUpper(harf) ? 65 : 97;// Karakter büyük harfse baslama decimal Id 65 KÜÇÜKSE 97

            return (char)(((harf - basladecId + atlamasayisi) % 26) + basladecId);
        }

        public static string Sifrele(this string orjinalyazi)
        {
            return orjinalyazi.Sifrele(8);
        }

        public static string Sifrele(this string orjinalyazi, int atlamasayisi)
        {
            var liste = orjinalyazi.ToCharArray().Reverse().ToArray();// Kelimeyi Ters çevirir/
            string sifreliyazi = string.Empty;
            Random random = new Random();


            for (int i = 1; i <= liste.Length; i++)
            {
                sifreliyazi += Sifrele(liste[i - 1], atlamasayisi);

                if (i % 3 != 0)
                    continue;

                // Her 3 harftan sonra random bir harf atar ve o herfide şifreleyerek ekler /
                int randomsayi = random.Next(65, 90);
                sifreliyazi += (char)randomsayi;
            }

            return sifreliyazi;
        }



        private static char Coz(char harf, int atlamasayisi)
        {
            if (!char.IsLetter(harf) || TurkceMi(harf))// Eğer karakterler harf değilse ve Türkçe ise
                return harf;

            int basladecId = char.IsUpper(harf) ? 65 : 97;// Karakter büyük harfse baslama decimal Id 65 KÜÇÜKSE 97

            int decId = (harf - basladecId - atlamasayisi) % 26;

            decId = decId >= 0 ? decId : decId + 26;// 0 dan küçükse harflerin dışında çıktığı için/

            return (char)(decId + basladecId);
        }

        public static string Coz(this string sifreliyazi)
        {
            return sifreliyazi.Coz(8);
        }

        public static string Coz(this string sifreliyazi, int atlamasayisi)
        {
            var liste = sifreliyazi.ToCharArray();




            string orjinalyazi = string.Empty;
            for (int i = 1; i <= liste.Length; i++)
            {
                if (i % 4 == 0) // Her 3 harftan sonra random eklenen harfi(4.harfe denk geliyor) almamak için atlar /
                    i++;

                orjinalyazi += Coz(liste[i - 1], atlamasayisi);
            }

            return new string(orjinalyazi.ToCharArray().Reverse().ToArray());// Kelimeyi Ters çevirir
        }


    }
}
