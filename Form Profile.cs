using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Project_SAD_CUTEES
{
    public partial class Form_Profile : Form
    {

        private Form1 form1;
        public Form_Profile()
        {
            InitializeComponent();

            form1 = new Form1();
            pict_logo.Location = new Point((panel1.Width - pict_logo.Width) / 2, (panel1.Height - pict_logo.Height) / 2);

            lbl_orders.Location = new Point(((panel1.Width - lbl_orders.Width) / 2) - 600, panel1.Top + 5);
            lbl_expense.Location = new Point(((panel1.Width - lbl_expense.Width) / 2) - 250, panel1.Top + 5);
            lbl_transaction.Location = new Point(((panel1.Width - lbl_transaction.Width) / 2) + 150, panel1.Top + 5);
            lbl_inventory.Location = new Point(((panel1.Width - lbl_inventory.Width) / 2) + 550, panel1.Top + 5);
        }

        private void Form_Profile_Load(object sender, EventArgs e)
        {
            DataTable Login = new DataTable();
            Form1.sqlquery = $"SELECT first_name FROM accounts WHERE(email = '{Form1.email}' and passwords = '{Form1.pass}')";
            Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(Login);
            lbl_signup.Text = Login.Rows[0][0].ToString();
            label1.Text = Login.Rows[0][0].ToString();
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Location = new Point(325 - label1.Width / 2, label1.Location.Y);
        }

        private void pict_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pict_minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            form1 = new Form1();
            form1.ShowDialog();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Click(object sender, EventArgs e)
        {
            this.Hide();
            form1 = new Form1();
            form1.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            form1 = new Form1();
            form1.ShowDialog();
        }

        private void lbl_changepw_MouseHover(object sender, EventArgs e)
        {
            lbl_changepw.ForeColor = Color.Gold;
        }

        private void lbl_changepw_MouseLeave(object sender, EventArgs e)
        {
            lbl_changepw.ForeColor = Color.White;
        }

        private void lbl_orders_Click(object sender, EventArgs e)
        {
            Form_Home home = new Form_Home();
            home.Show();
            this.Close();
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void guna2Panel2_Click_1(object sender, EventArgs e)
        {
            form1 = new Form1();
            form1.Show();
            this.Close();
        }
    }
}
