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
    public partial class KitapBilgileriGoster : Form
    {
        public KitapBilgileriGoster()
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
                if (AlinmisKitap.alankisiad == txtAra.Text)
                {
                    veri = listele.GetList("Select * From AlınmısKitap ");//iş katmanına sorgu gönderilir
                    dataGridView1.DataSource = veri.Tables["AlinmisKitapEntities"];// gelen veri datagrid e yazdırılır
                }
            }

        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            veri = listele.GetList("Select * From AlınmısKitap where KitapAd like '%" + txtAra.Text + "%'");//iş katmanından gelen veri veri adlı veri kümesine aktarılır
            dataGridView1.DataSource = veri.Tables["AlinmisKitapEntities"];//datagride veri küğmesindeki veri aktarılır

            if (txtAra.Text == "")// textboxın içi boşsa
            {

                AlinmisKitaplarıListele(); //alınmıskitaplarılistele fonksiyonu çağrılır
            }
        }

        //KitapTeslimEt frm = new KitapTeslimEt();
        //if (Convert.ToInt32(frm.hesapla()) == 2)
        //        {
        //            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
        //        }

    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                if (dataGridView1.Rows[i].Cells["TeslimDurumu"].Value.ToString() == "Kütüphanede") // veritabanında teslim durumu degeri kütüphanede ye eşit ise
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Green;//satırı yeşil yap
                }
                if (dataGridView1.Rows[i].Cells["TeslimDurumu"].Value.ToString() == "Teslime 2 Gün Kaldı") // veritabanında teslim durumu degeri kütüphanede ye eşit ise
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;//satırı yeşil yap
                }
                if (dataGridView1.Rows[i].Cells["TeslimDurumu"].Value.ToString() == "Teslime Süresi Geçti") // veritabanında teslim durumu degeri kütüphanede ye eşit ise
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;//satırı yeşil yap
                }

            }
        }
    }
}
