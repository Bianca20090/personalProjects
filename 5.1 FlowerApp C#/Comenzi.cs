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
using System.Globalization;

namespace proiectPAWBuseBianca
{

    public partial class Comenzi : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bianc\Documents\lvProduse_db.mdf;Integrated Security=True;Connect Timeout=30");

        public void memorare()
        {
            con.Open();
            string Myquery = "select * from Comenzi_tb";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(Myquery, con);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView2.ReadOnly = true;
            dataGridView2.DataSource = ds.Tables[0];
            con.Close();
        }
        public Comenzi()
        {
            InitializeComponent();
            Fillcombo();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bianc\Documents\lvProduse_db.mdf;Integrated Security=True;Connect Timeout=30");
            string sql = "select Culoare, pret, cantitate from produse_tb where TipFloare='" + cbtipFloare.SelectedItem.ToString() + "';";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rdr;
            try
            {
                con.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string culoare = rdr.GetString(0);
                    int cantitate = Convert.ToInt32(rdr.GetValue(2));
                    float pret = float.Parse(rdr.GetValue(1).ToString());
                    tbcCuloare.Text = culoare;
                    tbCantDisp.Text = cantitate.ToString();
                    tbcPret.Text = pret.ToString();
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
            string sql = "select * from produse_tb";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rdr;
            try
            {
                con.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string name = rdr.GetString(0);
                    cbtipFloare.Items.Add(name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btAdaugaComanda_Click(object sender, EventArgs e)
        {
            if (tbNume.Text == "" || cbtipFloare.Text == "" || tbcCuloare.Text == "" || tbcPret.Text == "" || tbcCantitate.Text == "" || tbNumar.Text == "" || tbId.SelectedText == null)
            {
                MessageBox.Show("Completati toate campurile!!!");
            }
            else
            {
                try
                {
                    con.Open();

                    SqlCommand selectCmd = new SqlCommand("SELECT data FROM produse_tb WHERE TipFloare='" + cbtipFloare.Text + "'", con);
                    
                    string produseDataStr = (string)selectCmd.ExecuteScalar();
                    DateTime produseData = DateTime.ParseExact(produseDataStr, "dddd, MMMM d, yyyy", CultureInfo.InvariantCulture);

                    DateTime dataLivraree = dataLivrare.Value.Date; 


                    if (dataLivraree > produseData)
                    {
                        if (int.Parse(tbCantDisp.Text) >= int.Parse(tbcCantitate.Text))
                        {
                            SqlCommand checkCmd = new SqlCommand("SELECT idC FROM Comenzi_tb WHERE idC='" + tbId.Text + "'", con);
                            int existingId = (int?)checkCmd.ExecuteScalar() ?? 0;

                            if (existingId == int.Parse(tbId.Text))
                            {
                                MessageBox.Show("ID-ul trebuie să fie diferit!");
                                con.Close();
                                return;
                            }


                            SqlCommand cmd = new SqlCommand("insert into Comenzi_tb values(" + tbId.Text + ",'" + tbNume.Text + "', '" + tbNumar.Text + "', '" + cbtipFloare.Text + "','" + tbcCuloare.Text + "'," + tbcCantitate.Text + "," + tbcPret.Text + ",'" + dataLivrare.Text + "')", con);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Comanda adaugata cu succes!!");
                            SqlCommand cmd2 = new SqlCommand("UPDATE produse_tb SET cantitate='" + (int.Parse(tbCantDisp.Text) - int.Parse(tbcCantitate.Text)).ToString() + "' where TipFloare='" + cbtipFloare.Text + "'", con);


                            cmd2.ExecuteNonQuery();
                            con.Close();
                            memorare();

                            tbcCantitate.Clear();
                            tbcCuloare.Clear();
                            tbcPret.Clear();
                            tbId.Clear();
                            tbNume.Clear();
                            tbNumar.Clear();
                            cbtipFloare.Text = "";
                            tbCantDisp.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Nu avem in stoc numarul dorit de flori!");
                            con.Close();

                        }
                    }
                    else
                    {
                        MessageBox.Show("Pentru data aleasa, nu avem in stoc numarul dorit de flori!");
                        con.Close();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    con.Close();
                }
               



            }


        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          //  tbId.Text=dataGridView2.SelectedRows[0].Cells
        }

        private void Comenzi_Load(object sender, EventArgs e)
        {
            memorare();
            ControlExtension.Draggable(dataGridView2, true);
        }

        private void btActualizeazaComanda_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                if (dataGridView2.SelectedCells.Count > 0)
                {
                    int id = int.Parse(dataGridView2.SelectedCells[0].Value.ToString());
                    string nume = "";
                    if (tbNume.Text == "")
                    {
                        nume = dataGridView2.SelectedCells[1].Value.ToString();

                    }
                    else
                    {
                        nume = tbNume.Text;
                    }
                    string telefon = "";
                    if (tbNumar.Text == "")
                    {
                        telefon = dataGridView2.SelectedCells[2].Value.ToString();

                    }
                    else
                    {
                        telefon = tbNumar.Text;
                    }
                    string floare = "";
                    if (cbtipFloare.Text == "")
                    {
                        floare = dataGridView2.SelectedCells[3].Value.ToString();
                        cbtipFloare.Text = floare;
                        tbcCuloare.Text= dataGridView2.SelectedCells[4].Value.ToString();
                        SqlCommand selectCmd = new SqlCommand("SELECT cantitate FROM produse_tb WHERE TipFloare='" + floare + "'", con);
                        selectCmd.ExecuteNonQuery();
                        int cantitateDisponibila = Convert.ToInt32(selectCmd.ExecuteScalar());
                        tbCantDisp.Text = cantitateDisponibila.ToString();
                        tbcCantitate.Text = dataGridView2.SelectedCells[5].Value.ToString();
                        tbcPret.Text = dataGridView2.SelectedCells[6].Value.ToString();

                    }
                    else
                    {

                        floare = cbtipFloare.Text;
                    }
                    string culoare = "";
                    if (tbcCuloare.Text == "")
                    {
                        culoare = dataGridView2.SelectedCells[4].Value.ToString();
                    }
                    else
                    {
                        culoare = tbcCuloare.Text;
                    }
                    int can = int.Parse(dataGridView2.SelectedCells[5].Value.ToString());
                    int cantitatec = 0;
                    
                    if (tbcCantitate.Text == "")
                    {
                        cantitatec = int.Parse(dataGridView2.SelectedCells[5].Value.ToString());
                        tbcCantitate.Text = cantitatec.ToString();
                        

                    }
                    else
                    {
                            cantitatec = int.Parse(tbcCantitate.Text);
                       

                    }
                    float pret = 0;
                    if (tbcPret.Text == "")
                    {
                        pret = float.Parse(dataGridView2.SelectedCells[6].Value.ToString());
                    }
                    else
                    {
                        pret = float.Parse(tbcPret.Text);
                    }

                    MessageBox.Show(int.Parse(tbcCantitate.Text).ToString());
                    if (int.Parse(tbCantDisp.Text) >= int.Parse(tbcCantitate.Text))
                    {
                        if (cbtipFloare.Text != dataGridView2.SelectedCells[3].Value.ToString())
                        {
                           
                            SqlCommand selectCmd = new SqlCommand("SELECT cantitate FROM produse_tb WHERE TipFloare='" + dataGridView2.SelectedCells[3].Value.ToString() + "'", con);
                            selectCmd.ExecuteNonQuery();
                            int cantitateDisponibila = Convert.ToInt32(selectCmd.ExecuteScalar());
                           

                            int cantitateActualizata = cantitateDisponibila + can; 

                            SqlCommand updateCmd = new SqlCommand("UPDATE produse_tb SET cantitate='" + cantitateActualizata + "' WHERE TipFloare='" + dataGridView2.SelectedCells[3].Value.ToString() + "'", con);
                            updateCmd.ExecuteNonQuery();
                           
                            SqlCommand updateCmd2 = new SqlCommand("UPDATE produse_tb SET cantitate='" + (int.Parse(tbCantDisp.Text)-int.Parse(tbcCantitate.Text)) + "' WHERE TipFloare='" + cbtipFloare.Text + "'", con);
                            updateCmd2.ExecuteNonQuery();


                        }
                        else
                        {
                            MessageBox.Show("hsfdsjaksj");
                            SqlCommand cmd2 = new SqlCommand("UPDATE produse_tb SET cantitate='" + (int.Parse(tbCantDisp.Text) + can - int.Parse(tbcCantitate.Text)) + "' where TipFloare='" + dataGridView2.SelectedCells[3].Value.ToString() + "'", con);
                            cmd2.ExecuteNonQuery();
                        }
                        MessageBox.Show("ksj");
                        string myQuery = "UPDATE comenzi_tb SET CuloareC= '" + culoare + "', NumeC='" + nume + "' ,FloareC='" + floare + "',sumaC= " + pret + ",telefonC='" + telefon + "', CantitateC= " + int.Parse(tbcCantitate.Text) + " where IdC=" + id + ";";
                        SqlCommand cmd = new SqlCommand(myQuery, con);
                        MessageBox.Show("h");

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Comanda a fost actualizata cu succes!");

                        }
                        else
                        {
                            MessageBox.Show("Nu s-a putut actualiza comanda.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nu avem atatea produse in stoc.");

                    }

                    con.Close();
                    memorare();
                    tbcCantitate.Clear();
                    tbcCuloare.Clear();
                    tbcPret.Clear();
                    tbId.Clear();
                    tbNume.Clear();
                    tbNumar.Clear();
                    cbtipFloare.Text = "";
                    tbCantDisp.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void btStergeComanda_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                if (dataGridView2.SelectedCells.Count > 0)
                {
                    string id = dataGridView2.SelectedCells[0].Value.ToString();
                    string floare;
                    floare = dataGridView2.SelectedCells[3].Value.ToString();
                    cbtipFloare.Text = floare;
                    tbcCuloare.Text = dataGridView2.SelectedCells[4].Value.ToString();
                    SqlCommand selectCmd = new SqlCommand("SELECT cantitate FROM produse_tb WHERE TipFloare='" + floare + "'", con);
                    selectCmd.ExecuteNonQuery();
                    int cantitateDisponibila = Convert.ToInt32(selectCmd.ExecuteScalar());
                    tbCantDisp.Text = cantitateDisponibila.ToString();
                    tbcCantitate.Text = dataGridView2.SelectedCells[5].Value.ToString();
                  


                    SqlCommand cmd2 = new SqlCommand("UPDATE produse_tb SET cantitate='" + (int.Parse(tbCantDisp.Text) +  int.Parse(tbcCantitate.Text)) + "' where TipFloare='" + dataGridView2.SelectedCells[3].Value.ToString() + "'", con);
                    cmd2.ExecuteNonQuery();

                    string myQuery = "DELETE FROM comenzi_tb WHERE idC=" + id;

                    SqlCommand cmd = new SqlCommand(myQuery, con);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Comanda a fost ștearsă cu succes!");
                        int rowIndex = dataGridView2.CurrentCell.RowIndex;
                        dataGridView2.Rows.RemoveAt(rowIndex);
                    }
                    else
                    {
                        MessageBox.Show("Nu s-a putut șterge comanda.");
                    }
                }

                con.Close();
                memorare();

                tbcCantitate.Clear();
                tbcCuloare.Clear();
                tbcPret.Clear();
                tbId.Clear();
                tbNume.Clear();
                tbNumar.Clear();
                cbtipFloare.Text = "";
                tbCantDisp.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void tbcPret_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbCantitatec_Click(object sender, EventArgs e)
        {

        }

        private void btInapoi_Click(object sender, EventArgs e)
        {
            Florariecs florariecs =new Florariecs();
            florariecs.Show();
            this.Hide();
        }

        private void tbCantDisp_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
