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
using System.Web.Compilation;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using static System.Net.WebRequestMethods;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;

namespace Project_SAD_CUTEES
{
    public partial class Add_Order : Form
    {
        DataTable dtproduct = new DataTable();
        DataTable dtsablon = new DataTable();
        public static string foto;
        public static string query;
        public static bool custfounded;
        public static string photoname;
        public static string name;
        public static bool customerada;
        public Add_Order()
        {
            InitializeComponent();
            Form1.workingDirectory = Environment.CurrentDirectory;
            Form1.projectDirectory = Directory.GetParent(Form1.workingDirectory).Parent.FullName;

        }

        private void Add_Order_Load(object sender, EventArgs e)
        {
            txt_address.Text = "";
            txt_custname.Text = "";
            txt_phone.Text = "";    
            photoname = "";
            dtproduct.Clear();
            dtsablon.Clear();
            label1.Location = new Point((this.Width - label1.Width) / 2, 30);
            panel_orderno.Location = new Point(991, 293);
            panel_orderyes.Visible = false;


            Form1.sqlquery = "select nama_jenis from jenis";
            Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(dtproduct);

            Form1.sqlquery = "select nama_sablon from ukuran_sablon limit 4";
            
            Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(dtsablon);

            cmb_product.DisplayMember = "nama_jenis";
            cmb_product.ValueMember = "nama_jenis";
            cmb_product.DataSource = dtproduct;

            cmb_productyes.DisplayMember = "nama_jenis";
            cmb_productyes.ValueMember = "nama_jenis";
            cmb_productyes.DataSource = dtproduct;

            cmb_sablon.DisplayMember = "nama_sablon";
            cmb_sablon.ValueMember = "nama_sablon";
            cmb_sablon.DataSource = dtsablon;
            btn_no.Checked = true;
            txt_qtyyes.Text = "";
            foto = "";
            cmb_productyes.SelectedIndex = 0;
            txt_coloryes.Text = "";
            cmb_size.SelectedIndex = 0;
            cmb_sablon.SelectedIndex = 0;
            txt_qty.Text = "";
            cmb_product.SelectedIndex = 0;
            txt_color.Text = "";
            cmb_size.SelectedIndex = 0;
            cmb_sablon.SelectedIndex = 0;
        }



        private void pict_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pict_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form_Home form_Home = new Form_Home();
            form_Home.Show();
            this.Close();
        }


        private void btn_yes_CheckedChanged(object sender, EventArgs e)
        {
            panel_orderyes.Visible = true;
            panel_orderno.Visible = false;
            panel_orderyes.Location = new Point(991, 293);
            btn_sablon.Checked = true;
            cmb_product.SelectedIndex = cmb_product.SelectedIndex;
            txt_coloryes.Text = txt_color.Text;
            cmb_sizeyes.SelectedIndex = cmb_size.SelectedIndex;
            txt_qtyyes.Text = txt_qty.Text;
             
            
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
                photoname = "\\\\gambar sablon\\\\"+ newFileName + fileExtension;
                string folderPath = Form1.projectDirectory + "\\gambar sablon\\";
                foto = folderPath +newFileName+ fileExtension;
                img.Save(Path.Combine(folderPath, newFileName + fileExtension));

                MessageBox.Show("Image uploaded", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btn_upload.Enabled = false;
            }
        }

