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
    public partial class Form_Sign_Up : Form
    {
        private Form1 form1;
        public Form_Sign_Up()
        {
            InitializeComponent();

            form1 = new Form1();

            this.Select();

            txt_firstname.Text = "First Name";
            txt_lastname.Text = "Last Name";
            txt_email.Text = "Email";
            txt_number.Text = "Phone Number";
            txt_password.Text = "Password";

            txt_firstname.ForeColor = txt_lastname.ForeColor = txt_email.ForeColor = txt_number.ForeColor = txt_password.ForeColor = Color.DarkGray;

            txt_firstname.GotFocus += RemoveText;
            txt_lastname.GotFocus += RemoveText2;
            txt_email.GotFocus += RemoveText3;
            txt_number.GotFocus += RemoveText4;
            txt_password.GotFocus += RemoveText5;

            txt_firstname.LostFocus += AddText;
            txt_lastname.LostFocus += AddText2;
            txt_email.LostFocus += AddText3;
            txt_number.LostFocus += AddText4;
            txt_password.LostFocus += AddText5;

            panel_login.Location = new Point((this.Width - panel_login.Width) / 2, (this.Height - panel_login.Height) / 2);
            pict_createaccount.Location = new Point((panel_login.Width - pict_createaccount.Width) / 2, (panel_login.Height - 400));

            PictureBox pict_close = form1.pict_close;
            pict_close.Location = form1.pict_close.Location;
            pict_close.Size = form1.pict_close.Size;
            this.Controls.Add(pict_close);

            pict_minimize.Location = form1.pict_minimize.Location;
            pict_minimize.Size = form1.pict_minimize.Size;


        }

        #region
        public void RemoveText(object sender, EventArgs e)
        {
            if (txt_firstname.Text == "First Name")
            {
                txt_firstname.Text = "";
                txt_firstname.ForeColor = Color.Black;
            }
        }
        public void RemoveText2(object sender, EventArgs e)
        {
            if (txt_lastname.Text == "Last Name")
            {
                txt_lastname.Text = "";
                txt_lastname.ForeColor = Color.Black;
            }
        }
        public void RemoveText3(object sender, EventArgs e)
        {
            if (txt_email.Text == "Email")
            {
                txt_email.Text = "";
                txt_email.ForeColor = Color.Black;
            }
        }
        public void RemoveText4(object sender, EventArgs e)
        {
            if (txt_number.Text == "Phone Number")
            {
                txt_number.Text = "";
                txt_number.ForeColor = Color.Black;
            }
        }
        public void RemoveText5(object sender, EventArgs e)
        {
            if (txt_password.Text == "Password")
            {
                txt_password.Text = "";
                txt_password.ForeColor = Color.Black;
            }
        }

        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_firstname.Text))
            {
                txt_firstname.Text = "First Name";
                txt_firstname.ForeColor = Color.DarkGray;
            }
        }

        public void AddText2(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_lastname.Text))
            {
                txt_lastname.Text = "First Name";
                txt_lastname.ForeColor = Color.DarkGray;
            }
        }
        public void AddText3(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_email.Text))
            {
                txt_email.Text = "Email";
                txt_email.ForeColor = Color.DarkGray;
            }
        }
        public void AddText4(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_number.Text))
            {
                txt_number.Text = "Phone Number";
                txt_number.ForeColor = Color.DarkGray;
            }
        }
        public void AddText5(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_password.Text))
            {
                txt_password.Text = "Password";
                txt_password.ForeColor = Color.DarkGray;
            }
        }
        #endregion

        private void lbl_login_MouseHover(object sender, EventArgs e)
        {
            lbl_login.ForeColor = Color.Blue;
        }

        private void lbl_login_MouseLeave(object sender, EventArgs e)
        {
            lbl_login.ForeColor = Color.Black;
        }

        private void lbl_login_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            string first_name = txt_firstname.Text;
            string last_name = txt_lastname.Text;
            string email = txt_email.Text;
            string pass = txt_password.Text;
            string num = txt_number.Text;
            if (first_name == null && email == null && pass == null && num == null && last_name == null)
            {
                MessageBox.Show("Please fill in the blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_firstname.Focus();
            }
            else
            {
                Form1.sqlquery = $"insert into accounts (first_name,last_name, email, passwords, phone_number) values('{first_name}','{last_name}','{email}','{pass}','{num}')";
                try
                {
                    Form1.sqlconnect.Open();
                    Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
                    Form1.mySqlDataReader = Form1.sqlcommand.ExecuteReader();

                    txt_firstname.Clear();
                    txt_lastname.Clear();
                    txt_email.Clear();
                    txt_password.Clear();
                    txt_number.Clear();
                    DialogResult result = MessageBox.Show("Sign Up is Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        Form1 form1 = new Form1();
                        form1.Show();
                        this.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Form1.sqlconnect.Close();
                }
            }
        }

        private void Form_Sign_Up_Load(object sender, EventArgs e)
        {
        }

        private void pict_minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;    
        }

        private void txt_number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
