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

namespace Proiect.Screens
{
    public partial class Stock : MetroFramework.Forms.MetroForm
    {
        public Stock()
        {
            InitializeComponent();
        }

        public int idProdus { get; set; }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Tranzactii_Load(object sender, EventArgs e)
        {
            LoadStock();
        }

        private void LoadStock()
        {
            StockgridView.DataSource = GetData();
            StockgridView.Columns[0].Visible = false;
        }

        private DataTable GetData()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from Stock", conn))
                {
                    conn.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    dt.Load(sdr);
                }
            }

            return dt;
        }

        private void ClientiTextBox_TextChanged(object sender, EventArgs e)
        {
            if (StockTextBox.Text.Trim() == string.Empty)
            {
                LoadStock();
            }

            else
            {
                StockgridView.DataSource = SearchStockById();
            }
        }

        private DataTable SearchStockById()
        {
            DataTable table = new DataTable();

            using (SqlConnection conn = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_SearchStockById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductID", StockTextBox.Text);
                    conn.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    table.Load(sdr);
                }
            }
            return table;
        }

        private void StockgridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

