using Proiect.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect.Screens.Produse
{
    public partial class ProductsRecord : MetroFramework.Forms.MetroForm
    {
        string connectionString = @"Data Source = DESKTOP-E8V89KH\SQLEXPRESS01; Initial Catalog = demo_db; Integrated Security = True; ";
        public ProductsRecord()
        {
            InitializeComponent();
        }

        private void ProductsRecord_Load(object sender, EventArgs e)
        {
            LoadAllProductsDataGridView();
        }

        private void LoadAllProductsDataGridView()
        {
            ProduseGridView.DataSource = GetData();
        }

        private object GetData()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from Products", conn))
                {
                    conn.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    dt.Load(sdr);
                }
            }

            return dt;
        }
    

        private void ProduseGridView_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
