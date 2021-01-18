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
    public partial class KitapTeslimEt : Form
    {
        public KitapTeslimEt()
        {
            InitializeComponent();
        }
        KitapBusiness ktp = new KitapBusiness(Application.StartupPath); //KitapBusiness adlı classdan yeni nesne oluşturulur ve programın çalıştığı dizin parametre olarak verilir
        DataSet veri = new DataSet(); //DataSet classından veri1 adlı veri kümesi oluşturduk
        OgrBusiness ogr = new OgrBusiness(Application.StartupPath); //OgrBusiness adlı classdan yeni nesne oluşturulur ve programın çalıştığı dizin parametre olarak verilir
        DataSet veri2 = new DataSet(); //DataSet classından veri2 adlı veri kümesi oluşturduk
        AlinmisKitapBusiness all = new AlinmisKitapBusiness(Application.StartupPath);//AlinmisKitapBusiness adlı classdan yeni nesne oluşturulur ve programın çalıştığı dizin parametre olarak verilir
        DataSet veri3 = new DataSet(); //DataSet classından veri3 adlı veri kümesi oluşturduk

        public void AlinmisKitaplarıListele()
        {
            veri3 = all.GetList("Select * From AlınmısKitap ");//iş katmanına sorgu gönderilir
            dataGridView1.DataSource = veri3.Tables["AlinmisKitapEntities"];// gelen veri datagrid e yazdırılır
        }

        public void Kitaplistele()
        {
            veri = ktp.GetList("Select * From KitapKayit ");//iş katmanına sorgu gönderilir
            dataGridView2.DataSource = veri.Tables["KitapEntities"];// gelen veri datagrid e yazdırılır
        }

        public void ogrlistele()
        {
            veri2 = ogr.GetList("Select * From OgrKayit ");//iş katmanına sorgu gönderilir
            dataGridView3.DataSource = veri2.Tables["OgrEntities"];// gelen veri datagrid e yazdırılır
        }

        private void KitapTeslimEt_Load(object sender, EventArgs e)
        {
            Kitaplistele();
            ogrlistele();
            AlinmisKitaplarıListele();
            
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0)//data gridde seçilen değer
            {
                int selectedrowindex = dataGridView2.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView2.Rows[selectedrowindex];
              
                TxtAd.Text = Convert.ToString(selectedRow.Cells[1].Value);//textboxın içine yazdırılır
              
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.SelectedCells.Count > 0)//data gridde seçilen değer
            {
                int selectedrowindex = dataGridView3.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView3.Rows[selectedrowindex];

                TxtTeslim.Text = Convert.ToString(selectedRow.Cells[1].Value);//textboxın içine yazdırılır
                
            }
        }


        public double hesapla()
        {
            DateTime ilkTarih = Convert.ToDateTime(dtpAlınanTarih.Text);
            DateTime sonTarih = Convert.ToDateTime(dtpVerilenTarih.Text);
            TimeSpan Sonuc = sonTarih - ilkTarih;
            double sonuc = Sonuc.TotalDays;
            return sonuc;
        }
        //public double hesapla1()
        //{
        //    DateTime d1;
        //    DateTime d2;
        //    TimeSpan ts;
        //    for (int i = 0; i < dataGridView1.RowCount - 1; i++)
        //    {
        //        d1 = Convert.ToDateTime(dataGridView1.Rows[i].Cells[3].Value);
        //        d2 = Convert.ToDateTime(dataGridView1.Rows[i].Cells[4].Value);
        //        ts = d1 - d2;
        //        double sonuc = ts.Days;
        //    }
        //}




        private void button7_Click(object sender, EventArgs e)
        {
            AlinmisKitapEntities alktp = new AlinmisKitapEntities();
            AlinmisKitapBusiness ekle = new AlinmisKitapBusiness(Application.StartupPath);//uygulamanın başlangıç dizini parametre olarak gönderilir
            //Textbox içindeki veriler veritabanına aktarılır                                                            
            alktp.alankisiad = TxtTeslim.Text;
            alktp.kitapad = TxtAd.Text;
            alktp.teslimdurum = TxtTeslimDurumu.Text;
            alktp.alındıgıtarih = dtpAlınanTarih.Text;
            alktp.teslimtarih = dtpVerilenTarih.Text;
            ekle.Ekle(alktp);
            MessageBox.Show("Eklendi");//ekrana uyarı bastırılır
            foreach (Control item in Controls) //bütün nesnelerini kontrol eder
            {
                if (item is TextBox && item is DateTimePicker) //nesneler datetimepicker ve text box ise
                {
                    item.Text = ""; //textlerini "" yani boş yapar
                }
            }
            AlinmisKitaplarıListele();
            hesapla();
        }
    }
}
