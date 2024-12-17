using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagement.AllUserControl
{
    public partial class UC_AddItems : UserControl
    {
        function fn = new function();
        string query;
        
        public UC_AddItems()
        {
            InitializeComponent();
        }
        
        private void UC_AddItems_Load_1(object sender, EventArgs e)
        {
            query = "select * from items";
            DataSet ds = fn.getData(query);
            guna2DataGridView2.DataSource = ds.Tables[0];
            loadData();
        }
        public void loadData()
        {
            query = "select * from items";
            DataSet ds = fn.getData(query);
            guna2DataGridView2.DataSource = ds.Tables[0];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            

            if (price.Text != "0" && price.Text != "" && txtName.Text !="" && Category.Text !="")
            {
                query = " insert into items(name, category, price) values ('" + txtName.Text + "', '" + Category.Text + "'," + price.Text + ")";
                fn.SetData(query);
                MessageBox.Show("Data Processed Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
                
            }
            else
            {
                MessageBox.Show("Please select category , Price & name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Category.SelectedIndex = -1;
            txtName.Clear();
            price.Clear();
        }

        int id;
        private void guna2DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(guna2DataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete Item ?", "Important Message ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                query = "delete from items where iid = " + id + "";
                fn.SetData(query);
                loadData();

            }
        }

        private void UC_AddItems_Enter(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void price_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsDigit(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
