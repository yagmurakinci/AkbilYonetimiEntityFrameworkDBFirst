using AkbilYonetimBusinessLayer;
using AkbilYonetimiDataLayer;
using AkbilYonetimiEntityLayer.Entities;
using System;
using System.Collections;
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
    public partial class FrmTalimatIslemleri : Form
    {
        AKBİLYONETİMİDBEntities akbilYonetimi = new AKBİLYONETİMİDBEntities();


        //public decimal YuklenecekMiktar { get; private set; }

        public FrmTalimatIslemleri()
        {
            InitializeComponent();
        }

        

        private void ComboBoxAkbilleriGetir()
        {
            try
            {

                cmbBoxAkbiller.DataSource = akbilYonetimi.Akbiller; //false
                //yeni kodlar gelecek
                cmbBoxAkbiller.DisplayMember = "AkbilNo";
                cmbBoxAkbiller.ValueMember = "AkbilNo";
            }
                catch (Exception hata)
                {

                    MessageBox.Show("Beklenmedik bir hata oluştu! "+hata.Message);
                    //TODO: loglama txt dosyasına yazdır
                }
            
            
        }

        private void FrmTalimatIslemleri_Load(object sender, EventArgs e)
        {
            
            ComboBoxAkbilleriGetir();
            cmbBoxAkbiller.SelectedIndex = -1;
            cmbBoxAkbiller.Text = "Akbil Seçiniz";
            dataGridViewTalimatlar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            timerBekleyenTalimat.Interval = 1000;
            timerBekleyenTalimat.Enabled = true;
            //metodu tekrar inceleyeceğiz
            TalimatlariGetir();
            BekleyenTalimatSayisiniGetir(); // hata verdiği için yorum satırı yaptık
            dataGridViewTalimatlar.ContextMenuStrip = contextMenuStripTalimatGrid;
            groupBoxBakiye.Enabled = false;


        }

        private void cmbBoxAkbiller_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxAkbiller.SelectedIndex>=0)
            {
                groupBoxBakiye.Enabled = true;
                txtBakiye.Clear();
            }
        }

        private void btnYukle_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbBoxAkbiller.SelectedIndex<0)
                {
                    MessageBox.Show("Talimat yüklemesi için akbil seçimi zorunludur!");
                    return;
                }
                if (txtBakiye.Text == null || txtBakiye.Text == string.Empty)
                    throw new Exception("Yükleme miktarı belirtilmemiş");

                Talimatlar yeniTalimat = new Talimatlar()
                {
                    AkbilID = cmbBoxAkbiller.SelectedValue.ToString(),
                    OlustulmaTarihi = DateTime.Now,
                    YuklendiMi = false,
                    YuklendigiTarih = null,
                    YuklenecekTutar = Convert.ToDecimal(txtBakiye.Text)
                };

                akbilYonetimi.Talimatlar.Add(yeniTalimat);
                int eklenenTalimatSayisi = akbilYonetimi.SaveChanges();




                if (eklenenTalimatSayisi>0)
                {
                    MessageBox.Show("Yeni talimat eklendi");
                    txtBakiye.Clear();
                    cmbBoxAkbiller.SelectedIndex = -1;
                    cmbBoxAkbiller.Text = "Akbil Seçiniz..";
                    groupBoxBakiye.Enabled = false;
                    TalimatlariGetir();
                    BekleyenTalimatSayisiniGetir();
                }
                else
                {
                    MessageBox.Show("Yeni talimat BAŞARISIZ!");
                }
               
               
            }
            catch (Exception hata)
            {

                MessageBox.Show("Beklenmedik bir hata oluştu" + hata.Message);
            }
        }

        private void TalimatlariGetir()
        {
            if (checkBoxTumunuGoster.Checked)
            {
                GrideTalimatlariGetir(true);
            }
            else
            {
                GrideTalimatlariGetir();
            }
        }

        private void GrideTalimatlariGetir (bool tumunuGoster = false)
        {
            try
            {
                if (tumunuGoster) //tumunuGoster true mu?? True ise girecek
                {
                    dataGridViewTalimatlar.DataSource = akbilYonetimi.Akbiller;
                }
                else
                {
                    //dataGridViewTalimatlar.DataSource = akbilYonetimi.KullanicininTalimatlari.Where(x=> x.YuklendiMi == false);

                    dataGridViewTalimatlar.DataSource = akbilYonetimi.KullanicininTalimatlari.Where(x => !x.YuklendiMi);
                }
                

                dataGridViewTalimatlar.Columns["Id"].Visible = false;
                dataGridViewTalimatlar.Columns["KullaniciId"].Visible = false;
                dataGridViewTalimatlar.Columns["AkbilID"].Width = 200;
                dataGridViewTalimatlar.Columns["OlustulmaTarihi"].Width = 200;
                dataGridViewTalimatlar.Columns["YuklendigiTarih"].Width = 150;

                dataGridViewTalimatlar.Columns["YuklendigiTarih"].HeaderText = "Yüklendiği Tarih";
                dataGridViewTalimatlar.Columns["OlustulmaTarihi"].HeaderText = "Oluşturulma Tarihi";
            }
            catch (Exception hata)
            {

                MessageBox.Show("Beklenmedik hata oluştu. HATA" + hata.Message);
            }
        }

        private void checkBoxBekleyenTalimatlar_CheckedChanged(object sender, EventArgs e)
        {
            TalimatlariGetir();
        }

        private void BekleyenTalimatSayisiniGetir()
        {
            try
            {
                lblBekleyenTalimat.Text = akbilYonetimi.SP_BekleyenTalimatSayisi(GenelIslemler.GirisYapmisKullaniciID).ToString();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Beklenmedik bir sorun oluştu!" + hata.Message);
                // hata log
            }

        }

        private void timerBekleyenTalimat_Tick(object sender, EventArgs e)
        {
           // if (lblBekleyenTalimat.Text!) "0")
            //{
                if (DateTime.Now.Second % 2==0)
                {
                    lblBekleyenTalimat.Font = new Font("Microsoft Sans Serif", 40);
                }
                else
                {
                    lblBekleyenTalimat.Font = new Font("Microsoft Sans Serif", 20);

                }
           // }
        }

        private void cikisyapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //sistemden çıkılacak

            GenelIslemler.GirisYapmisKullaniciAdSoyad = string.Empty;
            GenelIslemler.GirisYapmisKullaniciID = 0;
            MessageBox.Show("Güle Güle");
            FrmGiris frmGiris = new FrmGiris();
            frmGiris.Show();
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i].Name == "FrmGiris") continue;
                Application.OpenForms[i].Close(); 
            }


        }

        private void anaMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIslemler frmIslemler = new FrmIslemler();
            frmIslemler.Show();
            this.Close();
        }

        private void groupBoxBakiye_Enter(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void talimatigerceklestirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //hangi talimat(lar) -->datagrid view multiselect yapabiliyor 
                //döngü lazım 
                int sayac = 0;
                foreach (DataGridViewRow item in dataGridViewTalimatlar.SelectedRows)
                {
                    //yeni kodlar gelecek
                }// 
                MessageBox.Show($"{sayac/2} adet talimat gerçekleşti!");
                TalimatlariGetir();
                BekleyenTalimatSayisiniGetir();
            }
            catch (Exception hata)
            {

                MessageBox.Show("Beklenmedik bir hata oluştu! " + hata.Message);
            }
        }

        private void talimatiSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int sayac = -1;
                foreach (DataGridViewRow item in dataGridViewTalimatlar.SelectedRows)
                {
                    bool yuklendiMi = (bool)item.Cells["YuklendiMi"].Value;
                    var akbilNo = item.Cells["AkbilID"].Value.ToString();
                    int talimatNo = (int)item.Cells["Id"].Value;
                    if (yuklendiMi)
                    {
                        MessageBox.Show($"DİKKAT! {akbilNo} seri numaralı akbilin {talimatNo}'lu yüklemesi yapılmıştır. YÜKLENEN TALİMATI SİLEMEZSİNİZ! \n İşlemlerinize devam etmemiz için tamama basınız");
                        continue;
                    }


                    //yeni kodlar gelecek
                }//foreach bitti
                MessageBox.Show($"{sayac} adet talimat silindi!");
                TalimatlariGetir();
                BekleyenTalimatSayisiniGetir();
            }
            catch (Exception hata)
            {

                MessageBox.Show("Beklenmedik bir hata oluştu! " + hata.Message);
            }
        }

        
    }
}
