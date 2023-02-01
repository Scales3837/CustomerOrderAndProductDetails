using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class CustomerDetails : Form
    {
        Data data = new Data();
        DataTable gv = new DataTable();
        DataTable ogv = new DataTable();
        DataTable pgv = new DataTable();

        public CustomerDetails()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void InputCustomerID_TextChanged(object sender, EventArgs e)
        {
            if (InputCustomerID.Text == "")
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            gv = data.GetData(InputCustomerID.Text);
            dataGridView1.DataSource = gv;
            if (gv.Columns.Count > 0)
            {
                dataGridView1.Visible = true;
            }
            else
            {
                dataGridView1.Visible = false;
            }
        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string OrderID = "";

            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                OrderID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                ogv = data.GetOrder(OrderID);
                dataGridView2.DataSource = ogv;
                if (ogv.Columns.Count > 0)
                {
                    od.Visible = true;
                    dataGridView2.Visible = true;
                }
                else
                {
                    od.Visible = false;
                    dataGridView2.Visible = false;
                }
            }
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            od.Visible = false;
            dataGridView2.Visible = false;
            InputCustomerID.Text = string.Empty;
            dataGridView1.Visible = false;
            pd.Visible = false;
            dataGridView3.Visible = false;
            MessageBox.Show("All the data has been cleared!");
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ProductID = "";

            if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                ProductID = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                pgv = data.GetProduct(ProductID);
                dataGridView3.DataSource = pgv;
                if (pgv.Columns.Count > 0)
                {
                    pd.Visible = true;
                    dataGridView3.Visible = true;
                }
                else
                {
                    pd.Visible = false;
                    dataGridView3.Visible = false;
                }
            }
        }
    }
}
