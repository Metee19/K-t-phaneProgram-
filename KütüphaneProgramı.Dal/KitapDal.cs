using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using KütüphaneProgramı.Entities;

namespace KütüphaneProgramı.Dal
{
   public class KitapDal
    {
        public KitapDal(string path) //KitapDal yapıcı fonksiyon
        {
            OleDbCommand komut = new OleDbCommand();//Veritabanında çalışa sorgular için komut nesnesini oluşturduk
            OleDbConnection bgl = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + @"\KütüphaneProgramı.accdb");//Veritabanı bağlantımızı açıp kapamak için bgl nesnesini oluşturduk
        }
        
        public int Ekle(KitapEntities kitapEntities)
        {
            OleDbConnection bgl = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = KütüphaneProgramı.accdb");
            OleDbCommand komut = bgl.CreateCommand();
            bgl.Open();//veritabanı baglantısı oluşturduk
            komut.CommandText = "Insert into KitapKayit(KitapAd,BarkodNo,KitapYazar,KitapDurumu)" + "Values('" + kitapEntities.ad + "','" + kitapEntities.barkodno + "','" + kitapEntities.yazar + "','" + kitapEntities.durum + "')";
            //textboxa girilen verileri veritabanına ekleyen insert sorgusunu yazdık 
            komut.Connection = bgl;

            int sonuc = komut.ExecuteNonQuery(); //sorgu çalıştırılır ve return edilir
            bgl.Close();//veritabanı baglantısını kapattık
            return sonuc;
        }

        public DataSet GetList(string query) //KitapKayit tablosundaki kayıtları çekmek için kullanılacak fonksiyon return tipi verikümesi
        {
            OleDbConnection bgl = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = KütüphaneProgramı.accdb");
            DataSet dataSet = new DataSet();//veri kümesi oluşturuyoruz

            bgl.Open();//database bağlantısı oluşturulur

            OleDbDataAdapter ekle = new OleDbDataAdapter(query, bgl);//dataadapter nesnesi oluşturulur sorgu ve bağlantı nesnesi verilir
            ekle.Fill(dataSet, "KitapEntities");//okunan veriler verikümesinin OgrKayit tablosuna aktarılır
            bgl.Close();//database bağlantısı sonlandırılır.
            return dataSet; //verikümesi return edilir
        }

        public int Sil(int id)
        {
            OleDbConnection bgl = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = KütüphaneProgramı.accdb");
            OleDbCommand komut = bgl.CreateCommand();
            bgl.Open();
            komut.CommandText = "Delete from KitapKayit where Kitapid=@p1";//sorgu yazılır bu sorguda kitapid eşit olan kitap silinir
            komut.Parameters.AddWithValue("@p1", id);//@p1 değişkenine datagriddeki değer atanır
            komut.Connection = bgl;
            int sonuc = komut.ExecuteNonQuery();//Sorgu çalıştırılır
            bgl.Close();
            return sonuc;
        }

        public int Guncelle(KitapEntities kitapEntities)//tabloda değişiklik yapıcağımız zaman çalışacak olan fonksiyon 
        {
            OleDbConnection bgl = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = KütüphaneProgramı.accdb");
            OleDbCommand komut = bgl.CreateCommand();
            bgl.Open();//database bağlantısı oluşturulur
            komut.CommandText = "update KitapKayit set KitapAd='" + kitapEntities.ad + "',BarkodNo='" + kitapEntities.barkodno + "',KitapYazar='" + kitapEntities.yazar + "',KitapDurumu='" + kitapEntities.durum+ "'";//update sorgusu yazılır
            komut.Connection = bgl;
            int sonuc = komut.ExecuteNonQuery();
            bgl.Close();//database bağlantısı sonlandırılır
            return sonuc;
        }


    }
}
