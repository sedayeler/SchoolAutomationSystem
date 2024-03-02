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
using DevExpress.XtraEditors;

namespace OkulOtomasyonSistemi
{
    public partial class FrmOgrenciler : Form
    {
        public FrmOgrenciler()
        {
            InitializeComponent();
        }

        private void FrmOgrenciler_Load(object sender, EventArgs e)
        {
            Listele();
            SehirEkle();
            Temizle();
            VeliEkle();
        }

        Sql_Connection sqlConnection = new Sql_Connection();
        void Listele()
        {
            //9.SINIF
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Execute Ogrenci9", sqlConnection.Connection());
            da1.Fill(dt1);
            gridControl1.DataSource = dt1;

            //10.SINIF
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Execute Ogrenci10", sqlConnection.Connection());
            da2.Fill(dt2);
            gridControl2.DataSource = dt2;

            //11.SINIF
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("Execute Ogrenci11", sqlConnection.Connection());
            da3.Fill(dt3);
            gridControl3.DataSource = dt3;

            //12.SINIF
            DataTable dt4 = new DataTable();
            SqlDataAdapter da4 = new SqlDataAdapter("Execute Ogrenci12", sqlConnection.Connection());
            da4.Fill(dt4);
            gridControl4.DataSource = dt4;
            sqlConnection.Connection().Close();
        }

        void VeliEkle()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select VELIID, (VELIANNE+ ' ' +VELIBABA) as VELIANNEBABA from Veliler", sqlConnection.Connection());
            da.Fill(dt);
            lookUpEdit1.Properties.ValueMember = "VELIID";
            lookUpEdit1.Properties.DisplayMember = "VELIANNEBABA";
            lookUpEdit1.Properties.DataSource = dt;
            sqlConnection.Connection().Close();
        }

