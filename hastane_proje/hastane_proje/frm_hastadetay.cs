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
    public partial class frm_hastadetay : Form
    {
     
        public frm_hastadetay()
        {
            InitializeComponent();
        }
        public string tc;
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void frm_hastadetay_Load(object sender, EventArgs e)
        {
            lbltc.Text = tc;
            //Ad Soyad cekme
            SqlCommand komut = new SqlCommand("Select hasta_ad, hasta_soyad from tbl_hasta where hasta_tc=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", lbltc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lbladsoyad.Text = dr[0] + " " + dr[1];  
            }
            bgl.baglanti().Close();
            //randevu gecmişi cekme
            GecmisRandevu();

            //bransları cekme
            SqlCommand komut2 = new SqlCommand("Select brans_ad From tbl_brans", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbbrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
        }

        private void cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            //bransa tıkladığımızda doktorlar o bülüme ait doktorar gelecek
            //ÖNCE combobox içeriği temizlensin
            cmbdoktor.Items.Clear();
            SqlCommand komut3 = new SqlCommand("Select doktor_ad,doktor_soyad From tbl_doktor where doktor_brans=@p1", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", cmbbrans.Text);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                cmbdoktor.Items.Add(dr3[0] + " " + dr3[1]);
            }
            bgl.baglanti().Close();
        }

        private void cmbdoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            AktifRandevuYenile();
        }

        private void lnkbilgi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmbilgiduzenle fr = new frmbilgiduzenle();
            if (!string.IsNullOrEmpty(lbltc.Text))
            {
                fr.TCno = lbltc.Text;
                fr.ShowDialog();
            }
            else
                msj.uyari("TC kimlik No alanı boş olamaz.");
           
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
        }
  
        private void GecmisRandevu()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From tbl_randevu where hastatc=" + tc, bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void AktifRandevuYenile()
        {
            DataTable dt = new DataTable();
            string q = "Select * From tbl_randevu where randevu_brans='" + cmbbrans.Text + "'" + " and randevu_doktor='" + cmbdoktor.Text + "' and randevu_durum=1";
            SqlDataAdapter da = new SqlDataAdapter(q, bgl.baglanti());
            da.Fill(dt);

            dataGridView2.DataSource = dt;
        }

        private void btnrandevual_Click(object sender, EventArgs e)
        {
     
            SqlCommand komut = new SqlCommand("Update tbl_randevu set randevu_durum=0,hasta_sikayet=@p2 where randevu_Id=@p3", bgl.baglanti());

            komut.Parameters.AddWithValue("@p2", rchsikayet.Text);
            komut.Parameters.AddWithValue("@p3", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            AktifRandevuYenile();
            GecmisRandevu();

            MessageBox.Show("Randevu Alındı", ",Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
