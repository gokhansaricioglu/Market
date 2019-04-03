using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace Market
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            FakeDB.VerileriDoldur();
            InitializeComponent();
        }

        private void BtnKayitOl_Click(object sender, EventArgs e)
        {
            // Kullanıcı adi Daha önce alnmış olmamalı
            var kullanici = FakeDB.Kullanicilar.Any(x => x.KullaniciAdi == TbKullaniciAdi.Text);
            var sifrecik = FakeDB.Kullanicilar.Any(y => y.Sifre == TbSifre.Text);
            if (kullanici == true)
            {
                MessageBox.Show("bu isimden var");
            }
            else if (sifrecik == true)
            {
                MessageBox.Show("Lütfen farklı sifre dene");
            }

        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            //Kullanici Adi ve Şifre FakeDB'dekilerle uyuşuyor mu?
            bool giris = FakeDB.Kullanicilar.Any(x => x.KullaniciAdi == TbKullaniciAdi.Text && x.Sifre == TbSifre.Text);
            if (giris == true)
            {
                MessageBox.Show("Girdin");
            }
            else
            {
                MessageBox.Show("Dogru bişey gir");
            }

        }

        private void BtnBireyselSatis_Click(object sender, EventArgs e)
        {
            //LbSatis'e bireysel Kullanicilar tarafindan alınan ürünler
            // AlanKişinin Kullanici Adi Urunun Adi ve Fiyati
            var bSatis = FakeDB.Satislar.Where(x => x.AlanKisi.KullaniciTipi == KullaniciTipi.Bireysel)
                                        .Select(y => new { y.AlanKisi.KullaniciAdi,                    y.SatilanUrun.UrunAdi, y.SatilanUrun.SatisFiyati });
            LbSatis.DataSource = bSatis.ToList();

        }

        private void BtnKurumsalSatis_Click(object sender, EventArgs e)
        {
            //LbSatis'e Kurumsal Kullanicilar tarafindan alınan ürünler
            // AlanKişinin Kullanici Adi Urunun Adi ve Fiyati
            var kSatis = FakeDB.Satislar.Where(x => x.AlanKisi.KullaniciTipi == KullaniciTipi.Kurumsal)
                                        .Select(y => new { y.AlanKisi.KullaniciAdi, y.SatilanUrun.UrunAdi, y.SatilanUrun.SatisFiyati });
            LbSatis.DataSource = kSatis.ToList();
        }

        private void BtnSatisTarihiGecmis_Click(object sender, EventArgs e)
        {
            // LBSatisTarih'e Satilirken SKT'si geçmiş olan ürünleri Listele
            // AlanKişinin Kullanici Adi Urunun Adi ve Fiyati
            var listele = FakeDB.Satislar.Where(x => x.SatilanUrun.SonKullanmaTarihi < x.SatisTarihi)
                .Select(y => new { y.AlanKisi.KullaniciAdi, y.SatilanUrun.UrunAdi, y.SatilanUrun.SatisFiyati });
            LbSatisTarih.DataSource = listele.ToList();
            
            
        }

        private void BtnTarihiGecmis_Click(object sender, EventArgs e)
        {
            // LBSatisTarih'e  SKT'si geçmiş olan ürünleri Listele
            // Urunun Adi ve Fiyati
            var tarihigecenler = FakeDB.Urunler.Where(x => x.SonKullanmaTarihi > DateTime.Now)
                .Select(y => new { y.UrunAdi, y.SatisFiyati });
            LbSatisTarih.DataSource = tarihigecenler.ToList();

        }

        private void BtnFiyatiDusuk_Click(object sender, EventArgs e)
        {
            //Fiyati TbFiyattan düşük olan ürün Var mı ? 
            // Var ise Bu ürünleri LbFiyata yazalım
            // Urunun Adi ve Fiyati
            var dusuk = FakeDB.Urunler.Where(x => x.SatisFiyati < Convert.ToDouble(TbFiyat.Text))
                .Select(y => new { y.UrunAdi, y.SatisFiyati });
            LbFiyat.DataSource = dusuk.ToList();
        }

        private void BtnFiyatiYuksek_Click(object sender, EventArgs e)
        {
            //Fiyati TbFiyattan Yüksek olan ürün Var mı ? 
            // Var ise Bu ürünleri LbFiyata yazalım
            // Urunun Adi ve Fiyati
            var dusuk = FakeDB.Urunler.Where(x => x.SatisFiyati > Convert.ToDouble(TbFiyat.Text))
                .Select(y => new { y.UrunAdi, y.SatisFiyati });
            LbFiyat.DataSource = dusuk.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tekGrup = FakeDB.Satislar.GroupBy(x => x.AlanKisi.KullaniciTipi, (key, list) =>
               {
                   return new
                   {
                       KullaniciTip = key,
                       KullaniciTuruSatisAdedi = list.Count()
                   };
               });
            var gruplu = FakeDB.Satislar.GroupBy(x => new { x.SatilanUrun.UrunTuru, x.AlanKisi.KullaniciTipi },
                (key, list) =>
                {
                    return new
                    {
                        KullaniciTip = key.KullaniciTipi,
                        Urunler = key.UrunTuru,
                        KullaniciTuruSatisAdedi = list.Count(),
                        kullaniciTuruS = list

                    };
                });
            foreach (var item in gruplu)
            {
                MessageBox.Show(item.Urunler + " " + item.KullaniciTip + " " + item.KullaniciTuruSatisAdedi);
            }
                

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var deney = FakeDB.Urunler.FirstOrDefault(x => x.SatisFiyati ==Convert.ToDouble( TbFiyat.Text));

           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var selam = FakeDB.Satislar.FirstOrDefault(x => x.AlanKisi.KullaniciTipi == KullaniciTipi.Kurumsal)
                .SatilanUrun.AlisFiyati;
            var selam2 = FakeDB.Satislar.FirstOrDefault(x => x.AlanKisi.KullaniciTipi == KullaniciTipi.Kurumsal)
                .Adet;

            


            MessageBox.Show(selam.ToString());
            MessageBox.Show(selam2.ToString());




        }
    }
}
