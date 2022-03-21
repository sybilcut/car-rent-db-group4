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
    public partial class Add : Form
    {

        
        NpgsqlConnection connection;
        public Add()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = $"Host=35.183.48.135;Port=5432;Database=master;UserID={Program.user};Password={Program.pass};";

            
            connection = new NpgsqlConnection();

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
            

            string ?query = null;

            if (TabWindow.SelectedTab == TabWindow.TabPages["CustomerTab"])
            {
                query = $@"INSERT INTO Customers(FirstName, 
                                                    LastName, 
                                                    StreetAddress1, 
                                                    StreetAddress2, 
                                                    PostalCode, 
                                                    DateofBirth, 
                                                    PhoneNumber, 
                                                    MembershipStatus, 
                                                    DrivingLicense)
                                VALUES
                                (NULLIF('{FirstNameText.Text}', ''), 
                                NULLIF('{LastNameText.Text}', ''), 
                                NULLIF('{Address1Text.Text}', ''), 
                                NULLIF('{Address2Text.Text}', ''), 
                                NULLIF('{PostalCodeText.Text}', ''), 
                                '{BirthDatePicker.Value}', 
                                NULLIF('{PhoneNumberText.Text}', ''), 
                                {(MemberCheck.Checked ? true : false)}, 
                                NULLIF('{DriversLicenseText.Text}', ''));";
            }

            if (TabWindow.SelectedTab == TabWindow.TabPages["VehicleTab"])
            {
                query = $@"INSERT INTO Vehicles(VIN, 
                                                Make, 
                                                Model, 
                                                Year, 
                                                Seats, 
                                                Colour, 
                                                InsuranceNumber, 
                                                Kms, 
                                                BranchID)
                                VALUES
                                (NULLIF('{VinText.Text}', ''), 
                                NULLIF('{MakeText.Text}', ''), 
                                NULLIF('{ModelText.Text}', ''), 
                                NULLIF('{YearText.Text}', ''), 
                                NULLIF('{SeatsText.Text}', ''), 
                                NULLIF('{ColourText.Text}', ''), 
                                NULLIF('{PolicyNumberText.Text}', ''), 
                                NULLIF('{KmsText.Text}', ''),
                                NULLIF('{VehicleBranchNumberText.Text}', ''));";
            }

            if (TabWindow.SelectedTab == TabWindow.TabPages["RentalTab"])
            {
                query = $@"INSERT INTO Rentals(PickupDate, 
                                                ReturnDate, 
                                                PickupTime, 
                                                ReturnTime, 
                                                CustomerID, 
                                                VIN, 
                                                PickupBID, 
                                                ReturnBID, 
                                                totalCost)
                                VALUES
                                (NULLIF('{PickupDatePicker.Text}', ''), 
                                NULLIF('{DropoffDatePicker.Text}', ''), 
                                NULLIF('{PickupTimeText.Text}', ''), 
                                NULLIF('{DropoffTimeText.Text}', ''), 
                                NULLIF('{CustIDText.Text}', ''), 
                                NULLIF('{VehicleNumberText.Text}', ''),  
                                NULLIF('{PickupBranchText.Text}', ''),  
                                NULLIF('{DropoffBranchText.Text}', ''),
                                NULLIF('{DriversLicenseText.Text}', ''));";
            }

            if (TabWindow.SelectedTab == TabWindow.TabPages["BranchTab"])
            {
                query = $@"INSERT INTO Branches(Description, 
                                                StreetAddress1, 
                                                StreetAddress2, 
                                                City,
                                                Province,
                                                PostalCode, 
                                                PhoneNumber)
                                VALUES
                                (NULLIF('{BranchDescText.Text}', ''), 
                                NULLIF('{BranchAddr1Text.Text}', ''), 
                                NULLIF('{BranchAddr2Text.Text}', ''), 
                                NULLIF('{CityText.Text}', ''), 
                                NULLIF('{ProvinceText.Text}', ''), 
                                NULLIF('{BranchPostalCodeText.Text}', ''), 
                                NULLIF('{BranchPhoneNumberText.Text}', ''));";
            }

            if (TabWindow.SelectedTab == TabWindow.TabPages["CarTypeTab"])
            {
                query = $@"INSERT INTO CarTypes(Description, 
                                                DailyRate, 
                                                WeeklyRate, 
                                                MonthlyRate)
                                VALUES
                                (NULLIF('{CarTypeDescText.Text}', ''), 
                                NULLIF('{DailyRateText.Text}', ''), 
                                NULLIF('{WeeklyRateText.Text}', ''), 
                                NULLIF('{MonthlyRateText.Text}', ''));";
            }
            NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
            try
            {
              cmd.ExecuteNonQuery();  
            }
            catch (Exception ex)
            {
                ErrorForm page = new ErrorForm(ex);
                page.Show();
            }
            
            AddedLabel.Visible = true;
            Clear_All();


        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Clear_All();
        }

        private void Clear_All()
        {
            foreach (Control control in TabWindow.Controls)
            {
                foreach (Control c in control.Controls)
                {
                    if (c is TextBox)
                    {
                        c.Text = "";
                    }
                }
            }
        }
    }
}