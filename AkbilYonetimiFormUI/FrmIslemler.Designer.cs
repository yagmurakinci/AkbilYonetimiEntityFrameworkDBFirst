
namespace AkbilYonetimiFormUI
{
    partial class FrmIslemler
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
            this.btnAkbiller = new System.Windows.Forms.Button();
            this.btnTalimatlar = new System.Windows.Forms.Button();
            this.btnAyarlar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAkbiller
            // 
            this.btnAkbiller.BackColor = System.Drawing.Color.Transparent;
            this.btnAkbiller.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAkbiller.Location = new System.Drawing.Point(109, 66);
            this.btnAkbiller.Name = "btnAkbiller";
            this.btnAkbiller.Size = new System.Drawing.Size(203, 44);
            this.btnAkbiller.TabIndex = 0;
            this.btnAkbiller.Text = "AKBİL İŞLEMLERİ";
            this.btnAkbiller.UseVisualStyleBackColor = false;
            this.btnAkbiller.Click += new System.EventHandler(this.btnAkbiller_Click);
            // 
            // btnTalimatlar
            // 
            this.btnTalimatlar.BackColor = System.Drawing.Color.Transparent;
            this.btnTalimatlar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTalimatlar.Location = new System.Drawing.Point(109, 116);
            this.btnTalimatlar.Name = "btnTalimatlar";
            this.btnTalimatlar.Size = new System.Drawing.Size(203, 44);
            this.btnTalimatlar.TabIndex = 1;
            this.btnTalimatlar.Text = "TALİMAT İŞLEMLERİ";
            this.btnTalimatlar.UseVisualStyleBackColor = false;
            this.btnTalimatlar.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAyarlar
            // 
            this.btnAyarlar.BackColor = System.Drawing.Color.Transparent;
            this.btnAyarlar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAyarlar.Location = new System.Drawing.Point(109, 166);
            this.btnAyarlar.Name = "btnAyarlar";
            this.btnAyarlar.Size = new System.Drawing.Size(203, 44);
            this.btnAyarlar.TabIndex = 2;
            this.btnAyarlar.Text = "AYARLAR";
            this.btnAyarlar.UseVisualStyleBackColor = false;
            this.btnAyarlar.Click += new System.EventHandler(this.button3_Click);
            // 
            // FrmIslemler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AkbilYonetimiFormUI.Properties.Resources._36;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(451, 328);
            this.Controls.Add(this.btnAyarlar);
            this.Controls.Add(this.btnTalimatlar);
            this.Controls.Add(this.btnAkbiller);
            this.Name = "FrmIslemler";
            this.Text = "Ana Menü";
            this.Load += new System.EventHandler(this.FrmIslemler_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAkbiller;
        private System.Windows.Forms.Button btnTalimatlar;
        private System.Windows.Forms.Button btnAyarlar;
    }
}