
namespace AkbilYonetimiFormUI
{
    partial class FrmGiris
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.btnGirisYap = new System.Windows.Forms.Button();
            this.btnKayitOl = new System.Windows.Forms.Button();
            this.checkBoxBeniHatirla = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(227, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Email";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(227, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Şifre";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(289, 52);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(149, 20);
            this.txtEmail.TabIndex = 2;
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(289, 82);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(149, 20);
            this.txtSifre.TabIndex = 3;
            this.txtSifre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSifre_KeyPress);
            // 
            // btnGirisYap
            // 
            this.btnGirisYap.Location = new System.Drawing.Point(289, 138);
            this.btnGirisYap.Name = "btnGirisYap";
            this.btnGirisYap.Size = new System.Drawing.Size(143, 23);
            this.btnGirisYap.TabIndex = 4;
            this.btnGirisYap.Text = "GİRİŞ YAP";
            this.btnGirisYap.UseVisualStyleBackColor = true;
            this.btnGirisYap.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnKayitOl
            // 
            this.btnKayitOl.Location = new System.Drawing.Point(289, 167);
            this.btnKayitOl.Name = "btnKayitOl";
            this.btnKayitOl.Size = new System.Drawing.Size(143, 23);
            this.btnKayitOl.TabIndex = 5;
            this.btnKayitOl.Text = "KAYIT OL";
            this.btnKayitOl.UseVisualStyleBackColor = true;
            this.btnKayitOl.Click += new System.EventHandler(this.btnKayitOl_Click);
            // 
            // checkBoxBeniHatirla
            // 
            this.checkBoxBeniHatirla.AutoSize = true;
            this.checkBoxBeniHatirla.ForeColor = System.Drawing.Color.Black;
            this.checkBoxBeniHatirla.Location = new System.Drawing.Point(289, 115);
            this.checkBoxBeniHatirla.Name = "checkBoxBeniHatirla";
            this.checkBoxBeniHatirla.Size = new System.Drawing.Size(80, 17);
            this.checkBoxBeniHatirla.TabIndex = 6;
            this.checkBoxBeniHatirla.Text = "Beni Hatırla";
            this.checkBoxBeniHatirla.UseVisualStyleBackColor = true;
            this.checkBoxBeniHatirla.CheckedChanged += new System.EventHandler(this.checkBoxBeniHatirla_CheckedChanged_1);
            // 
            // FrmGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AkbilYonetimiFormUI.Properties.Resources._36;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(499, 308);
            this.Controls.Add(this.checkBoxBeniHatirla);
            this.Controls.Add(this.btnKayitOl);
            this.Controls.Add(this.btnGirisYap);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmGiris";
            this.Text = "Giriş";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmGiris_FormClosed);
            this.Load += new System.EventHandler(this.FrmGiris_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Button btnGirisYap;
        private System.Windows.Forms.Button btnKayitOl;
        private System.Windows.Forms.CheckBox checkBoxBeniHatirla;
    }
}

