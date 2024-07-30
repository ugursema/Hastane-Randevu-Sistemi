using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace hastane_proje
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti() //sql baglantısını class da oluşturup projenin için de cagırdım
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-EJ24LEI;Initial Catalog=hastane_proje;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
