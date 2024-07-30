using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace hastane_proje
{
    public partial class frm_uyeol : Form
    {
        public frm_uyeol()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void btnkayıtol_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtad.Text))
            {
                msj.uyari("Hasta Ad Giriniz."); //msj sınıfımızı cagırdık bilgi girilmediğinde ekrana uyarı gelir ve alana odaklar
                txtad.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtsoyad.Text))
            {
                msj.uyari("Hasta Soyad Giriniz.");
                txtsoyad.Focus();
                return;
            }
            if (string.IsNullOrEmpty(msktc.Text))
            {
                msj.uyari("Hasta TC Giriniz.");
                msktc.Focus();
                return;
            }
            if (string.IsNullOrEmpty(msktel.Text))
            {
                msj.uyari("Hasta Telefon Giriniz.");
                msktel.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtsifre.Text))
            {
                msj.uyari("Hasta Sifre Giriniz.");
                txtsifre.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cmbcinsiyet.Text))
            {
                msj.uyari("Hasta cinsiyet Seciniz.");
                cmbcinsiyet.Focus();
                return;
            }
            SqlCommand komut = new SqlCommand("insert into tbl_hasta  (hasta_ad,hasta_soyad,hasta_tc,hasta_tel,hasta_sifre,hasta_cinsiyet) values(@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", msktc.Text);
            komut.Parameters.AddWithValue("@p4", msktel.Text);
            komut.Parameters.AddWithValue("@p5", txtsifre.Text);
            komut.Parameters.AddWithValue("@p6", cmbcinsiyet.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Kaydınız gerçekleşmiştir. \n Şifreniz: " + txtsifre.Text, "Bilgi", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
