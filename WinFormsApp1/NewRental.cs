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
    public partial class NewRental : Form
    {   public NpgsqlConnection myConnection;
        public NpgsqlCommand myCommand, myCommand2;
        public NpgsqlDataReader myReader;
        public int dailyrate, weeklyrate, monthlyrate, totalPrice;
        public NewRental()
        {
            InitializeComponent();
            ////////////////////////////////
            VehicleTypes.Items.Add("All Vehicle Types");
            //DropoffLocation.Items.Add("Same as pick up location");

            ///Adding vehicles types + branches that we have in the database
            string connectionString = $"Host=35.183.48.135;Port=5432;Database=master;UserID={Program.user};Password={Program.pass};";
            myConnection = new NpgsqlConnection(connectionString);
            try
            {
                myConnection.Open();  //open the connection to BD
                myCommand = new NpgsqlCommand();
                myCommand.Connection = myConnection;  //linking command 
                myCommand.CommandText = "select distinct cartype from car ";
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    VehicleTypes.Items.Add(myReader["cartype"].ToString());
                }
                myReader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error");
                this.Close();
            }

            /////fill pickup/drop off location in Edmonton Car Rental
            myCommand2 = new NpgsqlCommand();
            myCommand2 = new NpgsqlCommand();
            myCommand2.Connection = myConnection;  //linking command 
            myCommand2.CommandText = "select * from branch ";
            myReader = myCommand2.ExecuteReader();
            while (myReader.Read())
            {
                PickupLocation.DisplayMember = "Text";
                DropoffLocation.DisplayMember = "Text";

                PickupLocation.ValueMember = "Value";
                DropoffLocation.ValueMember = "Value";

                PickupLocation.Items.Add(new {Text = $@"{myReader["BID"].ToString()}, {myReader["Description"].ToString()}, { myReader["city"].ToString()}", Value = myReader["BID"].ToString() });
                DropoffLocation.Items.Add(new { Text = $@"{myReader["BID"].ToString()}, {myReader["Description"].ToString()}, { myReader["city"].ToString()}", Value = myReader["BID"].ToString() });
            }
            myReader.Close();

        }

        private void editRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchEdit page = new SearchEdit();
            page.Show();
            this.Hide();
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

        private void button2_Click(object sender, EventArgs e)
        {
            PickupLocation.SelectedIndex = -1;
            DropoffLocation.SelectedIndex = -1;
            VehicleTypes.SelectedIndex = -1;
            searchResult.Items.Clear();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void VehicleTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        { /* $@"Select * from Car, Rental, Cartype, Branch
            where Car.VIN = Rental.VIN and CarType.CartypeID = Car.Cartype
            and 
            '{customerPickupDate.Value.ToShortDateString()}' >= Rental.ReturnDate and 
            
            ;"
          */
            int pickupBranchID = Int32.Parse((PickupLocation.SelectedItem as dynamic).Value); 
            int dropoffBranchID = Int32.Parse((DropoffLocation.SelectedItem as dynamic).Value);
            MessageBox.Show(pickupBranchID.ToString(), dropoffBranchID.ToString());
            myCommand.CommandText = "select * from Car, Rental, Cartype, Branch where "; //the first line of SQL query 

            if (VehicleTypes.Text == "All Vehicle Types")  //if the customer wants all types of vehicles
                //myCommand.CommandText += "Car.VIN = Rental.VIN and '" + customerPickupDate.Value.ToShortDateString() +"' >= Rental.ReturnDate";
                myCommand.CommandText = $@"
                                       select * from Car, Cartype where Car.cartype = cartype.cartypeID and Car.VIN in 
                                         (Select car.VIN
                                            from Car, Rental, Cartype, Branch
                                            where Car.VIN = Rental.VIN 
                                            and Rental.ReturnBID = car.Branch_ID
                                            and Car.Cartype = CarType.CartypeID
                                            and car.Branch_ID = {pickupBranchID}
                                            and '{customerPickupDate.Value.ToShortDateString()}' >= Rental.ReturnDate 
                                            group by car.VIN)  ;"; 

            else if (VehicleTypes.Text != "All Vehicle Types") // else, they have specific car brand in mind 
                myCommand.CommandText = $@"
                                       select * from Car, Cartype where Car.cartype = cartype.cartypeID and Car.VIN in 
                                         (Select car.VIN
                                            from Car, Rental, Cartype, Branch
                                            where Car.VIN = Rental.VIN 
                                            and Rental.ReturnBID = car.Branch_ID
                                            and Car.Cartype = CarType.CartypeID
                                            and car.Branch_ID = {pickupBranchID}
                                            and '{customerPickupDate.Value.ToShortDateString()}' >= Rental.ReturnDate 
                                            and Car.Cartype = '{VehicleTypes.Text}'
                                            group by car.VIN) ;";
          
            try
            {
                MessageBox.Show(myCommand.CommandText);
                myReader = myCommand.ExecuteReader();
                TimeSpan Range = customerDropoffDate.Value - customerPickupDate.Value ;
                int DayRent = Range.Days + 1;
                MessageBox.Show("You rent for " + DayRent.ToString() + " days.");

                while (myReader.Read())
                {
                    dailyrate = Convert.ToInt32(myReader["dailyRate"]);
                    weeklyrate = Convert.ToInt32(myReader["weeklyRate"]);
                    monthlyrate = Convert.ToInt32(myReader["monthlyRate"]);

                    if (DayRent <= 7)
                    {
                        dailyrate = Convert.ToInt32(myReader["dailyRate"]);
                        totalPrice = dailyrate * DayRent;
                    }
                    else if (DayRent <= 30)
                        totalPrice = (DayRent / 7) * weeklyrate + (DayRent % 7) * dailyrate;
                    else
                        totalPrice = (DayRent / 30) * monthlyrate + (((DayRent % 30) / 7) * weeklyrate) + (((DayRent % 30) % 7) * dailyrate);
                    
                    searchResult.Items.Add($@"{myReader["cartype"].ToString()}, {myReader["make"].ToString()}, {myReader["model"].ToString()}, {myReader["year"].ToString()}, {myReader["colour"].ToString()}, {myReader["noofseats"].ToString()} seats, price ${totalPrice.ToString()}({DayRent} days) ");
                }
                myReader.Close(); 
            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.ToString(), "Error");
            }
        }

        private void PickupLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropoffLocation.SelectedIndex = PickupLocation.SelectedIndex;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void searchResult_SelectedIndexChanged(object sender, EventArgs e)
        {
          

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(searchResult.CheckedItems.Count.ToString()+" checks");
            //customer can only check 1 car out 
            if (searchResult.CheckedItems.Count > 1)
                MessageBox.Show("can only rent 1 car at a time pls");
            else if (searchResult.CheckedItems.Count == 1)
            {
                Add page = new Add();
                page.Show();
                this.Hide();
            }
        }

        private void pickupDate_ValueChanged(object sender, EventArgs e)
        {
            if (customerDropoffDate.Value <= customerPickupDate.Value)
            {
                customerDropoffDate.Value = customerPickupDate.Value.AddDays(1); //default the pickup date to 1 day from today
                MessageBox.Show("Drop off Date must be At least 1 day from pick up");
            }
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NewRental_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
