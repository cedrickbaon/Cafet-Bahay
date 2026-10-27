namespace UI
{
    partial class ucInventoryandSales
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
            dateTimePicker1 = new DateTimePicker();
            comboBox1 = new ComboBox();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            colInventorySalesProductID = new DataGridViewTextBoxColumn();
            colInventorySalesProductName = new DataGridViewTextBoxColumn();
            colInventorySalesCategory = new DataGridViewTextBoxColumn();
            colInventorySalesCurrentStock = new DataGridViewTextBoxColumn();
            colInventorySalesStockStatus = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker1.Location = new Point(196, 248);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(328, 35);
            dateTimePicker1.TabIndex = 3;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(652, 245);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(294, 38);
            comboBox1.TabIndex = 4;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colInventorySalesProductID, colInventorySalesProductName, colInventorySalesCategory, colInventorySalesCurrentStock, colInventorySalesStockStatus });
            dataGridView1.Location = new Point(54, 300);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 45;
            dataGridView1.Size = new Size(1351, 477);
            dataGridView1.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightGreen;
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(96, 90);
            panel1.Name = "panel1";
            panel1.Size = new Size(601, 137);
            panel1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18.3396225F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(63, 30);
            label1.Name = "label1";
            label1.Size = new Size(366, 37);
            label1.TabIndex = 0;
            label1.Text = "Inventory and Sales Report";
            label1.Click += label1_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.SandyBrown;
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label7);
            panel2.Location = new Point(731, 90);
            panel2.Name = "panel2";
            panel2.Size = new Size(601, 137);
            panel2.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(63, 248);
            label2.Name = "label2";
            label2.Size = new Size(127, 30);
            label2.TabIndex = 8;
            label2.Text = "Date Range:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(545, 248);
            label3.Name = "label3";
            label3.Size = new Size(101, 30);
            label3.TabIndex = 9;
            label3.Text = "Category:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 19.6981125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(117, 11);
            label4.Name = "label4";
            label4.Size = new Size(240, 40);
            label4.TabIndex = 0;
            label4.Text = "Total Sales Today";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 18.3396225F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(117, 69);
            label5.Name = "label5";
            label5.Size = new Size(118, 37);
            label5.TabIndex = 1;
            label5.Text = "P 15,003";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 18.3396225F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(89, 79);
            label6.Name = "label6";
            label6.Size = new Size(163, 37);
            label6.TabIndex = 3;
            label6.Text = "3 Items Low";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 19.6981125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(89, 21);
            label7.Name = "label7";
            label7.Size = new Size(234, 40);
            label7.TabIndex = 2;
            label7.Text = "Low Stock Alerts";
            // 
            // colInventorySalesProductID
            // 
            colInventorySalesProductID.HeaderText = "Product ID";
            colInventorySalesProductID.MinimumWidth = 6;
            colInventorySalesProductID.Name = "colInventorySalesProductID";
            // 
            // colInventorySalesProductName
            // 
            colInventorySalesProductName.HeaderText = "Product Name";
            colInventorySalesProductName.MinimumWidth = 6;
            colInventorySalesProductName.Name = "colInventorySalesProductName";
            // 
            // colInventorySalesCategory
            // 
            colInventorySalesCategory.HeaderText = "Category";
            colInventorySalesCategory.MinimumWidth = 6;
            colInventorySalesCategory.Name = "colInventorySalesCategory";
            // 
            // colInventorySalesCurrentStock
            // 
            colInventorySalesCurrentStock.HeaderText = "Current Stock";
            colInventorySalesCurrentStock.MinimumWidth = 6;
            colInventorySalesCurrentStock.Name = "colInventorySalesCurrentStock";
            // 
            // colInventorySalesStockStatus
            // 
            colInventorySalesStockStatus.HeaderText = "Stock Status";
            colInventorySalesStockStatus.MinimumWidth = 6;
            colInventorySalesStockStatus.Name = "colInventorySalesStockStatus";
            // 
            // ucInventoryandSales
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Controls.Add(comboBox1);
            Controls.Add(dateTimePicker1);
            Name = "ucInventoryandSales";
            Size = new Size(1432, 803);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private ComboBox comboBox1;
        private DataGridView dataGridView1;
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Label label5;
        private Label label4;
        private Label label2;
        private Label label3;
        private DataGridViewTextBoxColumn colInventorySalesProductID;
        private DataGridViewTextBoxColumn colInventorySalesProductName;
        private DataGridViewTextBoxColumn colInventorySalesCategory;
        private DataGridViewTextBoxColumn colInventorySalesCurrentStock;
        private DataGridViewTextBoxColumn colInventorySalesStockStatus;
        private Label label6;
        private Label label7;
    }
}
