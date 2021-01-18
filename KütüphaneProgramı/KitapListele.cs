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
    public partial class KitapListele : Form
    {
        public KitapListele()
        {
            InitializeComponent();
        }

        KitapBusiness ktp = new KitapBusiness(Application.StartupPath); //OgrBusiness adlı classdan yeni nesne oluşturulur ve programın çalıştığı dizin parametra olarak verilir
        DataSet veri = new DataSet(); //DataSet classından veri adlı veri kümesi oluşturduk

        public void Kitaplistele()
        {
            veri = ktp.GetList("Select * From KitapKayit ");//iş katmanına sorgu gönderilir
            dataGridView1.DataSource = veri.Tables["KitapEntities"];// gelen veri datagrid e yazdırılır
        }
        private void KitapListele_Load(object sender, EventArgs e)
        {
            Kitaplistele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            var sonuc = ktp.Sil(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));//iş katmanına silincek olan verinin id si verilir

            if (sonuc > 0)//dönen verinin değerine göre
            {
                MessageBox.Show("Silme işlemi gerçekleşti");//ekrana uyarı bastırılır

            }
            veri.Tables["KitapEntities"].Clear();//verikümesinin kitap tablosu temizlenir
            Kitaplistele();//Datagride veriler güncellenmiş şekilde getirilir
            foreach (Control item in Controls)//bütün control nesneleri kontrol edilir
            {
                if (item is TextBox)//eğer nesneler textbox ise
                {
                    item.Text = "";//içi boşaltırlır
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)//data gridde seçilen değer
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                Txtİd.Text = Convert.ToString(selectedRow.Cells[0].Value);//textboxların içine yazdırılır
                TxtAd.Text = Convert.ToString(selectedRow.Cells[1].Value);//textboxların içine yazdırılır
                TxtBarkodNo.Text = Convert.ToString(selectedRow.Cells[2].Value);//textboxların içine yazdırılır
                TxtYazar.Text = Convert.ToString(selectedRow.Cells[3].Value);
                TxtDurum.Text = Convert.ToString(selectedRow.Cells[4].Value);//textboxların içine yazdırılır
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            KitapEntities ktpguncelle = new KitapEntities();//OgrEntities classından yeni nesne oluşturulur.
            ktpguncelle.kitapid = Convert.ToInt32(Txtİd.Text);//textbox içindeki veriler set bloğu ile aktarılır
            ktpguncelle.ad = TxtAd.Text;
            ktpguncelle.barkodno = Convert.ToInt32(TxtBarkodNo.Text);
            ktpguncelle.yazar = TxtYazar.Text;
            ktpguncelle.durum = TxtDurum.Text;
            

            var sonuc = ktp.Guncelle(ktpguncelle);//update işlemi için iş katmanına istek gönderilir

            if (sonuc > 0)//dönen sonuca göre
            {

                MessageBox.Show("Güncelleme işlemi gerçekleşti");//ekrana uyarı bastırılır
            }
            MessageBox.Show("Güncelleme işlemi gerçekleşti");//ekrana güncelleme işlemi gerçekleşti diye uyarı basılır
            veri.Tables["KitapEntities"].Clear();//veri kümesinin uye tablosu temizlenir
            Kitaplistele();//Datagride veriler güncellenmiş şekilde getirilir//uye listele fonksiyonu çağrılır
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
