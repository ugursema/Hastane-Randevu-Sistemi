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
    public partial class frm_sekretergiris : Form
    {
        public frm_sekretergiris()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void btngiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From tbl_sekreter where sekreter_tc=@p1 and sekreter_sifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", msktc.Text);
            komut.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                frm_sekreterdetay frs = new frm_sekreterdetay();
                frs.tcnumara = msktc.Text;
                frs.ShowDialog();
                //this.Hide();

            }
            else
            {
                MessageBox.Show("Hatalı TC & Sifre girdiniz.");
            }
            bgl.baglanti().Close();
        }
    }
}
