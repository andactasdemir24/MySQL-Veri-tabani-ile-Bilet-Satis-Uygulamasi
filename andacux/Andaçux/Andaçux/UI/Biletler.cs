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
    public partial class Biletler : Form
    {
        public Biletler()
        {
            InitializeComponent();
        }

        private void btnBiletEkle_Click(object sender, EventArgs e)
        {
            FormBilet form = new FormBilet()
            {
                Text = "Bilet Ekle",
                Bilet = new Bilet() { ID = Guid.NewGuid() },
            };

        tekrar:
            var sonuc = form.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.BiletEkle(form.Bilet);

                if (b)
                {
                    DataSet ds = BLogic.BiletGetir("");
                    if (ds != null)
                        dataGridView2.DataSource = ds.Tables[0];
                }
                else
                    goto tekrar;

            }
        }

        private void btnBiletBul_Click(object sender, EventArgs e)
        {
            DataSet ds = BLogic.BiletGetir(toolStripTextBox2.Text);
            if (ds != null)
                dataGridView2.DataSource = ds.Tables[0];
        }

        private void btnBiletDüzenle_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView2.SelectedRows[0];

            FormBilet form = new FormBilet()
            {
                Text = "Bilet Güncelle",
                Güncelleme = true,
                Bilet = new Bilet()
                {
                    ID = Guid.Parse(row.Cells[0].Value.ToString()),
                    Ad = row.Cells[1].Value.ToString(),
                    Adet = row.Cells[2].Value.ToString(),
                    Kategori = row.Cells[3].Value.ToString(),
                    Fiyat = double.Parse(row.Cells[4].Value.ToString()),
                    Adres = row.Cells[5].Value.ToString(),

                },
            };

            var sonuc = form.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.BiletGüncelle(form.Bilet);

                if (b)
                {

                    row.Cells[1].Value = form.Bilet.Ad;
                    row.Cells[2].Value = form.Bilet.Adet;
                    row.Cells[3].Value = form.Bilet.Kategori;
                    row.Cells[4].Value = form.Bilet.Fiyat;
                    row.Cells[5].Value = form.Bilet.Adres;

                }

            }
        }

        private void btnBiletSil_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView2.SelectedRows[0];
            var ID = row.Cells[0].Value.ToString();

            var sonuc = MessageBox.Show("Seçili kayıt silinsin mi?", "Silmeyi onayla", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.BiletSil(ID);

                if (b)
                {
                    DataSet ds = BLogic.BiletGetir("");
                    if (ds != null)
                        dataGridView2.DataSource = ds.Tables[0];
                }
            }
        }

        private void Biletler_Load(object sender, EventArgs e)
        {

            DataSet ds2 = BLogic.BiletGetir("");
            if (ds2 != null)
                dataGridView2.DataSource = ds2.Tables[0];
        }
        public Bilet Bilet { get; set; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView2.SelectedRows[0];


            Bilet = new Bilet()
            {
                ID = Guid.Parse(row.Cells[0].Value.ToString()),
                Ad = row.Cells[1].Value.ToString(),
                Adet = row.Cells[2].Value.ToString(),
                Kategori = row.Cells[3].Value.ToString(),
                Fiyat = double.Parse(row.Cells[4].Value.ToString()),
                Adres = row.Cells[5].Value.ToString(),

            };
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
