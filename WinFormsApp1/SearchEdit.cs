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

namespace WinFormsApp1
{
    public partial class SearchEdit : Form
    {

        SqlConnection connection;
        public SearchEdit()
        {
            InitializeComponent();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add form = new Add();
            form.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;";


            connection = new SqlConnection();

            connection.ConnectionString = connectionString;

            connection.Open();
            if (connection != null)
            {
                label32.Text = "Connection " + connection.State.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;";

            
            using (SqlConnection connection = new SqlConnection())
            {
                    
                connection.ConnectionString = connectionString;
                    
                connection.Open();

                if (connection.State == ConnectionState.Open)
                {
                        
                    label32.Text = "Connected!";

                }
            }
        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                //retrieve the SQL Server instance version
                string query = $@"SELECT * FROM Customers c
                                WHERE
                                FirstName LIKE '%{textBox15.Text}%' AND
                                LastName LIKE '%{textBox16.Text}%' AND
                                StreetAddress1 LIKE '%{textBox17.Text}%' AND
                                (StreetAddress2 LIKE '%{textBox18.Text}%' OR StreetAddress2 IS NULL) AND
                                (PostalCode LIKE '%{textBox19.Text}%' OR PostalCode IS NULL) AND
                                PhoneNumber LIKE '%{textBox20.Text}%';";

                //define the SqlCommand object
                SqlCommand cmd = new SqlCommand(query, connection);

                //Set the SqlDataAdapter object
                SqlDataAdapter dAdapter = new SqlDataAdapter(cmd);

                //define dataset
                DataSet ds = new DataSet();

                //fill dataset with query results
                dAdapter.Fill(ds);

                //set DataGridView control to read-only
                dataGridView1.ReadOnly = true;

                //set the DataGridView control's data source/data table
                dataGridView1.DataSource = ds.Tables[0];

            }
            catch (Exception eep)
            {
                MessageBox.Show(eep.Message);
            }

        }

        private void reportingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporting page = new Reporting();
            page.Show();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewRental page = new NewRental();
            page.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
