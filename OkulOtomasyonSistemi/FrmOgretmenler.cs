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
    public partial class FrmOgretmenler : Form
    {
        public FrmOgretmenler()
        {
            InitializeComponent();
        }

        private void FrmOgretmenler_Load(object sender, EventArgs e)
        {
            Listele();
            BransEkle();
            Temizle();
        }

        Sql_Connection sqlConnection = new Sql_Connection();
        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Ogretmenler", sqlConnection.Connection());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            sqlConnection.Connection().Close();
        }

        void BransEkle()
        {
            SqlCommand cmd = new SqlCommand("Select * from Branslar", sqlConnection.Connection());
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                CmbBrans.Properties.Items.Add(read[1]);
            }
            sqlConnection.Connection().Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Insert into Ogretmenler (OGRTID, OGRTAD, OGRTSOYAD, OGRTTC, OGRTTEL, OGRTMAIL, OGRTADRES, OGRTBRANS) Values ('" + TxtId.Text + "', '" + TxtAd.Text + "', '" + TxtSoyad.Text + "', '" + MskTc.Text + "', '" + MskTel.Text + "', '" + TxtMail.Text + "', '" + RchAdres.Text + "', '" + CmbBrans.Text + "')", sqlConnection.Connection());
            cmd.ExecuteNonQuery();
            sqlConnection.Connection().Close();
            MessageBox.Show("Öğretmen Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                TxtId.Text = dr["OGRTID"].ToString();
                TxtAd.Text = dr["OGRTAD"].ToString();
                TxtSoyad.Text = dr["OGRTSOYAD"].ToString();
                MskTc.Text = dr["OGRTTC"].ToString();
                MskTel.Text = dr["OGRTTEL"].ToString();
                TxtMail.Text = dr["OGRTMAIL"].ToString();
                RchAdres.Text = dr["OGRTADRES"].ToString();
                CmbBrans.Text = dr["OGRTBRANS"].ToString();
            }
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update Ogretmenler set OGRTAD = @Ad, OGRTSOYAD = @Soyad, OGRTTC = @Tc, OGRTTEL = @Tel, OGRTMAIL = @Mail, OGRTADRES = @Adres, OGRTBRANS = @Brans where OGRTID = @ID", sqlConnection.Connection());
            cmd.Parameters.AddWithValue("@Ad", TxtAd.Text);
            cmd.Parameters.AddWithValue("@Soyad", TxtSoyad.Text);
            cmd.Parameters.AddWithValue("@Tc", MskTc.Text);
            cmd.Parameters.AddWithValue("@Tel", MskTel.Text);
            cmd.Parameters.AddWithValue("@Mail", TxtMail.Text);
            cmd.Parameters.AddWithValue("@Adres", RchAdres.Text);
            cmd.Parameters.AddWithValue("@Brans", CmbBrans.Text);
            cmd.Parameters.AddWithValue("@ID", TxtId.Text);
            cmd.ExecuteNonQuery();
            sqlConnection.Connection().Close();
            MessageBox.Show("Öğretmen Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete from Ogretmenler where OGRTID = @ID", sqlConnection.Connection());
            cmd.Parameters.AddWithValue("@ID", TxtId.Text);
            cmd.ExecuteNonQuery();
            sqlConnection.Connection().Close();
            MessageBox.Show("Öğretmen Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();
        }

        void Temizle()
        {
            TxtId.Text = " ";
            TxtAd.Text = " ";
            TxtSoyad.Text = " ";
            MskTc.Text = " ";
            MskTel.Text = " ";
            TxtMail.Text = " ";
            RchAdres.Text = " ";
            CmbBrans.Text = " ";
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}

