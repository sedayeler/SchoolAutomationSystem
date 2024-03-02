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

namespace OkulOtomasyonSistemi
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        Sql_Connection sqlconnection = new Sql_Connection();
        private void BtnOgrt_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select OGRTTC, OGRTSIFRE from Ogretmenler inner join OgrtAyarlar on Ogretmenler.OGRTID = OgrtAyarlar.AYARLAROGRTID where OGRTTC = @Tc and OGRTSIFRE = @Sifre", sqlconnection.Connection());
            cmd.Parameters.AddWithValue("@Tc", MskKullanici.Text);
            cmd.Parameters.AddWithValue("@Sifre", TxtSifre.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                FrmOgrtAnaModul frmAnaModul = new FrmOgrtAnaModul();
                frmAnaModul.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı veya Şifre", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MskKullanici.Text = " ";
                TxtSifre.Text = " ";
            }
            sqlconnection.Connection().Close();
        }

        DbOkulOtomasyonEntities db = new DbOkulOtomasyonEntities();
        private void BtnOgrenci_Click(object sender, EventArgs e)
        {
            var query = from d1 in db.Ogrenciler
                        join d2 in db.OgrAyarlar
                        on d1.OGRID equals d2.AYARLAROGRID
                        where d1.OGRTC == MskKullanici.Text &&
                              d2.OGRSIFRE == TxtSifre.Text
                        select new { };
            if (query.Any())
            {
                FrmOgrAnaModul frmOgrAnaModul = new FrmOgrAnaModul();
                frmOgrAnaModul.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı veya Şifre", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MskKullanici.Text = " ";
                TxtSifre.Text = " ";
            }
        }
    }
}
