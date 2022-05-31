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
    public partial class FormUye : Form
    {
        public FormUye()
        {
            InitializeComponent();
        }

      

        public Uye Uye { get; set; }
        public bool Güncelleme { get; set; } = false;
        private void BtnOk_Click(object sender, EventArgs e)
        {           
            if (!ErrorControl(txtAd)) return;
            if (!ErrorControl(txtSoyad)) return;
            if (!ErrorControl(txtTel)) return;
            if (!ErrorControl(txtTc)) return;
            if (!ErrorControl(txtMail)) return;
            if (!ErrorControl(txtSehir)) return;
            if (!ErrorControl(txtYas)) return;
            if (!ErrorControl(txtAdres)) return;


            Uye.Ad = txtAd.Text;
            Uye.SoyAd = txtSoyad.Text;
            Uye.Telefon = txtTel.Text;
            Uye.Tc = txtTc.Text;
            Uye.Mail = txtMail.Text;
            Uye.Şehir = txtSehir.Text;
            Uye.Yaş = txtYas.Text;
            Uye.Adres = txtAdres.Text;

            DialogResult = DialogResult.OK;
        }
       

        private void BtnCancel_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.Cancel;
        }

        private bool ErrorControl(Control c)
        {
            if(c is TextBox) { 
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

            if (c is MaskedTextBox)
            {
                if (!((MaskedTextBox)c).MaskFull)
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

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void FormUye_Load(object sender, EventArgs e)
        {
            txtID.Text = Uye.ID.ToString();

            if (Güncelleme)
            {
                txtAd.Text = Uye.Ad;
                txtSoyad.Text = Uye.SoyAd;
                txtTel.Text = Uye.Telefon;
                txtTc.Text = Uye.Tc;
                txtMail.Text = Uye.Mail;
                txtSehir.Text = Uye.Şehir;
                txtYas.Text = Uye.Yaş;
                txtAdres.Text = Uye.Adres;
            }
            else
            {

            }
        }
    }
}
