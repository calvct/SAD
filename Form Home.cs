using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Project_SAD_CUTEES
{
    public partial class Form_Home : Form
    {
        Guna2Panel[] pesanan;
        Guna2Panel[] order;
        Guna2HtmlLabel[] lbl_cust;
        Guna2HtmlLabel[] lbl_order;
        Guna2HtmlLabel[] status;
        Guna2HtmlLabel[] lbl_product;
        Guna2HtmlLabel[] lbl_type;
        Guna2HtmlLabel[] lbl_qty; 
        Guna2HtmlLabel[] lbl_deadline;
        Guna2HtmlLabel[] lbl_total;
        Guna2PictureBox[] pb;
        Guna2Button[] btn_orderdetail;
        public string curstatus;
        DataTable dtorder = new DataTable();

        public string id;
        private Form1 form1;
        public int y;
        public int y1;
        public int y2;
        public int y3;
        public int y4;
        public int y5;
        public int jumlahfoto;

        public int buttonnumber;
        
        public static string firstname;
        public static string orderId;
        public Form_Home()
        {
            InitializeComponent();
            Form1.workingDirectory = Environment.CurrentDirectory;
            Form1.projectDirectory = Directory.GetParent(Form1.workingDirectory).Parent.FullName;
            form1 = new Form1(); 
            pict_logo.Location = new Point((panel1.Width - pict_logo.Width)/2, (panel1.Height - pict_logo.Height)/2);

            lbl_orders.Location = new Point(((panel1.Width - lbl_orders.Width)/ 2) - 350, panel1.Top + 5);
            lbl_expense.Location = new Point(((panel1.Width - lbl_expense.Width) / 2) , panel1.Top + 5);
            lbl_transaction.Location = new Point(((panel1.Width - lbl_transaction.Width) / 2) + 400, panel1.Top + 5);

            btn_current.Location = new Point(((panel1.Width - btn_current.Width) / 2) - 350, panel1.Top + 43);
            txt_search.GotFocus += RemoveText;
            txt_search.LostFocus += AddText;
        }

        #region
        private void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_search.Text))
            {
                txt_search.Text = "Search Order by ID / Name";
                txt_search.ForeColor = Color.DarkGray;
            }
        }

        private void RemoveText(object sender, EventArgs e)
        {
            if (txt_search.Text == "Search Order by ID / Name")
            {
                txt_search.Text = "";
                txt_search.ForeColor = Color.Black;
            }
        }
        #endregion

        private void Form_Home_Load(object sender, EventArgs e)
        {
            curstatus = "'Need to Process' or status_order = 'In Process'";
            listdata(curstatus);
        }

        private void pict_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pict_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
            btn_shipping.FillColor = Color.White;
            btn_todo.FillColor = Color.Gold;
            btn_done.FillColor = Color.White;
            btn_canceled.FillColor = Color.White;
            btn_addorder.Show();
            plus1.Show();
            plus2.Show();
            guna2Panel2.Visible = true;/*
            guna2Panel1.Location = new Point(193, 376);*/
            curstatus = "'Need to Process' or status_order = 'In Process'";
            for (int i = 0; i < order.Count(); i++)
            {
                guna2Panel1.Controls.Remove(order[i]);
                guna2Panel1.Controls.Remove(pesanan[i]);
            }
            listdata(curstatus);
            


        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            btn_shipping.FillColor = Color.White;
            btn_todo.FillColor = Color.White;
            btn_done.FillColor = Color.Gold;
            btn_canceled.FillColor = Color.White;
            btn_addorder.Hide();
            plus1.Hide();
            plus2.Hide();
            guna2Panel2.Visible = false;
            curstatus = "'Done'";
            for (int i = 0; i < order.Count(); i++)
            {
                guna2Panel1.Controls.Remove(order[i]);
                guna2Panel1.Controls.Remove(pesanan[i]);
            }

            listdata(curstatus);

        }

        private void btn_current_Click(object sender, EventArgs e)
        {

        }

        private void pict_accounticon_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Profile form_Profile = new Form_Profile();
            form_Profile.ShowDialog();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_addorder_Click(object sender, EventArgs e)
        {
            Add_Order add_Order = new Add_Order();
            add_Order.Show();
            this.Close();
        }

        private void btn_shipping_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < order.Count(); i++)
            {
                guna2Panel1.Controls.Remove(order[i]);
                guna2Panel1.Controls.Remove(pesanan[i]);
            }
            btn_shipping.FillColor = Color.Gold;
            btn_todo.FillColor = Color.White;
            btn_done.FillColor = Color.White;
            btn_canceled.FillColor = Color.White;
            btn_addorder.Hide();
            plus1.Hide();
            plus2.Hide();
            guna2Panel2.Visible = false;
            curstatus = "'Shipping'";
            /*
            guna2Panel1.Location = new Point(193, 306);*/
            listdata(curstatus);

        }

        private void btn_need_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < order.Count(); i++)
            {
                guna2Panel1.Controls.Remove(order[i]);
                guna2Panel1.Controls.Remove(pesanan[i]);
            }

            curstatus = "'Need to Process'";
            btn_allorder.FillColor = Color.White;
            btn_inprocess.FillColor = Color.White;
            btn_need.FillColor = Color.Gold;
            listdata(curstatus);
            



        }

        private void btn_inprocess_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < order.Count(); i++)
            {
                guna2Panel1.Controls.Remove(order[i]);
                guna2Panel1.Controls.Remove(pesanan[i]);
            }


            btn_allorder.FillColor = Color.White;
            btn_inprocess.FillColor = Color.Gold;
            btn_need.FillColor = Color.White;
            curstatus = "'In Process'";
            listdata(curstatus);
            





        }

        private void lbl_orders_Click(object sender, EventArgs e)
        {

        }

        private void btn_canceled_Click(object sender, EventArgs e)
        {
            btn_shipping.FillColor = Color.White;
            btn_todo.FillColor = Color.White;
            btn_done.FillColor = Color.White;
            btn_canceled.FillColor = Color.Gold;
            btn_addorder.Hide();
            plus1.Hide();
            plus2.Hide();
            guna2Panel2.Visible = false;
            curstatus = "'Refunded'";
            listdata(curstatus);
        }

        private void btn_allorder_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < order.Count(); i++)
            {
                guna2Panel1.Controls.Remove(order[i]);
                guna2Panel1.Controls.Remove(pesanan[i]);
            }
            btn_allorder.FillColor = Color.Gold;
            btn_inprocess.FillColor = Color.White;
            btn_need.FillColor = Color.White;
            curstatus = "'Need to Process' or status_order = 'In Process'";
            listdata(curstatus);

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.BackColor = Color.Gold;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void btn_orderdetail_Click(object sender, EventArgs e)
        {
            MessageBox.Show("halo");
            if (sender is Guna2Button clickedButton)
            {
                orderId = clickedButton.Tag.ToString();
                //MessageBox.Show(orderId);
                //this.Close();
                

            }
            Order_Detail order_Detail = new Order_Detail();
            order_Detail.Show();
            this.Close();



        }

        private void lbl_expense_Click(object sender, EventArgs e)
        {
            Product_Expense form = new Product_Expense();
            form.Show();
            this.Close();
        }

        private void guna2ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void lbl_transaction_Click(object sender, EventArgs e)
        {
            Transaction_Report transaction_Report = new Transaction_Report();
            transaction_Report.Show();
            this.Close();
        }

        public void listdata(string current)
        {
            DataTable Login = new DataTable();
            Form1.sqlquery = $"SELECT first_name FROM accounts WHERE(email = '{Form1.email}' and passwords = '{Form1.pass}')";
            Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(Login);
            lbl_signup.Text = Login.Rows[0][0].ToString();
            firstname = Login.Rows[0][0].ToString();

            dtorder = new DataTable();
            Form1.sqlquery = $"SELECT order_id from `order` where status_order = {current};";
            Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(dtorder);
            DataTable dtjum = new DataTable();
            Form1.sqlquery = "select order_id,count(order_id) from detail_order group by 1;";
            Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(dtjum);
            pesanan = new Guna2Panel[dtorder.Rows.Count];
            order = new Guna2Panel[dtorder.Rows.Count];
            guna2Panel1.AutoScroll = true;
            DataTable dtcust = new DataTable();

            DataTable dtjumlahfoto = new DataTable();

            DataTable dtjumlahorder = new DataTable();


            DataTable dtdetail = new DataTable();

            Form1.sqlquery = $"select count(*)\r\nfrom `order` where status_order = {current};";
            Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(dtjumlahorder);

            if (Convert.ToInt16(dtjumlahorder.Rows[0][0]) > 1)
            {
                lbl_jumlahorder.Text = dtjumlahorder.Rows[0][0].ToString() + " Orders";

            }
            else
            {
                lbl_jumlahorder.Text = dtjumlahorder.Rows[0][0].ToString() + " Order";
            }

            y = 78;
            y1 = y + 61;
            for (int i = 0; i < dtorder.Rows.Count; i++)
            {

                int height = Convert.ToInt32(dtjum.Rows[i][1]);
                Form1.sqlquery = $"SELECT c.nama_customer, o.order_id, o.status_order from `order` o, customer c where c.customer_id = o.customer_id and o.order_id = '{dtorder.Rows[i][0]}' ;";
                Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
                Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
                Form1.mySqlDataAdapter.Fill(dtcust);


                Form1.sqlquery = $"select order_id, count(order_id) from detail_order where order_id = '{dtorder.Rows[i][0].ToString()}' group by 1;";
                Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
                Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
                Form1.mySqlDataAdapter.Fill(dtjumlahfoto);
                jumlahfoto = Convert.ToInt16(dtjumlahfoto.Rows[i][1].ToString());

                pesanan[i] = new Guna2Panel();
                pesanan[i].Location = new Point(0, y);
                pesanan[i].Size = new Size(1700, 61);
                pesanan[i].FillColor = Color.White;
                order[i] = new Guna2Panel();
                order[i].Location = new Point(0, y1);
                order[i].Size = new Size(1700, 250 * jumlahfoto);
                order[i].FillColor = Color.LightGray;

                y += order[i].Height + pesanan[i].Height;
                y1 += order[i].Height + pesanan[i].Height;
                guna2Panel1.Controls.Add(pesanan[i]);
                guna2Panel1.Controls.Add(order[i]);
            }
            lbl_cust = new Guna2HtmlLabel[dtcust.Rows.Count];
            lbl_order = new Guna2HtmlLabel[dtcust.Rows.Count];
            status = new Guna2HtmlLabel[dtcust.Rows.Count];
            for (int i = 0; i < dtcust.Rows.Count; i++)
            {
                lbl_cust[i] = new Guna2HtmlLabel();
                lbl_cust[i].Location = new Point(60, 12);
                lbl_cust[i].Size = new Size(255, 39);
                lbl_cust[i].Font = new Font("Microsoft Sans Serif", 24);
                lbl_cust[i].Text = dtcust.Rows[i][0].ToString();
                lbl_order[i] = new Guna2HtmlLabel();
                lbl_order[i].Location = new Point(943, 12);
                lbl_order[i].Size = new Size(255, 39);
                lbl_order[i].Font = new Font("Microsoft Sans Serif", 24);
                lbl_order[i].Text = "Order ID : " + dtcust.Rows[i][1].ToString();
                status[i] = new Guna2HtmlLabel();
                status[i].Location = new Point(1357, 10);
                status[i].Size = new Size(255, 39);
                status[i].Font = new Font("Microsoft Sans Serif", 24);
                status[i].BorderStyle = BorderStyle.FixedSingle;
                status[i].ForeColor = Color.Black;
                status[i].Text = dtcust.Rows[i][2].ToString();
                if (dtcust.Rows[i][2].ToString() == "Need to Process")
                {
                    status[i].BackColor = Color.DarkOrange;
                    status[i].Text = dtcust.Rows[i][2].ToString();

                }
                else if (dtcust.Rows[i][2].ToString() == "In Process")
                {
                    status[i].BackColor = Color.Gold;
                    status[i].Text = dtcust.Rows[i][2].ToString();
                    status[i].ForeColor = Color.Black;
                }
                pesanan[i].Controls.Add(lbl_cust[i]);
                pesanan[i].Controls.Add(lbl_order[i]);
                pesanan[i].Controls.Add(status[i]);



            }



            for (int i = 0; i < dtorder.Rows.Count; i++)
            {
                dtdetail = new DataTable();
                Form1.sqlquery = $"select p.nama_produk, u.nama_sablon, p.warna,p.ukuran,p.stock, date_format(o.deadline,\"%d %M %Y\"), o.total_harga, p.gambar_sablon\r\nfrom produk p, ukuran_sablon u, `order` o, detail_order d\r\nwhere p.sablon_id = u.sablon_id and d.order_id = o.order_id and d.produk_id = p.PRODUK_ID and o.ORDER_ID = '{dtorder.Rows[i][0].ToString()}' ;";
                Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
                Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
                Form1.mySqlDataAdapter.Fill(dtdetail);

                lbl_product = new Guna2HtmlLabel[dtdetail.Rows.Count];
                lbl_deadline = new Guna2HtmlLabel[dtdetail.Rows.Count];
                lbl_qty = new Guna2HtmlLabel[dtdetail.Rows.Count];
                lbl_type = new Guna2HtmlLabel[dtdetail.Rows.Count];
                lbl_total = new Guna2HtmlLabel[dtdetail.Rows.Count];
                pb = new Guna2PictureBox[dtdetail.Rows.Count];
                btn_orderdetail = new Guna2Button[dtdetail.Rows.Count];

                y2 = 18;
                y3 = 70;
                y4 = 122;
                for (int j = 0; j < dtdetail.Rows.Count; j++)
                {
                    btn_orderdetail[j] = new Guna2Button();
                    btn_orderdetail[j].Location = new Point(1300, order[i].Height - 200);
                    btn_orderdetail[j].Size = new Size(300, 50);
                    btn_orderdetail[j].Text = "Order Detail";
                    btn_orderdetail[j].Font = new Font("Microsoft Sans Serif", 24);
                    btn_orderdetail[j].ForeColor = Color.Black;
                    btn_orderdetail[j].BackColor = Color.White;
                    btn_orderdetail[j].FillColor = Color.White;

                    btn_orderdetail[j].Tag = dtorder.Rows[i][0].ToString();

                    btn_orderdetail[j].Click += btn_orderdetail_Click;

                    if (j == dtdetail.Rows.Count - 1 && dtdetail.Rows.Count > 0)
                    {
                        lbl_deadline[j] = new Guna2HtmlLabel();
                        lbl_deadline[j].Location = new Point(270, (172 + (220 * j)));
                        lbl_deadline[j].Size = new Size(497, 33);
                        lbl_deadline[j].Text = "Deadline : " + dtdetail.Rows[j][5].ToString();
                        lbl_deadline[j].Font = new Font("Microsoft Sans Serif", 24);
                        lbl_deadline[j].ForeColor = Color.Black;

                        int tampung = Convert.ToInt32(dtdetail.Rows[j][6]);
                        lbl_total[j] = new Guna2HtmlLabel();
                        lbl_total[j].Location = new Point(1200, (172 + (220 * j)));
                        lbl_total[j].Size = new Size(497, 33);
                        lbl_total[j].Text = "Total Price : " + tampung.ToString("C", CultureInfo.CreateSpecificCulture("id-ID"));
                        lbl_total[j].Font = new Font("Microsoft Sans Serif", 24);
                        lbl_total[j].ForeColor = Color.Black;



                    }
                    else if (j == dtdetail.Rows.Count - 1 && dtdetail.Rows.Count == 0)
                    {
                        lbl_deadline[j] = new Guna2HtmlLabel();
                        lbl_deadline[j].Location = new Point(270, 172);
                        lbl_deadline[j].Size = new Size(497, 33);
                        lbl_deadline[j].Text = "Deadline : " + dtdetail.Rows[j][6].ToString();
                        lbl_deadline[j].Font = new Font("Microsoft Sans Serif", 24);
                        lbl_deadline[j].ForeColor = Color.Black;

                        int tampung = Convert.ToInt32(dtdetail.Rows[j][6]);
                        lbl_total[j] = new Guna2HtmlLabel();
                        lbl_total[j].Location = new Point(1200, 172);
                        lbl_total[j].Size = new Size(497, 33);
                        lbl_total[j].Text = "Total Price : " + tampung.ToString("C", CultureInfo.CreateSpecificCulture("id-ID"));
                        lbl_total[j].Font = new Font("Microsoft Sans Serif", 24);
                        lbl_total[j].ForeColor = Color.Black;
                    }

                    lbl_product[j] = new Guna2HtmlLabel();
                    lbl_product[j].Location = new Point(270, y2);
                    lbl_product[j].Size = new Size(497, 33);
                    lbl_product[j].Text = "Product : " + dtdetail.Rows[j][0].ToString();
                    lbl_product[j].Font = new Font("Microsoft Sans Serif", 24);
                    lbl_product[j].ForeColor = Color.Black;
                    lbl_type[j] = new Guna2HtmlLabel();
                    lbl_type[j].Location = new Point(270, y3);
                    lbl_type[j].Size = new Size(497, 33);
                    lbl_type[j].Text = "Type : " + dtdetail.Rows[j][1].ToString() + ", " + dtdetail.Rows[j][2].ToString() + ", " + dtdetail.Rows[j][3].ToString();
                    lbl_type[j].Font = new Font("Microsoft Sans Serif", 24);
                    lbl_type[j].ForeColor = Color.Black;
                    lbl_qty[j] = new Guna2HtmlLabel();
                    lbl_qty[j].Location = new Point(270, y4);
                    lbl_qty[j].Size = new Size(497, 33);
                    lbl_qty[j].Text = "Quantity : " + dtdetail.Rows[j][4].ToString();
                    lbl_qty[j].Font = new Font("Microsoft Sans Serif", 24);
                    lbl_qty[j].ForeColor = Color.Black;
                    pb[j] = new Guna2PictureBox();
                    if (string.IsNullOrEmpty(dtdetail.Rows[j][7].ToString()))
                    {
                        pb[j].Location = new Point(61, y2);
                        pb[j].Size = new Size(203, 192);
                        pb[j].SizeMode = PictureBoxSizeMode.Zoom;

                    }
                    else
                    {
                        Form1.full_url = Form1.projectDirectory + dtdetail.Rows[j][7].ToString();
                        pb[j].Location = new Point(61, y2);
                        pb[j].Size = new Size(203, 192);
                        pb[j].ImageLocation = Form1.full_url;
                        pb[j].SizeMode = PictureBoxSizeMode.Zoom;

                    }
                    y2 += 220;
                    y3 += 220;
                    y4 += 220;


                    order[i].Controls.Add(btn_orderdetail[j]);
                    order[i].Controls.Add(lbl_product[j]);
                    order[i].Controls.Add(pb[j]);
                    order[i].Controls.Add(lbl_type[j]);
                    order[i].Controls.Add(lbl_qty[j]);

                    order[i].Controls.Add(lbl_deadline[j]);
                    order[i].Controls.Add(lbl_total[j]);

                }

            }
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                id = 
            }
        }
    }
}
