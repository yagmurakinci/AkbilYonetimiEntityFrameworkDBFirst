using AkbilYonetimBusinessLayer;
using AkbilYonetimiDataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkbilYonetimiFormUI
{
    public partial class FrmGiris : Form
    {
        public string Email { get; set; }
        AKBİLYONETİMİDBEntities akbilYonetimi = new AKBİLYONETİMİDBEntities();
        public FrmGiris()
        {
            InitializeComponent();
        }
      

      

        private void button1_Click(object sender, EventArgs e)
        {
            GirisYap();
        }

        private void GirisYap()
        {
            try
            {
                foreach (var item in Controls)
                {
                    if (item is TextBox && (((TextBox)item).Text == null || ((TextBox)item).Text == string.Empty))
                    {
                        MessageBox.Show("Zorunlu alanlar boş geçilemez! ");
                        return; 
                    }
                }

                string parola = GenelIslemler.MD5Encryption(txtSifre.Text);
                var girisYapanKullanici = akbilYonetimi.Kullanicilar.FirstOrDefault(k => k.Email.ToLower() == txtEmail.Text.ToLower() && k.Parola == parola);
                if (girisYapanKullanici==null)
                {
                    MessageBox.Show("Kullanıcı adınız ya da şifreniz yanlıştır!");
                    return;
                }

                GenelIslemler.GirisYapmisKullaniciID = girisYapanKullanici.Id;
                GenelIslemler.GirisYapmisKullaniciAdSoyad = $"{girisYapanKullanici.Isim} {girisYapanKullanici.Soyisim}";


                    MessageBox.Show($"Hoşgeldiniz.... {GenelIslemler.GirisYapmisKullaniciAdSoyad}");

                LogYoneticisi.LoguYaz($"{GenelIslemler.GirisYapmisKullaniciAdSoyad} adlı kullanıcı giriş yaptı.");


                    if (checkBoxBeniHatirla.Checked)
                    {
                        Properties.Settings.Default.KullaniciEmail = txtEmail.Text;
                        Properties.Settings.Default.KullaniciSifre = txtSifre.Text;
                        AkbilYonetimiFormUI.Properties.Settings.Default.BeniHatirla = true;
                        Properties.Settings.Default.Save();
                    }
                    this.Hide();
                    FrmIslemler frmIslemler = new FrmIslemler();
                    frmIslemler.Show();
                
            }
            catch (Exception hata)
            {
                
                MessageBox.Show("Beklenmedik hata oluştu!");
                LogYoneticisi.LoguYaz($"FrmGiris GirisYap metodu HATA: {hata}");
            }
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmKayitOl frmKayitOl = new FrmKayitOl();
            frmKayitOl.Show();
            
        }

        private void FrmGiris_Load(object sender, EventArgs e)
        {
            if (Email !=null)
            {
                txtEmail.Text = Email;
            }
            txtEmail.TabIndex = 1;
            txtSifre.TabIndex = 2;
            btnGirisYap.TabIndex = 3;
            btnKayitOl.TabIndex = 4;


            if (AkbilYonetimiFormUI.Properties.Settings.Default.BeniHatirla)
            {
                txtEmail.Text = AkbilYonetimiFormUI.Properties.Settings.Default.KullaniciEmail;
                txtSifre.Text = AkbilYonetimiFormUI.Properties.Settings.Default.KullaniciSifre;
                checkBoxBeniHatirla.Checked = true;
            }

        }

        private void txtSifre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                GirisYap();
            }
        }

        private void checkBoxBeniHatirla_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBeniHatirla.Checked)
            {
                AkbilYonetimiFormUI.Properties.Settings.Default.BeniHatirla = true;
            }
            else
            {
                AkbilYonetimiFormUI.Properties.Settings.Default.BeniHatirla = false;
            }
        }

        private void FrmGiris_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void checkBoxBeniHatirla_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!checkBoxBeniHatirla.Checked)
            {
                Properties.Settings.Default.KullaniciEmail = string.Empty;
                Properties.Settings.Default.KullaniciSifre = string.Empty;
                AkbilYonetimiFormUI.Properties.Settings.Default.BeniHatirla = false;
                Properties.Settings.Default.Save();
            }
        }
    }
}
