using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market
{
    public enum UrunTuru
    {
        Yiyecek,
        Giyim,
        EvBakim,
        KisiselBakim
    }
    public class Urun
    {
        public string UrunId { get; set; }
        public string UrunAdi { get; set; }
        public UrunTuru UrunTuru { get; set; }
        public double AlisFiyati { get; set; }
        public double SatisFiyati { get; set; }
        public DateTime SonKullanmaTarihi { get; set; }
        public Urun(string urunAdi, UrunTuru urunTuru)
        {
            UrunId = Guid.NewGuid().ToString();
            UrunAdi = urunAdi;
            UrunTuru = urunTuru;
            Random rnd = new Random();
            AlisFiyati = rnd.Next(0, 80);
            SatisFiyati = AlisFiyati + (AlisFiyati * rnd.Next(40) / 100);
            SonKullanmaTarihi = new DateTime(rnd.Next(2017, 2020), rnd.Next(1, 13), rnd.Next(1, 28));
        }
    }
}
