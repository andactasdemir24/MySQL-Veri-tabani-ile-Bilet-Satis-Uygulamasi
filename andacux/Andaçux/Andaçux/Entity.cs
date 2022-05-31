using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andaçux
{
    public class Uye
    {
        public Guid ID { get; set; }
        public string Ad { get; set; }
        public string SoyAd { get; set; }
        public string Telefon { get; set; }
        public string Tc { get; set; }
        public string Mail { get; set; }
        public string Şehir { get; set; }
        public string Yaş { get; set; }
        public string Adres { get; set; }

        public override string ToString()
        {
            return $"{Ad} {SoyAd}";
        }
    }
       
    public class Bilet
    {
        public Guid ID { get; set; }
        public string Ad { get; set; }
        public string Adet { get; set; }
        public string Kategori { get; set; }
        public double Fiyat { get; set; }
        public string Adres { get; set; }

        public override string ToString()
        {
            return $"{Ad} {Adres}";
        }
    }

    public class Satis
    {
        public Guid ID { get; set; }
        public Guid UyeID { get; set; }
        public Guid BiletID { get; set; }
        public DateTime Tarih { get; set; }
        public double Fiyat { get; set; }

    }
    
    public class Odeme
    {
        public Guid ID { get; set; }
        public Guid UyeID { get; set; }
        public DateTime Tarih { get; set; }
        public double Tutar { get; set; }
        public string Tür { get; set; }
        public string Açıklama { get; set; }

    }

}
