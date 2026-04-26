using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani
{
    public class Makale
    {
        public int ID { get; set; }
        public int KategoriID { get; set; }
        public string Kategori { get; set; }
        public int YazarID { get; set; }
        public string Yazar { get; set; }
        public string Baslik { get; set; }
        public string Ozet { get; set; }
        public string Icerik { get; set; }
        public string KapakResim { get; set; }
        public int OkumaSayisi { get; set; }
        public int BegeniSayisi { get; set; }
        public DateTime YayinTarihi { get; set; }
        public bool AktifMi { get; set; }
        public bool SilindiMi { get; set; }
    }
}
