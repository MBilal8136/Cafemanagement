using DGVPrinterHelper;
using Guna.UI2.WinForms;
using System;
using System.Collections;
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
    public partial class UC_PlaceOrder : UserControl
    {
        function fn = new function();
        string query;
        public UC_PlaceOrder()
        {
            InitializeComponent();
        }

        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string category = comboCategory.Text;
            query = "select name from items where category ='" + category + "'";
            DataSet ds = fn.getData(query);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string category = comboCategory.Text;
            query = "select name from items where category ='" + category + "' and name like '" + txtSearch.Text + "%'";
            DataSet ds = fn.getData(query);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want to Reset ?", "Information ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            { 
            guna2DataGridView2.Rows.Clear();
            total = 0;
            txtItemName.Clear();
            txtPrice.Clear();
            labelTotalAmount.Text = "Rs. 00";
        }
            else { }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQuantityUpDown.ResetText();
            txtTotal.Clear();

            string text = listBox1.GetItemText(listBox1.SelectedItem);
            txtItemName.Text = text;
            query = "select price from items where name ='" + text + "'";
            DataSet ds = fn.getData(query);

            try
            {
                txtPrice.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch { } 
        }

        private void txtQuantityUpDown_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPrice.Text != "")
                {
                    Int64 quan = Int64.Parse(txtQuantityUpDown.Value.ToString());
                    Int64 price = Int64.Parse(txtPrice.Text);
                    txtTotal.Text = (quan * price).ToString();
                }
                else
                {
                    MessageBox.Show("Please select Item ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtQuantityUpDown.Value = 0;
                }
            }
            catch (Exception )
            {

            }
        }
        protected int n, total = 0;

        int amount;

        private void guna2DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

            amount = int.Parse(guna2DataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString());
            }
            catch (Exception)
            { }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {

                if (total != 0)
                {
                    MessageBox.Show(" Delete items ?", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    guna2DataGridView2.Rows.RemoveAt(this.guna2DataGridView2.SelectedRows[0].Index);

                    total -= amount;
                    labelTotalAmount.Text = "Rs. " + total;
                }
                else
                {
                    MessageBox.Show(" No item selected ?", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    total = 0;


                }
            }
            catch { }
            }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (total != 0)
            {
                DGVPrinter printer = new DGVPrinter();
                printer.Title = " Customer Bill";
                printer.SubTitle = string.Format("Date : {0}", DateTime.Now.Date);
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = "Totle Payable Amount :" + labelTotalAmount.Text;
                printer.FooterSpacing = 15;
                printer.PrintDataGridView(guna2DataGridView2);

                total = 0;
                guna2DataGridView2.Rows.Clear();
                labelTotalAmount.Text = "Rs. " + total;
            }
            else
            {
                MessageBox.Show("Please Enter Items for Print", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if(char.IsLetter(ch)==true)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void UC_PlaceOrder_Load(object sender, EventArgs e)
        {
           
        }

        private void btnAddtoCart_Click(object sender, EventArgs e)
        {
            if (txtTotal.Text != "0" && txtTotal.Text != "")
            {
                n = guna2DataGridView2.Rows.Add();
                guna2DataGridView2.Rows[n].Cells[0].Value = txtItemName.Text;
                guna2DataGridView2.Rows[n].Cells[1].Value = txtPrice.Text;
                guna2DataGridView2.Rows[n].Cells[2].Value = txtQuantityUpDown.Value;
                guna2DataGridView2.Rows[n].Cells[3].Value = txtTotal.Text;

                total += int.Parse(txtTotal.Text);
                labelTotalAmount.Text = "Rs. " + total;

                txtQuantityUpDown.Value=0;

            }
            else
            {
                MessageBox.Show("minimum quantity need to be 1", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
