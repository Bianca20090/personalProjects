
namespace proiectPAWBuseBianca
{
    partial class PaginaLogin
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
            this.tbusernaame = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbpassw = new System.Windows.Forms.TextBox();
            this.btacces = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(142, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 49);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            // 
            // tbusernaame
            // 
            this.tbusernaame.Location = new System.Drawing.Point(122, 203);
            this.tbusernaame.Name = "tbusernaame";
            this.tbusernaame.Size = new System.Drawing.Size(201, 22);
            this.tbusernaame.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(67, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "User name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(67, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password:";
            // 
            // tbpassw
            // 
            this.tbpassw.Location = new System.Drawing.Point(122, 280);
            this.tbpassw.Name = "tbpassw";
            this.tbpassw.Size = new System.Drawing.Size(201, 22);
            this.tbpassw.TabIndex = 4;
            this.tbpassw.UseSystemPasswordChar = true;
            // 
            // btacces
            // 
            this.btacces.BackColor = System.Drawing.Color.Thistle;
            this.btacces.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btacces.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btacces.Location = new System.Drawing.Point(151, 342);
            this.btacces.Name = "btacces";
            this.btacces.Size = new System.Drawing.Size(119, 56);
            this.btacces.TabIndex = 5;
            this.btacces.Text = "Login";
            this.btacces.UseVisualStyleBackColor = false;
            this.btacces.Click += new System.EventHandler(this.btacces_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(418, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "X";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 553);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(378, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "Nota: Ambele campuri se completeaza cu: admin\r\n";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // PaginaLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::proiectPAWBuseBianca.Properties.Resources.Asset_1_100;
            this.ClientSize = new System.Drawing.Size(457, 581);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btacces);
            this.Controls.Add(this.tbpassw);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbusernaame);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PaginaLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PaginaLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tbusernaame;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox tbpassw;
        private System.Windows.Forms.Button btacces;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}