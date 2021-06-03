using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Proiect.General;

namespace Proiect.Screens.Clienti
{
    public partial class ClientiRecord : MetroFramework.Forms.MetroForm
    {
        public ClientiRecord()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClientiRecord_Load(object sender, EventArgs e)
        {
            LoadAllCustomersData();
        }

        private void LoadAllCustomersData()
        {
            ClientiDataGridView.DataSource = GetData();
            ClientiDataGridView.Columns[0].Visible = false;
        }

        private DataTable GetData()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from Customers", conn))
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
            if (ClientiTextBox.Text.Trim() == string.Empty)
            {
                LoadAllCustomersData();
            }

            else
            {
                ClientiDataGridView.DataSource = SearchClientByNume();
            }
        }

        private object SearchClientByNume()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("Select CustomerID, Name, Mobile, Address from Customers Where Name Like '%' + @Name + '%'", conn))
                {
                    cmd.Parameters.AddWithValue("@Name", ClientiTextBox.Text);
                    conn.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    dt.Load(sdr);
                }
            }
            return dt;
        }

        private void ClientiDataGridView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int row = ClientiDataGridView.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                int idClient = Convert.ToInt32(ClientiDataGridView.Rows[row].Cells[0].Value);

                if (idClient > 0)
                {
                    ClientNou cn = new ClientNou();
                    cn.IsUpdate = true;
                    cn.idClient = idClient;
                    cn.ShowDialog();
                    LoadAllCustomersData();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Eroare : " + exc.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClientiDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

