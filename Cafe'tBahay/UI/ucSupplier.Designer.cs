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
            txtEmailSuppiler = new TextBox();
            txtContactPerson = new TextBox();
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
            colSupplierName = new DataGridViewTextBoxColumn();
            colContactPerson = new DataGridViewTextBoxColumn();
            colPhone = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            btnRemoveSupplier = new Button();
            btnEditSupplier = new Button();
            btnAddItem = new Button();
            pnlAddItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgSupplierItems).BeginInit();
            SuspendLayout();
            // 
            // pnlAddItem
            // 
            pnlAddItem.BackColor = Color.Silver;
            pnlAddItem.Controls.Add(txtEmailSuppiler);
            pnlAddItem.Controls.Add(txtContactPerson);
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
            pnlAddItem.Location = new Point(902, 119);
            pnlAddItem.Name = "pnlAddItem";
            pnlAddItem.Size = new Size(377, 663);
            pnlAddItem.TabIndex = 9;
            pnlAddItem.Visible = false;
            // 
            // txtEmailSuppiler
            // 
            txtEmailSuppiler.Font = new Font("Tahoma", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmailSuppiler.Location = new Point(14, 397);
            txtEmailSuppiler.Name = "txtEmailSuppiler";
            txtEmailSuppiler.Size = new Size(335, 33);
            txtEmailSuppiler.TabIndex = 15;
            // 
            // txtContactPerson
            // 
            txtContactPerson.Font = new Font("Tahoma", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContactPerson.Location = new Point(14, 212);
            txtContactPerson.Name = "txtContactPerson";
            txtContactPerson.Size = new Size(335, 33);
            txtContactPerson.TabIndex = 14;
            // 
            // txtPhoneSupplier
            // 
            txtPhoneSupplier.Font = new Font("Tahoma", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPhoneSupplier.Location = new Point(11, 304);
            txtPhoneSupplier.Name = "txtPhoneSupplier";
            txtPhoneSupplier.Size = new Size(335, 33);
            txtPhoneSupplier.TabIndex = 13;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.ButtonFace;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Tahoma", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(199, 576);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 37);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // cmbStatus
            // 
            cmbStatus.Font = new Font("Tahoma", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(14, 502);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(335, 33);
            cmbStatus.TabIndex = 11;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Tahoma", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(11, 474);
            label9.Name = "label9";
            label9.Size = new Size(77, 25);
            label9.TabIndex = 10;
            label9.Text = "Status:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Tahoma", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(14, 369);
            label8.Name = "label8";
            label8.Size = new Size(70, 25);
            label8.TabIndex = 8;
            label8.Text = "Email:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Tahoma", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(14, 276);
            label7.Name = "label7";
            label7.Size = new Size(77, 25);
            label7.TabIndex = 6;
            label7.Text = "Phone:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(14, 184);
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
            btnSaveChanges.Location = new Point(51, 576);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(120, 37);
            btnSaveChanges.TabIndex = 2;
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
            txtSupplierName.TabIndex = 1;
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
            dtgSupplierItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgSupplierItems.Columns.AddRange(new DataGridViewColumn[] { colSupplierId, colSupplierName, colContactPerson, colPhone, colEmail, colStatus });
            dtgSupplierItems.Location = new Point(143, 109);
            dtgSupplierItems.Name = "dtgSupplierItems";
            dtgSupplierItems.RowHeadersWidth = 45;
            dtgSupplierItems.Size = new Size(707, 714);
            dtgSupplierItems.TabIndex = 8;
            dtgSupplierItems.CellClick += dtgSupplierItems_CellClick;
            // 
            // colSupplierId
            // 
            colSupplierId.HeaderText = "Supplier ID";
            colSupplierId.MinimumWidth = 6;
            colSupplierId.Name = "colSupplierId";
            colSupplierId.ReadOnly = true;
            colSupplierId.Width = 110;
            // 
            // colSupplierName
            // 
            colSupplierName.HeaderText = "Supplier Name";
            colSupplierName.MinimumWidth = 6;
            colSupplierName.Name = "colSupplierName";
            colSupplierName.ReadOnly = true;
            colSupplierName.Width = 110;
            // 
            // colContactPerson
            // 
            colContactPerson.HeaderText = "Contact Person";
            colContactPerson.MinimumWidth = 6;
            colContactPerson.Name = "colContactPerson";
            colContactPerson.ReadOnly = true;
            colContactPerson.Width = 110;
            // 
            // colPhone
            // 
            colPhone.HeaderText = "Phone";
            colPhone.MinimumWidth = 6;
            colPhone.Name = "colPhone";
            colPhone.ReadOnly = true;
            colPhone.Width = 110;
            // 
            // colEmail
            // 
            colEmail.HeaderText = "Email";
            colEmail.MinimumWidth = 6;
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            colEmail.Width = 110;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            colStatus.Width = 110;
            // 
            // btnRemoveSupplier
            // 
            btnRemoveSupplier.Font = new Font("Tahoma", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRemoveSupplier.Location = new Point(598, 45);
            btnRemoveSupplier.Name = "btnRemoveSupplier";
            btnRemoveSupplier.Size = new Size(180, 50);
            btnRemoveSupplier.TabIndex = 7;
            btnRemoveSupplier.Text = "🗑 Remove";
            btnRemoveSupplier.UseVisualStyleBackColor = true;
            btnRemoveSupplier.Click += btnRemoveSupplier_Click;
            // 
            // btnEditSupplier
            // 
            btnEditSupplier.Font = new Font("Tahoma", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEditSupplier.Location = new Point(400, 45);
            btnEditSupplier.Name = "btnEditSupplier";
            btnEditSupplier.Size = new Size(150, 50);
            btnEditSupplier.TabIndex = 6;
            btnEditSupplier.Text = "🖉 Edit";
            btnEditSupplier.UseVisualStyleBackColor = true;
            btnEditSupplier.Click += btnEditSupplier_Click;
            // 
            // btnAddItem
            // 
            btnAddItem.Font = new Font("Tahoma", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddItem.Location = new Point(172, 45);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(190, 50);
            btnAddItem.TabIndex = 5;
            btnAddItem.Text = "+ Add New";
            btnAddItem.UseVisualStyleBackColor = true;
            btnAddItem.Click += btnAddItem_Click;
            // 
            // ucSupplier
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlAddItem);
            Controls.Add(dtgSupplierItems);
            Controls.Add(btnRemoveSupplier);
            Controls.Add(btnEditSupplier);
            Controls.Add(btnAddItem);
            Name = "ucSupplier";
            Size = new Size(1713, 956);
            pnlAddItem.ResumeLayout(false);
            pnlAddItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgSupplierItems).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlAddItem;
        private Button btnRemoveSupplier;
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
        private DataGridViewTextBoxColumn colSupplierId;
        private DataGridViewTextBoxColumn colSupplierName;
        private DataGridViewTextBoxColumn colContactPerson;
        private DataGridViewTextBoxColumn colPhone;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colStatus;
        private Button button2;
        private Button btnEditSupplier;
        private Button btnAddItem;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox txtPhoneSupplier;
    }
}
