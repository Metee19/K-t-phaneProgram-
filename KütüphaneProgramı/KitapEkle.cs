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
    public partial class KitapEkle : Form
    {
        public KitapEkle()
        {
            InitializeComponent();
        }

        private void BtnOgr_Click(object sender, EventArgs e)
        {
            KitapEntities ktp = new KitapEntities();
            KitapBusiness ekle = new KitapBusiness(Application.StartupPath);//uygulamanın başlangıç dizini parametre olarak gönderilir
            //Textbox içindeki veriler veritabanına aktarılır                                                            
            ktp.ad = TxtAd.Text;
            ktp.yazar = TxtYazar.Text;
            //ktp.tur = TxtTur.Text;
            ktp.barkodno = Convert.ToInt32(TxtBarkodNo.Text);
            ktp.durum = TxtDurum.Text;
            ekle.Ekle(ktp);
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
