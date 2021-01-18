using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KütüphaneProgramı.Entities
{
    public class OgrEntities //OgrKayit tablosunun degişkenleri
    {
        public int id { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string tc { get; set; }
        public string mail { get; set; }
        public string telefon { get; set; }
    }
}
