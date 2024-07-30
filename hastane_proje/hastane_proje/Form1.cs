using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hastane_proje
{
    public partial class Frmgirisler : Form
    {
        public Frmgirisler()
        {
            InitializeComponent();
        }

        private void btnhasta_Click(object sender, EventArgs e)
        {
            frm_hastagiris fr = new frm_hastagiris(); // Hasta üzerine tıklandığında hasta giriş sayfasına yönlendiriyor
            fr.ShowDialog(); //pencereyi kapana kadar baska islem yapılamaz programı tamamen kapatmaz
        }

        private void btndoktor_Click(object sender, EventArgs e)
        {
            frm_doktorgiris fr = new frm_doktorgiris(); //Doktor giris sayfasına yönlendirme yapar
            fr.ShowDialog();
        }

        private void btnsekreter_Click(object sender, EventArgs e)
        {
            frm_sekretergiris fr = new frm_sekretergiris(); //Sekreter giris sayfasına yönlendirme yapar
            fr.ShowDialog();
        }
        
    }
}
