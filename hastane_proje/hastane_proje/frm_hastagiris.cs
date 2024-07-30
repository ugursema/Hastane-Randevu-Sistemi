using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;  // sql de veri çekmek için kütüphane ekliyoruz

namespace hastane_proje
{
    public partial class frm_hastagiris : Form
    {
        public frm_hastagiris()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi(); //sql baglantisini cagirdik bgl adını biz verdik
        private void lnkuyeol_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_uyeol fr = new frm_uyeol(); //üye ol paneline yönlendirme
            fr.ShowDialog();
           // this.Hide(); formu gizler geriye dönüş yapabilmek için kullanmıyoruz
        }

        private void btngiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from tbl_hasta where hasta_tc=@p1 and hasta_sifre=@p2", bgl.baglanti());
            //verileri sql'e sorgulamak için kullanılır
            komut.Parameters.AddWithValue("@p1", msktc.Text);
            komut.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader dr= komut.ExecuteReader();
            if (dr.Read())
            {
                frm_hastadetay fr = new frm_hastadetay();
                fr.tc = msktc.Text; //tc public bir degisken erisim saglanır 
                fr.ShowDialog();
            }
            else
            {
                MessageBox.Show("Hatalı TC & sifre");
            }
            bgl.baglanti().Close();
        }
    }
}
/*ExecuteNonQuery: Insert, update, delete işlemlerinde kullanılmaktadır. İşlem sonucuna göre geriye int tipinde değer döndürmektedir.
ExecuteScalar: Tek alanlık bir değeri geri döndürmek için kullanılmaktadır. Object tipinde veri döndürmektedir.
ExecuteReader: Birden fazla satır sonucu döndüren sorgular için kullanılmaktadır. Geriye SqlDataReader tipinde veri döndürmektedir.
SqlCommand, T-Sql sorguları ile veritabanı üzerinde sorgulama, ekleme, güncelleme, silme işlemlerini yapmak için kullanılmaktadır. System.Data.SqlClient namespace' i altında bulunmaktadır. 
 */
