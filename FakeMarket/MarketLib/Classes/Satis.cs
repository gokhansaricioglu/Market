using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market
{
    public class Satis
    {
        public Satis(Kullanici alanKisi, Urun satilanUrun)
        {
            SatisId = Guid.NewGuid().ToString();
            Random rnd = new Random();
            AlanKisi = alanKisi;
            SatilanUrun = satilanUrun;
            Adet = rnd.Next(1,11);
            SatisTarihi = 
                new DateTime(rnd.Next(2017, 2020), rnd.Next(1, 13), rnd.Next(1, 28));
        }

        public string SatisId { get; set; }
        public Kullanici AlanKisi { get; set; }
        public Urun SatilanUrun { get; set; }
        public int Adet { get; set; }
        public DateTime SatisTarihi { get; set; }
    }
}
