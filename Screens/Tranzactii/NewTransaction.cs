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
    public partial class NewTransaction : MetroFramework.Forms.MetroForm
    {
        public NewTransaction()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                using (SqlConnection conn = new SqlConnection(ApplicationSetting.ConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Transactions(TransactionID, CustomerID, CustomerName, ProductID, ProductName, PurchasePrice) " +
                                                           "VALUES(@TransactionId, @ClientId, @ClientNume, @ProdusId, @ProdusDen, @TranzVal)", conn))
                    {
                        cmd.Parameters.AddWithValue("@TransactionId", TranzactieIDTextBox.Text);
                        cmd.Parameters.AddWithValue("@ClientId", ClientIDTextBox.Text);
                        cmd.Parameters.AddWithValue("@ClientNume", ClientNumeTextBox.Text);
                        cmd.Parameters.AddWithValue("@ProdusId", ProdusIDTextBox.Text);
                        cmd.Parameters.AddWithValue("@ProdusDen", ProdusDenTextBox.Text);
                        cmd.Parameters.AddWithValue("@TranzVal", TranzactieValTextBox.Text);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Tranzactia a fost adaugata cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }

            }
        }
        private bool isValid()
        {
            if (TranzactieIDTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("ID-ul tranzactiei este necesar!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TranzactieIDTextBox.Focus();
                return false;
            }
            return true;
        }

        private void pictureBox1_Click(object sender, EventArgs e) { }
        
    }
}
