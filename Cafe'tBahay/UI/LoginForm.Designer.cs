namespace UI
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            btnClickCashier = new Button();
            btnClickAdmin = new Button();
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
            panel1.Size = new Size(890, 59);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 18.3396225F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(48, 9);
            label1.Name = "label1";
            label1.Size = new Size(767, 33);
            label1.TabIndex = 0;
            label1.Text = "C a f e ’ t  B a h a y     ——    Sales and Inventory System";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.BackColor = SystemColors.ControlDark;
            panel2.Controls.Add(btnClickCashier);
            panel2.Controls.Add(btnClickAdmin);
            panel2.Controls.Add(label2);
            panel2.ForeColor = SystemColors.ActiveBorder;
            panel2.Location = new Point(136, 130);
            panel2.Name = "panel2";
            panel2.Size = new Size(613, 295);
            panel2.TabIndex = 1;
            // 
            // btnClickCashier
            // 
            btnClickCashier.Anchor = AnchorStyles.None;
            btnClickCashier.BackColor = Color.Gray;
            btnClickCashier.FlatAppearance.BorderColor = SystemColors.ActiveBorder;
            btnClickCashier.FlatAppearance.BorderSize = 0;
            btnClickCashier.FlatStyle = FlatStyle.Flat;
            btnClickCashier.Font = new Font("Tahoma", 16.3018875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClickCashier.ForeColor = SystemColors.ActiveCaptionText;
            btnClickCashier.Location = new Point(357, 182);
            btnClickCashier.Name = "btnClickCashier";
            btnClickCashier.Size = new Size(198, 56);
            btnClickCashier.TabIndex = 2;
            btnClickCashier.Text = "Cashier Login";
            btnClickCashier.UseVisualStyleBackColor = false;
            btnClickCashier.Click += btnClickCashier_Click_1;
            // 
            // btnClickAdmin
            // 
            btnClickAdmin.Anchor = AnchorStyles.None;
            btnClickAdmin.BackColor = Color.Gray;
            btnClickAdmin.FlatAppearance.BorderColor = SystemColors.ActiveBorder;
            btnClickAdmin.FlatAppearance.BorderSize = 0;
            btnClickAdmin.FlatStyle = FlatStyle.Flat;
            btnClickAdmin.Font = new Font("Tahoma", 16.3018875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClickAdmin.ForeColor = SystemColors.ActiveCaptionText;
            btnClickAdmin.Location = new Point(48, 182);
            btnClickAdmin.Name = "btnClickAdmin";
            btnClickAdmin.Size = new Size(198, 56);
            btnClickAdmin.TabIndex = 1;
            btnClickAdmin.Text = "Admin Login";
            btnClickAdmin.UseVisualStyleBackColor = false;
            btnClickAdmin.Click += btnClickAdmin_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 27.8490562F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(71, 50);
            label2.Name = "label2";
            label2.Size = new Size(460, 49);
            label2.TabIndex = 0;
            label2.Text = "Login to Cafe’t Bahay";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(890, 504);
            Controls.Add(panel2);
            Controls.Add(panel1);
            ForeColor = SystemColors.ControlDarkDark;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            Text = "Form1";
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
        private Button btnClickAdmin;
        private Label label2;
        private Button btnClickCashier;
    }
}
