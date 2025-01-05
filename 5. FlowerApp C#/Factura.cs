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
using System.IO;



namespace proiectPAWBuseBianca
{
    public partial class Factura : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bianc\Documents\lvProduse_db.mdf;Integrated Security=True;Connect Timeout=30");
        public void memorare()
        {
            con.Open();
            string Myquery = "select * from Facturi_tb";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(Myquery, con);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView2.ReadOnly = true;
            dataGridView2.DataSource = ds.Tables[0];
            con.Close();
           

        }

        public Factura()
        {
            InitializeComponent();
            Fillcombo();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bianc\Documents\lvProduse_db.mdf;Integrated Security=True;Connect Timeout=30");
            string sql = "select idC, cantitateC, sumaC from comenzi_tb where numeC='"+comboBox1.SelectedItem.ToString()+"';";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rdr;
            try
            {
                con.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string ind = rdr.GetInt32(0).ToString();
                    int cantitate = Convert.ToInt32(rdr.GetValue(1));
                    float pret = float.Parse(rdr.GetValue(2).ToString());
                   tbId.Text = ind;
                    tbcCantitate.Text = cantitate.ToString();
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
            string sql = "select * from comenzi_tb";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rdr;
            try
            {
                con.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string name = rdr.GetString(1);
                    comboBox1.Items.Add(name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        float total = 0;
        private void btAdauga_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                float total = Convert.ToInt32(tbcCantitate.Text) * float.Parse(tbcPret.Text);
                int newCommandId = int.Parse(tbId.Text); // Numărul de comandă nouă

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    object cellValue = row.Cells["comId"].Value;
                    int existingCommandId;

                    if (cellValue != null && cellValue != DBNull.Value)
                    {
                        existingCommandId = int.Parse(cellValue.ToString());
                    }
                    else
                    {
                        cellValue = 0;
                        continue; 
                    }
                    if (existingCommandId == newCommandId)
                    {
                        Random random = new Random();
                        int newGeneratedId = random.Next(1, 1000); 

                        row.Cells["comId"].Value = newGeneratedId.ToString();

                        SqlCommand cmdUpdate = new SqlCommand("UPDATE Facturi_tb SET comId = '" + newGeneratedId + "' WHERE comId = '" + existingCommandId + "'", con);
                        cmdUpdate.ExecuteNonQuery();

                        break;
                    }
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO Facturi_tb (comId, nume, cantitate, pret, total) VALUES('" + tbId.Text + "','" + comboBox1.SelectedItem.ToString() + "'," + tbcCantitate.Text + ", " + tbcPret.Text + "," + total + ");", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Factura adaugata cu succes!");
                con.Close();
                memorare();
                string fileName = "facturi.txt";

                if (!File.Exists(fileName))
                {
                    using (StreamWriter sw = new StreamWriter(fileName, true))
                    {
                        sw.WriteLine("Istoric Facturi!");
                    }
                }
                if (tbcCantitate.Text != "" && tbcPret.Text != "" && tbId.Text != "")
                {
                    using (StreamWriter sw = new StreamWriter(fileName, true))
                    {
                        sw.Write(tbId.Text);
                        sw.Write(" ,");
                        sw.Write(comboBox1.Text);
                        sw.Write(" ,");
                        sw.Write(tbcPret.Text);
                        sw.Write(" ,");
                        sw.Write(tbcCantitate.Text);
                        sw.WriteLine();
                    }
                }


                tbcCantitate.Clear();
                tbcPret.Clear();
                tbId.Clear();
                comboBox1.Text = "";

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("A apărut o eroare: " + ex.Message);
                //MessageBox.Show("Acelasi client are deja o factura!");
            }

        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Factura_Load(object sender, EventArgs e)
        {
            memorare();
        }

        private void btStergeComanda_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                if (dataGridView2.SelectedCells.Count > 0)
                {
                    string id = dataGridView2.SelectedCells[0].Value.ToString();

                    string myQuery = "DELETE FROM Facturi_tb WHERE comId='" + id + "'";

                    SqlCommand cmd = new SqlCommand(myQuery, con);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Factura a fost stersa cu succes!");
                        int rowIndex = dataGridView2.CurrentCell.RowIndex;
                        dataGridView2.Rows.RemoveAt(rowIndex);
                    }
                    else
                    {
                        MessageBox.Show("Nu s-a putut sterge factura.");
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
        Bitmap bitmap;
        private void btPrint_Click(object sender, EventArgs e)
        {

            //Panel panel1 = new Panel();
            //this.Controls.Add(panel1);
            //Graphics graphics = panel1.CreateGraphics();
            //Size size = this.ClientSize;
            //bitmap = new Bitmap(size.Width, size.Height, graphics);
            //graphics = Graphics.FromImage(bitmap);
            //Point point = PointToScreen(panel1.Location);
            //graphics.CopyFromScreen(point.X, point.Y, 0, 0, size);
            //printPreviewDialog1.Document = printDocument1;
            //printPreviewDialog1.ShowDialog();


            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap img = new Bitmap(dataGridView2.Width, dataGridView2.Height);
            dataGridView2.DrawToBitmap(img, new Rectangle(0, 0, dataGridView2.Width, dataGridView2.Height));
            e.Graphics.DrawImage(img, 120, 20);
            //e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void btInapoi_Click(object sender, EventArgs e)
        {
            Florariecs florariecs = new Florariecs();
            florariecs.Show();
            this.Hide();
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            string[] getFiles = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            List<string> textLines = File.ReadAllLines(getFiles[0]).ToList();
            foreach(var line in textLines)
            {
              lbDrAndDp.Items.Add(line);
            }
        }
    }
    
}
