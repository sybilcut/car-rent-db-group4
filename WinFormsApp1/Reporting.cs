using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace WinFormsApp1
{
    public partial class Reporting : Form
    {
        NpgsqlDataAdapter dAdapter;
        DataSet ds;
        NpgsqlConnection connection;

        public Reporting()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            string query = "";
            

            if (IncomeButton.Checked == true)
            {
                label7.Text = IncomeButton.Text;
                /* find branch that has earned the most money from rentals */
                query = $@"Select BID, earnings from
                                (Select BID, Sum(R.Total_rentValue) as earnings from Branch B, Rental R where B.BID = R.PickupBID group by B.BID, R.PickupBID) 
                            as D where earnings = (select max(earnings) from
                                (Select BID, Sum(R.Total_rentValue) as earnings from Branch B, Rental R where B.BID = R.PickupBID group by B.BID, R.PickupBID) as a)";
            }

            if (HighRentedButton.Checked)
            {
                label7.Text = HighRentedButton.Text;
                /* find the cartype that was rented the most location indescrimant */
                query = $@"select D.CarTypeID, Times_Rented from
                        (Select C.CarType as CarTypeID, count(TID) as Times_Rented from Rental R, Car C where C.VIN = R.VIN group by C.CarType) 
                    as D where Times_Rented = 
                        (select max(TimesCarTypeRented) from
                            (Select C1.CarType, count(TID) as TimesCarTypeRented from Rental R1, Car C1 where C1.VIN = R1.VIN group by C1.CarType) as D)";
            }

            /* find the vehicle with the highest odometernumber rating */
            if (HighKMButton.Checked)
            {
                label7.Text = HighKMButton.Text;
                query = $@"select Vin, odometernumber from car where odometernumber = 
                        (select max(odometernumber) from car)";
            }

            /* find all times vehicle with higest odometer number was rented atm */
            if (CityRentedButton.Checked)
            {
                label7.Text = CityRentedButton.Text;
                query = $@"select R.TID, Odometernumber from Rental R, Car C where R.VIN = C.VIN and odometernumber = 
                        (select max(odometernumber) from car c, rental r where c.vin = r.vin and R.ReturnDate >= '2020-02-20' and Pickupdate <= '2020-02-20') 
                    and R.ReturnDate >= '2020-02-20' and Pickupdate <= '2020-02-20'";
            }

            /*Find how much each branch earns per rental on average*/
            if (AvgEarningButton.Checked)
            {
                label7.Text = AvgEarningButton.Text;
                query = $@"Select BID as Branch, Avg(R.Total_rentValue::numeric::float8)as Average_Earnings, count(r.Tid) as Num_of_rentals from Rental R, Branch B where B.BID = R.PickupBID group by B.BID";
            }

            /*most loyal non member customer ie. non member customer with the most transactions*/
            if (nonMemberButton.Checked)
            {
                label7.Text = nonMemberButton.Text;
                query = $@"select CID, fullName,rentals from
                        (select C.CustomerID as CID, c.LastName::text || ', '::text || c.FirstName::text as fullName, count(TID) as rentals from Customers C, Rental R where r.CustomerID = c.CustomerID and c.Membership_Status = false group by C.CustomerID, c.FirstName, c.LastName) 
                             as D where rentals = (select max(rentals) from(select C.CustomerID, count(TID) as rentals from Customers C, Rental R where r.CustomerID = c.CustomerID and c.Membership_Status = false group by C.CustomerID) as D2)";
            }

            try {
                NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
                dAdapter = new NpgsqlDataAdapter(cmd);
                ds = new DataSet();
                dAdapter.Fill(ds);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = ds.Tables[0];
                label7.Visible = true;
            }
            catch (Exception eep)
            {
                ErrorForm page = new ErrorForm(eep);
                page.Show();
            }
        }

        private void Reporting_Load(object sender, EventArgs e)
        {
            string connectionString = $"Host=35.183.48.135;Port=5432;Database=master;UserID={Program.user};Password={Program.pass};";

            try
            {
                connection = new NpgsqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open();
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
    }
}
