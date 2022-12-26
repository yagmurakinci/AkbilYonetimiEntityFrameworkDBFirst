using AkbilYonetimBusinessLayer;
using AkbilYonetimiDataLayer;
using AkbilYonetimiEntityLayer.Entities;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

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

                cmbBoxAkbiller.DataSource = akbilYonetimi.Akbiller.ToList(); //false
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
                    dataGridViewTalimatlar.DataSource = akbilYonetimi.KullanicininTalimatlari.Where(x => x.KullaniciId==GenelIslemler.GirisYapmisKullaniciID).ToList();
                }
                else
                {
                    //dataGridViewTalimatlar.DataSource = akbilYonetimi.KullanicininTalimatlari.Where(x=> x.YuklendiMi == false);

                    dataGridViewTalimatlar.DataSource = akbilYonetimi.KullanicininTalimatlari.Where(x => x.KullaniciId == GenelIslemler.GirisYapmisKullaniciID && !x.YuklendiMi).ToList();
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
                lblBekleyenTalimat.Text = akbilYonetimi.KullanicininTalimatlari.Where(x => x.KullaniciId == GenelIslemler.GirisYapmisKullaniciID && !x.YuklendiMi).Count().ToString();
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
                    //seçili rowdaki talimatId bulup bulduğumuz talimatın özelliklerini değiştirip save changes yapıcaz
                    var talimatID = (int)item.Cells["Id"].Value;
                    var talimat = akbilYonetimi.Talimatlar.FirstOrDefault(x => x.Id == talimatID);
                    talimat.YuklendiMi = true;
                    talimat.YuklendigiTarih = DateTime.Now;
                    sayac += akbilYonetimi.SaveChanges();

                }
                MessageBox.Show($"{sayac} adet talimat gerçekleşti!");
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


                    int talimatID = (int)item.Cells["Id"].Value;
                    var talimat = akbilYonetimi.Talimatlar.FirstOrDefault(x => x.Id == talimatID);
                    akbilYonetimi.Talimatlar.Remove(talimat);
                    sayac += akbilYonetimi.SaveChanges();
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

        private void xmlDisariAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // dışarı aktarılacak veriyi XML formatına getirdikten sonra
                // xml hakdeki dosyayı kaydetmemiz lazım
                // Dosya Kaydedici nesneye ihtiyacımız var. SaveDialog
                //SaveDialog --> textbox label combo button gibi bir tool'dur.
                //Kaydetme penceresini açar.
                if (akbilYonetimi.KullanicininTalimatlari.Count() == 0)
                {
                    MessageBox.Show("Dışarı aktarılacak bir talimat bulunmuyor.");
                    return;
                }
                saveFileDialog1.Title = "Talimat Kaydet";
                saveFileDialog1.Filter = " XML FORMAT | *.xml";
                saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    XmlSerializer xmlSerilizer = new XmlSerializer(typeof(List<KullanicininTalimatlari>));

                    var talimatlar = akbilYonetimi.KullanicininTalimatlari.Where(x => x.KullaniciId == GenelIslemler.GirisYapmisKullaniciID).ToList();

                    using (StreamWriter yazici = new StreamWriter(saveFileDialog1.FileName))
                    {
                        xmlSerilizer.Serialize(yazici, talimatlar);
                    }
                    MessageBox.Show($"{talimatlar.Count} adet talimat dışarı aktarıldı.");

                }


            }
            catch (Exception hata)
            {

                MessageBox.Show("Beklenmedik bir hata oluştu! " + hata.Message);
            }
        }

        private void jsonDisariAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // dışarı aktarılacak veriyi XML formatına getirdikten sonra
                // xml hakdeki dosyayı kaydetmemiz lazım
                // Dosya Kaydedici nesneye ihtiyacımız var. SaveDialog
                //SaveDialog --> textbox label combo button gibi bir tool'dur.
                //Kaydetme penceresini açar.
                if (akbilYonetimi.KullanicininTalimatlari.Count() == 0)
                {
                    MessageBox.Show("Dışarı aktarılacak bir talimat bulunmuyor.");
                    return;
                }
                saveFileDialog1.Title = "Talimat Kaydet";
                saveFileDialog1.Filter = " JSON FORMAT | *.json";
                saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    JsonSerializer jsonSerializer = new JsonSerializer();

                    var talimatlar = akbilYonetimi.KullanicininTalimatlari.Where(x => x.KullaniciId == GenelIslemler.GirisYapmisKullaniciID).ToList();

                    using (StreamWriter yazici = new StreamWriter(saveFileDialog1.FileName))
                    {
                        jsonSerializer.Serialize(yazici, talimatlar);
                    }
                    MessageBox.Show($"{talimatlar.Count} adet talimat dışarı aktarıldı.");

                }


            }
            catch (Exception hata)
            {

                MessageBox.Show("Beklenmedik bir hata oluştu! " + hata.Message);
            }
        }

        private void xmlIceriAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //içeri aktarma işlemi bu proje için uygun değildir!
                //biz öğrenme amacıyla yazdık.
                //dosya açabilmek için OpenFileDialog kullanılmalıdır.
                openFileDialog1.Title = "XML Talimat dosyası seçiniz";
                openFileDialog1.Filter = "XML Formatı | *.xml";
                openFileDialog1.Multiselect = false;
                openFileDialog1.FileName = string.Empty;
                openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var cevap = openFileDialog1.ShowDialog();
                if (cevap == DialogResult.OK)
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<KullanicininTalimatlari>));
                    using (StreamReader okuyucu = new StreamReader(openFileDialog1.FileName))
                    {
                        var yeniTalimatlar = (List<KullanicininTalimatlari>)xmlSerializer.Deserialize(okuyucu);

                        foreach (var item in yeniTalimatlar)
                        {
                            Talimatlar t = new Talimatlar()
                            {
                                AkbilID = item.AkbilID,
                                OlustulmaTarihi = DateTime.Now,
                                YuklendigiTarih = null,
                                YuklendiMi = false,
                                YuklenecekTutar = item.YuklenecekTutar
                            };
                            akbilYonetimi.Talimatlar.Add(t);
                            akbilYonetimi.SaveChanges();
                        }
                    }
                }
                TalimatlariGetir();
                BekleyenTalimatSayisiniGetir();

            }
            catch (Exception hata)
            {

                MessageBox.Show("Beklenmedik bir hata oluştu! " + hata.Message);
            }
        }

        private void jsonIceriAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //içeri aktarma işlemi bu proje için uygun değildir!
                //biz öğrenme amacıyla yazdık.
                //dosya açabilmek için OpenFileDialog kullanılmalıdır.
                openFileDialog1.Title = "JSON Talimat dosyası seçiniz";
                openFileDialog1.Filter = "JSON Formatı | *.json";
                openFileDialog1.Multiselect = false;
                openFileDialog1.FileName = string.Empty;
                openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var cevap = openFileDialog1.ShowDialog();
                if (cevap == DialogResult.OK)
                {
                    JsonSerializer jsonSerializer = new JsonSerializer();
                    using (StreamReader okuyucu = new StreamReader(openFileDialog1.FileName))
                    {
                        //var yeniTalimatlar = (List<KullanicininTalimatlari>)xmlSerializer.Deserialize(okuyucu);
                        var yeniTalimatlar = (List<KullanicininTalimatlari>)jsonSerializer.Deserialize(okuyucu, typeof(List<KullanicininTalimatlari>));

                        foreach (var item in yeniTalimatlar)
                        {
                            Talimatlar t = new Talimatlar()
                            {
                                AkbilID = item.AkbilID,
                                OlustulmaTarihi = DateTime.Now,
                                YuklendigiTarih = null,
                                YuklendiMi = false,
                                YuklenecekTutar = item.YuklenecekTutar
                            };
                            akbilYonetimi.Talimatlar.Add(t);
                            akbilYonetimi.SaveChanges();
                        }
                    }
                }
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
