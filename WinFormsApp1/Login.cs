﻿using System;
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
             NewRental form = new NewRental(); //link to pages NewRental() 
            form.Show();
            this.Hide();
        }
    }
}
