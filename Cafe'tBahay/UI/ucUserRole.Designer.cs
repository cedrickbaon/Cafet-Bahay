namespace UI
{
    partial class ucUserRole
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            colUserName = new DataGridViewTextBoxColumn();
            colUserRole = new DataGridViewComboBoxColumn();
            colStatus = new DataGridViewComboBoxColumn();
            label1 = new Label();
            panel1 = new Panel();
            btnUserRoleCancel = new Button();
            cmbUserRoleStatus = new ComboBox();
            label5 = new Label();
            this.btnUserRoleSaveChanges = new Button();
            label4 = new Label();
            label3 = new Label();
            cmbUserRolePickUserrole = new ComboBox();
            label2 = new Label();
            txtUserRoleAddUserName = new TextBox();
            this.btnUserRoleEditUser = new Button();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colUserName, colUserRole, colStatus });
            dataGridView1.GridColor = SystemColors.ActiveBorder;
            dataGridView1.Location = new Point(79, 238);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 45;
            dataGridView1.Size = new Size(753, 528);
            dataGridView1.TabIndex = 0;
            // 
            // colUserName
            // 
            colUserName.HeaderText = "Username";
            colUserName.MinimumWidth = 6;
            colUserName.Name = "colUserName";
            // 
            // colUserRole
            // 
            colUserRole.HeaderText = "User Role";
            colUserRole.MinimumWidth = 6;
            colUserRole.Name = "colUserRole";
            colUserRole.Resizable = DataGridViewTriState.True;
            colUserRole.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            colStatus.Resizable = DataGridViewTriState.True;
            colStatus.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 25.8113213F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(79, 47);
            label1.Name = "label1";
            label1.Size = new Size(464, 46);
            label1.TabIndex = 1;
            label1.Text = "User Role Management";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(btnUserRoleCancel);
            panel1.Controls.Add(cmbUserRoleStatus);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(this.btnUserRoleSaveChanges);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(cmbUserRolePickUserrole);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtUserRoleAddUserName);
            panel1.Location = new Point(875, 321);
            panel1.Name = "panel1";
            panel1.Size = new Size(434, 325);
            panel1.TabIndex = 2;
            // 
            // btnUserRoleCancel
            // 
            btnUserRoleCancel.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUserRoleCancel.Location = new Point(234, 263);
            btnUserRoleCancel.Name = "btnUserRoleCancel";
            btnUserRoleCancel.Size = new Size(159, 39);
            btnUserRoleCancel.TabIndex = 6;
            btnUserRoleCancel.Text = "Cancel";
            btnUserRoleCancel.UseVisualStyleBackColor = true;
            // 
            // cmbUserRoleStatus
            // 
            cmbUserRoleStatus.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbUserRoleStatus.FormattingEnabled = true;
            cmbUserRoleStatus.Location = new Point(138, 181);
            cmbUserRoleStatus.Name = "cmbUserRoleStatus";
            cmbUserRoleStatus.Size = new Size(243, 38);
            cmbUserRoleStatus.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(21, 189);
            label5.Name = "label5";
            label5.Size = new Size(74, 30);
            label5.TabIndex = 5;
            label5.Text = "Status:";
            // 
            // btnUserRoleSaveChanges
            // 
            this.btnUserRoleSaveChanges.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnUserRoleSaveChanges.Location = new Point(44, 263);
            this.btnUserRoleSaveChanges.Name = "btnUserRoleSaveChanges";
            this.btnUserRoleSaveChanges.Size = new Size(159, 39);
            this.btnUserRoleSaveChanges.TabIndex = 4;
            this.btnUserRoleSaveChanges.Text = "Save Changes";
            this.btnUserRoleSaveChanges.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(21, 132);
            label4.Name = "label4";
            label4.Size = new Size(105, 30);
            label4.TabIndex = 4;
            label4.Text = "User Role:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(21, 77);
            label3.Name = "label3";
            label3.Size = new Size(111, 30);
            label3.TabIndex = 3;
            label3.Text = "Username:";
            // 
            // cmbUserRolePickUserrole
            // 
            cmbUserRolePickUserrole.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbUserRolePickUserrole.FormattingEnabled = true;
            cmbUserRolePickUserrole.Location = new Point(138, 132);
            cmbUserRolePickUserrole.Name = "cmbUserRolePickUserrole";
            cmbUserRolePickUserrole.Size = new Size(243, 38);
            cmbUserRolePickUserrole.TabIndex = 2;
            cmbUserRolePickUserrole.SelectedIndexChanged += cmbUserRolePickUserrole_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 19.6981125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(164, 20);
            label2.Name = "label2";
            label2.Size = new Size(139, 40);
            label2.TabIndex = 1;
            label2.Text = "Edit User";
            // 
            // txtUserRoleAddUserName
            // 
            txtUserRoleAddUserName.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUserRoleAddUserName.Location = new Point(138, 77);
            txtUserRoleAddUserName.Name = "txtUserRoleAddUserName";
            txtUserRoleAddUserName.Size = new Size(243, 35);
            txtUserRoleAddUserName.TabIndex = 0;
            // 
            // btnUserRoleEditUser
            // 
            this.btnUserRoleEditUser.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnUserRoleEditUser.Location = new Point(673, 193);
            this.btnUserRoleEditUser.Name = "btnUserRoleEditUser";
            this.btnUserRoleEditUser.Size = new Size(159, 39);
            this.btnUserRoleEditUser.TabIndex = 3;
            this.btnUserRoleEditUser.Text = "Edit User";
            this.btnUserRoleEditUser.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.ForeColor = SystemColors.ScrollBar;
            textBox1.Location = new Point(79, 179);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(381, 35);
            textBox1.TabIndex = 5;
            textBox1.Text = "Search users..";
            // 
            // ucUserRole
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBox1);
            Controls.Add(this.btnUserRoleEditUser);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "ucUserRole";
            Size = new Size(1430, 833);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private DataGridViewTextBoxColumn colUserName;
        private DataGridViewComboBoxColumn colUserRole;
        private DataGridViewComboBoxColumn colStatus;
        private Panel panel1;
        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private Label label5;
        private Label label4;
        private Label label3;
        private ComboBox comboBox1;
        private Label label2;
        private TextBox txtUserRoleAddUserName;
        private Button btnUserRoleCancel;
        private ComboBox cmbUserRoleStatus;
        private ComboBox cmbUserRolePickUserrole;
        private Button btnUserRoleSaveChanges;
        private Button btnUserRoleEditUser;

    }
}
