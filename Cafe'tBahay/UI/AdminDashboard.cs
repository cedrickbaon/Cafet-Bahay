using System;
using System.Windows.Forms;

namespace UI
{
    public partial class AdminDashboard : Form
    {
            public AdminDashboard()
        {
            InitializeComponent();

        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            try
            {
                // Confirms the signed-in account is still an Admin.
                AppServices.Users.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
                Close();
            }
        }

        private void ShowPage(UserControl page)
        {
            pnlContent.Controls.Clear();

            page.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(page);

            page.Show();
        }

        private void btnSupplier_Click(
            object sender,
            EventArgs e)
        {
            ShowPage(new ucSupplier());
        }

        private void btnInventoryandSales_Click_1(object sender, EventArgs e)
        {
            ShowPage(new ucInventoryandSales());
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            ShowPage(new ucCategory());
        }

        private void btnUserRole_Click(object sender, EventArgs e)
        {
            ShowPage(new ucUserRole());
        }

        private void btnProductMaintenance_Click(object sender, EventArgs e)
        {
            ShowPage(new UcProductMaintenance());
        }

        private void btnProductSearch_Click(object sender, EventArgs e)
        {
            ShowPage(new ucProductSearch());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}