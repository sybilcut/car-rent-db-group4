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
        public const int MAX_VAL = 99999999;

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
            string connectionString = $"Host=35.183.48.135;Port=5432;Database=master;UserID={Program.user};Password={Program.pass};";

            try
            {
                connection = new NpgsqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open();

                if (connection != null)
                {
                    label32.Text = "Connection " + connection.State.ToString();
                }

            }
            catch (Exception eep)
            {
                ErrorForm page = new ErrorForm(eep);
                page.Show();
                this.Close();
                Login l = new Login();
                l.Show();
            }
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
                            LOWER(FirstName) LIKE LOWER('%{FirstNameText.Text}%')
                            AND (LOWER(MiddleName) LIKE LOWER('%{MiddleNameText.Text}%') 
                                OR MiddleName IS NULL)
                            AND LOWER(LastName) LIKE LOWER('%{LastNameText.Text}%')
                            AND (LOWER(StreetAddress1) LIKE LOWER('%{Address1Text.Text}%') 
                                OR StreetAddress1 IS NULL)
                            AND (LOWER(StreetAddress2) LIKE LOWER('%{Address2Text.Text}%') 
                                OR StreetAddress2 IS NULL)
                            AND (LOWER(PostalCode) LIKE LOWER('%{PostalCodeText.Text}%') 
                                OR PostalCode IS NULL)
                            AND (LOWER(PhoneNum) LIKE LOWER('%{PhoneNumberText.Text}%') 
                                OR PhoneNum IS NULL)
                            AND (LOWER(Insurance) LIKE LOWER('%{InsuranceText.Text}%') 
                                OR Insurance IS NULL)
                            AND (LOWER(Driving_license) LIKE LOWER('%{DrivingLicenseText.Text}%') 
                                OR Driving_license IS NULL);";
            }

            if (TabWindow.SelectedTab == TabWindow.TabPages["VehicleTab"])
            {
                query = $@"SELECT * FROM Car c WHERE
                            LOWER(VIN) LIKE LOWER('%{VinText.Text}%')
                            AND LOWER(Make) LIKE LOWER('%{MakeText.Text}%')
                            AND LOWER(Model) LIKE LOWER('%{ModelText.Text}%')
                            AND (Year BETWEEN '{((YearMinText.Text.Length>0) ? YearMinText.Text : 0)}'::int4 
                                          AND '{((YearMaxText.Text.Length>0) ? YearMaxText.Text : MAX_VAL)}'::int4)
                            AND (noOfSeats BETWEEN '{((SeatsMinText.Text.Length>0) ? SeatsMinText.Text : 0)}'::int4
                                               AND '{((SeatsMaxText.Text.Length > 0) ? SeatsMaxText.Text : MAX_VAL)}'::int4)
                            AND LOWER(Colour) LIKE LOWER('%{ColourText.Text}%')
                            AND (InsuranceNo::text LIKE ('%{PolicyNumberText.Text}%') 
                                OR InsuranceNo IS NULL)
                            AND (odometernumber BETWEEN '{((KmsMinText.Text.Length > 0) ? KmsMinText.Text : 0)}'::int4 
                                                    AND '{((KmsMaxText.Text.Length > 0) ? KmsMaxText.Text : MAX_VAL)}'::int4 
                                OR odometernumber IS NULL)
                            AND Branch_ID::text LIKE ('%{BranchNumberText.Text}%')
                            AND LOWER(CarType) LIKE LOWER('%{CarTypeText.Text}%');";
            }

            if (TabWindow.SelectedTab == TabWindow.TabPages["RentalTab"])
            {
                query = $@"SELECT * FROM Rental c WHERE
                            TID::text LIKE LOWER('%{RentalIDText.Text}%')
                            AND (PickupDate BETWEEN '{PickupMinDatePicker.Value.ToShortDateString()}'::date 
                                                AND '{PickupMaxDatePicker.Value.ToShortDateString()}'::date)
                            AND (ReturnDate BETWEEN '{DropoffMinDatePicker.Value.ToShortDateString()}'::date 
                                                AND '{DropoffMaxDatePicker.Value.ToShortDateString()}'::date)
                            AND CustomerID::text LIKE LOWER('{CustomerIDText.Text}%')
                            AND LOWER(VIN) LIKE LOWER('{RentalVINText.Text}%')
                            AND PickupBID::text LIKE ('{PickupBranchText.Text}%')
                            AND (ReturnBID::text LIKE ('{ReturnBranchText.Text}%') 
                                OR ReturnBID IS NULL)
                            AND (Total_rentValue BETWEEN '{((PriceMinText.Text.Length > 0) ? PriceMinText.Text : 0)}'::money 
                                                     AND '{((PriceMaxText.Text.Length > 0) ? PriceMaxText.Text : MAX_VAL)}'::money);";
            }

            if (TabWindow.SelectedTab == TabWindow.TabPages["BranchTab"])
            {
                query = $@"SELECT * FROM Branch c WHERE
                            (LOWER(Street_address1) LIKE LOWER('%{BranchAddr1Text.Text}%') OR Street_address1 IS NULL)
                            AND (LOWER(Street_Address2) LIKE LOWER('%{BranchAddr2Text.Text}%') OR Street_address2 IS NULL)
                            AND LOWER(Province) LIKE LOWER('%{ProvinceText.Text}%')
                            AND LOWER(City) LIKE LOWER('%{CityText.Text}%')
                            AND (LOWER(Description) LIKE LOWER('%{DescriptionText.Text}%') OR description IS NULL)
                            AND (LOWER(PostalCode) LIKE LOWER('%{BranchPostalCodeText.Text}%') OR PostalCode IS NULL)
                            AND (LOWER(PhoneNum) LIKE LOWER('%{BranchPhoneNumText.Text}%') OR PhoneNum IS NULL);";
            }

            if (TabWindow.SelectedTab == TabWindow.TabPages["CarTypeTab"])
            {
                query = $@"SELECT * FROM CarType c WHERE
                            LOWER(CarTypeID) LIKE LOWER('%{CarDescText.Text}%') 
                            AND (DailyRate BETWEEN '{((DailyRateMinText.Text.Length > 0) ? DailyRateMinText.Text : 0)}'::money 
                                               AND '{((DailyRateMaxText.Text.Length > 0) ? DailyRateMaxText.Text : MAX_VAL)}'::money) 
                            AND (WeeklyRate BETWEEN '{((WeeklyRateMinText.Text.Length > 0) ? WeeklyRateMinText.Text : 0)}'::money 
                                                AND '{((WeeklyRateMaxText.Text.Length > 0) ? WeeklyRateMaxText.Text : MAX_VAL)}'::money) 
                            AND (MonthlyRate BETWEEN '{((MonthlyRateMinText.Text.Length > 0) ? MonthlyRateMinText.Text : 0)}'::money 
                                                 AND '{((MonthlyRateMaxText.Text.Length > 0) ? MonthlyRateMaxText.Text : MAX_VAL)}'::money);";
            }

            try
            {
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

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
            {
                SaveButton.Text = "No data";
                return;
            }
            else
            {
                try
                {
                    dAdapter.UpdateCommand = new NpgsqlCommandBuilder(dAdapter).GetUpdateCommand();
                    dAdapter.Update(ds);
                    SaveButton.Text = "Saved!";
                }
                catch(Exception eep)
                {
                    MessageBox.Show(eep.Message);
                }
            }
        }

        private void SaveButton_LostFocus(object sender, EventArgs e)
        {
            SaveButton.Text = "Save";
        }
    }
}
