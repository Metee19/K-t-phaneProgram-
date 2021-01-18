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
using System.Data.OleDb;
namespace KütüphaneProgramı
{
    public partial class ÖgrenciAldiklariListele : Form
    {
        public ÖgrenciAldiklariListele()
        {
            InitializeComponent();
        }
        AlinmisKitapBusiness listele = new AlinmisKitapBusiness(Application.StartupPath);//AlinmisKitapBusiness adlı classdan yeni nesne oluşturulur ve programın çalıştığı dizin parametre olarak verilir
        DataSet veri = new DataSet(); //DataSet classından veri adlı veri kümesi oluşturduk
        AlinmisKitapEntities AlinmisKitap = new AlinmisKitapEntities();

        public void AlinmisKitaplarıListele()
        {
            OleDbConnection bgl = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = KütüphaneProgramı.accdb");
            bgl.Open();
            OleDbCommand komut = new OleDbCommand("Select AlanKisi from AlınmısKitap", bgl);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (AlinmisKitap.alankisiad== textBox1.Text)
                {
                    veri = listele.GetList("Select * From AlınmısKitap ");//iş katmanına sorgu gönderilir
                    dataGridView1.DataSource = veri.Tables["AlinmisKitapEntities"];// gelen veri datagrid e yazdırılır
                }
            }
           
        }

        private void ÖgrenciAldiklariListele_Load(object sender, EventArgs e)
        {
            //veri = listele.GetList("Select * From AlınmısKitap ");//iş katmanına sorgu gönderilir
            //dataGridView1.DataSource = veri.Tables["AlinmisKitapEntities"];// gelen veri datagrid e yazdırılır
        }



        private void Btnİade_Click(object sender, EventArgs e)
        {
            
                listele.Sil(dataGridView1.CurrentRow.Cells[0].Value.ToString());//iş katmanına silincek olan verinin degeri verilir

                MessageBox.Show("Silme işlemi gerçekleşti");//ekrana uyarı bastırılır

           
            veri.Tables["AlinmisKitapEntities"].Clear();//verikümesinin kitap tablosu temizlenir
            AlinmisKitaplarıListele();//Datagride veriler güncellenmiş şekilde getirilir
            foreach (Control item in Controls)//bütün control nesneleri kontrol edilir
            {
                if (item is TextBox)//eğer nesneler textbox ise
                {
                    item.Text = "";//içi boşaltırlır
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            veri = listele.GetList("Select * From AlınmısKitap where AlanKisi like '%" + textBox1.Text + "%'");//iş katmanından gelen veri veri adlı veri kümesine aktarılır
            dataGridView1.DataSource = veri.Tables["AlinmisKitapEntities"];//datagride veri küğmesindeki veri aktarılır

            if (textBox1.Text == "")// textboxın içi boşsa
            {

                AlinmisKitaplarıListele(); //alınmıskitaplarılistele fonksiyonu çağrılır
            }
        }
    }
}
