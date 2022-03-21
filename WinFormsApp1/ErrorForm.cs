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
    public partial class ErrorForm : Form
    {
        public static Exception ex;
        public ErrorForm(Exception e)
        {
            InitializeComponent();
            ex = e;
        }

        private void ErrorForm_Load(object sender, EventArgs e)
        {
            label1.Text = ex.Message;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
