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

namespace Proiect.Screens.Tranzactii
{
    public partial class Transactions : MetroFramework.Forms.MetroForm
    {
        public Transactions()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Tranzactii_Load(object sender, EventArgs e)
        {
            LoadTransactions();
        }

        private void LoadTransactions()
        {
            TranzactiiGridView.DataSource = GetData();
            TranzactiiGridView.Columns[0].Visible = false;
        }

        private object GetData()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from Transactions", conn))
                {
                    conn.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    dt.Load(sdr);
                }
            }

            return dt;
        }

        private void TranzactiiTextBox_TextChanged(object sender, EventArgs e)
        {
            if (TranzactiiTextBox.Text.Trim() == string.Empty)
            {
                LoadTransactions();
            }

            else
            {
                TranzactiiGridView.DataSource = SearchTransactionById();
            }
        }
        private DataTable SearchTransactionById()
        {
            DataTable table = new DataTable();

            using (SqlConnection conn = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("ups_SearchTransactionById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransactionId", TranzactiiTextBox.Text);
                    conn.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    table.Load(sdr);
                }
            }
            return table;
        }

        private void TranzactiiGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

