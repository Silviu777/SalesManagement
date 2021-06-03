using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proiect.Screens.Produse;
using Proiect.Screens.Clienti;
using Proiect.Screens.Tranzactii;

namespace Proiect.Screens
{
    public partial class DashboardForm : MetroFramework.Forms.MetroForm
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void metroTile6_Click(object sender, EventArgs e)
        {
            ProduseScreen prod = new ProduseScreen();
            prod.Show();
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            ProductsRecord prod = new ProductsRecord();
            prod.Show();
        }

        private void metroTile10_Click(object sender, EventArgs e)
        {
            ClientiRecord cr = new ClientiRecord();
            cr.Show();
        }

        private void metroTile9_Click(object sender, EventArgs e)
        {
            ClientNou cn = new ClientNou();
            cn.Show();       
        }

        private void metroTile7_Click(object sender, EventArgs e)
        {
            Stock stock = new Stock();
            stock.Show();
        }

        private void metroTile2_Click_1(object sender, EventArgs e)
        {
            Transactions transaction = new Transactions();
            transaction.Show();
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            NewTransaction newT = new NewTransaction();
            newT.Show();
        }

    }
}
