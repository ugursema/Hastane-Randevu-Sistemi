using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hastane_proje
{
   public static class msj //msj sınıfı olusturduk porjede her yerdde yazmak yerine gereken yerde cagırmadık için
    {
        public static Boolean sor(string mesaj)
        {
            DialogResult s = new DialogResult();
            s = MessageBox.Show(mesaj, "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (s == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void bilgi(string mesaj)
        {
            MessageBox.Show(mesaj, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        public static void uyari(string mesaj)
        {
            MessageBox.Show(mesaj, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
