namespace UI
{
    partial class ucNewSales
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
            panelProducts = new Panel();
            lblProduct = new Label();
            dgvProducts = new DataGridView();
            panelCart = new Panel();
            lblOrder = new Label();
            dgvCart = new DataGridView();
            lblSubtotal = new Label();
            lblTotal = new Label();
            lblPayment = new Label();
            txtPayment = new TextBox();
            lblChange = new Label();
            btnComplete = new Button();
            panelProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            panelCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            SuspendLayout();
            // 
            // panelProducts
            // 
            panelProducts.Controls.Add(lblProduct);
            panelProducts.Controls.Add(dgvProducts);
            panelProducts.Location = new Point(205, 137);
            panelProducts.Name = "panelProducts";
            panelProducts.Size = new Size(350, 425);
            panelProducts.TabIndex = 5;
            // 
            // lblProduct
            // 
            lblProduct.AutoSize = true;
            lblProduct.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblProduct.Location = new Point(9, 8);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(187, 30);
            lblProduct.TabIndex = 0;
            lblProduct.Text = "Product Selection";
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeight = 29;
            dgvProducts.Location = new Point(9, 51);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.Size = new Size(324, 340);
            dgvProducts.TabIndex = 1;
            // 
            // panelCart
            // 
            panelCart.Controls.Add(lblOrder);
            panelCart.Controls.Add(dgvCart);
            panelCart.Controls.Add(lblSubtotal);
            panelCart.Controls.Add(lblTotal);
            panelCart.Controls.Add(lblPayment);
            panelCart.Controls.Add(txtPayment);
            panelCart.Controls.Add(lblChange);
            panelCart.Controls.Add(btnComplete);
            panelCart.Location = new Point(581, 137);
            panelCart.Name = "panelCart";
            panelCart.Size = new Size(376, 425);
            panelCart.TabIndex = 6;
            // 
            // lblOrder
            // 
            lblOrder.AutoSize = true;
            lblOrder.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblOrder.Location = new Point(9, 8);
            lblOrder.Name = "lblOrder";
            lblOrder.Size = new Size(149, 30);
            lblOrder.TabIndex = 0;
            lblOrder.Text = "Current Order";
            // 
            // dgvCart
            // 
            dgvCart.ColumnHeadersHeight = 29;
            dgvCart.Location = new Point(9, 51);
            dgvCart.Name = "dgvCart";
            dgvCart.RowHeadersWidth = 51;
            dgvCart.Size = new Size(350, 170);
            dgvCart.TabIndex = 1;
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Location = new Point(9, 238);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(95, 17);
            lblSubtotal.TabIndex = 2;
            lblSubtotal.Text = "Subtotal: ₱0.00";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(9, 272);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(75, 17);
            lblTotal.TabIndex = 3;
            lblTotal.Text = "Total: ₱0.00";
            // 
            // lblPayment
            // 
            lblPayment.AutoSize = true;
            lblPayment.Location = new Point(9, 306);
            lblPayment.Name = "lblPayment";
            lblPayment.Size = new Size(60, 17);
            lblPayment.TabIndex = 4;
            lblPayment.Text = "Payment:";
            // 
            // txtPayment
            // 
            txtPayment.Location = new Point(88, 302);
            txtPayment.Name = "txtPayment";
            txtPayment.Size = new Size(88, 25);
            txtPayment.TabIndex = 5;
            // 
            // lblChange
            // 
            lblChange.AutoSize = true;
            lblChange.Location = new Point(9, 340);
            lblChange.Name = "lblChange";
            lblChange.Size = new Size(91, 17);
            lblChange.TabIndex = 6;
            lblChange.Text = "Change: ₱0.00";
            // 
            // btnComplete
            // 
            btnComplete.BackColor = Color.DarkRed;
            btnComplete.ForeColor = Color.White;
            btnComplete.Location = new Point(9, 382);
            btnComplete.Name = "btnComplete";
            btnComplete.Size = new Size(219, 38);
            btnComplete.TabIndex = 7;
            btnComplete.Text = "COMPLETE SALE";
            btnComplete.UseVisualStyleBackColor = false;
            // 
            // ucNewSales
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelProducts);
            Controls.Add(panelCart);
            Name = "ucNewSales";
            Size = new Size(1182, 738);
            panelProducts.ResumeLayout(false);
            panelProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            panelCart.ResumeLayout(false);
            panelCart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelProducts;
        private Label lblProduct;
        private DataGridView dgvProducts;
        private Panel panelCart;
        private Label lblOrder;
        private DataGridView dgvCart;
        private Label lblSubtotal;
        private Label lblTotal;
        private Label lblPayment;
        private TextBox txtPayment;
        private Label lblChange;
        private Button btnComplete;
    }
}
