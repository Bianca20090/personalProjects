
namespace proiectPAWBuseBianca
{
    partial class Livrarics
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbProduse = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbCantitatec = new System.Windows.Forms.Label();
            this.lbTipFloarec = new System.Windows.Forms.Label();
            this.tbcAdresa = new System.Windows.Forms.TextBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.cbCurier = new System.Windows.Forms.ComboBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.btInapoi = new System.Windows.Forms.Button();
            this.btActualizeaza = new System.Windows.Forms.Button();
            this.btAdauga = new System.Windows.Forms.Button();
            this.tbNume = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbPretc = new System.Windows.Forms.Label();
            this.tbcTelefon = new System.Windows.Forms.TextBox();
            this.tbIdComanda = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // lbProduse
            // 
            this.lbProduse.AutoSize = true;
            this.lbProduse.BackColor = System.Drawing.Color.Transparent;
            this.lbProduse.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProduse.Location = new System.Drawing.Point(12, 18);
            this.lbProduse.Name = "lbProduse";
            this.lbProduse.Size = new System.Drawing.Size(193, 68);
            this.lbProduse.TabIndex = 2;
            this.lbProduse.Text = "Livrari";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 16);
            this.label3.TabIndex = 26;
            this.label3.Text = "ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 53;
            this.label1.Text = "Nume Livrator:";
            // 
            // lbCantitatec
            // 
            this.lbCantitatec.AutoSize = true;
            this.lbCantitatec.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCantitatec.Location = new System.Drawing.Point(21, 259);
            this.lbCantitatec.Name = "lbCantitatec";
            this.lbCantitatec.Size = new System.Drawing.Size(46, 16);
            this.lbCantitatec.TabIndex = 52;
            this.lbCantitatec.Text = "Status:";
            // 
            // lbTipFloarec
            // 
            this.lbTipFloarec.AutoSize = true;
            this.lbTipFloarec.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTipFloarec.Location = new System.Drawing.Point(21, 210);
            this.lbTipFloarec.Name = "lbTipFloarec";
            this.lbTipFloarec.Size = new System.Drawing.Size(47, 16);
            this.lbTipFloarec.TabIndex = 50;
            this.lbTipFloarec.Text = "Adresa";
            // 
            // tbcAdresa
            // 
            this.tbcAdresa.Location = new System.Drawing.Point(24, 229);
            this.tbcAdresa.Name = "tbcAdresa";
            this.tbcAdresa.Size = new System.Drawing.Size(247, 22);
            this.tbcAdresa.TabIndex = 47;
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "In curs de procesare",
            "Expediata"});
            this.cbStatus.Location = new System.Drawing.Point(24, 278);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(247, 24);
            this.cbStatus.TabIndex = 55;
            // 
            // cbCurier
            // 
            this.cbCurier.FormattingEnabled = true;
            this.cbCurier.Items.AddRange(new object[] {
            "Fan Curier",
            "Cargus",
            "Sameday"});
            this.cbCurier.Location = new System.Drawing.Point(24, 184);
            this.cbCurier.Name = "cbCurier";
            this.cbCurier.Size = new System.Drawing.Size(247, 24);
            this.cbCurier.TabIndex = 56;
            // 
            // dataGridView3
            // 
            this.dataGridView3.BackgroundColor = System.Drawing.Color.Thistle;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.RosyBrown;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Thistle;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView3.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView3.Location = new System.Drawing.Point(318, 18);
            this.dataGridView3.Name = "dataGridView3";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.RosyBrown;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView3.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView3.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Thistle;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.PowderBlue;
            this.dataGridView3.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.Size = new System.Drawing.Size(836, 616);
            this.dataGridView3.TabIndex = 57;
            this.dataGridView3.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellContentClick);
            // 
            // btInapoi
            // 
            this.btInapoi.BackColor = System.Drawing.Color.RosyBrown;
            this.btInapoi.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btInapoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btInapoi.Location = new System.Drawing.Point(17, 579);
            this.btInapoi.Name = "btInapoi";
            this.btInapoi.Size = new System.Drawing.Size(133, 31);
            this.btInapoi.TabIndex = 61;
            this.btInapoi.Text = "Inapoi";
            this.btInapoi.UseVisualStyleBackColor = false;
            this.btInapoi.Click += new System.EventHandler(this.btInapoi_Click);
            // 
            // btActualizeaza
            // 
            this.btActualizeaza.BackColor = System.Drawing.Color.RosyBrown;
            this.btActualizeaza.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btActualizeaza.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btActualizeaza.Location = new System.Drawing.Point(140, 504);
            this.btActualizeaza.Name = "btActualizeaza";
            this.btActualizeaza.Size = new System.Drawing.Size(131, 47);
            this.btActualizeaza.TabIndex = 59;
            this.btActualizeaza.Text = "Actualizeaza";
            this.btActualizeaza.UseVisualStyleBackColor = false;
            this.btActualizeaza.Click += new System.EventHandler(this.btActualizeaza_Click);
            // 
            // btAdauga
            // 
            this.btAdauga.BackColor = System.Drawing.Color.RosyBrown;
            this.btAdauga.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAdauga.Location = new System.Drawing.Point(20, 504);
            this.btAdauga.Name = "btAdauga";
            this.btAdauga.Size = new System.Drawing.Size(102, 47);
            this.btAdauga.TabIndex = 58;
            this.btAdauga.Text = "Adauga";
            this.btAdauga.UseVisualStyleBackColor = false;
            this.btAdauga.Click += new System.EventHandler(this.btAdauga_Click);
            // 
            // tbNume
            // 
            this.tbNume.Location = new System.Drawing.Point(24, 335);
            this.tbNume.Name = "tbNume";
            this.tbNume.ReadOnly = true;
            this.tbNume.Size = new System.Drawing.Size(247, 22);
            this.tbNume.TabIndex = 69;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 316);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 68;
            this.label2.Text = "Nume:";
            // 
            // lbPretc
            // 
            this.lbPretc.AutoSize = true;
            this.lbPretc.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPretc.Location = new System.Drawing.Point(19, 360);
            this.lbPretc.Name = "lbPretc";
            this.lbPretc.Size = new System.Drawing.Size(53, 16);
            this.lbPretc.TabIndex = 67;
            this.lbPretc.Text = "Telefon:";
            // 
            // tbcTelefon
            // 
            this.tbcTelefon.Location = new System.Drawing.Point(25, 379);
            this.tbcTelefon.Name = "tbcTelefon";
            this.tbcTelefon.ReadOnly = true;
            this.tbcTelefon.Size = new System.Drawing.Size(249, 22);
            this.tbcTelefon.TabIndex = 66;
            // 
            // tbIdComanda
            // 
            this.tbIdComanda.FormattingEnabled = true;
            this.tbIdComanda.Location = new System.Drawing.Point(20, 137);
            this.tbIdComanda.Name = "tbIdComanda";
            this.tbIdComanda.Size = new System.Drawing.Size(251, 24);
            this.tbIdComanda.TabIndex = 70;
            this.tbIdComanda.Text = "Selecteaza Comanda";
            this.tbIdComanda.SelectedIndexChanged += new System.EventHandler(this.tbIdComanda_SelectedIndexChanged);
            // 
            // Livrarics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::proiectPAWBuseBianca.Properties.Resources.Asset_3_100;
            this.ClientSize = new System.Drawing.Size(1207, 657);
            this.Controls.Add(this.tbIdComanda);
            this.Controls.Add(this.tbNume);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbPretc);
            this.Controls.Add(this.tbcTelefon);
            this.Controls.Add(this.btInapoi);
            this.Controls.Add(this.btActualizeaza);
            this.Controls.Add(this.btAdauga);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.cbCurier);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbCantitatec);
            this.Controls.Add(this.lbTipFloarec);
            this.Controls.Add(this.tbcAdresa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbProduse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Livrarics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Livrarics";
            this.Load += new System.EventHandler(this.Livrarics_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbProduse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbCantitatec;
        private System.Windows.Forms.Label lbTipFloarec;
        public System.Windows.Forms.TextBox tbcAdresa;
        public System.Windows.Forms.ComboBox cbStatus;
        public System.Windows.Forms.ComboBox cbCurier;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Button btInapoi;
        private System.Windows.Forms.Button btActualizeaza;
        private System.Windows.Forms.Button btAdauga;
        public System.Windows.Forms.TextBox tbNume;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbPretc;
        public System.Windows.Forms.TextBox tbcTelefon;
        private System.Windows.Forms.ComboBox tbIdComanda;
    }
}