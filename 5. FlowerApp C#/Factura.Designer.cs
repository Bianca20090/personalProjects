
namespace proiectPAWBuseBianca
{
    partial class Factura
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Factura));
            this.lbProduse = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btAdauga = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tbId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbCantitatec = new System.Windows.Forms.Label();
            this.lbPretc = new System.Windows.Forms.Label();
            this.tbcCantitate = new System.Windows.Forms.TextBox();
            this.tbcPret = new System.Windows.Forms.TextBox();
            this.btStergeComanda = new System.Windows.Forms.Button();
            this.btInapoi = new System.Windows.Forms.Button();
            this.btPrint = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbDrAndDp = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbProduse
            // 
            this.lbProduse.AutoSize = true;
            this.lbProduse.BackColor = System.Drawing.Color.Transparent;
            this.lbProduse.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProduse.Location = new System.Drawing.Point(22, 24);
            this.lbProduse.Name = "lbProduse";
            this.lbProduse.Size = new System.Drawing.Size(208, 68);
            this.lbProduse.TabIndex = 3;
            this.lbProduse.Text = "Factura";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(34, 126);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(196, 25);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Text = "Selecteaza Clientul";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btAdauga
            // 
            this.btAdauga.BackColor = System.Drawing.Color.RosyBrown;
            this.btAdauga.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAdauga.Location = new System.Drawing.Point(34, 345);
            this.btAdauga.Name = "btAdauga";
            this.btAdauga.Size = new System.Drawing.Size(196, 47);
            this.btAdauga.TabIndex = 59;
            this.btAdauga.Text = "Adauga factura";
            this.btAdauga.UseVisualStyleBackColor = false;
            this.btAdauga.Click += new System.EventHandler(this.btAdauga_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.Color.Thistle;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.RosyBrown;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.Thistle;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView2.Location = new System.Drawing.Point(441, 12);
            this.dataGridView2.Name = "dataGridView2";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.RosyBrown;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridView2.RowHeadersWidth = 51;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.Thistle;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.PowderBlue;
            this.dataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(754, 496);
            this.dataGridView2.TabIndex = 60;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(29, 182);
            this.tbId.Name = "tbId";
            this.tbId.ReadOnly = true;
            this.tbId.Size = new System.Drawing.Size(100, 22);
            this.tbId.TabIndex = 62;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 17);
            this.label1.TabIndex = 61;
            this.label1.Text = "Id:";
            // 
            // lbCantitatec
            // 
            this.lbCantitatec.AutoSize = true;
            this.lbCantitatec.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCantitatec.Location = new System.Drawing.Point(24, 213);
            this.lbCantitatec.Name = "lbCantitatec";
            this.lbCantitatec.Size = new System.Drawing.Size(60, 16);
            this.lbCantitatec.TabIndex = 68;
            this.lbCantitatec.Text = "Cantitate:";
            // 
            // lbPretc
            // 
            this.lbPretc.AutoSize = true;
            this.lbPretc.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPretc.Location = new System.Drawing.Point(24, 261);
            this.lbPretc.Name = "lbPretc";
            this.lbPretc.Size = new System.Drawing.Size(34, 16);
            this.lbPretc.TabIndex = 67;
            this.lbPretc.Text = "Pret:";
            // 
            // tbcCantitate
            // 
            this.tbcCantitate.Location = new System.Drawing.Point(27, 232);
            this.tbcCantitate.Name = "tbcCantitate";
            this.tbcCantitate.ReadOnly = true;
            this.tbcCantitate.Size = new System.Drawing.Size(102, 22);
            this.tbcCantitate.TabIndex = 66;
            // 
            // tbcPret
            // 
            this.tbcPret.Location = new System.Drawing.Point(27, 280);
            this.tbcPret.Name = "tbcPret";
            this.tbcPret.ReadOnly = true;
            this.tbcPret.Size = new System.Drawing.Size(102, 22);
            this.tbcPret.TabIndex = 65;
            // 
            // btStergeComanda
            // 
            this.btStergeComanda.BackColor = System.Drawing.Color.RosyBrown;
            this.btStergeComanda.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btStergeComanda.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btStergeComanda.Location = new System.Drawing.Point(196, 563);
            this.btStergeComanda.Name = "btStergeComanda";
            this.btStergeComanda.Size = new System.Drawing.Size(131, 47);
            this.btStergeComanda.TabIndex = 69;
            this.btStergeComanda.Text = "Sterge";
            this.btStergeComanda.UseVisualStyleBackColor = false;
            this.btStergeComanda.Click += new System.EventHandler(this.btStergeComanda_Click);
            // 
            // btInapoi
            // 
            this.btInapoi.BackColor = System.Drawing.Color.RosyBrown;
            this.btInapoi.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btInapoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btInapoi.Location = new System.Drawing.Point(12, 563);
            this.btInapoi.Name = "btInapoi";
            this.btInapoi.Size = new System.Drawing.Size(133, 47);
            this.btInapoi.TabIndex = 70;
            this.btInapoi.Text = "Inapoi";
            this.btInapoi.UseVisualStyleBackColor = false;
            this.btInapoi.Click += new System.EventHandler(this.btInapoi_Click);
            // 
            // btPrint
            // 
            this.btPrint.BackColor = System.Drawing.Color.RosyBrown;
            this.btPrint.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPrint.Location = new System.Drawing.Point(761, 563);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(131, 47);
            this.btPrint.TabIndex = 71;
            this.btPrint.Text = "PRINT";
            this.btPrint.UseVisualStyleBackColor = false;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.AutoScroll = true;
            this.panel1.BackgroundImage = global::proiectPAWBuseBianca.Properties.Resources.Asset_3_100;
            this.panel1.Controls.Add(this.lbDrAndDp);
            this.panel1.Location = new System.Drawing.Point(12, 411);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(401, 71);
            this.panel1.TabIndex = 72;
            this.panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel1_DragDrop);
            this.panel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel1_DragEnter);
            // 
            // lbDrAndDp
            // 
            this.lbDrAndDp.FormattingEnabled = true;
            this.lbDrAndDp.ItemHeight = 16;
            this.lbDrAndDp.Location = new System.Drawing.Point(3, 13);
            this.lbDrAndDp.Name = "lbDrAndDp";
            this.lbDrAndDp.Size = new System.Drawing.Size(374, 84);
            this.lbDrAndDp.TabIndex = 73;
            // 
            // Factura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::proiectPAWBuseBianca.Properties.Resources.Asset_3_100;
            this.ClientSize = new System.Drawing.Size(1207, 657);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.btInapoi);
            this.Controls.Add(this.btStergeComanda);
            this.Controls.Add(this.lbCantitatec);
            this.Controls.Add(this.lbPretc);
            this.Controls.Add(this.tbcCantitate);
            this.Controls.Add(this.tbcPret);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.btAdauga);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lbProduse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Factura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Factura";
            this.Load += new System.EventHandler(this.Factura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbProduse;
        private System.Windows.Forms.Button btAdauga;
        private System.Windows.Forms.DataGridView dataGridView2;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbCantitatec;
        private System.Windows.Forms.Label lbPretc;
        public System.Windows.Forms.TextBox tbcCantitate;
        public System.Windows.Forms.TextBox tbcPret;
        private System.Windows.Forms.Button btStergeComanda;
        private System.Windows.Forms.Button btInapoi;
        private System.Windows.Forms.Button btPrint;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lbDrAndDp;
    }
}