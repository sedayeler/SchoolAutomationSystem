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
    public partial class FrmVeliler : Form
    {
        public FrmVeliler()
        {
            InitializeComponent();
        }

        DbOkulOtomasyonEntities db = new DbOkulOtomasyonEntities();
        void Listele()
        {
            var query = from item in db.Veliler
                        select new { item.VELIID, item.VELIANNE, item.VELIBABA, item.VELITEL1, item.VELITEL2, item.VELIMAIL };

            gridControl1.DataSource = query.ToList();
        }

        private void FrmVeliler_Load(object sender, EventArgs e)
        {
            Listele();
            Temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            Veliler veli = new Veliler();
            veli.VELIANNE = TxtAnne.Text;
            veli.VELIBABA = TxtBaba.Text;
            veli.VELITEL1 = MskTel1.Text;
            veli.VELITEL2 = MskTel2.Text;
            veli.VELIMAIL = TxtMail.Text;
            db.Veliler.Add(veli);
            db.SaveChanges();
            Listele();
            MessageBox.Show("Veli Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle < gridView1.RowCount)
            {
                TxtId.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VELIID")?.ToString();
                TxtAnne.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VELIANNE")?.ToString();
                TxtBaba.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VELIBABA")?.ToString();
                MskTel1.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VELITEL1")?.ToString();
                MskTel2.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VELITEL2")?.ToString();
                TxtMail.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VELIMAIL")?.ToString();
            }
            else { }
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VELIID").ToString());
            var item = db.Veliler.Find(id);
            item.VELIANNE = TxtAnne.Text;
            item.VELIBABA = TxtBaba.Text;
            item.VELITEL1 = MskTel1.Text;
            item.VELITEL2 = MskTel2.Text;
            item.VELIMAIL = TxtMail.Text;
            db.SaveChanges();
            Listele();
            MessageBox.Show("Veli Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VELIID").ToString());
            var item = db.Veliler.Find(id);
            db.Veliler.Remove(item);
            db.SaveChanges();
            Listele();
            MessageBox.Show("Veli Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        void Temizle()
        {
            TxtId.Text = " ";
            TxtAnne.Text = " ";
            TxtBaba.Text = " ";
            MskTel1.Text = " ";
            MskTel2.Text = " ";
            TxtMail.Text = " ";
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
