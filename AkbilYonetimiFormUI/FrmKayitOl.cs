﻿using AkbilYonetimBusinessLayer;
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
    public partial class FrmKayitOl : Form
    {
        public FrmKayitOl()
        {
            InitializeComponent();
        }
        AKBİLYONETİMİDBEntities akbilYonetimi = new AKBİLYONETİMİDBEntities();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in Controls)
                {
                    if (item is TextBox && (((TextBox)item).Text ==null || ((TextBox)item).Text == string.Empty ))
                    {
                        MessageBox.Show("Zorunlu alanlar boş geçilemez! ");
                        return; 
                    }
                }
                //aynı emailden varsa hata ver
                //linq komutları entity framework ile çokça kullanılır


                //select count(*) from Kullanicilar where
                //Email='bbb'

                //if (akbilYonetimi.Kullanicilar.FirstorDefault(x=> x.Email.ToLower()==txtEmail.Text.ToLower())!=null)

                if (akbilYonetimi.Kullanicilar.Count(x=> x.Email.ToLower()==txtEmail.Text.ToLower())!=0)
                {
                    MessageBox.Show("Bu email sistemde zaten vardır");
                    return;
                }

                Kullanicilar yeniKullanici = new Kullanicilar()
                {
                    DogumTarihi = dtpDogumTarihi.Value,
                    Email = txtEmail.Text,
                    Isim = txtIsim.Text,
                    Soyisim = txtSoyisim.Text,
                    KayitTarihi = DateTime.Now,
                    Parola = GenelIslemler.MD5Encryption(txtSifre.Text)

                };

                akbilYonetimi.Kullanicilar.Add(yeniKullanici);
                int sonuc = akbilYonetimi.SaveChanges(); // add, update, delete

                
                
                //yeni kodlar gelecek
                if (sonuc>0)
                {
                    MessageBox.Show("Yeni Kullanıcı Eklendi");
                    //temizlik
                    foreach (var item in this.Controls)
                    {
                        if (item is TextBox)
                        {
                            ((TextBox)item).Enabled = false;
                        }
                        if (item is DateTimePicker)
                        {
                            ((DateTimePicker)item).Enabled = false;
                        }
                    }//foreach bitti
                    DialogResult cevap = MessageBox.Show("Giriş sayfasına yönlendirilmek ister misiniz?","Soru",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
                    if (cevap==DialogResult.Yes)
                    {
                        FrmGiris frmGiris = new FrmGiris();
                        frmGiris.Email = txtEmail.Text;
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            Application.OpenForms[i].Hide();
                        }

                        frmGiris.Show();
                        
                    }

                }//if bitti sonuc>0
                else
                {
                    MessageBox.Show("Ekleme işlemi başarısız...");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Beklenmedik hata oluştu! \n Hata: {ex.Message}","HATA BİLDİRİMİ",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }
        }

        private void FrmKayitOl_Load(object sender, EventArgs e)
        {
            txtSifre.PasswordChar = '*';
            dtpDogumTarihi.MaxDate = new DateTime(2015, 12, 31);
            dtpDogumTarihi.Value = new DateTime(2015, 12, 31);
            
            
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmGiris frmGiris = new FrmGiris();
            frmGiris.Email = txtEmail.Text;
            frmGiris.Show();
        }

        private void FrmKayitOl_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            FrmGiris frmGiris = new FrmGiris();
            frmGiris.Email = txtEmail.Text;
            frmGiris.Show();
        }
    }
}
