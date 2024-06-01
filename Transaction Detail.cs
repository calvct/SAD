using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Util;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Project_SAD_CUTEES
{
    public partial class Transaction_Detail : Form
    {
        public Transaction_Detail()
        {
            InitializeComponent();
        }

        private void Transaction_Detail_Load(object sender, EventArgs e)
        {
            label3.Text = Transaction_Report.productname;
            DataTable dtcoy = new DataTable();
            //Form1.sqlquery = $"SELECT\r\n    u.nama_sablon AS 'Type',\r\n    SUM(p.stock) AS 'Total Quantity',\r\n    SUM(j.harga_jenis + u.harga_sablon) AS 'Revenue',\r\n    SUM(IFNULL(p.total_modal, 0)) AS 'Cost of Product',\r\n    SUM(j.harga_jenis + u.harga_sablon - IFNULL(p.total_modal, 0)) AS 'Net Profit'\r\nFROM\r\n    produk p\r\n    JOIN ukuran_sablon u ON p.sablon_id = u.sablon_id\r\n    JOIN jenis j ON j.jenis_id = p.jenis_id\r\nwhere p.NAMA_PRODUK = '{Transaction_Report.productname}' and u.nama_sablon = 'Polos' \r\nGROUP BY 1\r\nunion\r\nSELECT\r\n    u.nama_sablon AS 'Type',\r\n    ifnull(SUM(p.stock),0) AS 'Total Quantity',\r\n    ifnull(SUM(j.harga_jenis + u.harga_sablon),0) AS 'Revenue',\r\n    SUM(IFNULL(p.total_modal, 0)) AS 'Cost f Product',\r\n    SUM(ifnull(j.harga_jenis + u.harga_sablon,0) - IFNULL(p.total_modal, 0)) AS 'Net Profit'\r\nFROM\r\n    produk p\r\n    JOIN ukuran_sablon u ON p.sablon_id = u.sablon_id\r\n    JOIN jenis j ON j.jenis_id = p.jenis_id\r\nwhere p.NAMA_PRODUK = '{Transaction_Report.productname}' and u.nama_sablon = 'Logo'\r\nGROUP BY 1\r\nunion\r\nSELECT\r\n    u.nama_sablon AS 'Type',\r\n    ifnull(SUM(p.stock),0) AS \"Total Quantity\",\r\n    ifnull(SUM(j.harga_jenis + u.harga_sablon),0) AS Revenue,\r\n    SUM(IFNULL(p.total_modal, 0)) AS \"Cost of Product\",\r\n    SUM(ifnull(j.harga_jenis + u.harga_sablon,0) - IFNULL(p.total_modal, 0)) AS \"Net Profit\"\r\nFROM\r\n    produk p\r\n    JOIN ukuran_sablon u ON p.sablon_id = u.sablon_id\r\n    JOIN jenis j ON j.jenis_id = p.jenis_id\r\nwhere p.NAMA_PRODUK = '{Transaction_Report.productname}' and u.nama_sablon =  'Size A4'\r\nGROUP BY 1\r\nunion\r\nSELECT\r\n    u.nama_sablon AS 'Type',\r\n    ifnull(SUM(p.stock),0) AS 'Total Quantity',\r\n    ifnull(SUM(j.harga_jenis + u.harga_sablon),0) AS 'Revenue',\r\n    SUM(IFNULL(p.total_modal, 0)) AS 'Cost of Product',\r\n    SUM(ifnull(j.harga_jenis + u.harga_sablon,0) - IFNULL(p.total_modal, 0)) AS 'Net profit'\r\nFROM\r\n    produk p\r\n    JOIN ukuran_sablon u ON p.sablon_id = u.sablon_id\r\n    JOIN jenis j ON j.jenis_id = p.jenis_id\r\nwhere p.NAMA_PRODUK = '{Transaction_Report.productname}' and u.nama_sablon = 'Size A5'\r\nGROUP BY 1\r\nunion\r\nSELECT\r\n    u.nama_sablon AS 'Type',\r\n    ifnull(SUM(p.stock),0) AS 'Total Quantity',\r\n    ifnull(SUM(j.harga_jenis + u.harga_sablon),0) AS Revenue,\r\n    SUM(IFNULL(p.total_modal, 0)) AS 'Cost of Product',\r\n    SUM(ifnull(j.harga_jenis + u.harga_sablon,0) - IFNULL(p.total_modal, 0)) AS 'Net Profit'\r\nFROM\r\n    produk p\r\n    JOIN ukuran_sablon u ON p.sablon_id = u.sablon_id\r\n    JOIN jenis j ON j.jenis_id = p.jenis_id\r\nwhere p.NAMA_PRODUK = '{Transaction_Report.productname}' and u.nama_sablon = 'Size A3'\r\nGROUP BY 1;";          
            Form1.sqlquery = $"call pTransaksi('{Transaction_Report.productname}');";
            Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
     
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(dtcoy);
            datagrid.DataSource = dtcoy;


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
            Transaction_Report transaction_Report = new Transaction_Report();
            transaction_Report.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
