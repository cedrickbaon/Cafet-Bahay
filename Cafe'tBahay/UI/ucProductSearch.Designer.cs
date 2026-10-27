namespace UI
{
    partial class ucProductSearch
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
            button2 = new Button();
            button1 = new Button();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            colProdSearchProductID = new DataGridViewTextBoxColumn();
            colProdSearchProductName = new DataGridViewTextBoxColumn();
            colProdSearchCategory = new DataGridViewTextBoxColumn();
            colProdSearchPrice = new DataGridViewTextBoxColumn();
            colProdSearchStockQuantity = new DataGridViewTextBoxColumn();
            colProdSearchStockStatus = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1376, 191);
            panel1.TabIndex = 0;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(1140, 79);
            button2.Name = "button2";
            button2.Size = new Size(129, 41);
            button2.TabIndex = 5;
            button2.Text = "Clear";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(994, 79);
            button1.Name = "button1";
            button1.Size = new Size(129, 41);
            button1.TabIndex = 4;
            button1.Text = "Search";
            button1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(643, 82);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(316, 38);
            comboBox1.TabIndex = 3;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.ForeColor = Color.Gainsboro;
            textBox1.Location = new Point(186, 82);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(304, 35);
            textBox1.TabIndex = 2;
            textBox1.Text = "Enter Product name or Id...";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(496, 85);
            label2.Name = "label2";
            label2.Size = new Size(158, 30);
            label2.TabIndex = 1;
            label2.Text = "Category Filter: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(17, 85);
            label1.Name = "label1";
            label1.Size = new Size(173, 30);
            label1.TabIndex = 0;
            label1.Text = "Search Products: ";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colProdSearchProductID, colProdSearchProductName, colProdSearchCategory, colProdSearchPrice, colProdSearchStockQuantity, colProdSearchStockStatus });
            dataGridView1.Location = new Point(17, 210);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 45;
            dataGridView1.Size = new Size(1106, 592);
            dataGridView1.TabIndex = 1;
            // 
            // colProdSearchProductID
            // 
            colProdSearchProductID.HeaderText = "Product ID";
            colProdSearchProductID.MinimumWidth = 6;
            colProdSearchProductID.Name = "colProdSearchProductID";
            // 
            // colProdSearchProductName
            // 
            colProdSearchProductName.HeaderText = "Product Name";
            colProdSearchProductName.MinimumWidth = 6;
            colProdSearchProductName.Name = "colProdSearchProductName";
            // 
            // colProdSearchCategory
            // 
            colProdSearchCategory.HeaderText = "Category";
            colProdSearchCategory.MinimumWidth = 6;
            colProdSearchCategory.Name = "colProdSearchCategory";
            // 
            // colProdSearchPrice
            // 
            colProdSearchPrice.HeaderText = "Price";
            colProdSearchPrice.MinimumWidth = 6;
            colProdSearchPrice.Name = "colProdSearchPrice";
            // 
            // colProdSearchStockQuantity
            // 
            colProdSearchStockQuantity.HeaderText = "Stock Quantity";
            colProdSearchStockQuantity.MinimumWidth = 6;
            colProdSearchStockQuantity.Name = "colProdSearchStockQuantity";
            // 
            // colProdSearchStockStatus
            // 
            colProdSearchStockStatus.HeaderText = "Stock Status";
            colProdSearchStockStatus.MinimumWidth = 6;
            colProdSearchStockStatus.Name = "colProdSearchStockStatus";
            // 
            // ucProductSearch
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Name = "ucProductSearch";
            Size = new Size(1290, 819);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private Label label2;
        private Label label1;
        private Button button2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn colProdSearchProductID;
        private DataGridViewTextBoxColumn colProdSearchProductName;
        private DataGridViewTextBoxColumn colProdSearchCategory;
        private DataGridViewTextBoxColumn colProdSearchPrice;
        private DataGridViewTextBoxColumn colProdSearchStockQuantity;
        private DataGridViewTextBoxColumn colProdSearchStockStatus;
    }
}
