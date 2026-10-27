namespace UI
{
    partial class UcProductMaintenance
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
            panel1 = new Panel();
            cmbProductMaintenanceSupplierID = new ComboBox();
            cmbProductMaintenanceProductStatus = new ComboBox();
            label8 = new Label();
            cmbProductMaintenanceCategotyID = new ComboBox();
            label7 = new Label();
            txtProductMaintenanceStockQuantity = new TextBox();
            label6 = new Label();
            txtProductMaintenancePrice = new TextBox();
            label5 = new Label();
            label4 = new Label();
            txtProductMaintenanceProductName = new TextBox();
            label3 = new Label();
            txtProductMaintenanceProductID = new TextBox();
            label2 = new Label();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            colProductID = new DataGridViewTextBoxColumn();
            colProductName = new DataGridViewTextBoxColumn();
            colCategoryID = new DataGridViewTextBoxColumn();
            colSupplierID = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colStockQuantity = new DataGridViewTextBoxColumn();
            colProductStatus = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonFace;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(cmbProductMaintenanceSupplierID);
            panel1.Controls.Add(cmbProductMaintenanceProductStatus);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(cmbProductMaintenanceCategotyID);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(txtProductMaintenanceStockQuantity);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtProductMaintenancePrice);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtProductMaintenanceProductName);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtProductMaintenanceProductID);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(346, 822);
            panel1.TabIndex = 0;
            // 
            // cmbProductMaintenanceSupplierID
            // 
            cmbProductMaintenanceSupplierID.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbProductMaintenanceSupplierID.FormattingEnabled = true;
            cmbProductMaintenanceSupplierID.Location = new Point(28, 392);
            cmbProductMaintenanceSupplierID.Name = "cmbProductMaintenanceSupplierID";
            cmbProductMaintenanceSupplierID.Size = new Size(290, 38);
            cmbProductMaintenanceSupplierID.TabIndex = 15;
            // 
            // cmbProductMaintenanceProductStatus
            // 
            cmbProductMaintenanceProductStatus.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbProductMaintenanceProductStatus.FormattingEnabled = true;
            cmbProductMaintenanceProductStatus.Location = new Point(26, 659);
            cmbProductMaintenanceProductStatus.Name = "cmbProductMaintenanceProductStatus";
            cmbProductMaintenanceProductStatus.Size = new Size(290, 38);
            cmbProductMaintenanceProductStatus.TabIndex = 14;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(26, 626);
            label8.Name = "label8";
            label8.Size = new Size(152, 30);
            label8.TabIndex = 13;
            label8.Text = "Product Status:";
            // 
            // cmbProductMaintenanceCategotyID
            // 
            cmbProductMaintenanceCategotyID.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbProductMaintenanceCategotyID.FormattingEnabled = true;
            cmbProductMaintenanceCategotyID.Location = new Point(26, 293);
            cmbProductMaintenanceCategotyID.Name = "cmbProductMaintenanceCategotyID";
            cmbProductMaintenanceCategotyID.Size = new Size(290, 38);
            cmbProductMaintenanceCategotyID.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(26, 260);
            label7.Name = "label7";
            label7.Size = new Size(128, 30);
            label7.TabIndex = 11;
            label7.Text = "Category ID:";
            // 
            // txtProductMaintenanceStockQuantity
            // 
            txtProductMaintenanceStockQuantity.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProductMaintenanceStockQuantity.Location = new Point(26, 565);
            txtProductMaintenanceStockQuantity.Name = "txtProductMaintenanceStockQuantity";
            txtProductMaintenanceStockQuantity.Size = new Size(290, 35);
            txtProductMaintenanceStockQuantity.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(26, 532);
            label6.Name = "label6";
            label6.Size = new Size(153, 30);
            label6.TabIndex = 9;
            label6.Text = "Stock Quantity:";
            // 
            // txtProductMaintenancePrice
            // 
            txtProductMaintenancePrice.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProductMaintenancePrice.Location = new Point(26, 472);
            txtProductMaintenancePrice.Name = "txtProductMaintenancePrice";
            txtProductMaintenancePrice.Size = new Size(290, 35);
            txtProductMaintenancePrice.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(26, 439);
            label5.Name = "label5";
            label5.Size = new Size(63, 30);
            label5.TabIndex = 7;
            label5.Text = "Price:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(26, 355);
            label4.Name = "label4";
            label4.Size = new Size(120, 30);
            label4.TabIndex = 5;
            label4.Text = "Supplier ID:";
            // 
            // txtProductMaintenanceProductName
            // 
            txtProductMaintenanceProductName.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProductMaintenanceProductName.Location = new Point(26, 204);
            txtProductMaintenanceProductName.Name = "txtProductMaintenanceProductName";
            txtProductMaintenanceProductName.Size = new Size(290, 35);
            txtProductMaintenanceProductName.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(26, 171);
            label3.Name = "label3";
            label3.Size = new Size(152, 30);
            label3.TabIndex = 3;
            label3.Text = "Product Name:";
            // 
            // txtProductMaintenanceProductID
            // 
            txtProductMaintenanceProductID.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProductMaintenanceProductID.Location = new Point(26, 119);
            txtProductMaintenanceProductID.Name = "txtProductMaintenanceProductID";
            txtProductMaintenanceProductID.Size = new Size(290, 35);
            txtProductMaintenanceProductID.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(26, 86);
            label2.Name = "label2";
            label2.Size = new Size(117, 30);
            label2.TabIndex = 1;
            label2.Text = "Product ID:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 27.8490562F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(26, 17);
            label1.Name = "label1";
            label1.Size = new Size(290, 55);
            label1.TabIndex = 0;
            label1.Text = "Product Entry";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colProductID, colProductName, colCategoryID, colSupplierID, colPrice, colStockQuantity, colProductStatus });
            dataGridView1.Location = new Point(366, 17);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 45;
            dataGridView1.Size = new Size(1194, 787);
            dataGridView1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(12, 714);
            button1.Name = "button1";
            button1.Size = new Size(142, 38);
            button1.TabIndex = 2;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(192, 714);
            button2.Name = "button2";
            button2.Size = new Size(142, 38);
            button2.TabIndex = 16;
            button2.Text = "Update";
            button2.UseVisualStyleBackColor = true;
            // 
            // colProductID
            // 
            colProductID.HeaderText = "Product ID";
            colProductID.MinimumWidth = 6;
            colProductID.Name = "colProductID";
            colProductID.ReadOnly = true;
            // 
            // colProductName
            // 
            colProductName.HeaderText = "Product Name";
            colProductName.MinimumWidth = 6;
            colProductName.Name = "colProductName";
            // 
            // colCategoryID
            // 
            colCategoryID.HeaderText = "Category ID";
            colCategoryID.MinimumWidth = 6;
            colCategoryID.Name = "colCategoryID";
            // 
            // colSupplierID
            // 
            colSupplierID.HeaderText = "Supplier ID";
            colSupplierID.MinimumWidth = 6;
            colSupplierID.Name = "colSupplierID";
            // 
            // colPrice
            // 
            colPrice.HeaderText = "Price";
            colPrice.MinimumWidth = 6;
            colPrice.Name = "colPrice";
            // 
            // colStockQuantity
            // 
            colStockQuantity.HeaderText = "Stock Quantity";
            colStockQuantity.MinimumWidth = 6;
            colStockQuantity.Name = "colStockQuantity";
            // 
            // colProductStatus
            // 
            colProductStatus.HeaderText = "Product Status";
            colProductStatus.MinimumWidth = 6;
            colProductStatus.Name = "colProductStatus";
            // 
            // UcProductMaintenance
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Name = "UcProductMaintenance";
            Size = new Size(1596, 822);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox textBox1;
        private Label label2;
        private Label label1;
        private ComboBox cmbProductMaintenanceSupplierID;
        private Label label7;
        private TextBox textBox5;
        private Label label6;
        private TextBox textBox4;
        private Label label5;
        private TextBox textBox3;
        private Label label4;
        private TextBox txtProductMaintenanceProductName;
        private Label label3;
        private ComboBox cmbProductMaintenanceProductStatus;
        private Label label8;
        private ComboBox cmbProductMaintenanceCategotyID;
        private TextBox txtProductMaintenanceProductID;
        private TextBox txtProductMaintenancePrice;
        private TextBox txtProductMaintenanceStockQuantity;
        private Label label9;
        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private DataGridViewTextBoxColumn colProductID;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colCategoryID;
        private DataGridViewTextBoxColumn colSupplierID;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colStockQuantity;
        private DataGridViewTextBoxColumn colProductStatus;
    }
}
