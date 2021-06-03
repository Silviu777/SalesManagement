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

namespace Proiect.Screens.Produse
{
    public partial class ProduseScreen : MetroFramework.Forms.MetroForm
    {
        public ProduseScreen()
        {
            InitializeComponent();
        }

        public bool isUpdate { get; set; }
        private List<int> Sizescart = new List<int>();

        private void CategorieComboBox_SelectedIndexChanged(object sender, EventArgs e) { }
        private void FurnizorComboBox_SelectedIndexChanged(object sender, EventArgs e) { }
        private void ProduseScreen_Load(object sender, EventArgs e)
        {
            if (!this.isUpdate) { }

            IncarcaDataGridView();
            IncarcaDateComboBox();
        }

        private void IncarcaDateComboBox()
        {
            CategorieComboBox.DataSource = GetComboBoxData(1);
            CategorieComboBox.DisplayMember = "Descriere";
            CategorieComboBox.ValueMember = "ID";

            FurnizorComboBox.DataSource = GetComboBoxData(2);
            FurnizorComboBox.DisplayMember = "Descriere";
            FurnizorComboBox.ValueMember = "ID";
        }

        private DataTable GetComboBoxData(int listTypeID)
        {
            DataTable record = new DataTable();

            using (SqlConnection conn = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("ups_ListTypesData_LoadIntoComboBox", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ListTypeID", listTypeID);

                    conn.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    record.Load(sdr);
                }
            }

            return record; 
        }
    

        private void IncarcaDataGridView()
        {
            SizesDataGridView.DataSource = GetSizesdata();
            SizesDataGridView.Columns[0].Visible = false;
        }

        private DataTable GetSizesdata()
        {
            DataTable tabel = new DataTable();

            using (SqlConnection conn = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_Sizes_LoadAllSizes", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ListTypeID", 1);

                    conn.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    tabel.Load(sdr);
                }
            }

            return tabel;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewProdButton_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void ClearControls()
        {
            NumeProdusTextBox.Clear();
            FurnizorComboBox.SelectedIndex = -1;
            CategorieComboBox.SelectedIndex = -1;
            PretAchizitieTextBox.Clear();
            PretVanzareTextBox.Clear();

            foreach (DataGridViewRow row in SizesDataGridView.Rows)
            {
                row.Cells["Selectat"].Value = 0;
            }

            NumeProdusTextBox.Focus();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                Sizescart.Clear();
                LoaddataIntoSizesCart();
                using (SqlConnection conn = new SqlConnection(ApplicationSetting.ConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Products(ProductID, Name, CategoryID, SupplierID, PurchasePrice, SalesPrice) VALUES (@ProductID, @Name, @CategoryID, @SupplierID, @PurchasePrice, @SalesPrice)", conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", ProdusIDTextBox.Text);
                        cmd.Parameters.AddWithValue("@Name", NumeProdusTextBox.Text);
                        cmd.Parameters.AddWithValue("@CategoryID", CategorieComboBox.Text);
                        cmd.Parameters.AddWithValue("@SupplierID", FurnizorComboBox.Text);
                        cmd.Parameters.AddWithValue("@PurchasePrice", PretAchizitieTextBox.Text);
                        cmd.Parameters.AddWithValue("@SalesPrice", PretVanzareTextBox.Text);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Produsul a fost inregistrat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void SalveazaSizes(int _id)
        {
            using (SqlConnection conn = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                foreach (int sizeID in Sizescart)
                {
                    using (SqlCommand cmd = new SqlCommand("usp_Products_InsertProductSizes", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ProductID", _id);
                        cmd.Parameters.AddWithValue("@SizeID", sizeID);

                        cmd.ExecuteNonQuery();
                    }
                }
                
            }
        }

        private void LoaddataIntoSizesCart()
        {
            foreach (DataGridViewRow row in SizesDataGridView.Rows)
            {
                if (row.Cells["Selectat"].Value != null && !DBNull.Value.Equals(row.Cells["Selectat"].Value) && Convert.ToBoolean(row.Cells["Selectat"].Value) == true)
                {
                    Sizescart.Add((int)row.Cells["ID"].Value);
                }

            }
        }

        private bool isValid()
        {
            if (NumeProdusTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Numele produsului este necesar", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NumeProdusTextBox.Focus();
                return false;
            }

            if (PretAchizitieTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Pretul de achizitie al produsului este necesar", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PretAchizitieTextBox.Focus();
                return false;
            }

            return true;
        }

    }

}

        
  