using System;
using System.Data;
using System.Windows.Forms;
using Model;

namespace UI
{
    public partial class ucSupplier : UserControl
    {
        private bool isEditMode = false;
        private int currentSupplierId = 0;

        public ucSupplier()
        {
            InitializeComponent();

            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Active");
            cmbStatus.Items.Add("Inactive");

            dtgSupplierItems.AutoGenerateColumns = false;
            dtgSupplierItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgSupplierItems.MultiSelect = false;
            dtgSupplierItems.CellClick += dtgSupplierItems_CellClick;

            LoadSuppliers();
            ResetToAddMode();
        }

        private void LoadSuppliers()
        {
            try
            {
                dtgSupplierItems.DataSource = AppServices.Suppliers.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error loading suppliers: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (this.ActiveControl != null && pnlAddItem.Contains(this.ActiveControl) && !(this.ActiveControl is Button))
                {
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void SetFieldsReadOnly(bool isReadOnly)
        {
            txtSupplierName.ReadOnly = isReadOnly;
            txtContactPerson.ReadOnly = isReadOnly;
            txtPhoneSupplier.ReadOnly = isReadOnly;
            txtEmailSuppiler.ReadOnly = isReadOnly;
            txtSupplierAddress.ReadOnly = isReadOnly;
            txtSupplierNotesRemarks.ReadOnly = isReadOnly;

            cmbStatus.Enabled = !isReadOnly;

            if (btnSaveChanges != null) btnSaveChanges.Visible = !isReadOnly;
            if (btnCancel != null) btnCancel.Visible = !isReadOnly;
        }

        private void ResetToAddMode()
        {
            isEditMode = false;
            currentSupplierId = 0;
            lblAddOrEdit.Text = "Add Supplier";

            SetFieldsReadOnly(false);

            txtSupplierName.Clear();
            txtContactPerson.Clear();
            txtPhoneSupplier.Clear();
            txtEmailSuppiler.Clear();
            txtSupplierAddress.Clear();
            txtSupplierNotesRemarks.Clear();
            cmbStatus.SelectedIndex = -1;

            dtgSupplierItems.ClearSelection();
            pnlAddItem.Visible = true;
        }

        private void PopulateFieldsFromSelectedRow()
        {
           
            if (dtgSupplierItems.CurrentRow != null && !dtgSupplierItems.CurrentRow.IsNewRow)
            {
                var rowView = dtgSupplierItems.CurrentRow.DataBoundItem as DataRowView;
                if (rowView != null)
                {
                    currentSupplierId = Convert.ToInt32(rowView["Id"]);
                    txtSupplierName.Text = rowView["Name"]?.ToString();
                    txtProductSupplied.Text = rowView["ProductsSupplied"]?.ToString();
                    txtContactPerson.Text = rowView["ContactPerson"]?.ToString();
                    txtPhoneSupplier.Text = rowView["ContactNumber"]?.ToString();
                    txtEmailSuppiler.Text = rowView["Email"]?.ToString();
                    txtSupplierAddress.Text = rowView["Address"]?.ToString();
                    cmbStatus.Text = rowView["Status"]?.ToString();
                    txtSupplierNotesRemarks.Text = rowView["Notes"]?.ToString();
                }
            }
        }
        

        private void dtgSupplierItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dtgSupplierItems.CurrentRow != null && !dtgSupplierItems.CurrentRow.IsNewRow)
            {
                isEditMode = false;
                lblAddOrEdit.Text = "View Supplier";

                PopulateFieldsFromSelectedRow();
                SetFieldsReadOnly(true);
            }
        }

        private void btnEditSupplier_Click(object sender, EventArgs e)
        {
            if (dtgSupplierItems.CurrentRow == null || dtgSupplierItems.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Please select a supplier from the list to edit.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isEditMode = true;
            lblAddOrEdit.Text = "Edit Supplier";

            PopulateFieldsFromSelectedRow();
            SetFieldsReadOnly(false);

            txtSupplierName.Focus();
            txtSupplierName.SelectAll();
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSupplierName.Text))
            {
                MessageBox.Show("Please enter the Supplier Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSupplierName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtContactPerson.Text))
            {
                MessageBox.Show("Please enter the Contact Person.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContactPerson.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPhoneSupplier.Text))
            {
                MessageBox.Show("Please enter the Phone Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhoneSupplier.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtEmailSuppiler.Text))
            {
                MessageBox.Show("Please enter the Email Address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmailSuppiler.Focus();
                return;
            }
            if (cmbStatus.SelectedIndex == -1 || string.IsNullOrWhiteSpace(cmbStatus.Text))
            {
                MessageBox.Show("Please select a Status.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbStatus.Focus();
                return;
            }

            try
            {
                var supplier = new Supplier
                {
                    Id = currentSupplierId,
                    Name = txtSupplierName.Text.Trim(),
                    ProductsSupplied = "", // Not used in this layout
                    ContactPerson = txtContactPerson.Text.Trim(),
                    ContactNumber = txtPhoneSupplier.Text.Trim(),
                    Email = txtEmailSuppiler.Text.Trim(),
                    Address = txtSupplierAddress.Text.Trim(),
                    Status = cmbStatus.Text.Trim(),
                    Notes = txtSupplierNotesRemarks.Text.Trim()
                }; 

                if (isEditMode)
                {
                    AppServices.Suppliers.Update(supplier);
                    MessageBox.Show("Supplier updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    AppServices.Suppliers.Add(supplier);
                    MessageBox.Show("New supplier added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadSuppliers();
                ResetToAddMode();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error saving supplier: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            ResetToAddMode();
        }
    }
}