using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Globalization;
using static Guna.UI2.Native.WinApi;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;
using Google.Protobuf.WellKnownTypes;

namespace Project_SAD_CUTEES
{
    public partial class View_Cart : Form
    {
        public string foto;
        public string photoname;
        public double price;
        public double harga;
        public double diskon;
        public double totaldiskon;
        public double subtotal;
        DataTable dtstock;
        DataTable dt;
        public View_Cart()
        {
            InitializeComponent();
        }

        private void View_Cart_Load(object sender, EventArgs e)
        {


            btn_addorder.Text = "Checkout";
            DataTable dtcust = new DataTable();
            Form1.sqlquery = $"select c.nama_customer,c.nomer_telepon,c.alamat from customer c, cart ca where c.customer_id = ca.customer_id and ca.nama_cartt = 'cart_{Add_Order.name}';";
            Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(dtcust);
            txt_name.Text = dtcust.Rows[0][0].ToString();
            txt_address.Text = dtcust.Rows[0][2].ToString();
            txt_phone.Text = dtcust.Rows[0][1].ToString();
            dt = new DataTable();
            txt_address.ReadOnly = true;
            txt_address.BackColor = Color.Gray;
            txt_address.ForeColor = Color.Black;
            txt_name.ReadOnly = true;
            txt_name.BackColor = Color.Gray;
            txt_name.ForeColor = Color.Black;
            txt_phone.ReadOnly = true;
            txt_phone.BackColor = Color.Gray;
            txt_phone.ForeColor = Color.Black;
            label1.Location = new Point((this.Width - label1.Width) / 2 - 18, 30);

            Form1.sqlquery = $"call pdatagrid('{Add_Order.name}');";
            Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(dt);
            dgv.DataSource = dt;/*
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                MessageBox.Show(dt.Rows[i][0].ToString());
            }*/
            DataTable dtharga = new DataTable();
            Form1.sqlquery = $"select sum(p.stock*(j.harga_jenis+u.harga_sablon)) from produk p, jenis j, ukuran_sablon u, detail_cart dc, cart c\r\nwhere p.jenis_id = j.jenis_id and p.sablon_id = u.sablon_id and dc.produk_id = p.produk_id and c.cart_id = dc.cart_id and c.cart_id = (select cart_id from cart where nama_cartt = concat('cart_','{Add_Order.name}') and dc.status_del = 'F');";
            Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(dtharga);

            txt_subtotal.Text = Convert.ToDecimal(dtharga.Rows[0][0]).ToString("C0", new CultureInfo("id-ID"));

            subtotal = Convert.ToDouble(dtharga.Rows[0][0].ToString());

            dtstock = new DataTable();
            Form1.sqlquery = $"select sum(p.stock) from produk p, detail_cart dc, cart c where dc.produk_id = p.produk_id and c.cart_id = dc.cart_id and c.cart_id = (select cart_id from cart where nama_cartt = concat('cart_','{Add_Order.name}') and dc.status_del = 'F') ;";
            Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(dtstock);

            DataTable dtdiskon = new DataTable();
            Form1.sqlquery = $"select fDiskon({dtstock.Rows[0][0].ToString()});";
            Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(dtdiskon);

             harga = Convert.ToDouble(dtharga.Rows[0][0].ToString());
             diskon = Convert.ToDouble(dtdiskon.Rows[0][0].ToString());
            
            totaldiskon = harga * diskon / 100;
            txt_discount.Text = Convert.ToDecimal(totaldiskon).ToString("C0", new CultureInfo("id-ID"));

            txt_price.KeyPress += Txt_price_KeyPress1;
            txt_price.GotFocus += Txt_price_GotFocus;

            txt_price.Text = "Price";
            txt_price.ForeColor = Color.LightGray;/*


            txt_discount.Text = price.ToString("C", CultureInfo.CreateSpecificCulture("id-ID"));*/

        }

        private void Txt_price_KeyPress1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                price = Convert.ToDouble(txt_price.Text);

                txt_price.Text = price.ToString("C", CultureInfo.CreateSpecificCulture("id-ID"));
                double total = harga - totaldiskon + price;
                txt_total.Text = total.ToString("C", CultureInfo.CreateSpecificCulture("id-ID"));
            }

        }

        private void Txt_price_GotFocus(object sender, EventArgs e)
        {
            if(txt_price.Text == "Price")
            {
                txt_price.Text = "";
                txt_price.ForeColor = Color.Black;
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Add_Order add_Order = new Add_Order();
            add_Order.Show();
            this.Close();
        }

        private void pict_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pict_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(dialog.FileName);
                // Mengambil gambar dari file yang dipilih
                string imagePath = dialog.FileName;
                string fileName = Path.GetFileNameWithoutExtension(dialog.FileName);
                string newFileName = fileName;
                string fileExtension = Path.GetExtension(dialog.FileName);
                photoname = "\\\\nota penjualan\\\\" + newFileName + fileExtension;
                string folderPath = Form1.projectDirectory + "\\nota penjualan\\";
                foto = folderPath + newFileName + fileExtension;
                img.Save(Path.Combine(folderPath, newFileName + fileExtension));
            }
        }

        private void cmb_shipment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void btn_addorder_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = date_deadline.Value;
            if (string.IsNullOrEmpty(cmb_shipment.Text) || string.IsNullOrEmpty(txt_discount.Text) || string.IsNullOrEmpty(photoname))
            {
                MessageBox.Show("Please input the product data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form1.sqlquery = $"insert into `order`(customer_id, jumlah_pesanan, sub_total, pilihan_pengiriman, harga_pengiriman, bukti_bayar, tanggal_order, deadline) values((select customer_id from customer where nama_customer = '{txt_name.Text}'), '{dtstock.Rows[0][0].ToString()}',{subtotal},'{cmb_shipment.Text}',{price},'{photoname}',curdate(),'{selectedDate.ToString("yyyy-MM-dd")}');";
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
                    
                }
                DataTable dtcart = new DataTable();
                Form1.sqlquery = $"select dc.Produk_id from cart c, detail_cart dc where dc.cart_id = c.cart_id and c.nama_cartt = 'cart_{Add_Order.name}'and dc.status_del = 'F';";
                Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
                Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
                Form1.mySqlDataAdapter.Fill(dtcart);
                for (int i = 0; i < dtcart.Rows.Count; i++)
                {

                    Form1.sqlquery = $"insert into detail_order(order_id, Produk_id) values((select max(order_id) from `order` order by created_at desc limit 1), '{dtcart.Rows[i][0].ToString()}');";
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
                        Form1.sqlquery = $"update detail_cart set status_del = 'T' where cart_id = (select Cart_id from cart where Nama_cartt = 'cart_{Add_Order.name}');";
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
                            
                        }
                    }
                   
                    
                }
                MessageBox.Show("The Order has been added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form_Home form_Home = new Form_Home();
                form_Home.Show();
                this.Close();
                Form1.sqlquery = $"delete from detail_cart where cart_id = (select cart.cart_id from cart, customer where cart.customer_id = customer.customer_id and customer.nama_customer = '{Add_Order.name}' ); delete from cart where CUSTOMER_ID = (select customer_id from customer where nama_customer = '{Add_Order.name}');";
                Form1.sqlconnect.Open();
                Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
                Form1.sqlcommand.ExecuteNonQuery();
                Form1.sqlconnect.Close();
                txt_price.Text = "";


            }
        }

        private void txt_subtotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_discount_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
