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
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }

        //ADO.NET
        Sql_Connection sqlconnection = new Sql_Connection();
        void OgrtListele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute AyarlarOgrt", sqlconnection.Connection());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            sqlconnection.Connection().Close();
        }

        void OgretmenEkle()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select OGRTID, (OGRTAD + ' ' + OGRTSOYAD) as OGRTADSOYAD, OGRTBRANS from Ogretmenler", sqlconnection.Connection());
            da.Fill(dt);
            lookUpEdit1.Properties.ValueMember = "OGRTID";
            lookUpEdit1.Properties.DisplayMember = "OGRTADSOYAD";
            lookUpEdit1.Properties.DataSource = dt;
            sqlconnection.Connection().Close();
        }

        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            OgrtListele();
            OgrListele();
            OgretmenEkle();
            OgrenciEkle();
            OgrtTemizle();
            OgrTemizle();
        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                TxtOgrtId.Text = dr["AYARLAROGRTID"].ToString();
                lookUpEdit1.Text = dr["OGRTADSOYAD"].ToString();
                MskOgrtTc.Text = dr["OGRTTC"].ToString();
                TxtBrans.Text = dr["OGRTBRANS"].ToString();
                TxtOgrtSifre.Text = dr["OGRTSIFRE"].ToString();
            }
        }

        private void lookUpEdit1_Properties_EditValueChanged(object sender, EventArgs e)
        {
            TxtOgrtSifre.Text = " ";
            SqlCommand cmd = new SqlCommand("Select * from Ogretmenler where OGRTID = @Id", sqlconnection.Connection());
            cmd.Parameters.AddWithValue("@Id", lookUpEdit1.ItemIndex + 1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TxtOgrtId.Text = dr["OGRTID"].ToString();
                MskOgrtTc.Text = dr["OGRTTC"].ToString();
                TxtBrans.Text = dr["OGRTBRANS"].ToString();
            }
            sqlconnection.Connection().Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Insert into OgrtAyarlar (AYARLAROGRTID, OGRTSIFRE) Values (@Id, @Sifre)", sqlconnection.Connection());
            cmd.Parameters.AddWithValue("Id", TxtOgrtId.Text);
            cmd.Parameters.AddWithValue("@Sifre", TxtOgrtSifre.Text);
            cmd.ExecuteNonQuery();
            sqlconnection.Connection().Close();
            OgrtListele();
            MessageBox.Show("Şifre Oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update OgrtAyarlar set OGRTSIFRE = @Sifre where AYARLAROGRTID = @Id", sqlconnection.Connection());
            cmd.Parameters.AddWithValue("@Id", TxtOgrtId.Text);
            cmd.Parameters.AddWithValue("@Sifre", TxtOgrtSifre.Text);
            cmd.ExecuteNonQuery();
            sqlconnection.Connection().Close();
            OgrtListele();
            MessageBox.Show("Şifre Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void OgrtTemizle()
        {
            TxtOgrtId.Text = " ";
            lookUpEdit1.EditValue = " ";
            MskOgrtTc.Text = " ";
            TxtBrans.Text = " ";
            TxtOgrtSifre.Text = " ";
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            OgrtTemizle();
        }

        //Entity Framework
        DbOkulOtomasyonEntities db = new DbOkulOtomasyonEntities();
        void OgrListele()
        {
            gridControl2.DataSource = db.AyarlarOgr();
        }

        void OgrenciEkle()
        {
            var query = from item in db.Ogrenciler
                        select new
                        {
                            OGRID = item.OGRID,
                            OGRADSOYAD = item.OGRAD + " " + item.OGRSOYAD,
                            OGRSINIF = item.OGRSINIF,
                        };
            lookUpEdit2.Properties.ValueMember = "OGRID";
            lookUpEdit2.Properties.DisplayMember = "OGRADSOYAD";
            lookUpEdit2.Properties.DataSource = query.ToList();
        }

        private void gridView2_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            TxtOgrId.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "AYARLAROGRID").ToString();
            lookUpEdit2.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OGRADSOYAD").ToString();
            MskOgrTc.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OGRTC").ToString();
            TxtSinif.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OGRSINIF").ToString();
            TxtOgrSifre.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OGRSIFRE").ToString();
        }

        private void lookUpEdit2_Properties_EditValueChanged(object sender, EventArgs e)
        {
            TxtOgrSifre.Text = " ";
            using (DbOkulOtomasyonEntities db = new DbOkulOtomasyonEntities())
            {
                Ogrenciler ogrenciler = db.Ogrenciler.Find(lookUpEdit2.ItemIndex + 1);
                if (ogrenciler != null)
                {
                    TxtOgrId.Text = ogrenciler.OGRID.ToString();
                    MskOgrTc.Text = ogrenciler.OGRTC;
                    TxtSinif.Text = ogrenciler.OGRSINIF;
                }
                else { }
            }
        }

        private void BtnOgrKaydet_Click(object sender, EventArgs e)
        {
            OgrAyarlar ogrAyarlar = new OgrAyarlar();
            ogrAyarlar.AYARLAROGRID = Convert.ToInt32(TxtOgrId.Text);
            ogrAyarlar.OGRSIFRE = TxtOgrSifre.Text;
            db.OgrAyarlar.Add(ogrAyarlar);
            db.SaveChanges();
            OgrListele();
            MessageBox.Show("Şifre Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnOgrGüncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "AYARLAROGRID"));
            var item = db.OgrAyarlar.Find(id);
            item.AYARLAROGRID = Convert.ToInt32(TxtOgrId.Text);
            item.OGRSIFRE = TxtOgrSifre.Text;
            db.SaveChanges();
            OgrListele();
            MessageBox.Show("Şifre Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void OgrTemizle()
        {
            TxtOgrtId.Text = " ";
            lookUpEdit2.EditValue = " ";
            MskOgrTc.Text = " ";
            TxtSinif.Text = " ";
            TxtOgrSifre.Text = " ";
        }

        private void BtnOgrTemizle_Click(object sender, EventArgs e)
        {
            OgrTemizle();
        }
    }
}
