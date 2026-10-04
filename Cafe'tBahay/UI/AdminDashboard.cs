using System;
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
        private ucSupplier supplierPage = new ucSupplier();
        private usInventory_Sales reportsPage = new usInventory_Sales();

        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();
            supplierPage.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(supplierPage);
        }
        private void btnInventoryandSales_Click_1(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();
            reportsPage.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(reportsPage);
        }
    }
}