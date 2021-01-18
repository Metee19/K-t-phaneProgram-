using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KütüphaneProgramı.Business;
using KütüphaneProgramı.Entities;
namespace KütüphaneProgramı
{
    public partial class OgrListele : Form
    {
        public OgrListele()
        {
            InitializeComponent();
        }
        OgrBusiness ogr = new OgrBusiness(Application.StartupPath); //OgrBusiness adlı classdan yeni nesne oluşturulur ve programın çalıştığı dizin parametra olarak verilir
        DataSet veri = new DataSet(); //DataSet classından veri adlı veri kümesi oluşturduk

        public void ogrlistele()
        {
            veri = ogr.GetList("Select * From OgrKayit ");//iş katmanına sorgu gönderilir
            dataGridView1.DataSource = veri.Tables["OgrEntities"];// gelen veri datagrid e yazdırılır
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)//data gridde seçilen değer
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                Txtİd.Text = Convert.ToString(selectedRow.Cells[0].Value);//textboxların içine yazdırılır
                TxtAd.Text = Convert.ToString(selectedRow.Cells[1].Value);//textboxların içine yazdırılır
                TxtSoyad.Text = Convert.ToString(selectedRow.Cells[2].Value);//textboxların içine yazdırılır
                TxtTC.Text = Convert.ToString(selectedRow.Cells[3].Value);
                TxtMail.Text = Convert.ToString(selectedRow.Cells[4].Value);//textboxların içine yazdırılır
                TxtTelefon.Text = Convert.ToString(selectedRow.Cells[5].Value);//textboxların içine yazdırılır
                

            }
        }

        private void OgrListele_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'kütüphaneProgramıDataSet.OgrKayit' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            //this.ogrKayitTableAdapter.Fill(this.kütüphaneProgramıDataSet.OgrKayit);
            ogrlistele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
           
                var sonuc = ogr.Sil(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));//iş katmanına silincek olan verinin id si verilir

                if (sonuc > 0)//dönen verinin değerine göre
                {
                    MessageBox.Show("Silme işlemi gerçekleşti");//ekrana uyarı bastırılır

                }
                veri.Tables["OgrEntities"].Clear();//verikümesinin OgrKayit tablosu temizlenir
            ogrlistele();//Datagride veriler güncellenmiş şekilde getirilir
            foreach (Control item in Controls)//bütün control nesneleri kontrol edilir
                {
                    if (item is TextBox)//eğer nesneler textbox ise
                    {
                        item.Text = "";//içi boşaltırlır
                    }
                }
           
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            
            OgrEntities ogrguncelle = new OgrEntities();//OgrEntities classından yeni nesne oluşturulur.
            ogrguncelle.id = Convert.ToInt32(Txtİd.Text);//textbox içindeki veriler set bloğu ile aktarılır
            ogrguncelle.ad = TxtAd.Text;
            ogrguncelle.soyad = TxtSoyad.Text;
            ogrguncelle.tc = TxtTC.Text;
            ogrguncelle.mail = TxtMail.Text;
            ogrguncelle.telefon = TxtTelefon.Text;

            var sonuc = ogr.Guncelle(ogrguncelle);//update işlemi için iş katmanına istek gönderilir

                if (sonuc > 0)//dönen sonuca göre
                {

                    MessageBox.Show("Güncelleme işlemi gerçekleşti");//ekrana uyarı bastırılır
                }
                MessageBox.Show("Güncelleme işlemi gerçekleşti");//ekrana güncelleme işlemi gerçekleşti diye uyarı basılır
                veri.Tables["OgrEntities"].Clear();//veri kümesinin OgrEntities tablosu temizlenir
            ogrlistele();//Datagride veriler güncellenmiş şekilde getirilir//ogrlistele fonksiyonu çağrılır
            foreach (Control item in Controls)//bütün nesneler kontrol edilir
                {
                    if (item is TextBox)//eğer nesne textbox ise
                    {
                        item.Text = "";//içindeki değerler "" yani boş olur
                    }
                }
            
        }
    }
}
