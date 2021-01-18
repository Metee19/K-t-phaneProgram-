using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using KütüphaneProgramı.Dal;
using KütüphaneProgramı.Entities;
using System.Data;
namespace KütüphaneProgramı.Business
{
   public class KitapBusiness //KitapKayit tablosu için iş katmanı 
    {
        KitapDal kitap;

        public KitapBusiness(string path)
        {
            kitap = new KitapDal(path);// gelen database pathini data access layer ına iletiyor
        }
        public int Ekle(KitapEntities ktp)//ögrenci ekleneceği zaman
        {
            return kitap.Ekle(ktp);//data acces layer için ögrenci bilgilerini gönderiyor
        }
        public DataSet GetList(string query)//veri çekmek için 
        {
            return kitap.GetList(query);//data access layer e sorguyu dönderip veri kümesi alıyor
        }

        public int Sil(int id)//veri silmek için 
        {
            return kitap.Sil(id);//verilen id ye göre veri silmek için 
        }

        public int Guncelle(KitapEntities kitapEntities)
        {
            return kitap.Guncelle(kitapEntities);
        }

    }
}
