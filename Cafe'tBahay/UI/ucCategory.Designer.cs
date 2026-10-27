namespace UI
{
    partial class ucCategory
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
            label1 = new Label();
            textBox1 = new TextBox();
            richTextBox1 = new RichTextBox();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            label2 = new Label();
            label3 = new Label();
            richTextBox2 = new RichTextBox();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            textBox2 = new TextBox();
            label4 = new Label();
            colCategoryCategoryID = new DataGridViewTextBoxColumn();
            colCategoryCatName = new DataGridViewTextBoxColumn();
            colCategoryDescription = new DataGridViewTextBoxColumn();
            colCategoryNotesRemarks = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(32, 41);
            label1.Name = "label1";
            label1.Size = new Size(163, 30);
            label1.TabIndex = 0;
            label1.Text = "Category Name:";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(32, 86);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(437, 35);
            textBox1.TabIndex = 1;
            // 
            // richTextBox1
            // 
            richTextBox1.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox1.Location = new Point(32, 216);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(437, 180);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(15, 713);
            button1.Name = "button1";
            button1.Size = new Size(104, 37);
            button1.TabIndex = 3;
            button1.Text = "Add New";
            button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colCategoryCategoryID, colCategoryCatName, colCategoryDescription, colCategoryNotesRemarks });
            dataGridView1.Location = new Point(559, 95);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 45;
            dataGridView1.Size = new Size(929, 704);
            dataGridView1.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(richTextBox2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(richTextBox1);
            panel1.Location = new Point(18, 17);
            panel1.Name = "panel1";
            panel1.Size = new Size(505, 782);
            panel1.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(32, 167);
            label2.Name = "label2";
            label2.Size = new Size(123, 30);
            label2.TabIndex = 2;
            label2.Text = "Description:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(32, 453);
            label3.Name = "label3";
            label3.Size = new Size(159, 30);
            label3.TabIndex = 3;
            label3.Text = "Notes\\Remarks:";
            // 
            // richTextBox2
            // 
            richTextBox2.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox2.Location = new Point(32, 495);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(437, 180);
            richTextBox2.TabIndex = 4;
            richTextBox2.Text = "";
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(385, 713);
            button2.Name = "button2";
            button2.Size = new Size(104, 37);
            button2.TabIndex = 5;
            button2.Text = "Clear";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(143, 713);
            button3.Name = "button3";
            button3.Size = new Size(104, 37);
            button3.TabIndex = 5;
            button3.Text = "Update";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.Location = new Point(263, 713);
            button4.Name = "button4";
            button4.Size = new Size(104, 37);
            button4.TabIndex = 6;
            button4.Text = "Delete";
            button4.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(1215, 36);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(273, 35);
            textBox2.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(1129, 41);
            label4.Name = "label4";
            label4.Size = new Size(80, 30);
            label4.TabIndex = 7;
            label4.Text = "Search:";
            // 
            // colCategoryCategoryID
            // 
            colCategoryCategoryID.HeaderText = "Category ID";
            colCategoryCategoryID.MinimumWidth = 6;
            colCategoryCategoryID.Name = "colCategoryCategoryID";
            // 
            // colCategoryCatName
            // 
            colCategoryCatName.HeaderText = "Category Name";
            colCategoryCatName.MinimumWidth = 6;
            colCategoryCatName.Name = "colCategoryCatName";
            // 
            // colCategoryDescription
            // 
            colCategoryDescription.HeaderText = "Description";
            colCategoryDescription.MinimumWidth = 6;
            colCategoryDescription.Name = "colCategoryDescription";
            // 
            // colCategoryNotesRemarks
            // 
            colCategoryNotesRemarks.HeaderText = "Notes\\Remarks";
            colCategoryNotesRemarks.MinimumWidth = 6;
            colCategoryNotesRemarks.Name = "colCategoryNotesRemarks";
            // 
            // ucCategory
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Name = "ucCategory";
            Size = new Size(1518, 816);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private RichTextBox richTextBox1;
        private Button button1;
        private DataGridView dataGridView1;
        private Panel panel1;
        private RichTextBox richTextBox2;
        private Label label3;
        private Label label2;
        private DataGridViewTextBoxColumn colCategoryCategoryID;
        private DataGridViewTextBoxColumn colCategoryCatName;
        private DataGridViewTextBoxColumn colCategoryDescription;
        private DataGridViewTextBoxColumn colCategoryNotesRemarks;
        private Button button4;
        private Button button3;
        private Button button2;
        private TextBox textBox2;
        private Label label4;
    }
}
