using AkbilYonetimBusinessLayer;
using AkbilYonetimiDataLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkbilYonetimiFormUI
{
    public partial class FrmAyarlar : Form
    {
        
        public FrmAyarlar()
        {
            InitializeComponent();
        }

        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            dtpDogumTarihi.Format = DateTimePickerFormat.Short;
        }

        private void KullaniciBilgileriniDoldur()
        {
            try
            {
                //yeni kodlar gelecek

            }
            catch (Exception hata)
            {

                MessageBox.Show("Beklenmedik bir hata oluştu" + hata.Message);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIsim.Text==null || txtIsim.Text==string.Empty || txtSoyisim.Text == null || txtSoyisim.Text == string.Empty)
                {
                    MessageBox.Show("Lütfen zorunlu alanları doldurunuz!");
                    return;
                }

                //yeni kodlar gelecek

            }
            catch (Exception hata)
            {

                MessageBox.Show("Beklenmedik bir hata oluştu" + hata.Message); 
            }
        }

        private void anamenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIslemler frmIslemler = new FrmIslemler();
            //açık olan tüm formları gizleyecek
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                Application.OpenForms[i].Hide();
            }

            frmIslemler.Show();
        }

       
    }
}
