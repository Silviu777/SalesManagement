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

namespace Proiect.Screens.Clienti
{
    public partial class ClientNou : MetroFramework.Forms.MetroForm
    {
        public ClientNou()
        {
            InitializeComponent();
        }

        public int idClient { get; set; }
        public bool IsUpdate { get; set; }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                if (this.IsUpdate)
                {
                    using (SqlConnection conn = new SqlConnection(ApplicationSetting.ConnectionString()))
                    {
                        using (SqlCommand cmd = new SqlCommand("usp_ClientUpdateById", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Name", NumeClientTextBox.Text);
                            cmd.Parameters.AddWithValue("@Mobile", TelefonTextBox.Text);
                            cmd.Parameters.AddWithValue("@Address", AdresaTextBox.Text);
                            cmd.Parameters.AddWithValue("@IdClient", this.idClient);

                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Datele clientului au fost actualizate cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ClearInfo();
                        }
                    }
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(ApplicationSetting.ConnectionString()))
                    {
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO Customers(Name, Mobile, Address) VALUES(@Name, @Mobile, @Address)", conn))
                        {
                            cmd.Parameters.AddWithValue("@Name", NumeClientTextBox.Text);
                            cmd.Parameters.AddWithValue("@Mobile", TelefonTextBox.Text);
                            cmd.Parameters.AddWithValue("@Address", AdresaTextBox.Text);

                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Clientul a fost adaugat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                }
            }
        }

        private void ClearInfo()
        {
            NumeClientTextBox.Clear();
            TelefonTextBox.Clear();
            AdresaTextBox.Clear();

            NumeClientTextBox.Focus();
            this.IsUpdate = false;
            this.idClient = 0;
        }

        private bool isValid()
        {
            if (NumeClientTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Numele clientului este necesar!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NumeClientTextBox.Focus();
                return false;
            }
            return true;
        }

        private void ClientNouButton_Click(object sender, EventArgs e)
        {
            NumeClientTextBox.Clear();
            TelefonTextBox.Clear();
            AdresaTextBox.Clear();

            NumeClientTextBox.Focus();
        }

        private void ClientNou_Load(object sender, EventArgs e)
        {
            if (this.IsUpdate)
            {
                LoadDataMap();
            }
        }

        private void LoadDataMap()
        {
            DataTable tabelDate = GetDataClient();
            DataRow row;
            row = tabelDate.Rows[0];

            NumeClientTextBox.Text = row["Name"].ToString();
            TelefonTextBox.Text = row["Mobile"].ToString();
            AdresaTextBox.Text = row["Address"].ToString();
        }

        private DataTable GetDataClient()
        {
            DataTable table = new DataTable();

            using (SqlConnection conn = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ClientGetDataByID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idClient", this.idClient);
                    conn.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    table.Load(sdr);
                }
            }
            return table;
        }
    }
}
