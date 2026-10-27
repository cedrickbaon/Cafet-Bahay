using System;
using System.Windows.Forms;

namespace UI
{
    public partial class CashierDashboard : Form
    {
        public CashierDashboard()
        {
            InitializeComponent();
        }

        private void ShowPage(UserControl page)
        {
            pnlCashier.Controls.Clear();

            page.Dock = DockStyle.Fill;
            pnlCashier.Controls.Add(page);

            page.Show();
        }
        private void btnNewSale_Click(object sender, EventArgs e)
        {
            ShowPage(new ucNewSales());

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowPage(new ucProductSearch());
        }
    }
}