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
    public partial class NewLogin : Form
    {
        public NewLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;


            if (username == "cashier" && password == "cashier123")
            {
                Cashier_Dashboard cashierDash = new Cashier_Dashboard();
                cashierDash.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid cashier credentials");
                txtPassword.Clear();
            }
        }
    }
}
