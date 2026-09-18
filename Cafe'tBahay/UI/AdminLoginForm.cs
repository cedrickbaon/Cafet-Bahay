using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class AdminLoginForm : Form
    {
        public AdminLoginForm()
        {
            InitializeComponent();
        }
        private void btnAdminLoginButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAdminUserName.Text) || string.IsNullOrWhiteSpace(txtAdminPassword.Text))
            {
                MessageBox.Show("Please enter both username and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtAdminUserName.Text == "admin" && txtAdminPassword.Text == "admin123")
            {
                AdminDashboard adminDashboard = new AdminDashboard();
                adminDashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Admin Username or Password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
