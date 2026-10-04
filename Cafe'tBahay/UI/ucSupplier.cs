using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class ucSupplier : UserControl
    {
        private bool isEditMode = false;
        private int nextSupplierId = 1;

        public ucSupplier()
        {
            InitializeComponent();

            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Active");
            cmbStatus.Items.Add("Inactive");

            dtgSupplierItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgSupplierItems.MultiSelect = false;

            ResetToAddMode();
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
            if (txtProductSupplied != null) txtProductSupplied.ReadOnly = isReadOnly;

            cmbStatus.Enabled = !isReadOnly;

            if (btnSaveChanges != null) btnSaveChanges.Visible = !isReadOnly;
            if (btnCancel != null) btnCancel.Visible = !isReadOnly;
        }

        private void ResetToAddMode()
        {
            isEditMode = false;
            lblAddOrEdit.Text = "Add Supplier";

            SetFieldsReadOnly(false);

            txtSupplierName.Clear();
            txtContactPerson.Clear();
            txtPhoneSupplier.Clear();
            txtEmailSuppiler.Clear();
            if (txtProductSupplied != null) txtProductSupplied.Clear();
            cmbStatus.SelectedIndex = -1;

            dtgSupplierItems.ClearSelection();
            pnlAddItem.Visible = true;
        }

        private void PopulateFieldsFromSelectedRow()
        {
            if (dtgSupplierItems.CurrentRow != null && !dtgSupplierItems.CurrentRow.IsNewRow)
            {
                var row = dtgSupplierItems.CurrentRow;
                if (txtProductSupplied != null) txtProductSupplied.Text = row.Cells[1].Value?.ToString();
                txtSupplierName.Text = row.Cells[2].Value?.ToString();
                txtContactPerson.Text = row.Cells[3].Value?.ToString();
                txtPhoneSupplier.Text = row.Cells[4].Value?.ToString();
                txtEmailSuppiler.Text = row.Cells[5].Value?.ToString();
                cmbStatus.Text = row.Cells[6].Value?.ToString();
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

            if (txtProductSupplied != null)
            {
                txtProductSupplied.Focus();
                txtProductSupplied.SelectAll();
            }
            else
            {
                txtSupplierName.Focus();
                txtSupplierName.SelectAll();
            }
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
            if (txtProductSupplied != null && string.IsNullOrWhiteSpace(txtProductSupplied.Text))
            {
                MessageBox.Show("Please enter the Product Supplied.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductSupplied.Focus();
                return;
            }

            if (isEditMode)
            {
                if (dtgSupplierItems.CurrentRow != null)
                {
                    var row = dtgSupplierItems.CurrentRow;
                    if (txtProductSupplied != null) row.Cells[1].Value = txtProductSupplied.Text.Trim();
                    row.Cells[2].Value = txtSupplierName.Text.Trim();
                    row.Cells[3].Value = txtContactPerson.Text.Trim();
                    row.Cells[4].Value = txtPhoneSupplier.Text.Trim();
                    row.Cells[5].Value = txtEmailSuppiler.Text.Trim();
                    row.Cells[6].Value = cmbStatus.Text.Trim();

                    MessageBox.Show("Supplier updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                string newId = $"SUPP-{nextSupplierId:D3}";
                nextSupplierId++;

                dtgSupplierItems.Rows.Add(
                    newId,
                    txtProductSupplied != null ? txtProductSupplied.Text.Trim() : "",
                    txtSupplierName.Text.Trim(),
                    txtContactPerson.Text.Trim(),
                    txtPhoneSupplier.Text.Trim(),
                    txtEmailSuppiler.Text.Trim(),
                    cmbStatus.Text.Trim()
                );

                MessageBox.Show("New supplier added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ResetToAddMode();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            ResetToAddMode();
        }
    }
}