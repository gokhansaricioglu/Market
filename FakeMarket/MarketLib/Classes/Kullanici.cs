using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market
{
    public enum KullaniciTipi
    {
        Kurumsal,
        Bireysel
    }
    public class Kullanici
    {
        public Kullanici(string kullaniciAdi, string sifre, DateTime dogumTarihi)
        {
            KullaniciAdi = kullaniciAdi;
            Sifre = sifre;
            DogumTarihi = dogumTarihi;
            KullaniciId = Guid.NewGuid().ToString();
        }

        public string KullaniciId { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public DateTime DogumTarihi { get; set; }
        public KullaniciTipi KullaniciTipi = KullaniciTipi.Bireysel;
    }
}
