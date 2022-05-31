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
    public partial class FormBilet : Form
    {
        public FormBilet()
        {
            InitializeComponent();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        public Bilet Bilet { get; set; }
        public bool Güncelleme { get; set; } = false;

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (!ErrorControl(txtBiletAd)) return;
            if (!ErrorControl(nmAdet)) return;
            if (!ErrorControl(cbKategori)) return;
            if (!ErrorControl(nmFiyat)) return;
            if (!ErrorControl(txtAdres)) return;

            Bilet.Ad = txtBiletAd.Text;
            Bilet.Adet = nmAdet.Text;
            Bilet.Kategori = cbKategori.Text;
            Bilet.Fiyat = (double)nmFiyat.Value;
            Bilet.Adres = txtAdres.Text;

            DialogResult = DialogResult.OK;
        }
        private bool ErrorControl(Control c)
        {
            if (c is TextBox || c is ComboBox)
            {
                if (c.Text == "")
                {
                    errorProvider1.SetError(c, "Eksik veya hatalı bilgi.");
                    c.Focus();
                    return false;
                }
                else
                {
                    errorProvider1.SetError(c, "");
                    return true;
                }
            }

            if (c is NumericUpDown)
            {
                if (((NumericUpDown)c).Value == 0)
                {
                    errorProvider1.SetError(c, "Eksik veya hatalı bilgi.");
                    c.Focus();
                    return false;
                }
                else
                {
                    errorProvider1.SetError(c, "");
                    return true;
                }
            }
            return true;
        }

        private void FormBilet_Load(object sender, EventArgs e)
        {
            txtID.Text = Bilet.ID.ToString();
            if (Güncelleme)
            {
                txtBiletAd.Text = Bilet.Ad;
                nmAdet.Text = Bilet.Adet;
                cbKategori.Text = Bilet.Kategori;
                nmFiyat.Value = (decimal)Bilet.Fiyat;
                txtAdres.Text = Bilet.Adres;
            }
        }
    }
}
