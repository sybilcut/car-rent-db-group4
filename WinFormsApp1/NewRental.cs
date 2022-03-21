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
    public partial class NewRental : Form
    {
        public NewRental()
        {
            InitializeComponent();
        }

        private void editRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchEdit page = new SearchEdit();
            page.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;";


            using (SqlConnection connection = new SqlConnection())
            {

                connection.ConnectionString = connectionString;

                connection.Open();

                if (connection.State == ConnectionState.Open)
                {

                    label32.Text = "Connected!";
                    button5.Visible = false;
                }
            }
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add page = new Add();
            page.Show();
            this.Hide();
        }

        private void reportingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
