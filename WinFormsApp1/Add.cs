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

            try {
                connection = new NpgsqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open();

                if (connection != null)
                {
                    label32.Text = "Connection " + connection.State.ToString();
                }

                Populate_Comboboxes();

            } catch (Exception eep)
            {
                ErrorForm page = new ErrorForm(eep);
                page.Show();
                this.Close();
                Login l = new Login();
                l.Show();
            }
        }
        private void Populate_Comboboxes()
        {
            string query;

            query = "SELECT * from Branch";
            NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
            NpgsqlDataAdapter dAdapter = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dAdapter.Fill(ds);
            VehicleBranchBox.ValueMember = "BID";
            VehicleBranchBox.DisplayMember = "City";
            VehicleBranchBox.DataSource = ds.Tables[0];

            PickupBox.ValueMember = "BID";
            PickupBox.DisplayMember = "City";
            PickupBox.DataSource = ds.Tables[0];

            DropoffBox.ValueMember = "BID";
            DropoffBox.DisplayMember = "City";
            DropoffBox.DataSource = ds.Tables[0];



            query = "SELECT * FROM CarType";
            cmd = new NpgsqlCommand(query, connection);
            dAdapter = new NpgsqlDataAdapter(cmd);
            DataSet ds2 = new DataSet();
            dAdapter.Fill(ds2);
            CarTypeBox.ValueMember = "CartypeID";
            CarTypeBox.DisplayMember = "CartypeID";
            CarTypeBox.DataSource = ds2.Tables[0];
            
            

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
                                                    MiddleName,
                                                    LastName, 
                                                    StreetAddress1, 
                                                    StreetAddress2, 
                                                    City,
                                                    Province,
                                                    PostalCode, 
                                                    DateofBirth, 
                                                    PhoneNum,
                                                    Insurance,
                                                    Membership_Status, 
                                                    Driving_License)
                                VALUES
                                (NULLIF('{FirstNameText.Text}', ''), 
                                NULLIF('{MiddleNameText.Text}', ''),
                                NULLIF('{LastNameText.Text}', ''), 
                                NULLIF('{Address1Text.Text}', ''), 
                                NULLIF('{Address2Text.Text}', ''), 
                                NULLIF('{CustCityText.Text}', ''), 
                                NULLIF('{CustProvText.Text}', ''), 
                                NULLIF('{PostalCodeText.Text}', ''), 
                                '{BirthDatePicker.Value}', 
                                NULLIF('{PhoneNumberText.Text}', ''), 
                                NULLIF('{InsuranceText.Text}', ''),
                                {(MemberCheck.Checked ? true : false)}, 
                                NULLIF('{DriversLicenseText.Text}', ''));";
            }

            if (TabWindow.SelectedTab == TabWindow.TabPages["VehicleTab"])
            {
                query = $@"INSERT INTO Car(VIN, 
                                                Make, 
                                                Model, 
                                                Year, 
                                                noOfSeats, 
                                                Colour, 
                                                InsuranceNo, 
                                                odometernumber, 
                                                Branch_ID,
                                                CarType)
                                VALUES
                                (NULLIF('{VinText.Text}', ''), 
                                NULLIF('{MakeText.Text}', ''), 
                                NULLIF('{ModelText.Text}', ''), 
                                NULLIF('{YearText.Text}', '')::int, 
                                NULLIF('{SeatsText.Text}', '')::int, 
                                NULLIF('{ColourText.Text}', ''), 
                                NULLIF('{PolicyNumberText.Text}', ''), 
                                NULLIF('{KmsText.Text}', '')::int,
                                NULLIF('{VehicleBranchBox.Text}', '')::int,
                                NULLIF('{CarTypeBox.Text}', ''));";
            }

            if (TabWindow.SelectedTab == TabWindow.TabPages["RentalTab"])
            {
                query = $@"INSERT INTO Rental(PickupDate, 
                                                ReturnDate, 
                                                PickupTime, 
                                                ReturnTime, 
                                                CustomerID, 
                                                VIN, 
                                                PickupBID, 
                                                ReturnBID, 
                                                total_rentValue)
                                VALUES
                                ('{PickupDatePicker.Value.ToShortDateString()}'::date, 
                                '{DropoffDatePicker.Value.ToShortDateString()}'::date, 
                                NULLIF('{PickupTimeHrText.Text}{PickupTimeMinText.Text}', '')::time,
                                NULLIF('{DropoffTimeHrText.Text}{DropoffTimeMinText.Text}', '')::time,
                                NULLIF('{CustIDText.Text}', '')::int, 
                                NULLIF('{VehicleNumberText.Text}', ''),  
                                NULLIF('{PickupBranchText.Text}', '')::int,  
                                NULLIF('{DropoffBranchText.Text}', '')::int,
                                NULLIF('{TotalPriceText.Text}', '')::money);";
            }

            if (TabWindow.SelectedTab == TabWindow.TabPages["BranchTab"])
            {
                query = $@"INSERT INTO Branch(Description, 
                                                Street_Address1, 
                                                Street_Address2, 
                                                City,
                                                Province,
                                                PostalCode, 
                                                PhoneNum)
                                VALUES
                                (NULLIF('{BranchDescText.Text}', ''), 
                                NULLIF('{BranchAddr1Text.Text}', ''), 
                                NULLIF('{BranchAddr2Text.Text}', ''), 
                                NULLIF('{CityText.Text}', ''), 
                                NULLIF('{ProvinceBox.Text}', ''), 
                                NULLIF('{BranchPostalCodeText.Text}', ''), 
                                NULLIF('{BranchPhoneNumberText.Text}', ''));";
            }

            if (TabWindow.SelectedTab == TabWindow.TabPages["CarTypeTab"])
            {
                query = $@"INSERT INTO CarType(CarTypeID, 
                                                DailyRate, 
                                                WeeklyRate, 
                                                MonthlyRate)
                                VALUES
                                (NULLIF('{CarTypeDescText.Text}', ''), 
                                NULLIF('{DailyRateText.Text}', '')::money, 
                                NULLIF('{WeeklyRateText.Text}', '')::money, 
                                NULLIF('{MonthlyRateText.Text}', '')::money);";
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

        private void Button1_LostFocus(object sender, EventArgs e)
        {
            AddedLabel.Visible = false;
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

        private void tabwindow_Selected(object sender, EventArgs e)
        {
            Populate_Comboboxes();
        }
    }
}