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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        public Dashboard(string user)
        {
            InitializeComponent();

          if(user == "Guest")
            {
                btnAddItem.Hide();
                btnUpdate.Hide();
                btnRemove.Hide();
            }
            else if (user == "admin")
            {
                btnPlaceOrder.Show();
                btnUpdate.Show();
                btnAddItem.Show();
                btnRemove.Show();
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            uC_AddItems1.Visible = false;
            uC_PlaceOrder1.Visible = false;
            uC_UpdateItems1.Visible = false;
            uC_Remove1.Visible = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
                Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            this.Hide();
            fm.Show();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            uC_AddItems1.Visible = true;
            uC_AddItems1.BringToFront();
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            uC_Welcom1.SendToBack();
            
            uC_PlaceOrder1.Visible= true;
            uC_PlaceOrder1.BringToFront();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            uC_UpdateItems1.Visible = true;
            uC_UpdateItems1.BringToFront();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            uC_Remove1.Visible = true;
            uC_Remove1.BringToFront();
        }
    }
}
