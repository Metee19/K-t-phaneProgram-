using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KütüphaneProgramı.Entities;
using KütüphaneProgramı.Dal;
using System.Data.OleDb;
using System.Data;
namespace KütüphaneProgramı.Business
{
    public class OgrBusiness //OgrKayit tablosu için iş katmanı
    {
        OgrDal ogr;
        public OgrBusiness(string path)
        {
            ogr = new OgrDal(path);// gelen database pathini data access layer ına iletiyor
        }
        public int Ekle(OgrEntities ogrr)//ögrenci ekleneceği zaman
        {
            return ogr.Ekle(ogrr);//data acces layer için ögrenci bilgilerini gönderiyor
        }

        public DataSet GetList(string query)//veri çekmek için 
        {

            return ogr.GetList(query);//data access layer e sorguyu dönderip veri kümesi alıyor
        }

        public int Sil(int id)//veri silmek için 
        {
            return ogr.Sil(id);//verilen id ye göre veri silmek için 
        }

        public int Guncelle(OgrEntities ogrEntities)
        {
            return ogr.Guncelle(ogrEntities);
        }
    }
}