        private void cmb_productyes_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cmb_product_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }


        private void cmb_sablon_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }
        private void cmb_size_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_no_CheckedChanged(object sender, EventArgs e)
        {
            btn_no.Checked = true;
        }

        private void btn_polos_CheckedChanged(object sender, EventArgs e)
        {
            btn_sablon.Checked = false;
            btn_no.Checked = true;
            panel_orderyes.Visible = false;
            panel_orderno.Visible = true;
            panel_orderno.Location = new Point(991, 293);
            cmb_product.SelectedIndex = cmb_productyes.SelectedIndex;
            txt_color.Text = txt_coloryes.Text;
            cmb_size.SelectedIndex = cmb_sizeyes.SelectedIndex;
            txt_qty.Text = txt_qtyyes.Text;
        }

        private void btn_addorder_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txt_custname.Text) || string.IsNullOrEmpty(txt_phone.Text) || string.IsNullOrEmpty(txt_address.Text))
            {
                MessageBox.Show("Please input the customer data","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                
                
            }
            else if (string.IsNullOrWhiteSpace(foto) || string.IsNullOrWhiteSpace(cmb_productyes.Text) || string.IsNullOrWhiteSpace(txt_coloryes.Text)
                || string.IsNullOrWhiteSpace(txt_qtyyes.Text) || string.IsNullOrWhiteSpace(cmb_sablon.Text) || string.IsNullOrWhiteSpace(cmb_sizeyes.Text))
            {
                MessageBox.Show("Please input the product data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                name = txt_custname.Text;

                DataTable dtcust = new DataTable();
                query = "select customer_id, Nama_customer, nomer_telepon, alamat from customer";
                Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
                Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
                Form1.mySqlDataAdapter.Fill(dtcust);

                if (dtcust.Rows.Count == 0)
                {
                    query = $"insert into customer(nama_customer,nomer_telepon,alamat) values('{txt_custname.Text}','{txt_phone.Text}','{txt_address.Text}');";
                    try
                    {
                        Form1.sqlconnect.Open();
                        Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
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
                    query = $"insert into cart(customer_id, nama_cartt) values((select customer_id from customer where upper(NAMA_CUSTOMER) = upper('{txt_custname.Text}')),'cart_{txt_custname.Text}');";
                    try
                    {
                        Form1.sqlconnect.Open();
                        Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
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
                    query = $"insert into produk(jenis_id,sablon_id,nama_produk,warna,ukuran,issablon,stock,gambar_sablon,account_id)values((select jenis_id from jenis where nama_jenis = '{cmb_productyes.Text}'),(select sablon_id from ukuran_sablon where nama_sablon = '{cmb_sablon.Text}'),'{cmb_productyes.Text}', '{txt_coloryes.Text}','{cmb_sizeyes.Text}',1,'{txt_qtyyes.Text}','{photoname}',(select account_id from accounts where first_name = '{Form_Home.firstname}'));";
                    try
                    {
                        Form1.sqlconnect.Open();
                        Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
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
                    query = $"insert into detail_cart(cart_id,produk_id) values((select cart_id from cart where nama_cartt = 'cart_{txt_custname.Text}'),(select produk_id from produk where nama_produk = '{cmb_productyes.Text}' order by created_at desc limit 1));";
                    try
                    {
                        Form1.sqlconnect.Open();
                        Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
                        Form1.mySqlDataReader = Form1.sqlcommand.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        Form1.sqlconnect.Close();
                        MessageBox.Show("The product has been added to the cart ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_qtyyes.Text = "";
                        foto = "";
                        cmb_productyes.SelectedIndex = 0;
                        txt_coloryes.Text = "";
                        cmb_sizeyes.SelectedIndex = 0;
                        cmb_sablon.SelectedIndex = 0;
                        photoname = "";
                    }

                }
                else
                {
                    for (int i = 0; i < dtcust.Rows.Count; i++)
                    {
                        if (dtcust.Rows[i][1].ToString().ToLower() == txt_custname.Text.ToLower() && dtcust.Rows[i][2].ToString().ToLower() == txt_phone.Text.ToLower() && dtcust.Rows[i][3].ToString().ToLower() == txt_address.Text.ToLower() )
                        {
                            custfounded = true;
                        }
                    }
                    if (custfounded == true)
                    {
                        query = $"insert into produk(jenis_id,sablon_id,nama_produk,warna,ukuran,issablon,stock,gambar_sablon,account_id)values((select jenis_id from jenis where nama_jenis = '{cmb_productyes.Text}'),(select sablon_id from ukuran_sablon where nama_sablon = '{cmb_sablon.Text}'),'{cmb_productyes.Text}', '{txt_coloryes.Text}','{cmb_sizeyes.Text}',1,'{txt_qtyyes.Text}','{photoname}',(select account_id from accounts where first_name = '{Form_Home.firstname}'));";
                        try
                        {
                            Form1.sqlconnect.Open();
                            Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
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
                        query = $"insert into detail_cart(cart_id,produk_id) values((select cart_id from cart where nama_cartt = 'cart_{txt_custname.Text}'),(select produk_id from produk where nama_produk = '{cmb_productyes.Text}' order by created_at desc limit 1));";
                        try
                        {
                            Form1.sqlconnect.Open();
                            Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
                            Form1.mySqlDataReader = Form1.sqlcommand.ExecuteReader();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            Form1.sqlconnect.Close();
                            MessageBox.Show("The product has been added to the cart ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txt_qtyyes.Text = "";
                            foto = "";
                            cmb_productyes.SelectedIndex = 0;
                            txt_coloryes.Text = "";
                            cmb_sizeyes.SelectedIndex = 0;
                            cmb_sablon.SelectedIndex = 0;
                            photoname = "";
                        }

                    }
                    else if (custfounded == false)
                    {
                        query = $"insert into customer(nama_customer,nomer_telepon,alamat)values('{txt_custname.Text}','{txt_phone.Text}','{txt_address.Text}');";
                        try
                        {
                            Form1.sqlconnect.Open();
                            Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
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
                        query = $"insert into cart(customer_id, nama_cartt) values((select customer_id from customer where upper(NAMA_CUSTOMER) = upper('{txt_custname.Text}')),'cart_{txt_custname.Text}');";
                        try
                        {
                            Form1.sqlconnect.Open();
                            Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
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
                        query = $"insert into produk(jenis_id,sablon_id,nama_produk,warna,ukuran,issablon,stock,gambar_sablon,account_id)values((select jenis_id from jenis where nama_jenis = '{cmb_productyes.Text}'),(select sablon_id from ukuran_sablon where nama_sablon = '{cmb_sablon.Text}'),'{cmb_productyes.Text}', '{txt_coloryes.Text}','{cmb_sizeyes.Text}',1,'{txt_qtyyes.Text}','{photoname}',(select account_id from accounts where first_name = '{Form_Home.firstname}'));";
                        try
                        {
                            Form1.sqlconnect.Open();
                            Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
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
                        query = $"insert into detail_cart(cart_id,produk_id) values((select cart_id from cart where nama_cartt = 'cart_{txt_custname.Text}'),(select produk_id from produk where nama_produk = '{cmb_productyes.Text}' order by created_at desc limit 1));";
                        try
                        {
                            Form1.sqlconnect.Open();
                            Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
                            Form1.mySqlDataReader = Form1.sqlcommand.ExecuteReader();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            Form1.sqlconnect.Close();
                            MessageBox.Show("The product has been added to the cart ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txt_qtyyes.Text = "";
                            foto = "";
                            cmb_productyes.SelectedIndex = 0;
                            txt_coloryes.Text = "";
                            cmb_sizeyes.SelectedIndex = 0;
                            cmb_sablon.SelectedIndex = 0;
                            photoname = "";
                        }

                    }

                    btn_upload.Enabled = true;
                }
                 

            }
        }


        private void btn_viewcart_Click(object sender, EventArgs e)
        {
            DataTable dtcust = new DataTable();
            query = "select cu.NAMA_CUSTOMER, cu.NOMER_TELEPON, cu.ALAMAT from cart c, customer cu where c.customer_id = cu.CUSTOMER_ID;";
            Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(dtcust);


            for (int i = 0; i < dtcust.Rows.Count; i++)
            {
                if (dtcust.Rows[i][0].ToString() == txt_custname.Text && dtcust.Rows[i][1].ToString() == txt_phone.Text && dtcust.Rows[i][2].ToString() == txt_address.Text)
                {
                    customerada = true;
                    break;
                }
                else
                {
                    customerada = false;
                    
                }
            }
            if (customerada == true)
            {
                View_Cart view = new View_Cart();
                view.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Cart is empty");
            }

            name = txt_custname.Text;

        }



        private void btn_addcart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_custname.Text) || string.IsNullOrEmpty(txt_phone.Text) || string.IsNullOrEmpty(txt_address.Text))
            {
                MessageBox.Show("Please input the customer data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrWhiteSpace(cmb_product.Text) || string.IsNullOrWhiteSpace(txt_color.Text)
                || string.IsNullOrWhiteSpace(txt_qty.Text) || string.IsNullOrWhiteSpace(cmb_size.Text))
            {
                MessageBox.Show("Please input the product data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DataTable dtcust = new DataTable();
                query = "select customer_id, Nama_customer, nomer_telepon, alamat from customer";
                Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
                Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
                Form1.mySqlDataAdapter.Fill(dtcust);
                if (dtcust.Rows.Count == 0)
                {
                    query = $"insert into customer(nama_customer,nomer_telepon,alamat) values('{txt_custname.Text}','{txt_phone.Text}','{txt_address.Text}');";
                    try
                    {
                        Form1.sqlconnect.Open();
                        Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
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
                    query = $"insert into cart(customer_id, nama_cartt) values((select customer_id from customer where upper(NAMA_CUSTOMER) = upper('{txt_custname.Text}')),'cart_{txt_custname.Text}');";
                    try
                    {
                        Form1.sqlconnect.Open();
                        Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
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
                    query = $"insert into produk(jenis_id,sablon_id,nama_produk,warna,ukuran,issablon,stock,account_id)values((select jenis_id from jenis where nama_jenis = '{cmb_product.Text}'),'5','{cmb_product.Text}', '{txt_color.Text}','{cmb_size.Text}','0',{txt_qty.Text},(select account_id from accounts where first_name = '{Form_Home.firstname}'));";
                    try
                    {
                        Form1.sqlconnect.Open();
                        Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
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
                    query = $"insert into detail_cart(cart_id,produk_id) values((select cart_id from cart where nama_cartt = 'cart_{txt_custname.Text}'),(select produk_id from produk where nama_produk = '{cmb_product.Text}' order by created_at desc limit 1));";
                    try
                    {
                        Form1.sqlconnect.Open();
                        Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
                        Form1.mySqlDataReader = Form1.sqlcommand.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        Form1.sqlconnect.Close();
                        MessageBox.Show("The product has been added to the cart ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_qty.Text = "";
                        foto = "";
                        cmb_product.SelectedIndex = 0;
                        txt_color.Text = "";
                        cmb_size.SelectedIndex = 0;
                        cmb_sablon.SelectedIndex = 0;
                        photoname = "";
                    }


                }
                else
                {
                    for (int i = 0; i < dtcust.Rows.Count; i++)
                    {
                        if (dtcust.Rows[i][1].ToString().ToLower() == txt_custname.Text.ToLower() && dtcust.Rows[i][2].ToString().ToLower() == txt_phone.Text.ToLower() && dtcust.Rows[i][3].ToString().ToLower() == txt_address.Text.ToLower())
                        {
                            custfounded = true;
                        }
                    }
                    if (custfounded == true)
                    {
                        query = $"insert into produk(jenis_id,sablon_id,nama_produk,warna,ukuran,issablon,stock,account_id)values((select jenis_id from jenis where nama_jenis = '{cmb_product.Text}'),'5','{cmb_product.Text}', '{txt_color.Text}','{cmb_size.Text}','0',{txt_qty.Text},(select account_id from accounts where first_name = '{Form_Home.firstname}'));";
                        try
                        {
                            Form1.sqlconnect.Open();
                            Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
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
                        query = $"insert into detail_cart(cart_id,produk_id) values((select cart_id from cart where nama_cartt = 'cart_{txt_custname.Text}'),(select produk_id from produk where nama_produk = '{cmb_product.Text}' order by created_at desc limit 1));";
                        try
                        {
                            Form1.sqlconnect.Open();
                            Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
                            Form1.mySqlDataReader = Form1.sqlcommand.ExecuteReader();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            Form1.sqlconnect.Close();
                            MessageBox.Show("The product has been added to the cart ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txt_qty.Text = "";
                            foto = "";
                            cmb_product.SelectedIndex = 0;
                            txt_color.Text = "";
                            cmb_size.SelectedIndex = 0;
                            cmb_sablon.SelectedIndex = 0;
                            photoname = "";
                        }

                    }
                    else if (custfounded == false)
                    {
                        query = $"insert into customer(nama_customer,nomer_telepon,alamat)values('{txt_custname.Text}','{txt_phone.Text}','{txt_address.Text}');";
                        try
                        {
                            Form1.sqlconnect.Open();
                            Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
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
                        query = $"insert into cart(customer_id, nama_cartt) values((select customer_id from customer where upper(NAMA_CUSTOMER) = upper('{txt_custname.Text}')),'cart_{txt_custname.Text}');";
                        try
                        {
                            Form1.sqlconnect.Open();
                            Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
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
                        query = $"insert into produk(jenis_id,sablon_id,nama_produk,warna,ukuran,issablon,stock,account_id)values((select jenis_id from jenis where nama_jenis = '{cmb_product.Text}'),'5','{cmb_product.Text}', '{txt_color.Text}','{cmb_size.Text}','0',{txt_qty.Text},(select account_id from accounts where first_name = '{Form_Home.firstname}'));";
                        try
                        {
                            Form1.sqlconnect.Open();
                            Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
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
                        query = $"insert into detail_cart(cart_id,produk_id) values((select cart_id from cart where nama_cartt = 'cart_{txt_custname.Text}'),(select produk_id from produk where nama_produk = '{cmb_product.Text}' order by created_at desc limit 1));";
                        try
                        {
                            Form1.sqlconnect.Open();
                            Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
                            Form1.mySqlDataReader = Form1.sqlcommand.ExecuteReader();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            Form1.sqlconnect.Close();
                            MessageBox.Show("The product has been added to the cart ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txt_qty.Text = "";
                            foto = "";
                            cmb_product.SelectedIndex = 0;
                            txt_color.Text = "";
                            cmb_size.SelectedIndex = 0;
                            cmb_sablon.SelectedIndex = 0;
                            photoname = "";
                        }

                    }
                    name = txt_custname.Text;
                    btn_upload.Enabled = true;
                }
            }
            
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            name = txt_custname.Text;
            DataTable dtcust = new DataTable();
            query = "select cu.NAMA_CUSTOMER, cu.NOMER_TELEPON, cu.ALAMAT from cart c, customer cu where c.customer_id = cu.CUSTOMER_ID;";
            Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(dtcust);


            for (int i = 0; i < dtcust.Rows.Count; i++)
            {
                if (dtcust.Rows[i][0].ToString() == txt_custname.Text && dtcust.Rows[i][1].ToString() == txt_phone.Text && dtcust.Rows[i][2].ToString() == txt_address.Text)
                {
                    View_Cart view = new View_Cart();
                    view.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cart is empty");
                }
            }
            


        }

        private void txt_phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_qtyyes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_custname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_coloryes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_color_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btn_sablon_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
