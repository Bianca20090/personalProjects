using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proiectPAWBuseBianca
{
    public partial class PaginaLogin : Form
    {
        public PaginaLogin()
        {
            InitializeComponent();
        }

        private void btacces_Click(object sender, EventArgs e)
        {
            Florariecs florariecs = new Florariecs();
            if ((tbusernaame.Text=="admin"|| tbusernaame.Text=="Admin")&& tbpassw.Text == "admin")
            {
                florariecs.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nume sau parola gresita!");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
