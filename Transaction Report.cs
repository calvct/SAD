using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;

namespace Project_SAD_CUTEES
{
    public partial class Transaction_Report : Form
    {
        public static string productname;
        public Transaction_Report()
        {
            InitializeComponent();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        public double totalharga;
        public int totaljual;
        private void Transaction_Report_Load(object sender, EventArgs e)
        {
            pict_logo.Location = new Point((panel1.Width - pict_logo.Width) / 2, (panel1.Height - pict_logo.Height) / 2);

            lbl_orders.Location = new Point(((panel1.Width - lbl_orders.Width) / 2) - 350, panel1.Top + 5);
            lbl_expense.Location = new Point(((panel1.Width - lbl_expense.Width) / 2), panel1.Top + 5);
            lbl_transaction.Location = new Point(((panel1.Width - lbl_transaction.Width) / 2) + 400, panel1.Top + 5);

            btn_current.Location = new Point(((panel1.Width - btn_current.Width) / 2) + 400, panel1.Top + 43);

            DataTable dttransaction = new DataTable();
            Form1.sqlquery = $"select * from vtransaksi";
            Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(dttransaction);
            dgv.DataSource = dttransaction;

            for (int i = 0; i<dttransaction.Rows.Count; i++)
            {
                totalharga += Convert.ToDouble(dttransaction.Rows[i][4]);
                totaljual += Convert.ToInt16(dttransaction.Rows[i][1]);
            }
            guna2TextBox2.Font = new Font("Microsoft Sans Serif", 24);
            guna2TextBox1.Font = new Font("Microsoft Sans Serif", 24);
            guna2TextBox2.Text = totalharga.ToString();
            guna2TextBox1.Text = totaljual.ToString();



            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Detail";
            buttonColumn.Text = "Detail";
            buttonColumn.Name = "editButton";
            buttonColumn.UseColumnTextForButtonValue = true;
            dgv.Columns.Add(buttonColumn);

        }

        private void pict_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pict_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonColumn_Click(object sender, DataGridViewCellEventArgs e)
        {

        

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == dgv.Columns["editbutton"].Index)
            {
                int rowIndex = e.RowIndex;

                // Dapatkan nilai sel yang ingin diedit (misalnya, kolom ID)
                productname = dgv.Rows[rowIndex].Cells["Product Name"].Value.ToString();
                Transaction_Detail transaction_Detail = new Transaction_Detail();
                transaction_Detail.Show();
                this.Close();
            }
        }

        private void lbl_expense_Click(object sender, EventArgs e)
        {
            Product_Expense form = new Product_Expense();
            form.Show();
            this.Close();
        }

        private void lbl_orders_Click(object sender, EventArgs e)
        {
            Form_Home form = new Form_Home();
            form.Show();
            this.Close();
        }
    }

}
