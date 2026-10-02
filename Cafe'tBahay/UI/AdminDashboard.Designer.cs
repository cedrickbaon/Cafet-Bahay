namespace UI
{
    partial class AdminDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblDateTime = new Label();
            lblAdminName = new Label();
            lblHeaderSubtitle = new Label();
            lblPageTitle = new Label();
            pnlContent = new Panel();
            label1 = new Label();
            lblBrand = new Label();
            lblSubtitle = new Label();
            btnSupplier = new Button();
            btnCategory = new Button();
            btnUserRole = new Button();
            btnProduct = new Button();
            btnProductSearch = new Button();
            btnReports = new Button();
            btnLogout = new Button();
            pnlSidebar = new Panel();
            pnlHeader.SuspendLayout();
            pnlSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(lblDateTime);
            pnlHeader.Controls.Add(lblAdminName);
            pnlHeader.Controls.Add(lblHeaderSubtitle);
            pnlHeader.Controls.Add(lblPageTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(210, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1343, 75);
            pnlHeader.TabIndex = 1;
            // 
            // lblDateTime
            // 
            lblDateTime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDateTime.AutoSize = true;
            lblDateTime.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDateTime.ForeColor = Color.FromArgb(100, 116, 139);
            lblDateTime.Location = new Point(1183, 51);
            lblDateTime.Name = "lblDateTime";
            lblDateTime.Size = new Size(160, 15);
            lblDateTime.TabIndex = 3;
            lblDateTime.Text = "September 18, 2026 | 9:20 PM";
            // 
            // lblAdminName
            // 
            lblAdminName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblAdminName.AutoSize = true;
            lblAdminName.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAdminName.ForeColor = Color.FromArgb(31, 41, 55);
            lblAdminName.Location = new Point(1215, 19);
            lblAdminName.Name = "lblAdminName";
            lblAdminName.Size = new Size(116, 21);
            lblAdminName.TabIndex = 2;
            lblAdminName.Text = "Administrator";
            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHeaderSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblHeaderSubtitle.Location = new Point(24, 51);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new Size(231, 19);
            lblHeaderSubtitle.TabIndex = 1;
            lblHeaderSubtitle.Text = "Overview of Cafe't Bahay operations";
            // 
            // lblPageTitle
            // 
            lblPageTitle.AutoSize = true;
            lblPageTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPageTitle.ForeColor = Color.FromArgb(31, 41, 55);
            lblPageTitle.Location = new Point(24, 9);
            lblPageTitle.Name = "lblPageTitle";
            lblPageTitle.Size = new Size(249, 37);
            lblPageTitle.TabIndex = 0;
            lblPageTitle.Text = "Admin Dashboard";
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.FromArgb(245, 247, 250);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(210, 75);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1343, 718);
            pnlContent.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(207, 0);
            label1.Name = "label1";
            label1.Size = new Size(43, 17);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // lblBrand
            // 
            lblBrand.AutoSize = true;
            lblBrand.Font = new Font("Segoe UI Light", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBrand.ForeColor = Color.White;
            lblBrand.Location = new Point(22, 0);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(160, 32);
            lblBrand.TabIndex = 1;
            lblBrand.Text = "CAFE'T BAHAY";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtitle.ForeColor = Color.Silver;
            lblSubtitle.Location = new Point(25, 41);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(158, 15);
            lblSubtitle.TabIndex = 2;
            lblSubtitle.Text = "Admin Management System";
            // 
            // btnSupplier
            // 
            btnSupplier.Cursor = Cursors.Hand;
            btnSupplier.FlatStyle = FlatStyle.Flat;
            btnSupplier.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSupplier.ForeColor = Color.White;
            btnSupplier.Location = new Point(13, 75);
            btnSupplier.Name = "btnSupplier";
            btnSupplier.Size = new Size(184, 48);
            btnSupplier.TabIndex = 4;
            btnSupplier.Text = "Supplier ";
            btnSupplier.UseVisualStyleBackColor = true;
            btnSupplier.Click += btnSupplier_Click;
            // 
            // btnCategory
            // 
            btnCategory.FlatStyle = FlatStyle.Flat;
            btnCategory.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCategory.ForeColor = Color.White;
            btnCategory.Location = new Point(13, 128);
            btnCategory.Name = "btnCategory";
            btnCategory.Size = new Size(184, 48);
            btnCategory.TabIndex = 5;
            btnCategory.Text = "Category ";
            btnCategory.UseVisualStyleBackColor = true;
            // 
            // btnUserRole
            // 
            btnUserRole.FlatStyle = FlatStyle.Flat;
            btnUserRole.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUserRole.ForeColor = Color.White;
            btnUserRole.Location = new Point(13, 183);
            btnUserRole.Name = "btnUserRole";
            btnUserRole.Size = new Size(184, 48);
            btnUserRole.TabIndex = 6;
            btnUserRole.Text = "User Role Management";
            btnUserRole.UseVisualStyleBackColor = true;
            // 
            // btnProduct
            // 
            btnProduct.FlatStyle = FlatStyle.Flat;
            btnProduct.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnProduct.ForeColor = Color.White;
            btnProduct.Location = new Point(13, 239);
            btnProduct.Name = "btnProduct";
            btnProduct.Size = new Size(184, 48);
            btnProduct.TabIndex = 7;
            btnProduct.Text = "Product Maintenance";
            btnProduct.UseVisualStyleBackColor = true;
            // 
            // btnProductSearch
            // 
            btnProductSearch.FlatStyle = FlatStyle.Flat;
            btnProductSearch.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnProductSearch.ForeColor = Color.White;
            btnProductSearch.Location = new Point(13, 291);
            btnProductSearch.Name = "btnProductSearch";
            btnProductSearch.Size = new Size(184, 48);
            btnProductSearch.TabIndex = 8;
            btnProductSearch.Text = "Product Search";
            btnProductSearch.UseVisualStyleBackColor = true;
            // 
            // btnReports
            // 
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReports.ForeColor = Color.White;
            btnReports.Location = new Point(13, 345);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(184, 37);
            btnReports.TabIndex = 9;
            btnReports.Text = "Inventory && Sales Report";
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(127, 29, 29);
            btnLogout.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(10, 400);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(184, 52);
            btnLogout.TabIndex = 10;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(31, 41, 55);
            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Controls.Add(btnReports);
            pnlSidebar.Controls.Add(btnProductSearch);
            pnlSidebar.Controls.Add(btnProduct);
            pnlSidebar.Controls.Add(btnUserRole);
            pnlSidebar.Controls.Add(btnCategory);
            pnlSidebar.Controls.Add(btnSupplier);
            pnlSidebar.Controls.Add(lblSubtitle);
            pnlSidebar.Controls.Add(lblBrand);
            pnlSidebar.Controls.Add(label1);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(210, 793);
            pnlSidebar.TabIndex = 0;
            // 
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1553, 793);
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);
            Controls.Add(pnlSidebar);
            Name = "AdminDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cafe't Bahay | Admin Dashboard";
            WindowState = FormWindowState.Maximized;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlSidebar.ResumeLayout(false);
            pnlSidebar.PerformLayout();
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderSubtitle;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Label lblAdminName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Button btnUserRole;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnProductSearch;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnlSidebar;
    }
}

