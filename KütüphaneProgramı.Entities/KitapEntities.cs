using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KütüphaneProgramı.Entities
{
    public class KitapEntities //KitapKayit veritabanı için degişkenler
    {
        public int kitapid { get; set; }
        public string ad { get; set; }
        public string yazar { get; set; }
        public string tur { get; set; }
        public int barkodno { get; set; }
        public string durum { get; set; }
    }
}
