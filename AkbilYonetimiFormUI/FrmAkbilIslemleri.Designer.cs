
namespace AkbilYonetimiFormUI
{
    partial class FrmAkbilIslemleri
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.anaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cikisyapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxAkbilProps = new System.Windows.Forms.GroupBox();
            this.cmbBoxAkbilTipleri = new System.Windows.Forms.ComboBox();
            this.txtAkbilSeriNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewAkbiller = new System.Windows.Forms.DataGridView();
            this.btnAkbilKaydet = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBoxAkbilProps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAkbiller)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.anaToolStripMenuItem,
            this.cikisyapToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(781, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // anaToolStripMenuItem
            // 
            this.anaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.anaToolStripMenuItem.Name = "anaToolStripMenuItem";
            this.anaToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.anaToolStripMenuItem.Text = "ANA MENÜ";
            // 
            // cikisyapToolStripMenuItem
            // 
            this.cikisyapToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cikisyapToolStripMenuItem.Name = "cikisyapToolStripMenuItem";
            this.cikisyapToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.cikisyapToolStripMenuItem.Text = "ÇIKIŞ YAP";
            this.cikisyapToolStripMenuItem.Click += new System.EventHandler(this.cikisyapToolStripMenuItem_Click);
            // 
            // groupBoxAkbilProps
            // 
            this.groupBoxAkbilProps.Controls.Add(this.cmbBoxAkbilTipleri);
            this.groupBoxAkbilProps.Controls.Add(this.txtAkbilSeriNo);
            this.groupBoxAkbilProps.Controls.Add(this.label2);
            this.groupBoxAkbilProps.Controls.Add(this.label1);
            this.groupBoxAkbilProps.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBoxAkbilProps.Location = new System.Drawing.Point(0, 27);
            this.groupBoxAkbilProps.Name = "groupBoxAkbilProps";
            this.groupBoxAkbilProps.Size = new System.Drawing.Size(642, 179);
            this.groupBoxAkbilProps.TabIndex = 1;
            this.groupBoxAkbilProps.TabStop = false;
            this.groupBoxAkbilProps.Text = "BİLGİLER";
            this.groupBoxAkbilProps.Enter += new System.EventHandler(this.groupBoxAkbilProps_Enter);
            // 
            // cmbBoxAkbilTipleri
            // 
            this.cmbBoxAkbilTipleri.FormattingEnabled = true;
            this.cmbBoxAkbilTipleri.Location = new System.Drawing.Point(158, 80);
            this.cmbBoxAkbilTipleri.Name = "cmbBoxAkbilTipleri";
            this.cmbBoxAkbilTipleri.Size = new System.Drawing.Size(183, 24);
            this.cmbBoxAkbilTipleri.TabIndex = 3;
            this.cmbBoxAkbilTipleri.SelectedIndexChanged += new System.EventHandler(this.cmbBoxAkbilTipleri_SelectedIndexChanged);
            // 
            // txtAkbilSeriNo
            // 
            this.txtAkbilSeriNo.Location = new System.Drawing.Point(158, 43);
            this.txtAkbilSeriNo.Name = "txtAkbilSeriNo";
            this.txtAkbilSeriNo.Size = new System.Drawing.Size(183, 22);
            this.txtAkbilSeriNo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(34, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "AKBİL TİPİ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(34, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "AKBİL SERİ NO:";
            // 
            // dataGridViewAkbiller
            // 
            this.dataGridViewAkbiller.AllowUserToAddRows = false;
            this.dataGridViewAkbiller.AllowUserToDeleteRows = false;
            this.dataGridViewAkbiller.AllowUserToOrderColumns = true;
            this.dataGridViewAkbiller.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAkbiller.Location = new System.Drawing.Point(0, 212);
            this.dataGridViewAkbiller.Name = "dataGridViewAkbiller";
            this.dataGridViewAkbiller.ReadOnly = true;
            this.dataGridViewAkbiller.Size = new System.Drawing.Size(773, 166);
            this.dataGridViewAkbiller.TabIndex = 2;
            this.dataGridViewAkbiller.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAkbiller_CellContentClick);
            // 
            // btnAkbilKaydet
            // 
            this.btnAkbilKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAkbilKaydet.Location = new System.Drawing.Point(648, 34);
            this.btnAkbilKaydet.Name = "btnAkbilKaydet";
            this.btnAkbilKaydet.Size = new System.Drawing.Size(125, 169);
            this.btnAkbilKaydet.TabIndex = 3;
            this.btnAkbilKaydet.Text = "YENİ AKBİLİ KAYDET";
            this.btnAkbilKaydet.UseVisualStyleBackColor = true;
            this.btnAkbilKaydet.Click += new System.EventHandler(this.btnAkbilKaydet_Click);
            // 
            // FrmAkbilIslemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 450);
            this.Controls.Add(this.btnAkbilKaydet);
            this.Controls.Add(this.dataGridViewAkbiller);
            this.Controls.Add(this.groupBoxAkbilProps);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmAkbilIslemleri";
            this.Text = "Akbil İşlemleri";
            this.Load += new System.EventHandler(this.FrmAkbilIslemleri_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxAkbilProps.ResumeLayout(false);
            this.groupBoxAkbilProps.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAkbiller)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem anaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cikisyapToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxAkbilProps;
        private System.Windows.Forms.ComboBox cmbBoxAkbilTipleri;
        private System.Windows.Forms.TextBox txtAkbilSeriNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewAkbiller;
        private System.Windows.Forms.Button btnAkbilKaydet;
    }
}