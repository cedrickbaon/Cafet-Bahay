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
    public partial class CashierLoginForm : Form
    {
        public CashierLoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCashierUserName.Text) || string.IsNullOrWhiteSpace(txtCashierPassword.Text))
            {
                MessageBox.Show("Please enter both username and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtCashierUserName.Text == "cashier" && txtCashierPassword.Text == "cashier123")
            {
                Cashier_Dashboard cashierDashboard = new Cashier_Dashboard();
                cashierDashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Cashier Username or Password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
