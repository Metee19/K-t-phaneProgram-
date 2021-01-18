using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KütüphaneProgramı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OgrEkle ogr = new OgrEkle();
            ogr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OgrListele ogr = new OgrListele();
            ogr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            KitapEkle ktp = new KitapEkle();
            ktp.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            KitapListele ktp = new KitapListele();
            ktp.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            KitapTeslimEt ktp = new KitapTeslimEt();
            ktp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ÖgrenciAldiklariListele ogr = new ÖgrenciAldiklariListele();
            ogr.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            KitapBilgileriGoster ktp = new KitapBilgileriGoster();
            ktp.Show();
        }
    }
}
