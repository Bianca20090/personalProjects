using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace proiectPAWBuseBianca
{
    public partial class ProduseForm : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bianc\Documents\lvProduse_db.mdf;Integrated Security=True;Connect Timeout=30");
       public void memorare()
        {
            con.Open();
            string Myquery = "select * from Produse_tb";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(Myquery, con);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
        public ProduseForm()
        {
            InitializeComponent();
        }

      

        private void Produse_Load(object sender, EventArgs e)
        {
            memorare();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btAdauga_Click(object sender, EventArgs e)
        {

            if (tbTip.Text == "" || tbCuloare.Text == "" || tbPret.Text == "" || tbCantitate.Text == "")
            {
                MessageBox.Show("Completati toate campurile!!!");
            }
            else
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Produse_tb VALUES('" + tbTip.Text + "', '" + tbCuloare.Text + "', " + tbPret.Text + ", " + tbCantitate.Text + ", '" + dateAprovizionare.Text + "')", con);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Produs adaugat cu succes!");
                con.Close();
                memorare();
                tbTip.Clear();
                tbCuloare.Clear();
                tbCantitate.Clear();
                tbPret.Clear();
                

            }

            // Produse p = new Produse();

            //if(p.DialogResult==DialogResult.OK)
            //{
            //string tip = p.tbTip.Text;
            //string culoare = p.tbCuloare.Text;
            //float pret = float.Parse(p.tbPret.Text);
            //int cantitate = int.Parse(p.tbCantitate.Text);
            //DateTime dateTime = p.dateAprovizionare.Value;

            //Produs p1 = new Produs(tip, culoare, pret, cantitate, dateTime);
            //ListViewItem itm = new ListViewItem(tip);
            //itm.SubItems.Add(culoare);
            //itm.SubItems.Add(pret.ToString());
            //itm.SubItems.Add(cantitate.ToString());
            //itm.SubItems.Add(dateTime.ToString());
            //lvProduse.Items.Add(itm);
            //lvProduse.Refresh();

            //ListViewItem itm = new ListViewItem(tbTip.Text);
            //itm.SubItems.Add(tbCuloare.Text);
            //itm.SubItems.Add(float.Parse(tbPret.Text).ToString());
            //itm.SubItems.Add(int.Parse(tbCantitate.Text).ToString());
            //itm.SubItems.Add(dateAprovizionare.Value.ToString());
            //lvProduse.Items.Add(itm);

            //   lvProduse.Refresh();

            //  }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        //    tbTip.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        //    tbCuloare.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        //    tbPret.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        //    tbCantitate.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        //    dateAprovizionare.Text = "'" + dataGridView1.SelectedRows[0].Cells[4].Value.ToString() + "'";
           

        }


        private void btActualizeaza_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                if (dataGridView1.SelectedCells.Count > 0)
                {
                    string id = dataGridView1.SelectedCells[0].Value.ToString();
                    string culoare="";
                    if (tbCuloare.Text == "")
                    {
                      
                        culoare = dataGridView1.SelectedCells[1].Value.ToString();
                    }
                    else
                    {
                        culoare = tbCuloare.Text;
                    }
                   
                    float pret = 0;
                    if (tbPret.Text == "")
                    {
                        pret = float.Parse(dataGridView1.SelectedCells[2].Value.ToString());
                    }
                    else
                    {
                        pret = float.Parse(tbPret.Text);
                    }
                    int cantitate = 0;
                    if (tbCantitate.Text == "")
                    {
                        cantitate = int.Parse(dataGridView1.SelectedCells[3].Value.ToString());
                    }
                    else
                    {
                        cantitate = int.Parse(tbCantitate.Text);
                    }
                    string myQuery = "UPDATE produse_tb SET Culoare= '" + culoare + "' ,Pret= " + pret + ", Cantitate= " + cantitate+" where TipFloare='"+id+"';";
                    SqlCommand cmd = new SqlCommand(myQuery, con);
                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Produsul a fost actualizat cu succes!");
                        
                    }
                    else
                    {
                        MessageBox.Show("Nu s-a putut actualiza produsul.");
                    }

                    con.Close();
                    memorare();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void btSterge_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();

                if (dataGridView1.SelectedCells.Count > 0)
                {
                    string id = dataGridView1.SelectedCells[0].Value.ToString();

                    string myQuery = "DELETE FROM Produse_tb WHERE TipFloare='"+id+"'";

                    SqlCommand cmd = new SqlCommand(myQuery, con);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Produsul a fost sters cu succes!");
                        int rowIndex = dataGridView1.CurrentCell.RowIndex;
                        dataGridView1.Rows.RemoveAt(rowIndex);
                    }
                    else
                    {
                        MessageBox.Show("Nu s-a putut sterge produsul.");
                    }
                }
               

                con.Close();
                memorare();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }

        }

        private void btInapoi_Click(object sender, EventArgs e)
        {
            Florariecs florariecs = new Florariecs();
            florariecs.Show();
            this.Hide();
        }
    }
}
