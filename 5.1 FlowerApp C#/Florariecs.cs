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
    public partial class Florariecs : Form
    {
        public Florariecs()
        {
            InitializeComponent();
        }
        ProduseForm produse = new ProduseForm();
        Comenzi comenzi = new Comenzi();
        Livrarics livrarics = new Livrarics();
        Factura factura = new Factura();
        private void button1_Click(object sender, EventArgs e)
        {
            produse.Show();
            this.Hide();
        }

        private void Florariecs_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            comenzi.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            livrarics.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            factura.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PaginaLogin log = new PaginaLogin();
            log.Show();
            this.Hide();
        }
    }
}
