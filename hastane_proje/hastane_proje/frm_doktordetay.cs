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
    public partial class frm_doktordetay : Form
    {
        public frm_doktordetay()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string tc;
        
        private void frm_doktordetay_Load(object sender, EventArgs e)
        {
            Lbltc.Text = tc;
            // ad soyad cekme
            SqlCommand komut = new SqlCommand("Select doktor_ad,doktor_soyad from tbl_doktor where doktor_tc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Lbltc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Lbladsoyad.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();
            // randevualr
            DataTable dt = new DataTable();
            SqlDataAdapter da= new SqlDataAdapter("Select * From tbl_randevu where randevu_doktor='"+ Lbladsoyad.Text + "' " , bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            frm_doktorbilgiduzenle fr = new frm_doktorbilgiduzenle();
            fr.tcno = Lbltc.Text;
            fr.ShowDialog();
        }

        private void btnduyurular_Click(object sender, EventArgs e)
        {
            frm_duyurular fr = new frm_duyurular();
            fr.ShowDialog();
        }

        private void btncıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            var sonuc = dataGridView1.CurrentRow.Cells["randevu_Id"].Value;

            SqlCommand komut = new SqlCommand("Select hasta_sikayet from tbl_randevu where randevu_Id=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", sonuc);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Rchsikayet.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();
        }
    }
    }

