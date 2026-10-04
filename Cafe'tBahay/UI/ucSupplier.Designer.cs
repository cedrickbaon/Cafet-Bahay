namespace UI
{
    partial class ucSupplier
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtEmailSuppiler;
        private System.Windows.Forms.TextBox txtContactPerson;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlAddItem = new Panel();
            txtProductSupplied = new TextBox();
            txtEmailSuppiler = new TextBox();
            txtContactPerson = new TextBox();
            lblProductSupplied = new Label();
            txtPhoneSupplier = new TextBox();
            btnCancel = new Button();
            cmbStatus = new ComboBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            btnSaveChanges = new Button();
            txtSupplierName = new TextBox();
            lblAddOrEdit = new Label();
            dtgSupplierItems = new DataGridView();
            colSupplierId = new DataGridViewTextBoxColumn();
            colProductSupplied = new DataGridViewTextBoxColumn();
            colSupplierName = new DataGridViewTextBoxColumn();
            colContactPerson = new DataGridViewTextBoxColumn();
            colPhone = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            btnEditSupplier = new Button();
            pnlAddItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgSupplierItems).BeginInit();
            SuspendLayout();
            // 
            // pnlAddItem
            // 
            pnlAddItem.BackColor = Color.Silver;
            pnlAddItem.Controls.Add(txtProductSupplied);
            pnlAddItem.Controls.Add(txtEmailSuppiler);
            pnlAddItem.Controls.Add(txtContactPerson);
            pnlAddItem.Controls.Add(lblProductSupplied);
            pnlAddItem.Controls.Add(txtPhoneSupplier);
            pnlAddItem.Controls.Add(btnCancel);
            pnlAddItem.Controls.Add(cmbStatus);
            pnlAddItem.Controls.Add(label9);
            pnlAddItem.Controls.Add(label8);
            pnlAddItem.Controls.Add(label7);
            pnlAddItem.Controls.Add(label6);
            pnlAddItem.Controls.Add(label5);
            pnlAddItem.Controls.Add(btnSaveChanges);
            pnlAddItem.Controls.Add(txtSupplierName);
            pnlAddItem.Controls.Add(lblAddOrEdit);
            pnlAddItem.Location = new Point(1029, 54);
            pnlAddItem.Name = "pnlAddItem";
            pnlAddItem.Size = new Size(377, 663);
            pnlAddItem.TabIndex = 9;
            pnlAddItem.Visible = false;
            // 
            // txtProductSupplied
            // 
            txtProductSupplied.Font = new Font("Tahoma", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProductSupplied.Location = new Point(14, 204);
            txtProductSupplied.Name = "txtProductSupplied";
            txtProductSupplied.Size = new Size(335, 33);
            txtProductSupplied.TabIndex = 1;
            // 
            // txtEmailSuppiler
            // 
            txtEmailSuppiler.Font = new Font("Tahoma", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmailSuppiler.Location = new Point(18, 448);
            txtEmailSuppiler.Name = "txtEmailSuppiler";
            txtEmailSuppiler.Size = new Size(335, 33);
            txtEmailSuppiler.TabIndex = 4;
            // 
            // txtContactPerson
            // 
            txtContactPerson.Font = new Font("Tahoma", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContactPerson.Location = new Point(17, 287);
            txtContactPerson.Name = "txtContactPerson";
            txtContactPerson.Size = new Size(335, 33);
            txtContactPerson.TabIndex = 2;
            // 
            // lblProductSupplied
            // 
            lblProductSupplied.AutoSize = true;
            lblProductSupplied.Font = new Font("Tahoma", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProductSupplied.Location = new Point(11, 176);
            lblProductSupplied.Name = "lblProductSupplied";
            lblProductSupplied.Size = new Size(179, 25);
            lblProductSupplied.TabIndex = 16;
            lblProductSupplied.Text = "Product Supplied:";
            // 
            // txtPhoneSupplier
            // 
            txtPhoneSupplier.Font = new Font("Tahoma", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPhoneSupplier.Location = new Point(17, 366);
            txtPhoneSupplier.Name = "txtPhoneSupplier";
            txtPhoneSupplier.Size = new Size(335, 33);
            txtPhoneSupplier.TabIndex = 3;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.ButtonFace;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Tahoma", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(199, 592);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 37);
            btnCancel.TabIndex = 12;
            btnCancel.TabStop = false;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // cmbStatus
            // 
            cmbStatus.Font = new Font("Tahoma", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(17, 530);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(335, 33);
            cmbStatus.TabIndex = 5;
            cmbStatus.TabStop = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Tahoma", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(18, 502);
            label9.Name = "label9";
            label9.Size = new Size(77, 25);
            label9.TabIndex = 10;
            label9.Text = "Status:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Tahoma", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(18, 420);
            label8.Name = "label8";
            label8.Size = new Size(70, 25);
            label8.TabIndex = 8;
            label8.Text = "Email:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Tahoma", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(11, 338);
            label7.Name = "label7";
            label7.Size = new Size(77, 25);
            label7.TabIndex = 6;
            label7.Text = "Phone:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(14, 259);
            label6.Name = "label6";
            label6.Size = new Size(160, 25);
            label6.TabIndex = 4;
            label6.Text = "Contact Person:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(14, 95);
            label5.Name = "label5";
            label5.Size = new Size(157, 25);
            label5.TabIndex = 3;
            label5.Text = "Supplier Name:";
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.BackColor = SystemColors.ButtonFace;
            btnSaveChanges.FlatStyle = FlatStyle.Flat;
            btnSaveChanges.Font = new Font("Tahoma", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSaveChanges.Location = new Point(51, 592);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(120, 37);
            btnSaveChanges.TabIndex = 15;
            btnSaveChanges.TabStop = false;
            btnSaveChanges.Text = "Save";
            btnSaveChanges.UseVisualStyleBackColor = false;
            btnSaveChanges.Click += btnSaveChanges_Click;
            // 
            // txtSupplierName
            // 
            txtSupplierName.Font = new Font("Tahoma", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSupplierName.Location = new Point(14, 123);
            txtSupplierName.Name = "txtSupplierName";
            txtSupplierName.Size = new Size(335, 33);
            txtSupplierName.TabIndex = 0;
            // 
            // lblAddOrEdit
            // 
            lblAddOrEdit.AutoSize = true;
            lblAddOrEdit.Font = new Font("Tahoma", 27.8490562F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAddOrEdit.Location = new Point(62, 23);
            lblAddOrEdit.Name = "lblAddOrEdit";
            lblAddOrEdit.Size = new Size(214, 49);
            lblAddOrEdit.TabIndex = 0;
            lblAddOrEdit.Text = "Add Item";
            // 
            // dtgSupplierItems
            // 
            dtgSupplierItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgSupplierItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgSupplierItems.Columns.AddRange(new DataGridViewColumn[] { colSupplierId, colProductSupplied, colSupplierName, colContactPerson, colPhone, colEmail, colStatus });
            dtgSupplierItems.Location = new Point(48, 38);
            dtgSupplierItems.Name = "dtgSupplierItems";
            dtgSupplierItems.RowHeadersWidth = 45;
            dtgSupplierItems.Size = new Size(958, 714);
            dtgSupplierItems.TabIndex = 8;
            dtgSupplierItems.CellClick += dtgSupplierItems_CellClick;
            // 
            // colSupplierId
            // 
            colSupplierId.HeaderText = "Supplier ID";
            colSupplierId.MinimumWidth = 6;
            colSupplierId.Name = "colSupplierId";
            colSupplierId.ReadOnly = true;
            // 
            // colProductSupplied
            // 
            colProductSupplied.HeaderText = "Product Supplied";
            colProductSupplied.MinimumWidth = 6;
            colProductSupplied.Name = "colProductSupplied";
            colProductSupplied.ReadOnly = true;
            // 
            // colSupplierName
            // 
            colSupplierName.HeaderText = "Supplier Name";
            colSupplierName.MinimumWidth = 6;
            colSupplierName.Name = "colSupplierName";
            colSupplierName.ReadOnly = true;
            // 
            // colContactPerson
            // 
            colContactPerson.HeaderText = "Contact Person";
            colContactPerson.MinimumWidth = 6;
            colContactPerson.Name = "colContactPerson";
            colContactPerson.ReadOnly = true;
            // 
            // colPhone
            // 
            colPhone.HeaderText = "Phone";
            colPhone.MinimumWidth = 6;
            colPhone.Name = "colPhone";
            colPhone.ReadOnly = true;
            // 
            // colEmail
            // 
            colEmail.HeaderText = "Email";
            colEmail.MinimumWidth = 6;
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // btnEditSupplier
            // 
            btnEditSupplier.Font = new Font("Tahoma", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEditSupplier.Location = new Point(48, 767);
            btnEditSupplier.Name = "btnEditSupplier";
            btnEditSupplier.Size = new Size(131, 43);
            btnEditSupplier.TabIndex = 6;
            btnEditSupplier.Text = "🖉 Edit";
            btnEditSupplier.UseVisualStyleBackColor = true;
            btnEditSupplier.Click += btnEditSupplier_Click;
            // 
            // ucSupplier
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlAddItem);
            Controls.Add(dtgSupplierItems);
            Controls.Add(btnEditSupplier);
            Name = "ucSupplier";
            Size = new Size(1713, 956);
            pnlAddItem.ResumeLayout(false);
            pnlAddItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgSupplierItems).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlAddItem;
        private Button btnCancel;
        private ComboBox cmbStatus;
        private Label label9;
        private TextBox textBox4;
        private Label label8;
        private TextBox textBox3;
        private Label label7;
        private TextBox textBox2;
        private Label label6;
        private Label label5;
        private Button btnSaveChanges;
        private TextBox txtSupplierName;
        private Label lblAddOrEdit;
        private DataGridView dtgSupplierItems;
        private Button button2;
        private Button btnEditSupplier;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox txtPhoneSupplier;
        private TextBox txtProductSupplied;
        private Label lblProductSupplied;
        private DataGridViewTextBoxColumn colSupplierId;
        private DataGridViewTextBoxColumn colProductSupplied;
        private DataGridViewTextBoxColumn colSupplierName;
        private DataGridViewTextBoxColumn colContactPerson;
        private DataGridViewTextBoxColumn colPhone;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colStatus;
    }
}
