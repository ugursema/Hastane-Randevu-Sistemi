using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hastane_proje
{
    static class Program
    {
        [STAThread] //From uygulamalarının giris noktasında bulunmalı/ dogru çalışmayablir
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Frmgirisler());
        }
    }
}
