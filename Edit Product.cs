using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static Guna.UI2.Native.WinApi;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;

namespace Project_SAD_CUTEES
{
    public partial class Edit_Product : Form
    {
        public double clothcost = 0;
        public double printcost = 0;
        public double total = 0;
        public Edit_Product()
        {
            InitializeComponent();
        }


        private void Edit_Product_Load(object sender, EventArgs e)
        {
            label1.Location = new Point((this.Width - label1.Width) / 2 + 20, 30);
            Form1.sqlquery = $"select c.nama_customer, c.nomer_telepon, c.alamat from customer c, `order` o where c.CUSTOMER_ID = o.customer_id and o.ORDER_ID = '{Product_Expense.idvalue}';";
            DataTable login = new DataTable();
            Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(login);
            txt_name.Text = login.Rows[0][0].ToString();
            txt_phone.Text = login.Rows[0][1].ToString();
            txt_address.Text = login.Rows[0][2].ToString();
            label11.Text = "Order ID : " + Product_Expense.idvalue;
            label11.Location = new Point((guna2Panel2.Width - label11.Width) / 2, 15);
            DataTable dtproduk = new DataTable();
            Form1.sqlquery = $"select p.nama_produk as \"Product\", p.ukuran as Size, if(p.issablon = 1, \"Sablon\" ,\"Polos\") as \"Type\", u.nama_sablon as \"Print Size\", p.stock as Quantity, concat('Rp. ',cast(o.harga_bersih AS DECIMAL(10,0))) as \"Price with Discount\"\r\nfrom produk p, `order` o , ukuran_sablon u, detail_order d\r\nwhere d.order_id = o.ORDER_ID and p.PRODUK_ID = d.produk_id and p.sablon_id = u.sablon_id and p.produk_id = (select p.produk_id from produk p, `order` o, detail_order d where d.order_id = o.order_id and p.produk_id = d.produk_id and p.NAMA_PRODUK = '{Product_Expense.produkname}' and o.ORDER_ID = '{Product_Expense.idvalue}' and p.ukuran = '{Product_Expense.ukuran}' and p.stock = {Product_Expense.qty});";
            Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(dtproduk);
            dgv.DataSource = dtproduk;


        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                clothcost = Convert.ToDouble(guna2TextBox1.Text);
                guna2TextBox1.Text = "Rp. " + clothcost;
                total = clothcost + printcost;
                guna2TextBox3.Text = "Rp. " + total;
            }
        }

        private void guna2TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                printcost = Convert.ToDouble(guna2TextBox2.Text);
                guna2TextBox2.Text = "Rp. " + printcost;
                total = clothcost + printcost;
                guna2TextBox3.Text = "Rp. " + total;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form1.sqlquery = Form1.sqlquery = $"UPDATE produk p, `order` o, detail_order d " +
                                              $"SET p.modal_produk = {clothcost}, p.modal_sablon = {printcost}, p.total_modal = {total} " +
                                              $"WHERE d.order_id = o.order_id " +
                                              $"AND p.produk_id = d.produk_id " +
                                              $"AND p.NAMA_PRODUK = '{Product_Expense.produkname}' " +
                                              $"AND o.ORDER_ID = '{Product_Expense.idvalue}' " +
                                              $"AND p.ukuran = '{Product_Expense.ukuran}' " +
                                              $"AND p.stock = {Product_Expense.qty}";
            try
            {
                Form1.sqlconnect.Open();
                Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
                Form1.mySqlDataReader = Form1.sqlcommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Form1.sqlconnect.Close();
                MessageBox.Show("Product expense has been added","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Product_Expense product_Expense = new Product_Expense();
                product_Expense.Show();
                this.Close();

            }
        }

        private void pict_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pict_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
