using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KütüphaneProgramı.Dal;
using KütüphaneProgramı.Entities;
using System.Data.OleDb;
using System.Data;
namespace KütüphaneProgramı.Business
{
    public class AlinmisKitapBusiness
    {
        AlinmisKitapDal al;
        public AlinmisKitapBusiness(string path)
        {
            al = new AlinmisKitapDal(path);// gelen database pathini data access layer ına iletiyor
        }
        public int Ekle(AlinmisKitapEntities all)//öğrenciye kitap verilecegi zaman
        {
            return al.Ekle(all);//data acces layer için ögrenci bilgilerini gönderiyor
        }

        public DataSet GetList(string query)//veri çekmek için 
        {

            return al.GetList(query);//data access layer e sorguyu dönderip veri kümesi alıyor
        }

        public void Sil(string AlanKisi)//veri silmek için 
        {
             al.Sil(AlanKisi);//verilen veriye ye göre veri silmek için 
        }

    }
}
