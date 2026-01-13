using MotorPartsInventoryManagement.Managers;
using MotorPartsInventoryManagement.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotorPartsInventoryManagement.Forms
{
    public partial class DamageStaffForm : UserControl
    {
        public DamageStaffForm()
        {
            InitializeComponent();
            LoadParts();
            LoadSuppliers();
            displayDamageRecords();
            this.VisibleChanged += DamageStaffForm_VisibleChanged;

        }

        private void LoadParts()
        {
            List<MotorPartsManager> allParts = MotorPartsManager.GetAll();

            // DISTINCT by PartName ONLY (ignore supplier)
            var uniqueParts = allParts
                .GroupBy(p => p.ProductName.Trim())
                .Select(g => g.First())
                .OrderBy(p => p.ProductName)
                .ToList();

            cmbPart.DataSource = uniqueParts;
            cmbPart.DisplayMember = "ProductName";
            cmbPart.ValueMember = "PartID";
            cmbPart.SelectedIndex = -1;

        }
        private void LoadSuppliers()
        {
            List<SupplierManager> suppliers = SupplierManager.GetAll();
            cmbSupplier.DataSource = suppliers;
            cmbSupplier.DisplayMember = "SupplierName";
            cmbSupplier.ValueMember = "SupplierID";
            cmbSupplier.SelectedIndex = -1;

        }
        private bool ValidateFields()
        {
            if (cmbPart.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a part.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbSupplier.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a supplier.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtQuan.Text))
            {
                MessageBox.Show("Please enter the quantity affected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validate quantity is a positive number
            if (!int.TryParse(txtQuan.Text, out int qty) || qty <= 0)
            {
                MessageBox.Show("Quantity must be a positive number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void btnRecord_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;

            // Check if user is logged in
            if (SessionManager.CurrentUser == null)
            {
                MessageBox.Show("User not logged in. Please login first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string productName = cmbPart.Text;  // Get product name
                int supplierID = Convert.ToInt32(cmbSupplier.SelectedValue);  // Get selected supplier
                int quantity = Convert.ToInt32(txtQuan.Text.Trim());
                string reason = cmbReason.Text.Trim();

                // Get the correct PartID for this product and supplier
                int partID = InventoryManager.GetPartIDByNameAndSupplier(productName, supplierID);

                // Record damage with the correct supplier
                InventoryManager.RecordDamage(
                    partID,
                    supplierID,  // Now includes supplier
                    SessionManager.CurrentUser.UserID,
                    quantity,
                    reason
                );

                MessageBox.Show("Damage recorded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
               // clearFields();
                displayDamageRecords();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //private void btnRecord_Click(object sender, EventArgs e)
        //{
        //    if (!ValidateFields()) return;

        //    // Check if user is logged in
        //    if (SessionManager.CurrentUser == null)
        //    {
        //        MessageBox.Show("User not logged in. Please login first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }


        //    try
        //    {
        //        int partID = Convert.ToInt32(cmbPart.SelectedValue);
        //        int quantity = Convert.ToInt32(txtQuan.Text.Trim());
        //        string reason = cmbReason.Text.Trim();



        //        InventoryManager.RecordDamage(
        //            partID,
        //            SessionManager.CurrentUser.UserID,  // Now pulls from session
        //            quantity,
        //            reason
        //        );


        //        MessageBox.Show("Recorded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        //  clearFields();
        //        displayDamageRecords();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        private void displayDamageRecords()
        {
            try
            {
                List<InventoryManager> allRecords = InventoryManager.GetAllDamageRecords();

                DataTable dt = new DataTable();
                dt.Columns.Add("Date", typeof(DateTime));
                dt.Columns.Add("Part Name", typeof(string));
                dt.Columns.Add("Supplier", typeof(string));
                dt.Columns.Add("Quantity Affected", typeof(int));
                dt.Columns.Add("Reason", typeof(string));

                foreach (var record in allRecords)
                {
                    dt.Rows.Add(
                        record.TransactionDate,
                        record.PartName,
                        record.SupplierName,
                        record.Quantity,
                        record.Remarks
                    );
                }

                dgvDamages.Columns.Clear();
                dgvDamages.DataSource = dt;
                dgvDamages.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvDamages.AllowUserToAddRows = false;
                dgvDamages.ReadOnly = true;

                // Format the Date column - Check if exists first
                if (dgvDamages.Columns.Contains("Date"))
                {
                    dgvDamages.Columns["Date"].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm tt";
                    dgvDamages.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

                if (dgvDamages.Columns.Contains("Quantity Affected") && dgvDamages.Columns["Quantity Affected"] != null)
                    dgvDamages.Columns["Quantity Affected"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                // Highlight recent records (last 24 hours)
                foreach (DataGridViewRow row in dgvDamages.Rows)
                {
                    if (row.Cells["Date"].Value != null)
                    {
                        DateTime recordDate = Convert.ToDateTime(row.Cells["Date"].Value);
                        if (recordDate >= DateTime.Now.AddHours(-24))
                        {
                            row.DefaultCellStyle.BackColor = Color.LightYellow;
                        }
                    }
                }

                // lblRecordCount.Text = $"Total Records: {allRecords.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading damage records: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DamageStaffForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                displayDamageRecords();
            }
        }

        private void DamageStaffForm_Load(object sender, EventArgs e)
        {
            displayDamageRecords();
        }
    }
}
