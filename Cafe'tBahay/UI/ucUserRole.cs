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
    public partial class ucUserRole : UserControl
    {
        public ucUserRole()
        {
            InitializeComponent();

            colUserRole.Items.Add("Admin");
            colUserRole.Items.Add("Cashier");

            colStatus.Items.Add("Active");
            colStatus.Items.Add("Inactive");

            cmbUserRolePickUserrole.Items.Add("Admin");
            cmbUserRolePickUserrole.Items.Add("Cashier");

            cmbUserRoleStatus.Items.Add("Active");
            cmbUserRoleStatus.Items.Add("Inactive");
        }

        private void cmbUserRolePickUserrole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
