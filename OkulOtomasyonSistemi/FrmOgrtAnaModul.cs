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
    public partial class FrmOgrtAnaModul : Form
    {
        public FrmOgrtAnaModul()
        {
            InitializeComponent();
        }

        FrmOgretmenler frmOgretmenler;
        private void BtnOgretmen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmOgretmenler == null || frmOgretmenler.IsDisposed)
            {
                frmOgretmenler = new FrmOgretmenler();
                frmOgretmenler.MdiParent = this;
                frmOgretmenler.Show();
            }
        }

        FrmOgrenciler frmOgrenciler;
        private void BtnOgrenciler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmOgrenciler == null || frmOgrenciler.IsDisposed)
            {
                frmOgrenciler = new FrmOgrenciler();
                frmOgrenciler.MdiParent = this;
                frmOgrenciler.Show();
            }
        }

        FrmVeliler frmVeliler;
        private void BtnVeliler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmVeliler == null || frmVeliler.IsDisposed)
            {
                frmVeliler = new FrmVeliler();
                frmVeliler.MdiParent = this;
                frmVeliler.Show();
            }
        }

        FrmAyarlar frmAyarlar;
        private void BtnAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmAyarlar == null || frmAyarlar.IsDisposed)
            {
                frmAyarlar = new FrmAyarlar();
                frmAyarlar.MdiParent = this;
                frmAyarlar.Show();
            }
        }

        FrmWebSayfa frmWebSayfa;
        private void BtnWebSayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmWebSayfa == null || frmWebSayfa.IsDisposed)
            {
                frmWebSayfa = new FrmWebSayfa();
                frmWebSayfa.MdiParent = this;
                frmWebSayfa.Show();
            }
        }
    }
}
