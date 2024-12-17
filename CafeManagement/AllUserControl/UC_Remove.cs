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
    public partial class UC_Remove : UserControl
    {
        function fn = new function();
        string query;
        public UC_Remove()
        {
            InitializeComponent();
        }

        private void UC_Remove_Load(object sender, EventArgs e)
        {


            loadData();


        }
        public void loadData()
        {
            query = "select * from items";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            query = "select * from items where name like '" + txtSearch.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }
        int id;
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete Item ?", "Important Message ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK) 
            {
                query = "delete from items where iid = " + id + "";
                fn.SetData(query);
                loadData();

            }
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
              id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            //if (MessageBox.Show("Delete Item ?", "Important Message ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            //{
            //    query = "delete from items where iid = " + id + "";
            //    fn.SetData(query);
            //    loadData();

            //}

        }

        private void UC_Remove_Enter(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
