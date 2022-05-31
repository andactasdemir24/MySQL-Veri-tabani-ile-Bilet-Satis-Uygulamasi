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
    public partial class FormSatis : Form
    {
        public FormSatis()
        {
            InitializeComponent();
        }


        public Satis Satis { get; set; }
        public bool Güncelleme { get; set; } = false;

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (nmFiyat.Value == 0)
            {
                errorProvider1.SetError(nmFiyat, "Lütfen fiyat giriniz!");
                nmFiyat.Focus();
                return;

            }
            else
            {
                errorProvider1.SetError(nmFiyat, "");
            }

         
            Satis.Tarih = dtTarih.Value;
            Satis.Fiyat = (double)nmFiyat.Value;
            Satis.BiletID = Guid.Parse(txtBilet.Text);
            Satis.UyeID = Guid.Parse( txtUye.Text);
         

            DialogResult = DialogResult.OK;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void FormSatis_Load(object sender, EventArgs e)
        {
            txtID.Text = Satis.ID.ToString();
            if (Güncelleme)
            {
                txtUye.Text = Satis.UyeID.ToString();
                txtBilet.Text = Satis.BiletID.ToString();
                nmFiyat.Value = (decimal)Satis.Fiyat;
                dtTarih.Value = Satis.Tarih;
            }
            
        }

        private void btnÜyeSeç_Click(object sender, EventArgs e)
        {
            Üyeler form = new Üyeler();
            if (form.ShowDialog() == DialogResult.OK)
            {
                txtUye.Text = form.Uye.ID.ToString();                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Biletler form = new Biletler();
            if (form.ShowDialog() == DialogResult.OK)
            {
                txtBilet.Text = form.Bilet.ID.ToString();
            }
        }
    }
}
