namespace UI
{
    partial class CashierDashboard
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelProducts;
        private System.Windows.Forms.Panel panelCart;

        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Button btnNewSale;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.Button btnLogout;

        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.Label lblChange;

        private System.Windows.Forms.TextBox txtPayment;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridView dgvCart;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            panelSidebar = new Panel();
            lblLogo = new Label();
            lblSubtitle = new Label();
            btnNewSale = new Button();
            btnSearch = new Button();
            btnLogout = new Button();
            panelHeader = new Panel();
            panelProducts = new Panel();
            lblProduct = new Label();
            dgvProducts = new DataGridView();
            panelCart = new Panel();
            lblOrder = new Label();
            dgvCart = new DataGridView();
            lblSubtotal = new Label();
            lblTotal = new Label();
            lblPayment = new Label();
            txtPayment = new TextBox();
            lblChange = new Label();
            btnComplete = new Button();
            lblTitle = new Label();
            panelSidebar.SuspendLayout();
            panelProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            panelCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(45, 45, 45);
            panelSidebar.Controls.Add(lblLogo);
            panelSidebar.Controls.Add(lblSubtitle);
            panelSidebar.Controls.Add(btnNewSale);
            panelSidebar.Controls.Add(btnSearch);
            panelSidebar.Controls.Add(btnLogout);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 80);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(250, 620);
            panelSidebar.TabIndex = 0;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(25, 30);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(225, 41);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "CAFÉ'T BAHAY";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.ForeColor = Color.White;
            lblSubtitle.Location = new Point(25, 70);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(139, 20);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Cashier POS System";
            // 
            // btnNewSale
            // 
            btnNewSale.BackColor = Color.FromArgb(64, 64, 64);
            btnNewSale.FlatStyle = FlatStyle.Flat;
            btnNewSale.ForeColor = Color.White;
            btnNewSale.Location = new Point(25, 130);
            btnNewSale.Name = "btnNewSale";
            btnNewSale.Size = new Size(200, 45);
            btnNewSale.TabIndex = 2;
            btnNewSale.Text = "New Sale";
            btnNewSale.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(64, 64, 64);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(25, 190);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(200, 45);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Product Search";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.DarkRed;
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(25, 580);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(200, 45);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // panelHeader
            // 
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1200, 80);
            panelHeader.TabIndex = 1;
            // 
            // panelProducts
            // 
            panelProducts.Controls.Add(lblProduct);
            panelProducts.Controls.Add(dgvProducts);
            panelProducts.Location = new Point(270, 100);
            panelProducts.Name = "panelProducts";
            panelProducts.Size = new Size(400, 500);
            panelProducts.TabIndex = 3;
            // 
            // lblProduct
            // 
            lblProduct.AutoSize = true;
            lblProduct.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblProduct.Location = new Point(10, 10);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(216, 32);
            lblProduct.TabIndex = 0;
            lblProduct.Text = "Product Selection";
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeight = 29;
            dgvProducts.Location = new Point(10, 60);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.Size = new Size(370, 400);
            dgvProducts.TabIndex = 1;
            // 
            // panelCart
            // 
            panelCart.Controls.Add(lblOrder);
            panelCart.Controls.Add(dgvCart);
            panelCart.Controls.Add(lblSubtotal);
            panelCart.Controls.Add(lblTotal);
            panelCart.Controls.Add(lblPayment);
            panelCart.Controls.Add(txtPayment);
            panelCart.Controls.Add(lblChange);
            panelCart.Controls.Add(btnComplete);
            panelCart.Location = new Point(700, 100);
            panelCart.Name = "panelCart";
            panelCart.Size = new Size(430, 500);
            panelCart.TabIndex = 4;
            // 
            // lblOrder
            // 
            lblOrder.AutoSize = true;
            lblOrder.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblOrder.Location = new Point(10, 10);
            lblOrder.Name = "lblOrder";
            lblOrder.Size = new Size(174, 32);
            lblOrder.TabIndex = 0;
            lblOrder.Text = "Current Order";
            // 
            // dgvCart
            // 
            dgvCart.ColumnHeadersHeight = 29;
            dgvCart.Location = new Point(10, 60);
            dgvCart.Name = "dgvCart";
            dgvCart.RowHeadersWidth = 51;
            dgvCart.Size = new Size(400, 200);
            dgvCart.TabIndex = 1;
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Location = new Point(10, 280);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(108, 20);
            lblSubtotal.TabIndex = 2;
            lblSubtotal.Text = "Subtotal: ₱0.00";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(10, 320);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(85, 20);
            lblTotal.TabIndex = 3;
            lblTotal.Text = "Total: ₱0.00";
            // 
            // lblPayment
            // 
            lblPayment.AutoSize = true;
            lblPayment.Location = new Point(10, 360);
            lblPayment.Name = "lblPayment";
            lblPayment.Size = new Size(68, 20);
            lblPayment.TabIndex = 4;
            lblPayment.Text = "Payment:";
            // 
            // txtPayment
            // 
            txtPayment.Location = new Point(100, 355);
            txtPayment.Name = "txtPayment";
            txtPayment.Size = new Size(100, 27);
            txtPayment.TabIndex = 5;
            // 
            // lblChange
            // 
            lblChange.AutoSize = true;
            lblChange.Location = new Point(10, 400);
            lblChange.Name = "lblChange";
            lblChange.Size = new Size(102, 20);
            lblChange.TabIndex = 6;
            lblChange.Text = "Change: ₱0.00";
            // 
            // btnComplete
            // 
            btnComplete.BackColor = Color.DarkRed;
            btnComplete.ForeColor = Color.White;
            btnComplete.Location = new Point(10, 450);
            btnComplete.Name = "btnComplete";
            btnComplete.Size = new Size(250, 45);
            btnComplete.TabIndex = 7;
            btnComplete.Text = "COMPLETE SALE";
            btnComplete.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.Location = new Point(280, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(318, 46);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Cashier Dashboard";
            // 
            // CashierDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 700);
            Controls.Add(panelSidebar);
            Controls.Add(panelHeader);
            Controls.Add(lblTitle);
            Controls.Add(panelProducts);
            Controls.Add(panelCart);
            Name = "CashierDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Café't Bahay | Cashier Dashboard";
            panelSidebar.ResumeLayout(false);
            panelSidebar.PerformLayout();
            panelProducts.ResumeLayout(false);
            panelProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            panelCart.ResumeLayout(false);
            panelCart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}