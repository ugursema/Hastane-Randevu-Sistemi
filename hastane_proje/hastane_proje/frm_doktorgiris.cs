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
    public partial class frm_doktorgiris : Form
    {
        public frm_doktorgiris()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void btngiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From tbl_doktor where doktor_tc=@p1 and doktor_sifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", msktc.Text);
            komut.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                frm_doktordetay fr = new frm_doktordetay();
                fr.tc = msktc.Text;
                fr.ShowDialog();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı ya da Sifre");
            }
            bgl.baglanti().Close();
        }
    }
}
