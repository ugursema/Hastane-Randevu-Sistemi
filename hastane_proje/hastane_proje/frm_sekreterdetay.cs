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
    public partial class frm_sekreterdetay : Form
    {
        public frm_sekreterdetay()
        {
            InitializeComponent();
        }
        public string tcnumara;
        public int secilen;
        sqlbaglantisi bgl = new sqlbaglantisi();

        private void frm_sekreterdetay_Load(object sender, EventArgs e)
        {
            Lbltc.Text = tcnumara;
            
            //Ad Soyad 
            SqlCommand komut1 = new SqlCommand("Select sekreter_adsoyad From tbl_sekreter where sekreter_tc=@p1", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", Lbltc.Text);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                Lbladsoyad.Text = dr1[0].ToString();
            }
            bgl.baglanti().Close();
            //Bransları Datagride aktarma
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from tbl_brans", bgl.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;

            //Doktorları listeye aktarma
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select (doktor_ad+' '+ doktor_soyad) as 'Doktorlar' ,doktor_brans From tbl_doktor", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource=dt2;

            //Brans 1 aktarma
            SqlCommand komut2 = new SqlCommand("Select brans_ad from tbl_brans", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbbrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
        }
        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komutkaydet = new SqlCommand("insert into tbl_randevu(randevu_tarih,randevu_saat,randevu_brans,randevu_doktor) values (@r1,@r2,@r3,@r4)", bgl.baglanti());
            komutkaydet.Parameters.AddWithValue("@r1", msktarih.Text);
            komutkaydet.Parameters.AddWithValue("@r2", msksaat.Text);
            komutkaydet.Parameters.AddWithValue("@r3", cmbbrans.Text);
            komutkaydet.Parameters.AddWithValue("@r4", cmbdoktor.Text);
            komutkaydet.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Oluşturuldu");
        }
        private void cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbdoktor.Items.Clear();
            SqlCommand komut = new SqlCommand("Select doktor_ad,doktor_soyad From tbl_doktor where doktor_brans=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbbrans.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbdoktor.Items.Add(dr[0] + " " +  dr[1]);
            }
            bgl.baglanti().Close();
        }
        private void btnduyuru_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_duyurular (duyuru) values (@d1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", rchduyuru.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru Oluşturuldu.");
        }

        private void btndoktorpnl_Click(object sender, EventArgs e)
        {
            frm_doktorpaneli drp = new frm_doktorpaneli();
            drp.ShowDialog();
        }

        private void btnbranspnl_Click(object sender, EventArgs e)
        {
            frm_brans frb = new frm_brans();
            frb.ShowDialog();
        }

        private void btnrandevuliste_Click(object sender, EventArgs e)
        {
            frm_randevulistesi frl = new frm_randevulistesi();
            frl.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_duyurular fr = new frm_duyurular();
            fr.ShowDialog();
        }
    }
}
