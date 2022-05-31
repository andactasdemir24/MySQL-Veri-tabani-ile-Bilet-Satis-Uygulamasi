using Andaçux.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Andaçux.UI
{
    public partial class Üyeler : Form
    {
        public Üyeler()
        {
            InitializeComponent();
        }


        private void btnÜyeEkle_Click(object sender, EventArgs e)
        {
            FormUye formUye = new FormUye()
            {
                Text = "Üye Ekle",
                Uye = new Uye() { ID = Guid.NewGuid() },
            };
        tekrar:
            var sonuc = formUye.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.ÜyeEkle(formUye.Uye);

                if (b)
                {
                    DataSet ds = BLogic.ÜyeGetir("");
                    if (ds != null)
                        dataGridView1.DataSource = ds.Tables[0];
                }
                else
                    goto tekrar;

            }
        }

        private void btnÜyeDüzenle_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];

            FormUye formUye = new FormUye()
            {
                Text = "Üye Güncelle",
                Güncelleme = true,
                Uye = new Uye()
                {
                    ID = Guid.Parse(row.Cells[0].Value.ToString()),
                    Ad = row.Cells[1].Value.ToString(),
                    SoyAd = row.Cells[2].Value.ToString(),
                    Telefon = row.Cells[3].Value.ToString(),
                    Tc = row.Cells[4].Value.ToString(),
                    Mail = row.Cells[5].Value.ToString(),
                    Şehir = row.Cells[6].Value.ToString(),
                    Yaş = row.Cells[7].Value.ToString(),
                    Adres = row.Cells[8].Value.ToString(),
                },
            };
            var sonuc = formUye.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.ÜyeGüncelle(formUye.Uye);

                if (b)
                {

                    row.Cells[1].Value = formUye.Uye.Ad;
                    row.Cells[2].Value = formUye.Uye.SoyAd;
                    row.Cells[3].Value = formUye.Uye.Telefon;
                    row.Cells[4].Value = formUye.Uye.Tc;
                    row.Cells[5].Value = formUye.Uye.Mail;
                    row.Cells[6].Value = formUye.Uye.Şehir;
                    row.Cells[7].Value = formUye.Uye.Yaş;
                    row.Cells[8].Value = formUye.Uye.Adres;
                }

            }
        }

        private void btnÜyeBul_Click(object sender, EventArgs e)
        {
            DataSet ds = BLogic.ÜyeGetir(toolStripTextBox1.Text);
            if (ds != null)
                dataGridView1.DataSource = ds.Tables[0];
        }



        private void btnÜyeSil_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            var ID = row.Cells[0].Value.ToString();

            var sonuc = MessageBox.Show("Seçili kayıt silinsin mi?", "Silmeyi onayla", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.ÜyeSil(ID);

                if (b)
                {
                    DataSet ds = BLogic.ÜyeGetir("");
                    if (ds != null)
                        dataGridView1.DataSource = ds.Tables[0];
                }
            }
        }

        private void Üyeler_Load(object sender, EventArgs e)
        {
            DataSet ds1 = BLogic.ÜyeGetir("");
            if (ds1 != null)
                dataGridView1.DataSource = ds1.Tables[0];
        }

        public Uye Uye { get; set; }
        private void btnOK_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];

            Uye = new Uye()
            {
                ID = Guid.Parse(row.Cells[0].Value.ToString()),
                Ad = row.Cells[1].Value.ToString(),
                SoyAd = row.Cells[2].Value.ToString(),
                Telefon = row.Cells[3].Value.ToString(),
                Tc = row.Cells[4].Value.ToString(),
                Mail = row.Cells[5].Value.ToString(),
                Şehir = row.Cells[6].Value.ToString(),
                Yaş = row.Cells[7].Value.ToString(),
                Adres = row.Cells[8].Value.ToString(),
            };

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
