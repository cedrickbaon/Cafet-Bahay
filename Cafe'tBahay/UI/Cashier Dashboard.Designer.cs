namespace UI
{
    partial class CashierDashboard
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelHeader;

        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Button btnNewSale;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnLogout;


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
            lblTitle = new Label();
            panelSidebar.SuspendLayout();
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
            panelSidebar.Location = new Point(0, 68);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(219, 527);
            panelSidebar.TabIndex = 0;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(22, 26);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(202, 37);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "CAFÉ'T BAHAY";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.ForeColor = Color.White;
            lblSubtitle.Location = new Point(22, 60);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(124, 17);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Cashier POS System";
            // 
            // btnNewSale
            // 
            btnNewSale.BackColor = Color.FromArgb(64, 64, 64);
            btnNewSale.FlatStyle = FlatStyle.Flat;
            btnNewSale.ForeColor = Color.White;
            btnNewSale.Location = new Point(22, 110);
            btnNewSale.Name = "btnNewSale";
            btnNewSale.Size = new Size(175, 38);
            btnNewSale.TabIndex = 2;
            btnNewSale.Text = "New Sale";
            btnNewSale.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(64, 64, 64);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(22, 162);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(175, 38);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Product Search";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.DarkRed;
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(22, 493);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(175, 38);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // panelHeader
            // 
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1050, 68);
            panelHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.Location = new Point(245, 21);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(282, 41);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Cashier Dashboard";
            // 
            // CashierDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 595);
            Controls.Add(panelSidebar);
            Controls.Add(panelHeader);
            Controls.Add(lblTitle);
            Name = "CashierDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Café't Bahay | Cashier Dashboard";
            panelSidebar.ResumeLayout(false);
            panelSidebar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}