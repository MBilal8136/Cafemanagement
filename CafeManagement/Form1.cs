using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGuest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dashboard ds= new Dashboard("Guest");
            ds.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUersname.Text =="admin" && txtPassword.Text =="admin")
            {
                Dashboard ds = new Dashboard("admin");
                ds.Show();
                this.Hide();
            }
            else
            {
                Form1 fm = new Form1();
                this.Hide();
                fm.Show();
                MessageBox.Show("Your Username and Password Wrong ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
