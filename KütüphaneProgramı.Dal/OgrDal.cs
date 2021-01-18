using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using KütüphaneProgramı.Entities;
namespace KütüphaneProgramı.Dal
{
    public class OgrDal //OgrKayit tablosu için data access layer
    {
        
        public OgrDal(string path) //OgrDal yapıcı fonksiyon
        {
            OleDbCommand komut = new OleDbCommand();//Veritabanında çalışa sorgular için komut nesnesini oluşturduk
            OleDbConnection bgl = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + @"\KütüphaneProgramı.accdb");//Veritabanı bağlantımızı açıp kapamak için bgl nesnesini oluşturduk
        }
        
        public int Ekle(OgrEntities ogrEkleEntities)
        {
            OleDbConnection bgl = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = KütüphaneProgramı.accdb");
            OleDbCommand komut = bgl.CreateCommand(); 
            bgl.Open();//veritabanı baglantısı oluşturduk
            komut.CommandText = "Insert into OgrKayit(OgrAd,OgrSoyad,OgrTC,OgrMail,OgrTelefon)" + "Values('" + ogrEkleEntities.ad + "','" + ogrEkleEntities.soyad + "','" + ogrEkleEntities.tc + "','" + ogrEkleEntities.mail + "','" + ogrEkleEntities.telefon + "')";
            //textboxa girilen verileri veritabanına ekleyen insert sorgusunu yazdık 
            komut.Connection = bgl;
           
            int sonuc = komut.ExecuteNonQuery(); //sorgu çalıştırılır ve return edilir
            bgl.Close();//veritabanı baglantısını kapattık
            return sonuc;
        }

        public DataSet GetList(string query) //OgrKayit tablosundaki kayıtları çekmek için kullanılacak fonksiyon return tipi verikümesi
        {
            OleDbConnection bgl = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = KütüphaneProgramı.accdb");
            DataSet dataSet = new DataSet();//veri kümesi oluşturuyoruz

            bgl.Open();//database bağlantısı oluşturulur

            OleDbDataAdapter ekle = new OleDbDataAdapter(query, bgl);//dataadapter nesnesi oluşturulur sorgu ve bağlantı nesnesi verilir
            ekle.Fill(dataSet, "OgrEntities");//okunan veriler verikümesinin OgrKayit tablosuna aktarılır
            bgl.Close();//database bağlantısı sonlandırılır.
            return dataSet; //verikümesi return edilir
        }

        public int Sil(int id)
        {
            OleDbConnection bgl = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = KütüphaneProgramı.accdb");
            OleDbCommand komut = bgl.CreateCommand();
            bgl.Open();
            komut.CommandText = "Delete from OgrKayit where Ogrİd=@p1";//sorgu yazılır bu sorguda id numarası eşit olan kitap silinir
            komut.Parameters.AddWithValue("@p1", id);//@p1 değişkenine datagriddeki değer atanır
            komut.Connection = bgl;
            int sonuc = komut.ExecuteNonQuery();//Sorgu çalıştırılır
            bgl.Close();
            return sonuc;
        }

        public int Guncelle(OgrEntities ogrEntities)//tabloda değişiklik yapıcağımız zaman çalışacak olan fonksiyon 
        {
            OleDbConnection bgl = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = KütüphaneProgramı.accdb");
            OleDbCommand komut = bgl.CreateCommand();
            bgl.Open();//database bağlantısı oluşturulur
            komut.CommandText = "update OgrKayit set OgrAd='" + ogrEntities.ad + "',OgrSoyad='" + ogrEntities.soyad + "',OgrTC='" + ogrEntities.tc + "',OgrMail='" + ogrEntities.mail + "',OgrTelefon='" + ogrEntities.telefon + "'";//update sorgusu yazılır
            komut.Connection = bgl;
            int sonuc = komut.ExecuteNonQuery();
            bgl.Close();//database bağlantısı sonlandırılır
            return sonuc;
        }
    }
}
