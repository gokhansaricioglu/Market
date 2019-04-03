using System;
using System.Windows.Forms;

namespace Market
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnKayitOl_Click(object sender, EventArgs e)
        {
            // Kullanıcı adi Daha önce alnmış olmamalı
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            //Kullanici Adi ve Şifre FakeDB'dekilerle uyuşuyor mu?
        }

        private void BtnBireyselSatis_Click(object sender, EventArgs e)
        {
            //LbSatis'e bireysel Kullanicilar tarafindan alınan ürünler
            // AlanKişinin Kullanici Adi Urunun Adi ve Fiyati
        }

        private void BtnKurumsalSatis_Click(object sender, EventArgs e)
        {
            //LbSatis'e Kurumsal Kullanicilar tarafindan alınan ürünler
            // AlanKişinin Kullanici Adi Urunun Adi ve Fiyati
        }

        private void BtnSatisTarihiGecmis_Click(object sender, EventArgs e)
        {
            // LBSatisTarih'e Satilirken SKT'si geçmiş olan ürünleri Listele
            // AlanKişinin Kullanici Adi Urunun Adi ve Fiyati
        }

        private void BtnTarihiGecmis_Click(object sender, EventArgs e)
        {
            // LBSatisTarih'e  SKT'si geçmiş olan ürünleri Listele
            // Urunun Adi ve Fiyati

        }

        private void BtnFiyatiDusuk_Click(object sender, EventArgs e)
        {
            //Fiyati TbFiyattan düşük olan ürün Var mı ? 
            // Var ise Bu ürünleri LbFiyata yazalım
            // Urunun Adi ve Fiyati
        }

        private void BtnFiyatiYuksek_Click(object sender, EventArgs e)
        {
            //Fiyati TbFiyattan Yüksek olan ürün Var mı ? 
            // Var ise Bu ürünleri LbFiyata yazalım
            // Urunun Adi ve Fiyati
        }
    }
}
