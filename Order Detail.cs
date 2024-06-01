using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Project_SAD_CUTEES
{
    public partial class Order_Detail : Form
    {
        public Order_Detail()
        {
            InitializeComponent();
        }
        public int x = 497;
        public int y = 1109;
        private void Order_Detail_Load(object sender, EventArgs e)
        {
            btn_1.Visible = false;
            btn_2.Visible = false;

            MessageBox.Show(Form_Home.orderId);
            lbl_orderid.Text = "Order ID : " + Form_Home.orderId;
            lbl_orderid.Location = new Point((guna2Panel2.Width - lbl_orderid.Width) / 2 - (guna2Panel2.Height - lbl_orderid.Height) / 2);
            guna2Panel2.Controls.Add(lbl_orderid);

            DataTable dtorderdetail = new DataTable();
            Form1.sqlquery = $"call pInvoice('{Form_Home.orderId}');";
            Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(dtorderdetail);

            DataTable dtdata = new DataTable();
            Form1.sqlquery = $"call pDetailOrder('{Form_Home.orderId}')";
            Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(dtdata);
            dgv.DataSource = dtdata;
            double diskon = Convert.ToDouble(dtorderdetail.Rows[0][7].ToString());
            double subtotal = Convert.ToDouble(dtorderdetail.Rows[0][6].ToString());
            double hasil = subtotal * diskon / 100;
            txt_name.Text = dtorderdetail.Rows[0][1].ToString();
            txt_phone.Text = dtorderdetail.Rows[0][2].ToString();
            txt_address.Text = dtorderdetail.Rows[0][3].ToString();
            txt_subtotal.Text = Convert.ToDecimal(dtorderdetail.Rows[0][6]).ToString("C0", new CultureInfo("id-ID"));
            txt_discount.Text = hasil.ToString("C0", new CultureInfo("id-ID"));

            txt_price.Text = Convert.ToDecimal(dtorderdetail.Rows[0][10]).ToString("C0", new CultureInfo("id-ID"));
            txt_total.Text = Convert.ToDecimal(dtorderdetail.Rows[0][11]).ToString("C0", new CultureInfo("id-ID"));
            txt_shipment.Text = dtorderdetail.Rows[0][9].ToString();
            txt_status.Text = dtorderdetail.Rows[0][5].ToString();
            date_deadline.Text = dtorderdetail.Rows[0][4].ToString();

            //lokasi button atau combobox next process
            if (txt_status.Text == "Need to Process")
            {
                btn_nextprocess.Text = "In Process";
            }
            else if (txt_status.Text == "In Process")
            {
                btn_nextprocess.Text = "Shipping";
            }
            else if (txt_status.Text == "Shipping")
            {
                btn_1.Visible = true;
                btn_2.Visible = true;
                btn_1.Text = "Retur New Product";
                btn_nextprocess.Text = "Done";
                btn_2.Text = "Refund";
            }

        }


        private void pict_minimize_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Form_Home form = new Form_Home();
            form.Show();
            this.Close();

        }

        private void pict_close_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_nextprocess_Click(object sender, EventArgs e)
        {
            if (txt_status.Text == "Need to Process")
            {
                DialogResult result = MessageBox.Show("Are you sure you want to change the process into In Process ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    txt_status.Text = "In Process";
                    Form1.sqlquery = $"update `order` set status_order = '{txt_status.Text}' where order_id = '{Form_Home.orderId}';";
                    Form1.sqlconnect.Open();
                    Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
                    Form1.mySqlDataReader = Form1.sqlcommand.ExecuteReader(); 
                    Form1.sqlconnect.Close();
                    Form_Home form = new Form_Home();
                    form.Show();
                    this.Close();
                }
            }
            else if (txt_status.Text == "In Process")
            {
                DataTable dtcek = new DataTable();
                Form1.sqlquery = $"select p.modal_produk\r\nfrom produk p, detail_order d\r\nwhere p.PRODUK_ID = d.produk_id and d.order_id = '{Form_Home.orderId}';";
                Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
                Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
                Form1.mySqlDataAdapter.Fill(dtcek);
                if (string.IsNullOrEmpty(dtcek.Rows[0][0].ToString()))
                {
                    DialogResult result2 = MessageBox.Show("Please input the product expense first", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    if(result2 == DialogResult.OK)
                    {
                        Product_Expense form = new Product_Expense();
                        form.Show();
                        this.Close();
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to change the process into Shipping ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        txt_status.Text = "Shipping";
                        Form1.sqlquery = $"update `order` set status_order = '{txt_status.Text}' where order_id = '{Form_Home.orderId}';";
                        Form1.sqlconnect.Open();
                        Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
                        Form1.mySqlDataReader = Form1.sqlcommand.ExecuteReader();
                        Form1.sqlconnect.Close();
                        Form_Home form = new Form_Home();
                        form.Show();
                        this.Close();
                    }
                }
                
            }
            else if (txt_status.Text == "Shipping")
            {
                DialogResult result = MessageBox.Show("Are you sure you want to change the process into Done ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    txt_status.Text = "Done";
                    Form1.sqlquery = $"update `order` set status_order = '{txt_status.Text}' where order_id = '{Form_Home.orderId}';";
                    Form1.sqlconnect.Open();
                    Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
                    Form1.mySqlDataReader = Form1.sqlcommand.ExecuteReader();
                    Form1.sqlconnect.Close();
                    Form_Home form = new Form_Home();
                    form.Show();
                    this.Close();
                }
            }
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to change the process into Done ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DataTable dtproduk = new DataTable();
                Form1.sqlquery = $"select produk_id from detail_order where order_id = '{Form_Home.orderId}';";
                Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
                Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
                Form1.mySqlDataAdapter.Fill(dtproduk);

                for(int i = 0; i <dtproduk.Rows.Count; i++)
                {
                    Form1.sqlquery = $"update produk set total_modal = (total_modal * 2) where produk_id = '{dtproduk.Rows[i][0]}';";
                    Form1.sqlconnect.Open();
                    Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
                    Form1.mySqlDataReader = Form1.sqlcommand.ExecuteReader();
                    Form1.sqlconnect.Close();
                }
            }

            
            Form_Home form = new Form_Home();
            form.Show();
            this.Close();
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to change the process into Done ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Form1.sqlquery = $"update `order` set total_harga = 0 where order_id = '{Form_Home.orderId}';";
                Form1.sqlconnect.Open();
                Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
                Form1.mySqlDataReader = Form1.sqlcommand.ExecuteReader();
                Form1.sqlconnect.Close();
            }


            Form_Home form = new Form_Home();
            form.Show();
            this.Close();
        }
    }
}



