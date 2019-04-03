using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market
{
    public static class FakeDB
    {
        public static List<Kullanici> Kullanicilar = new List<Kullanici>();
        public static List<Urun> Urunler = new List<Urun>();
        public static List<Satis> Satislar = new List<Satis>();
        public static void VerileriDoldur()
        {
            Kullanici mahmut = new Kullanici("mahmut", "123456", new DateTime(1995, 08, 08));
            Kullanici omer = new Kullanici("omer", "123456", new DateTime(1995, 11, 18));
            Kullanici tuncer = new Kullanici("tuncer", "123456", new DateTime(1995, 01, 22));
            Kullanici onemli = new Kullanici("kurumsal", "123456", new DateTime(1995, 10, 08));
            onemli.KullaniciTipi = KullaniciTipi.Kurumsal;
            Kullanici onemli2 = new Kullanici("kurumsalDiger", "123456", new DateTime(1995, 01, 15));
            onemli2.KullaniciTipi = KullaniciTipi.Kurumsal;

            Kullanicilar.Add(mahmut);
            Kullanicilar.Add(omer);
            Kullanicilar.Add(tuncer);
            Kullanicilar.Add(onemli);
            Kullanicilar.Add(onemli2);

            Urun urun = new Urun("Çikolata", UrunTuru.Yiyecek); 
            Urun urun2 = new Urun("Hoodie", UrunTuru.Giyim); 
            Urun urun3 = new Urun("Süpürge", UrunTuru.EvBakim); 
            Urun urun4 = new Urun("Şampuan", UrunTuru.KisiselBakim);

            Urunler.Add(urun);
            Urunler.Add(urun2);
            Urunler.Add(urun3);
            Urunler.Add(urun4);

            for (int i = 1; i <= 44; i++)
            {
                Urun varOlanUrun = Urunler[i % 4];
                Urun rndUrun = new Urun(varOlanUrun.UrunAdi + i.ToString(), varOlanUrun.UrunTuru);
            }

            Random random = new Random();
            for (int i = 0; i < 180; i++)
            {
                int aliciKisiIndis = random.Next(0, Kullanicilar.Count);
                int urunIndis = random.Next(0, Urunler.Count);
                Satislar.Add(new Satis(Kullanicilar[aliciKisiIndis], Urunler[urunIndis]));

            }

        }
    }
}
