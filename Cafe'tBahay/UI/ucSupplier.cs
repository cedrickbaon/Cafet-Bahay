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
            cmbStatus.Items.Add("Active");
            cmbStatus.Items.Add("Inactive");

            dtgSupplierItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgSupplierItems.MultiSelect = false;

        }


        private void btnAddItem_Click(object sender, EventArgs e)
        {
            txtSupplierName.Clear();
            txtContactPerson.Clear();
            txtPhoneSupplier.Clear();
            txtEmailSuppiler.Clear();
            cmbStatus.SelectedIndex = -1;

            pnlAddItem.Visible = true;
        }

        private void btnEditSupplier_Click(object sender, EventArgs e)
        {
            if (dtgSupplierItems.CurrentRow == null || dtgSupplierItems.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Please select a supplier to edit.");
                return;
            }

            lblAddOrEdit.Text = "Edit Supplier";

            var row = dtgSupplierItems.CurrentRow;
            txtSupplierName.Text = row.Cells[1].Value?.ToString();
            txtContactPerson.Text = row.Cells[2].Value?.ToString();
            txtPhoneSupplier.Text = row.Cells[3].Value?.ToString();
            txtEmailSuppiler.Text = row.Cells[4].Value?.ToString();
            cmbStatus.Text = row.Cells[5].Value?.ToString();

            pnlAddItem.Visible = true;
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

            if (isEditMode)
            {
                if (dtgSupplierItems.CurrentRow != null)
                {
                    var row = dtgSupplierItems.CurrentRow;
                    row.Cells[1].Value = txtSupplierName.Text.Trim();
                    row.Cells[2].Value = txtContactPerson.Text.Trim();
                    row.Cells[3].Value = txtPhoneSupplier.Text.Trim();
                    row.Cells[4].Value = txtEmailSuppiler.Text.Trim();
                    row.Cells[5].Value = cmbStatus.Text.Trim();

                    MessageBox.Show("Supplier updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                string newId = $"SUPP-{nextSupplierId:D3}";
                nextSupplierId++;

                dtgSupplierItems.Rows.Add(
                    newId,
                    txtSupplierName.Text.Trim(),
                    txtContactPerson.Text.Trim(),
                    txtPhoneSupplier.Text.Trim(),
                    txtEmailSuppiler.Text.Trim(),
                    cmbStatus.Text.Trim()
                );

                MessageBox.Show("New supplier added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            pnlAddItem.Visible = false;
        }

        private void dtgSupplierItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgSupplierItems.CurrentRow != null && !dtgSupplierItems.CurrentRow.IsNewRow)
            {
                var row = dtgSupplierItems.CurrentRow;

                txtSupplierName.Text = row.Cells[1].Value?.ToString();
                txtContactPerson.Text = row.Cells[2].Value?.ToString();
                txtPhoneSupplier.Text = row.Cells[3].Value?.ToString();
                txtEmailSuppiler.Text = row.Cells[4].Value?.ToString();
                cmbStatus.Text = row.Cells[5].Value?.ToString();

                isEditMode = true;
            }
        }

        private void btnRemoveSupplier_Click(object sender, EventArgs e)
        {
            if (dtgSupplierItems.CurrentRow == null || dtgSupplierItems.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Please select a supplier to remove.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to permanently delete this item?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                dtgSupplierItems.Rows.Remove(dtgSupplierItems.CurrentRow);

                txtSupplierName.Clear();
                txtContactPerson.Clear();
                txtPhoneSupplier.Clear();
                txtEmailSuppiler.Clear();
                cmbStatus.SelectedIndex = -1;
                pnlAddItem.Visible = false;

                MessageBox.Show("Supplier removed successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            pnlAddItem.Visible = false;

            txtSupplierName.Clear();
            txtContactPerson.Clear();
            txtPhoneSupplier.Clear();
            txtEmailSuppiler.Clear();
            cmbStatus.SelectedIndex = -1;
        }
    }

}
