using System;
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
    public partial class FrmIslemler : Form
    {
        public FrmIslemler()
        {
            InitializeComponent();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            //Farklı yöntemlerden devam ister show diolog ister show
            FrmTalimatIslemleri frmTalimatIslemleri = new FrmTalimatIslemleri();
            frmTalimatIslemleri.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmAyarlar frmAyarlar = new FrmAyarlar();
            frmAyarlar.Show();
        }

        private void btnAkbiller_Click(object sender, EventArgs e)
        {
            FrmAkbilIslemleri frmAkbilIslemleri = new FrmAkbilIslemleri();
            frmAkbilIslemleri.ShowDialog();
        }

       
    }
}
