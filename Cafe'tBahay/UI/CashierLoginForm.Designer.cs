namespace UI
{
    partial class CashierLoginForm
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
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            label4 = new Label();
            label3 = new Label();
            txtCashierPassword = new TextBox();
            button1 = new Button();
            txtCashierUserName = new TextBox();
            btnAdminLoginButton = new Button();
            label2 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(label1);
            panel1.ForeColor = SystemColors.AppWorkspace;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(870, 59);
            panel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 18.3396225F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(39, 9);
            label1.Name = "label1";
            label1.Size = new Size(767, 33);
            label1.TabIndex = 0;
            label1.Text = "C a f e ’ t  B a h a y     ——    Sales and Inventory System";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.BackColor = SystemColors.ControlDark;
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(txtCashierPassword);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(txtCashierUserName);
            panel2.Controls.Add(btnAdminLoginButton);
            panel2.Controls.Add(label2);
            panel2.ForeColor = SystemColors.ActiveBorder;
            panel2.Location = new Point(118, 101);
            panel2.Name = "panel2";
            panel2.Size = new Size(635, 385);
            panel2.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 16.3018875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(67, 212);
            label4.Name = "label4";
            label4.Size = new Size(143, 30);
            label4.TabIndex = 7;
            label4.Text = "Password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 16.3018875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(67, 105);
            label3.Name = "label3";
            label3.Size = new Size(149, 30);
            label3.TabIndex = 6;
            label3.Text = "Username:";
            // 
            // txtCashierPassword
            // 
            txtCashierPassword.Font = new Font("Tahoma", 23.7735844F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCashierPassword.ForeColor = Color.Black;
            txtCashierPassword.Location = new Point(67, 245);
            txtCashierPassword.Name = "txtCashierPassword";
            txtCashierPassword.Size = new Size(506, 50);
            txtCashierPassword.TabIndex = 5;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = Color.Gray;
            button1.FlatAppearance.BorderColor = SystemColors.ActiveBorder;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Tahoma", 16.3018875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(202, 311);
            button1.Name = "button1";
            button1.Size = new Size(198, 56);
            button1.TabIndex = 4;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // txtCashierUserName
            // 
            txtCashierUserName.Font = new Font("Tahoma", 23.7735844F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCashierUserName.ForeColor = Color.Black;
            txtCashierUserName.Location = new Point(67, 138);
            txtCashierUserName.Name = "txtCashierUserName";
            txtCashierUserName.Size = new Size(506, 50);
            txtCashierUserName.TabIndex = 2;
            // 
            // btnAdminLoginButton
            // 
            btnAdminLoginButton.Anchor = AnchorStyles.None;
            btnAdminLoginButton.BackColor = Color.Gray;
            btnAdminLoginButton.FlatAppearance.BorderColor = SystemColors.ActiveBorder;
            btnAdminLoginButton.FlatAppearance.BorderSize = 0;
            btnAdminLoginButton.FlatStyle = FlatStyle.Flat;
            btnAdminLoginButton.Font = new Font("Tahoma", 16.3018875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdminLoginButton.ForeColor = SystemColors.ActiveCaptionText;
            btnAdminLoginButton.Location = new Point(424, 447);
            btnAdminLoginButton.Name = "btnAdminLoginButton";
            btnAdminLoginButton.Size = new Size(198, 56);
            btnAdminLoginButton.TabIndex = 1;
            btnAdminLoginButton.Text = "Login";
            btnAdminLoginButton.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(129, 37);
            label2.Name = "label2";
            label2.Size = new Size(387, 64);
            label2.TabIndex = 0;
            label2.Text = "Cashier Login";
            // 
            // CashierLoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(867, 541);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "CashierLoginForm";
            Text = "CashierLoginForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private TextBox textBox2;
        private TextBox txtCashierUserName;
        private Button btnAdminLoginButton;
        private Label label2;
        private Button button1;
        private TextBox txtCashierPassword;
        private Label label3;
        private Label label4;
    }
}