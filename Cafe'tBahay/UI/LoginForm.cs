namespace UI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnClickAdmin_Click(object sender, EventArgs e)
        {
            AdminLoginForm adminForm = new AdminLoginForm();
            adminForm.Show();
            this.Hide();
        }
        private void btnClickCashier_Click_1(object sender, EventArgs e)
        {
            CashierLoginForm cashierForm = new CashierLoginForm();
            cashierForm.Show();
            this.Hide();
        }
    }
}
