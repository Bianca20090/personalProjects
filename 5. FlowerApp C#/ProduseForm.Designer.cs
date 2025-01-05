
namespace proiectPAWBuseBianca
{
    partial class ProduseForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbProduse = new System.Windows.Forms.Label();
            this.tbTip = new System.Windows.Forms.TextBox();
            this.tbPret = new System.Windows.Forms.TextBox();
            this.tbCuloare = new System.Windows.Forms.TextBox();
            this.tbCantitate = new System.Windows.Forms.TextBox();
            this.lbTipFloare = new System.Windows.Forms.Label();
            this.lbCuloare = new System.Windows.Forms.Label();
            this.lbPret = new System.Windows.Forms.Label();
            this.lbCantitate = new System.Windows.Forms.Label();
            this.dateAprovizionare = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btAdauga = new System.Windows.Forms.Button();
            this.btActualizeaza = new System.Windows.Forms.Button();
            this.btSterge = new System.Windows.Forms.Button();
            this.btInapoi = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbProduse
            // 
            this.lbProduse.AutoSize = true;
            this.lbProduse.BackColor = System.Drawing.Color.Transparent;
            this.lbProduse.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProduse.Location = new System.Drawing.Point(12, 29);
            this.lbProduse.Name = "lbProduse";
            this.lbProduse.Size = new System.Drawing.Size(222, 68);
            this.lbProduse.TabIndex = 0;
            this.lbProduse.Text = "Produse";
            // 
            // tbTip
            // 
            this.tbTip.Location = new System.Drawing.Point(24, 158);
            this.tbTip.Name = "tbTip";
            this.tbTip.Size = new System.Drawing.Size(133, 22);
            this.tbTip.TabIndex = 2;
            // 
            // tbPret
            // 
            this.tbPret.Location = new System.Drawing.Point(24, 291);
            this.tbPret.Name = "tbPret";
            this.tbPret.Size = new System.Drawing.Size(133, 22);
            this.tbPret.TabIndex = 3;
            // 
            // tbCuloare
            // 
            this.tbCuloare.Location = new System.Drawing.Point(24, 225);
            this.tbCuloare.Name = "tbCuloare";
            this.tbCuloare.Size = new System.Drawing.Size(133, 22);
            this.tbCuloare.TabIndex = 4;
            // 
            // tbCantitate
            // 
            this.tbCantitate.Location = new System.Drawing.Point(24, 359);
            this.tbCantitate.Name = "tbCantitate";
            this.tbCantitate.Size = new System.Drawing.Size(133, 22);
            this.tbCantitate.TabIndex = 5;
            // 
            // lbTipFloare
            // 
            this.lbTipFloare.AutoSize = true;
            this.lbTipFloare.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTipFloare.Location = new System.Drawing.Point(21, 139);
            this.lbTipFloare.Name = "lbTipFloare";
            this.lbTipFloare.Size = new System.Drawing.Size(46, 16);
            this.lbTipFloare.TabIndex = 6;
            this.lbTipFloare.Text = "Floare:";
            // 
            // lbCuloare
            // 
            this.lbCuloare.AutoSize = true;
            this.lbCuloare.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCuloare.Location = new System.Drawing.Point(21, 206);
            this.lbCuloare.Name = "lbCuloare";
            this.lbCuloare.Size = new System.Drawing.Size(54, 16);
            this.lbCuloare.TabIndex = 7;
            this.lbCuloare.Text = "Culoare:";
            // 
            // lbPret
            // 
            this.lbPret.AutoSize = true;
            this.lbPret.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPret.Location = new System.Drawing.Point(21, 272);
            this.lbPret.Name = "lbPret";
            this.lbPret.Size = new System.Drawing.Size(45, 16);
            this.lbPret.TabIndex = 8;
            this.lbPret.Text = "Pret/b:";
            // 
            // lbCantitate
            // 
            this.lbCantitate.AutoSize = true;
            this.lbCantitate.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCantitate.Location = new System.Drawing.Point(21, 340);
            this.lbCantitate.Name = "lbCantitate";
            this.lbCantitate.Size = new System.Drawing.Size(60, 16);
            this.lbCantitate.TabIndex = 9;
            this.lbCantitate.Text = "Cantitate:";
            // 
            // dateAprovizionare
            // 
            this.dateAprovizionare.CalendarMonthBackground = System.Drawing.Color.RosyBrown;
            this.dateAprovizionare.Location = new System.Drawing.Point(24, 430);
            this.dateAprovizionare.Name = "dateAprovizionare";
            this.dateAprovizionare.Size = new System.Drawing.Size(200, 22);
            this.dateAprovizionare.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 411);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Data:";
            // 
            // btAdauga
            // 
            this.btAdauga.BackColor = System.Drawing.Color.RosyBrown;
            this.btAdauga.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAdauga.Location = new System.Drawing.Point(15, 539);
            this.btAdauga.Name = "btAdauga";
            this.btAdauga.Size = new System.Drawing.Size(102, 47);
            this.btAdauga.TabIndex = 13;
            this.btAdauga.Text = "Adauga";
            this.btAdauga.UseVisualStyleBackColor = false;
            this.btAdauga.Click += new System.EventHandler(this.btAdauga_Click);
            // 
            // btActualizeaza
            // 
            this.btActualizeaza.BackColor = System.Drawing.Color.RosyBrown;
            this.btActualizeaza.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btActualizeaza.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btActualizeaza.Location = new System.Drawing.Point(135, 539);
            this.btActualizeaza.Name = "btActualizeaza";
            this.btActualizeaza.Size = new System.Drawing.Size(131, 47);
            this.btActualizeaza.TabIndex = 14;
            this.btActualizeaza.Text = "Actualizeaza";
            this.btActualizeaza.UseVisualStyleBackColor = false;
            this.btActualizeaza.Click += new System.EventHandler(this.btActualizeaza_Click);
            // 
            // btSterge
            // 
            this.btSterge.BackColor = System.Drawing.Color.RosyBrown;
            this.btSterge.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btSterge.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSterge.Location = new System.Drawing.Point(282, 539);
            this.btSterge.Name = "btSterge";
            this.btSterge.Size = new System.Drawing.Size(102, 47);
            this.btSterge.TabIndex = 15;
            this.btSterge.Text = "Sterge";
            this.btSterge.UseVisualStyleBackColor = false;
            this.btSterge.Click += new System.EventHandler(this.btSterge_Click);
            // 
            // btInapoi
            // 
            this.btInapoi.BackColor = System.Drawing.Color.RosyBrown;
            this.btInapoi.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btInapoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btInapoi.Location = new System.Drawing.Point(12, 614);
            this.btInapoi.Name = "btInapoi";
            this.btInapoi.Size = new System.Drawing.Size(133, 31);
            this.btInapoi.TabIndex = 16;
            this.btInapoi.Text = "Inapoi";
            this.btInapoi.UseVisualStyleBackColor = false;
            this.btInapoi.Click += new System.EventHandler(this.btInapoi_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Thistle;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.RosyBrown;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Thistle;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.Location = new System.Drawing.Point(437, 29);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.RosyBrown;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Thistle;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.PowderBlue;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(726, 616);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // ProduseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::proiectPAWBuseBianca.Properties.Resources.Asset_1_100;
            this.ClientSize = new System.Drawing.Size(1207, 657);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btInapoi);
            this.Controls.Add(this.btSterge);
            this.Controls.Add(this.btActualizeaza);
            this.Controls.Add(this.btAdauga);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateAprovizionare);
            this.Controls.Add(this.lbCantitate);
            this.Controls.Add(this.lbPret);
            this.Controls.Add(this.lbCuloare);
            this.Controls.Add(this.lbTipFloare);
            this.Controls.Add(this.tbCantitate);
            this.Controls.Add(this.tbCuloare);
            this.Controls.Add(this.tbPret);
            this.Controls.Add(this.tbTip);
            this.Controls.Add(this.lbProduse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProduseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Produse";
            this.Load += new System.EventHandler(this.Produse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbProduse;
        public System.Windows.Forms.TextBox tbTip;
        public System.Windows.Forms.TextBox tbPret;
        public System.Windows.Forms.TextBox tbCuloare;
        public System.Windows.Forms.TextBox tbCantitate;
        private System.Windows.Forms.Label lbTipFloare;
        private System.Windows.Forms.Label lbCuloare;
        private System.Windows.Forms.Label lbPret;
        private System.Windows.Forms.Label lbCantitate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btAdauga;
        private System.Windows.Forms.Button btActualizeaza;
        private System.Windows.Forms.Button btSterge;
        private System.Windows.Forms.Button btInapoi;
        public System.Windows.Forms.DateTimePicker dateAprovizionare;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}