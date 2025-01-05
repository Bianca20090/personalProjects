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
    public partial class Livrarics : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bianc\Documents\lvProduse_db.mdf;Integrated Security=True;Connect Timeout=30");

        public void memorare()
        {
            con.Open();
            string Myquery = "select * from Livrari_tb";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(Myquery, con);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView3.ReadOnly = true;
            dataGridView3.DataSource = ds.Tables[0];
            con.Close();
        }
        public Livrarics()
        {
            InitializeComponent();
            Fillcombo();
        }
        private void tbIdComanda_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bianc\Documents\lvProduse_db.mdf;Integrated Security=True;Connect Timeout=30");
            string sql = "select numeC, TelefonC from comenzi_tb where IdC=" + Convert.ToInt32(tbIdComanda.SelectedItem) + ";";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rdr;
            try
            {
                con.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string nume = rdr.GetString(0);
                    string telefon = rdr.GetString(1);
                    tbNume.Text = nume;
                    tbcTelefon.Text = telefon;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void Fillcombo()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bianc\Documents\lvProduse_db.mdf;Integrated Security=True;Connect Timeout=30");
            string sql = "select * from comenzi_tb";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rdr;
            try
            {
                con.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                   int id = Convert.ToInt32(rdr.GetValue(0));
                    tbIdComanda.Items.Add(id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void btAdauga_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand checkCmd = new SqlCommand("SELECT idComanda FROM Livrari_tb WHERE idComanda='" + tbIdComanda.Text + "'", con);
                int existingId = (int?)checkCmd.ExecuteScalar() ?? 0;

                if (existingId == int.Parse(tbIdComanda.SelectedItem.ToString()))
                {
                    MessageBox.Show("Aceasta comanda a fost/este in curs de livrare!");
                    con.Close();
                    return;
                }

                if (string.IsNullOrEmpty(tbcAdresa.Text) || tbIdComanda.SelectedItem == null || cbCurier.SelectedItem == null || cbStatus.SelectedItem == null)
                {
                    MessageBox.Show("Completati toate campurile!!!");
                }



                else
                {
                    SqlCommand cmd = new SqlCommand("insert into Livrari_tb values('" + tbIdComanda.SelectedItem.ToString() + "','" + cbCurier.SelectedItem.ToString() + "',' " + tbcAdresa.Text + "', '" + cbStatus.SelectedItem.ToString() + "', '" + tbNume.Text + "','" + tbcTelefon.Text + "' )", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Livrare adaugata cu succes!!");
                    con.Close();
                    memorare();

                    tbcAdresa.Clear();
                    tbIdComanda.Text = "";


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }


        }

        private void btActualizeaza_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();

                if (dataGridView3.SelectedCells.Count > 0)
                {
                    int id = int.Parse(dataGridView3.SelectedCells[0].Value.ToString());
                    string nume = "";
                    if (cbCurier.SelectedItem == null)
                    {
                        nume = dataGridView3.SelectedCells[1].Value.ToString();
                    }
                    else
                    {
                        nume = cbCurier.SelectedItem.ToString();
                    }

                    string status = "";
                    if (cbStatus.SelectedItem == null)
                    {
                        status = dataGridView3.SelectedCells[3].Value.ToString();
                    }
                    else
                    {
                        status = cbStatus.SelectedItem.ToString();
                    }

                    string adresa = "";
                    if (tbcAdresa.Text == "")
                    {
                        adresa = dataGridView3.SelectedCells[2].Value.ToString();

                    }
                    else
                    {
                        adresa = tbcAdresa.Text;
                    }
                  


                    string myQuery = "UPDATE livrari_tb SET Curier= '" + nume + "', Adresa='" + adresa + "' ,Status='" + status + "' where IdComanda=" + id;

                    SqlCommand cmd = new SqlCommand(myQuery, con);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Livrarea a fost actualizata cu succes!");

                    }
                    else
                    {
                        MessageBox.Show("Nu s-a putut actualiza datele despre aceasta livrare.");
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

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Livrarics_Load(object sender, EventArgs e)
        {
            memorare();
        
        }

        private void btInapoi_Click(object sender, EventArgs e)
        {
            Florariecs florariecs = new Florariecs();
            florariecs.Show();
            this.Hide();
        }

        // private void btSterge_Click(object sender, EventArgs e)
        //{
        //try
        //{
        //    con.Open();

        //    if (dataGridView3.SelectedCells.Count > 0)
        //    {
        //        int id = int.Parse(dataGridView3.SelectedCells[0].Value.ToString());

        //        string myQuery = "DELETE FROM livrari_tb WHERE idComanda=" + id;

        //        SqlCommand cmd = new SqlCommand(myQuery, con);

        //        int result = cmd.ExecuteNonQuery();

        //        if (result > 0)
        //        {
        //            MessageBox.Show("Livrarea a fost stearsa cu succes!");
        //            int rowIndex = dataGridView3.CurrentCell.RowIndex;
        //            dataGridView3.Rows.RemoveAt(rowIndex);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Nu s-a putut sterge aceasta livrare.");
        //        }
        //    }


        //    con.Close();
        //    memorare();
        //}
        //catch (Exception ex)
        //{
        //    MessageBox.Show(ex.Message);
        //    con.Close();
        //}

        //  }


    }
}
