using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OkulOtomasyonSistemi
{
    public partial class FrmWebSayfa : Form
    {
        public FrmWebSayfa()
        {
            InitializeComponent();
        }

        private void FrmWebSayfa_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://efal.meb.k12.tr/");
        }
    }
}
