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
            string username = txtAdminUserName.Text;
            string password = txtAdminPassword.Text;


            if (username == "admin" && password == "admin123")
            {
                AdminDashboard adminDash = new AdminDashboard();
                adminDash.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid admin credentials");
                txtAdminPassword.Clear();
            }
        }
    }
 }

