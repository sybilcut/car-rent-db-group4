using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WinFormsApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Program.user = UsernameText.Text;
            Program.pass = PasswordText.Text;
<<<<<<< HEAD
            Add form = new Add(); //link to pages
=======
             NewRental form = new NewRental(); //link to pages NewRental() 
>>>>>>> 8c6f3696b5eb3432fa70d7a6c57698097341c725
            form.Show();
            this.Hide();
        }
    }
}
