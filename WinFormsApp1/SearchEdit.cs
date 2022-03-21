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
using Npgsql;

namespace WinFormsApp1
{
    public partial class SearchEdit : Form
    {
        NpgsqlDataAdapter dAdapter;
        DataSet ds;

        NpgsqlConnection connection;
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
            /*
            if (Program.user == null || Program.pass == null)
            {
                Login login = new Login();
                login.Show();
            }
            else
            {
            */
                string connectionString = $"Host=35.183.48.135;Port=5432;Database=master;UserID={Program.user};Password={Program.pass};";

                connection = new NpgsqlConnection();

                connection.ConnectionString = connectionString;

                connection.Open();
                if (connection != null)
                {
                    label32.Text = "Connection" + connection.State.ToString();
                }
            //}
            
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

            string connectionString = $"Host=35.183.48.135;Port=5432;Database=master;UserID={Program.user};Password={Program.pass};";

            
            using (NpgsqlConnection connection = new NpgsqlConnection())
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
            string ?query = null;

            if (TabWindow.SelectedTab == TabWindow.TabPages["CustomerTab"])
            {
                query = $@"SELECT * FROM Customers c WHERE
                            LOWER(FirstName) LIKE LOWER('%{FirstNameText.Text}%') AND
                            LOWER(LastName) LIKE LOWER('%{LastNameText.Text}%') AND
                            LOWER(StreetAddress1) LIKE LOWER('%{Address1Text.Text}%') AND
                            (LOWER(StreetAddress2) LIKE LOWER('%{Address2Text.Text}%') OR StreetAddress2 IS NULL) AND
                            (LOWER(PostalCode) LIKE LOWER('%{PostalCodeText.Text}%') OR PostalCode IS NULL) AND
                            LOWER(PhoneNumber) LIKE LOWER(('%{PhoneNumberText.Text}%'));";
            }

            if (TabWindow.SelectedTab == TabWindow.TabPages["VehicleTab"])
            {
                query = $@"SELECT * FROM Vehicles c WHERE
                            LOWER(VIN) LIKE LOWER('%{VinText.Text}%') AND
                            LOWER(Make) LIKE LOWER('%{MakeText.Text}%') AND
                            LOWER(Model) LIKE LOWER('%{ModelText.Text}%') AND
                            LOWER(Year) LIKE LOWER('%{YearMinText.Text}%') AND 
                            LOWER(Seats) LIKE LOWER('%{SeatsMinText.Text}%') AND
                            LOWER(Colour) LIKE LOWER('%{ColourText.Text}%') AND
                            LOWER(PolicyNumber) LIKE LOWER('%{PolicyNumberText.Text}%') AND
                            LOWER(Kms) LIKE LOWER('%{KmsMinText.Text}%') AND
                            LOWER(BranchNumber) LIKE LOWER('%{BranchNumberText.Text}%') AND
                            LOWER(VehicleClass) LIKE LOWER('%{VehicleClassText.Text}%');";
            }

            if (TabWindow.SelectedTab == TabWindow.TabPages["RentalTab"])
            {
                query = $@"SELECT * FROM Rentals c WHERE
                            LOWER(RentalID) LIKE LOWER('%{RentalIDText.Text}%') AND
                            LOWER(PickupDate) LIKE LOWER('%{PickupMinDatePicker.Text}%') AND
                            LOWER(DropoffDate) LIKE LOWER('%{DropoffMinDatePicker.Text}%') AND
                            LOWER(TotalPrice) LIKE LOWER('%{PriceMinText.Text}%');";
            }

            if (TabWindow.SelectedTab == TabWindow.TabPages["BranchTab"])
            {
                query = $@"SELECT * FROM Branches c WHERE
                            LOWER(Address1) LIKE LOWER('%{BranchAddr1Text.Text}%') AND
                            LOWER(Address2) LIKE LOWER('%{BranchAddr2Text.Text}%') AND
                            LOWER(Province) LIKE LOWER('%{ProvinceText.Text}%') AND
                            LOWER(City) LIKE LOWER('%{CityText.Text}%') AND 
                            LOWER(Description) LIKE LOWER('%{DescriptionText.Text}%') AND
                            LOWER(PostalCode) LIKE LOWER('%{BranchPostalCodeText.Text}%') AND
                            LOWER(PhoneNumber) LIKE LOWER('%{BranchPhoneNumText.Text}%');";
            }

            if (TabWindow.SelectedTab == TabWindow.TabPages["CarTypeTab"])
            {
                query = $@"SELECT * FROM CarTypes c WHERE
                            LOWER(Description) LIKE LOWER('%{CarDescText.Text}%') AND
                            LOWER(DailyRate) LIKE LOWER('%{DailyRateText.Text}%') AND
                            LOWER(WeeklyRate) LIKE LOWER('%{WeeklyRateText.Text}%') AND
                            LOWER(MonthlyRate) LIKE LOWER('%{MonthlyRateText.Text}%');";
            }




            try
            {

    
                /*
                                
                    */
                //define the SqlCommand object
                NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

                //Set the SqlDataAdapter object
                dAdapter = new NpgsqlDataAdapter(cmd);

                //define dataset
                ds = new DataSet();

                //fill dataset with query results
                dAdapter.Fill(ds);

                //set DataGridView control to read-only
                dataGridView1.ReadOnly = false;

                //set the DataGridView control's data source/data table
                switch (TabWindow.SelectedTab.Text)
                {
                    case "Customer":
                        dataGridView1.DataSource = ds.Tables[0];
                        break;
                    case "Vehicle":
                        dataGridView1.DataSource = ds.Tables[1];
                        break;
                    case "Rental":
                        dataGridView1.DataSource = ds.Tables[2];
                        break;
                    case "Branch":
                        dataGridView1.DataSource = ds.Tables[3];
                        break;
                    case "Car Type":
                        dataGridView1.DataSource = ds.Tables[4];
                        break;
                    default:
                        dataGridView1.DataSource = ds.Tables[0];
                        break;
                }
                

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

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
            {
                SaveButton.Text = "No data";
                return;
            }
            else
            {
                dAdapter.UpdateCommand = new NpgsqlCommandBuilder(dAdapter).GetUpdateCommand();
                dAdapter.Update(ds);
            }
        }
    }
}
