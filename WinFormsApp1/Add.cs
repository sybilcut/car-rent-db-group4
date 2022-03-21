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
    public partial class Add : Form
    {

        
        SqlConnection connection;
        public Add()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;";


            connection = new SqlConnection();

            connection.ConnectionString = connectionString;

            connection.Open();
            if (connection != null)
            {
                label32.Text = "Connection" + connection.State.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            

            
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SearchEdit form = new SearchEdit();
            form.Show();
            this.Hide();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewRental page = new NewRental();
            page.Show();
            this.Hide();
        }

        private void reportingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporting page = new Reporting();
            page.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //retrieve the SQL Server instance version
            string query = $@"INSERT INTO Customers(FirstName, LastName, StreetAddress1, PostalCode, DateofBirth, PhoneNumber, MembershipStatus, DrivingLicense)
                                VALUES
                                (NULLIF('{textBox15.Text}', ''), NULLIF('{textBox16.Text}', ''), NULLIF('{textBox17.Text}', ''), NULLIF('{textBox18.Text}', ''), '{dateTimePicker2.Value}', NULLIF('{textBox20.Text}', ''), 0, NULLIF('{textBox21.Text}', ''));";

            SqlCommand cmd = new SqlCommand(query, connection);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ErrorForm page = new ErrorForm();
                page.Show();
            }
            
            
        }
    }
}