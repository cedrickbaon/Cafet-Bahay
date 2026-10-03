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
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();
            var page = new ucSupplier();
            page.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(page);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();
            var page = new usInventory_Sales();
            page.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(page);
        }
    }
}
