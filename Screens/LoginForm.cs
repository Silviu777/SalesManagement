using Proiect.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using Proiect.Screens;

namespace Proiect
{
    public partial class LoginForm : MetroFramework.Forms.MetroForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }


        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                using (SqlConnection con = new SqlConnection(ApplicationSetting.ConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_Login_VerifyLoginDetails", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserName", UserNameTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", PasswordTextBox.Text.Trim());

                        con.Open();
                        SqlDataReader sdr = cmd.ExecuteReader();

                        if (sdr.Read())
                        {
                            this.Hide();
                            DashboardForm df = new DashboardForm();
                            df.Show();
                        }
                        
                        else
                        {
                            MessageBox.Show("Unul dintre parametri este introdus gresit", "Esuat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
            }
        }

        private bool isValid()
        {
            if (UserNameTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Numele utilizatorului este obligatoriu!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UserNameTextBox.Focus();
                return false;
            }

            if (PasswordTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Parola este obligatorie", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PasswordTextBox.Focus();
                return false;
            }

            return true;
        }

        private void PasswordTextBox_Click(object sender, EventArgs e)
        {

        }
    }
}