        void SehirEkle()
        {
            SqlCommand cmd = new SqlCommand("Select * from Iller", sqlConnection.Connection());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CmbIl.Properties.Items.Add(dr[1]);
            }
            sqlConnection.Connection().Close();
        }

        private void CmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbIlce.Properties.Items.Clear();
            CmbIlce.Text = " ";
            SqlCommand cmd = new SqlCommand("Select * from Ilceler where sehir = @sehir", sqlConnection.Connection());
            cmd.Parameters.AddWithValue("@sehir", CmbIl.SelectedIndex + 1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CmbIlce.Properties.Items.Add(dr[1]);
            }
            sqlConnection.Connection().Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Insert into Ogrenciler (OGRAD, OGRSOYAD, OGRTC, OGRNO, OGRSINIF, OGRDGTRH, OGRCINSIYET, OGRVELIID, OGRIL, OGRILCE, OGRADRES) Values (@Ad, @Soyad, @Tc, @No, @Sınıf, @DgTrh, @Cinsiyet, @VeliId, @Il, @Ilce, @Adres)", sqlConnection.Connection());
            cmd.Parameters.AddWithValue("@Ad", TxtAd.Text);
            cmd.Parameters.AddWithValue("@Soyad", TxtSoyad.Text);
            cmd.Parameters.AddWithValue("@Tc", MskTc.Text);
            cmd.Parameters.AddWithValue("@No", MskOgrNo.Text);
            cmd.Parameters.AddWithValue("@Sınıf", CmbSinif.Text);
            cmd.Parameters.AddWithValue("@DgTrh", dateEdit1.Text);
            if (RdKadin.Checked)
            {
                cmd.Parameters.AddWithValue("@Cinsiyet", RdKadin.Text);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Cinsiyet", RdErkek.Text);
            }
            cmd.Parameters.AddWithValue("@VeliId", lookUpEdit1.EditValue);
            cmd.Parameters.AddWithValue("@Il", CmbIl.Text);
            cmd.Parameters.AddWithValue("@Ilce", CmbIlce.Text);
            cmd.Parameters.AddWithValue("@Adres", RchAdres.Text);
            cmd.ExecuteNonQuery();
            sqlConnection.Connection().Close();
            MessageBox.Show("Öğrenci Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                TxtId.Text = dr["OGRID"].ToString();
                TxtAd.Text = dr["OGRAD"].ToString();
                TxtSoyad.Text = dr["OGRSOYAD"].ToString();
                MskTc.Text = dr["OGRTC"].ToString();
                MskOgrNo.Text = dr["OGRNO"].ToString();
                CmbSinif.Text = dr["OGRSINIF"].ToString();
                dateEdit1.Text = dr["OGRDGTRH"].ToString();
                RdKadin.Checked = dr["OGRCINSIYET"].ToString() == "Kadın";
                RdErkek.Checked = dr["OGRCINSIYET"].ToString() == "Erkek";
                lookUpEdit1.Text = dr["VELIANNEBABA"].ToString();
                CmbIl.Text = dr["OGRIL"].ToString();
                CmbIlce.Text = dr["OGRILCE"].ToString();
                RchAdres.Text = dr["OGRADRES"].ToString();
            }
        }

        private void gridView2_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (dr != null)
            {
                TxtId.Text = dr["OGRID"].ToString();
                TxtAd.Text = dr["OGRAD"].ToString();
                TxtSoyad.Text = dr["OGRSOYAD"].ToString();
                MskTc.Text = dr["OGRTC"].ToString();
                MskOgrNo.Text = dr["OGRNO"].ToString();
                CmbSinif.Text = dr["OGRSINIF"].ToString();
                dateEdit1.Text = dr["OGRDGTRH"].ToString();
                RdKadin.Checked = dr["OGRCINSIYET"].ToString() == "Kadın";
                RdErkek.Checked = dr["OGRCINSIYET"].ToString() == "Erkek";
                lookUpEdit1.Text = dr["VELIANNEBABA"].ToString();
                CmbIl.Text = dr["OGRIL"].ToString();
                CmbIlce.Text = dr["OGRILCE"].ToString();
                RchAdres.Text = dr["OGRADRES"].ToString();
            }
        }

        private void gridView3_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            if (dr != null)
            {
                TxtId.Text = dr["OGRID"].ToString();
                TxtAd.Text = dr["OGRAD"].ToString();
                TxtSoyad.Text = dr["OGRSOYAD"].ToString();
                MskTc.Text = dr["OGRTC"].ToString();
                MskOgrNo.Text = dr["OGRNO"].ToString();
                CmbSinif.Text = dr["OGRSINIF"].ToString();
                dateEdit1.Text = dr["OGRDGTRH"].ToString();
                RdKadin.Checked = dr["OGRCINSIYET"].ToString() == "Kadın";
                RdErkek.Checked = dr["OGRCINSIYET"].ToString() == "Erkek";
                lookUpEdit1.Text = dr["VELIANNEBABA"].ToString();
                CmbIl.Text = dr["OGRIL"].ToString();
                CmbIlce.Text = dr["OGRILCE"].ToString();
                RchAdres.Text = dr["OGRADRES"].ToString();
            }
        }

        private void gridView4_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView4.GetDataRow(gridView4.FocusedRowHandle);
            if (dr != null)
            {
                TxtId.Text = dr["OGRID"].ToString();
                TxtAd.Text = dr["OGRAD"].ToString();
                TxtSoyad.Text = dr["OGRSOYAD"].ToString();
                MskTc.Text = dr["OGRTC"].ToString();
                MskOgrNo.Text = dr["OGRNO"].ToString();
                CmbSinif.Text = dr["OGRSINIF"].ToString();
                dateEdit1.Text = dr["OGRDGTRH"].ToString();
                RdKadin.Checked = dr["OGRCINSIYET"].ToString() == "Kadın";
                RdErkek.Checked = dr["OGRCINSIYET"].ToString() == "Erkek";
                lookUpEdit1.Text = dr["VELIANNEBABA"].ToString();
                CmbIl.Text = dr["OGRIL"].ToString();
                CmbIlce.Text = dr["OGRILCE"].ToString();
                RchAdres.Text = dr["OGRADRES"].ToString();
            }
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update Ogrenciler set OGRAD= @Ad, OGRSOYAD= @Soyad, OGRTC= @Tc, OGRNO= @No, OGRSINIF= @Sınıf, OGRDGTRH= @DgTrh, OGRCINSIYET= @Cinsiyet, OGRVELIID= @VeliId, OGRIL= @Il, OGRILCE= @Ilce, OGRADRES= @Adres where OGRID= @Id", sqlConnection.Connection());
            cmd.Parameters.AddWithValue("@Ad", TxtAd.Text);
            cmd.Parameters.AddWithValue("@Soyad", TxtSoyad.Text);
            cmd.Parameters.AddWithValue("@Tc", MskTc.Text);
            cmd.Parameters.AddWithValue("@No", MskOgrNo.Text);
            cmd.Parameters.AddWithValue("@Sınıf", CmbSinif.Text);
            cmd.Parameters.AddWithValue("@DgTrh", dateEdit1.Text);
            if (RdKadin.Checked)
            {
                cmd.Parameters.AddWithValue("@Cinsiyet", RdKadin.Text);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Cinsiyet", RdErkek.Text);
            }
            cmd.Parameters.AddWithValue("@VeliId", lookUpEdit1.EditValue);
            cmd.Parameters.AddWithValue("@Il", CmbIl.Text);
            cmd.Parameters.AddWithValue("@Ilce", CmbIlce.Text);
            cmd.Parameters.AddWithValue("@Adres", RchAdres.Text);
            cmd.Parameters.AddWithValue("Id", TxtId.Text);
            cmd.ExecuteNonQuery();
            sqlConnection.Connection().Close();
            MessageBox.Show("Öğrenci Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete from Ogrenciler where OGRID= @Id", sqlConnection.Connection());
            cmd.Parameters.AddWithValue("@Id", TxtId.Text);
            cmd.ExecuteNonQuery();
            sqlConnection.Connection().Close();
            MessageBox.Show("Öğrenci Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();
        }

        void Temizle()
        {
            TxtId.Text = " ";
            TxtAd.Text = " ";
            TxtSoyad.Text = " ";
            MskTc.Text = " ";
            MskOgrNo.Text = " ";
            CmbSinif.Text = " ";
            dateEdit1.Text = " ";
            RdKadin.Checked = false;
            RdErkek.Checked = false;
            lookUpEdit1.Text = " ";
            CmbIl.Text = " ";
            CmbIlce.Text = " ";
            RchAdres.Text = " ";
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
