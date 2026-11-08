using System;
using System.Data;
using System.Windows.Forms;
namespace UI
{
    public partial class ucUserRole : UserControl
    {
        DataGridView grid; TextBox username, password; ComboBox role;
        public ucUserRole() { InitializeComponent(); Build(); RefreshList(); }
        void Build()
        {
            var panel=UiToolkit.Layout(this,"User Role Management",130);
            var bar=UiToolkit.Bar(); panel.Controls.Add(bar,0,1);
            username=UiToolkit.Text(bar,"Username",145);
            password=UiToolkit.Text(bar,"Password",145); password.UseSystemPasswordChar=true;
            role=UiToolkit.Combo(bar,"Role",110); role.Items.AddRange(new object[]{"Admin","Cashier"}); role.SelectedIndex=1;
            UiToolkit.Button(bar,"Add Account",Add);
            UiToolkit.Button(bar,"Change Role",ChangeRole);
            UiToolkit.Button(bar,"Reset Password / Unlock",ResetPassword);
            UiToolkit.Button(bar,"Delete Selected",Delete);
            UiToolkit.Button(bar,"Refresh",RefreshList);
            grid=UiToolkit.Grid(); panel.Controls.Add(grid,0,2);
        }
        void RefreshList() { grid.DataSource=AppServices.Users.GetAll(); }
        void Add()
        {
            AppServices.Users.Create(username.Text.Trim(),password.Text,Convert.ToString(role.SelectedItem));
            RefreshList(); password.Clear(); UiToolkit.Info("Account created.");
        }
        void ChangeRole()
        {
            AppServices.Users.ChangeRole(UiToolkit.Id(UiToolkit.Selected(grid)),Convert.ToString(role.SelectedItem));
            RefreshList(); UiToolkit.Info("Role updated.");
        }
        void ResetPassword()
        {
            AppServices.Users.ResetPasswordAndUnlock(UiToolkit.Id(UiToolkit.Selected(grid)),password.Text);
            password.Clear(); RefreshList(); UiToolkit.Info("Password reset and account unlocked.");
        }
        void Delete()
        {
            int id=UiToolkit.Id(UiToolkit.Selected(grid));
            if(MessageBox.Show("Delete this account?", "Confirm", MessageBoxButtons.YesNo)==DialogResult.Yes)
            { AppServices.Users.Delete(id); RefreshList(); }
        }
        private void cmbUserRolePickUserrole_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
