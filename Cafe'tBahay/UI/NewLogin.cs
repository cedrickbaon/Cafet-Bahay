using System;
using System.Windows.Forms;

namespace UI
{
    public partial class NewLogin : Form
    {
        public NewLogin()
        {
            InitializeComponent();

            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(
            object sender,
            EventArgs e)
        {
            btnLogin.Enabled = false;

            try
            {
                var user = AppServices.Users.Login(
                    txtUserName.Text,
                    txtPassword.Text);

                Form dashboard;

                if (user.Role == "Admin")
                    dashboard = new AdminDashboard();
                else
                    dashboard = new Cashier_Dashboard();

                using (dashboard)
                {
                    Hide();

                    try
                    {
                        dashboard.ShowDialog(this);
                    }
                    finally
                    {
                        AppServices.Users.Logout();

                        Show();

                        txtPassword.Clear();
                        txtUserName.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    this,
                    ex.Message,
                    "Login failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPassword.Clear();
                txtUserName.Focus();
            }
            finally
            {
                btnLogin.Enabled = true;
            }
        }
    }
}