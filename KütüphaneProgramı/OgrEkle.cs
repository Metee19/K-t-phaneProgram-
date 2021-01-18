using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KütüphaneProgramı.Entities;
using KütüphaneProgramı.Business;
using System.Data.OleDb;
namespace KütüphaneProgramı
{
    public partial class OgrEkle : Form
    {
        public OgrEkle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OgrEntities ogr = new OgrEntities();
            OgrBusiness ekle = new OgrBusiness(Application.StartupPath);//uygulamanın başlangıç dizini parametre olarak gönderilir
           // ogr.id = Convert.ToInt32(Txtİd.Text);
            ogr.ad = TxtAd.Text;
            ogr.soyad = TxtSoyad.Text;
            ogr.tc = TxtTC.Text;
            ogr.mail = TxtMail.Text;
            ogr.telefon = TxtTelefon.Text;
            ekle.Ekle(ogr);
            MessageBox.Show("Eklendi");//ekrana uyarı bastırılır
            foreach (Control item in Controls) //bütün nesnelerini kontrol eder
            {
                if (item is TextBox) //nesneler text box ise
                {
                    item.Text = ""; //textlerini "" yani boş yapar
                }
            }
        }
    }
}
