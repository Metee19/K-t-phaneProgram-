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
    public class AlinmisKitapDal //Alınmış kitap tablosu için data access layer
    {
        public AlinmisKitapDal(string path) //AlinmisKİtapDal yapıcı fonksiyon
        {
            OleDbCommand komut = new OleDbCommand();//Veritabanında çalışa sorgular için komut nesnesini oluşturduk
            OleDbConnection bgl = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + @"\KütüphaneProgramı.accdb");//Veritabanı bağlantımızı açıp kapamak için bgl nesnesini oluşturduk
        }
        public int Ekle(AlinmisKitapEntities alinmisKitapEntities)
        {
            OleDbConnection bgl = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = KütüphaneProgramı.accdb");
            OleDbCommand komut = bgl.CreateCommand();
            bgl.Open();//veritabanı baglantısı oluşturduk
            komut.CommandText = "Insert into AlınmısKitap(AlanKisi,KitapAd,TeslimDurumu,AlındıgıTarih,TeslimTarihi)" + "Values('" + alinmisKitapEntities.alankisiad + "','" + alinmisKitapEntities.kitapad + "','" + alinmisKitapEntities.teslimdurum + "','" + alinmisKitapEntities.alındıgıtarih + "','" + alinmisKitapEntities.teslimtarih + "')";
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
            ekle.Fill(dataSet, "AlinmisKitapEntities");//okunan veriler verikümesinin OgrKayit tablosuna aktarılır
            bgl.Close();//database bağlantısı sonlandırılır.
            return dataSet; //verikümesi return edilir
        }

        public void Sil(string AlanKisi)
        {
            OleDbConnection bgl = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = KütüphaneProgramı.accdb");
            OleDbCommand komut = bgl.CreateCommand();
            bgl.Open();
            komut.CommandText = "Delete from AlınmısKitap where AlanKisi=@p1";//sorgu yazılır bu sorguda Alan kişiye eşit olan kayıt silinir
            komut.Parameters.AddWithValue("@p1", AlanKisi);//@p1 değişkenine datagriddeki değer atanır
            komut.Connection = bgl;
             komut.ExecuteNonQuery();//Sorgu çalıştırılır
            bgl.Close();
            
        }
    }
}
