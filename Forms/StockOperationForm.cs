using MotorPartsInventoryManagement.Managers;
using MotorPartsInventoryManagement.Models;
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
    public partial class StockOperationForm : UserControl
    {
        private User currentUser;

        public StockOperationForm()
        {
            InitializeComponent();
            LoadParts();
            LoadSuppliers();
            displayTransactions();
            displayStockOutTransactions();
            displayLowStock();
            displayAdjustments();
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

            cmbPartN.DataSource = uniqueParts;
            cmbPartN.DisplayMember = "ProductName";
            cmbPartN.ValueMember = "PartID";
            cmbPartN.SelectedIndex = -1;

            cmbPartNa.DataSource = uniqueParts;
            cmbPartNa.DisplayMember = "ProductName";
            cmbPartNa.ValueMember = "PartID";
            cmbPartNa.SelectedIndex = -1;
        }


        private void LoadSuppliers()
        {
            List<SupplierManager> suppliers = SupplierManager.GetAll();

            cmbSupplier.DataSource = suppliers;
            cmbSupplier.DisplayMember = "SupplierName";
            cmbSupplier.ValueMember = "SupplierID";
            cmbSupplier.SelectedIndex = -1;

            cmbSuppli.DataSource = suppliers;
            cmbSuppli.DisplayMember = "SupplierName";
            cmbSuppli.ValueMember = "SupplierID";
            cmbSuppli.SelectedIndex = -1;

            cmbSupp.DataSource = suppliers;
            cmbSupp.DisplayMember = "SupplierName";
            cmbSupp.ValueMember = "SupplierID";
            cmbSupp.SelectedIndex = -1;
        }

        private void cmbPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPart.SelectedIndex != -1)
            {
                // Get selected part details
                MotorPartsManager selectedPart = (MotorPartsManager)cmbPart.SelectedItem;

               
            }
        }

        private void dgvStockIn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: Handle cell click if needed
        }

        private void displayTransactions()
        {
            try
            {
                // Get only Stock In transactions
                List<InventoryManager> allTransactions = InventoryManager.GetStockInTransactions();

                // Create a custom DataTable with only the columns we want
                DataTable dt = new DataTable();
                dt.Columns.Add("Date", typeof(DateTime));
                dt.Columns.Add("Part Name", typeof(string));
                dt.Columns.Add("Supplier", typeof(string));
                dt.Columns.Add("Quantity Added", typeof(int));
                dt.Columns.Add("Receipt No.", typeof(string));

                foreach (var transaction in allTransactions)
                {
                    // Extract supplier from remarks
                    string supplier = ExtractSupplierFromRemarks(transaction.Remarks);

                    dt.Rows.Add(
                        transaction.TransactionDate,
                        transaction.PartName,
                        supplier,
                        transaction.Quantity,
                        transaction.ReferenceNumber
                    );
                }

                // Clear existing columns to avoid mismatches (e.g., "TransactionID")
                dgvStockIn.Columns.Clear();

                dgvStockIn.DataSource = dt;
                dgvStockIn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvStockIn.AllowUserToAddRows = false;

                // Format the Date column
                if (dgvStockIn.Columns.Contains("Date"))
                {
                    dgvStockIn.Columns["Date"].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm tt";
                    dgvStockIn.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

                // Adjust column widths
                if (dgvStockIn.Columns.Contains("Receipt No."))
                {
                    dgvStockIn.Columns["Receipt No."].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

                if (dgvStockIn.Columns.Contains("Quantity Added"))
                {
                    dgvStockIn.Columns["Quantity Added"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

                // Highlight recent transactions (last 24 hours)
                foreach (DataGridViewRow row in dgvStockIn.Rows)
                {
                    DateTime transDate = Convert.ToDateTime(row.Cells["Date"].Value);
                    if (transDate >= DateTime.Now.AddHours(-24))
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading transactions: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void displayLowStock()
        {
            try
            {
                List<InventoryManager> lowStockItems = InventoryManager.GetLowStockItems();

                DataTable dt = new DataTable();
                dt.Columns.Add("Part Name", typeof(string));
                dt.Columns.Add("Supplier", typeof(string));
                dt.Columns.Add("Quantity On Hand", typeof(int));
                dt.Columns.Add("Reorder Level", typeof(int));
                dt.Columns.Add("Status", typeof(string));

                foreach (var item in lowStockItems)
                {
                    dt.Rows.Add(
                        item.PartName,
                        item.SupplierName,
                        item.QuantityOnHand,
                        item.ReorderLevel,
                        item.Status
                    );
                }

                dgvLowStock.Columns.Clear();
                dgvLowStock.DataSource = dt;
                dgvLowStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvLowStock.AllowUserToAddRows = false;
                dgvLowStock.ReadOnly = true;

                // Format columns
                if (dgvLowStock.Columns.Contains("Quantity On Hand") && dgvLowStock.Columns["Quantity On Hand"] != null)
                    dgvLowStock.Columns["Quantity On Hand"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                if (dgvLowStock.Columns.Contains("Reorder Level") && dgvLowStock.Columns["Reorder Level"] != null)
                    dgvLowStock.Columns["Reorder Level"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                if (dgvLowStock.Columns.Contains("Status") && dgvLowStock.Columns["Status"] != null)
                    dgvLowStock.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                // Apply row colors based on status
                foreach (DataGridViewRow row in dgvLowStock.Rows)
                {
                    if (row.Cells["Quantity On Hand"].Value != null)
                    {
                        int qty = Convert.ToInt32(row.Cells["Quantity On Hand"].Value);

                        if (qty == 0)
                        {
                            // Out of stock - Red
                            row.DefaultCellStyle.BackColor = Color.LightCoral;
                            row.DefaultCellStyle.ForeColor = Color.DarkRed;
                        }
                        else
                        {
                            // Low stock - Yellow
                            row.DefaultCellStyle.BackColor = Color.Khaki;
                            row.DefaultCellStyle.ForeColor = Color.DarkOrange;
                        }
                    }
                }

                // Update count label if you have one
                //   lblLowStockCount.Text = $"Low Stock Items: {lowStockItems.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading low stock items: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private string ExtractSupplierFromRemarks(string remarks)
        {
            // Extract supplier name from remarks (format: "Supplier: SupplierName")
            if (string.IsNullOrEmpty(remarks))
                return "";

            // If remarks starts with "Supplier: "
            if (remarks.StartsWith("Supplier: "))
            {
                // Handle format: "Supplier: X | Reason: Y" or "Supplier: X | Adjustment: Y"
                int pipeIndex = remarks.IndexOf("|");
                if (pipeIndex > 0)
                {
                    // Extract only the supplier name between "Supplier: " and "|"
                    return remarks.Substring(10, pipeIndex - 10).Trim();
                }
                else
                {
                    // No pipe, extract everything after "Supplier: "
                    return remarks.Substring(10).Trim();
                }
            }

            return remarks;
        }

        private void clearFields()
        {
            cmbPart.SelectedIndex = -1;
            cmbSupplier.SelectedIndex = -1;
            txtDeliveryreceipt.Clear();
            txtQuantityToAdd.Clear();
        }

        private void clearStockOutFields()
        {
            cmbPartN.SelectedIndex = -1;
            cmbSuppli.SelectedIndex = -1;
            txtQuanDed.Clear();
            txtReas.Clear();
        }

        private void clearAdjustmentFields()
        {
            cmbPartNa.SelectedIndex = -1;
            cmbSupp.SelectedIndex = -1;
            txtQuantity.Clear();
            txtReason.Clear();
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

            if (string.IsNullOrWhiteSpace(txtDeliveryreceipt.Text))
            {
                MessageBox.Show("Please enter delivery receipt number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtQuantityToAdd.Text))
            {
                MessageBox.Show("Please enter quantity to add.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validate quantity is a positive number
            if (!int.TryParse(txtQuantityToAdd.Text, out int qty) || qty <= 0)
            {
                MessageBox.Show("Quantity must be a positive number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void StockOperationForm_Load(object sender, EventArgs e)
        {
            displayTransactions();
            displayStockOutTransactions();
            displayAdjustments();
        }

        private bool ValidateStockOutFields()
        {
            if (cmbPartN.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a part.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbSuppli.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a supplier.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtQuanDed.Text))
            {
                MessageBox.Show("Please enter quantity to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(txtQuanDed.Text, out int qty) || qty <= 0)
            {
                MessageBox.Show("Quantity must be a positive number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtReas.Text))
            {
                MessageBox.Show("Please enter a reason for stock out.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool ValidateAdjustmentFields()
        {
            if (cmbPartNa.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a part.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbSupp.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a supplier.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                MessageBox.Show("Please enter adjustment quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Allow negative numbers for adjustments (can be + or -)
            if (!int.TryParse(txtQuantity.Text, out int qty) || qty == 0)
            {
                MessageBox.Show("Adjustment quantity must be a non-zero number.\nUse positive to add, negative to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtReason.Text))
            {
                MessageBox.Show("Please enter a reason for the adjustment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;

            if (SessionManager.CurrentUser == null)
            {
                MessageBox.Show("User not logged in. Please login first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string productName = cmbPart.Text;  // Get product name from combo box text
                int supplierID = Convert.ToInt32(cmbSupplier.SelectedValue);
                int quantity = Convert.ToInt32(txtQuantityToAdd.Text.Trim());
                string deliveryReceipt = txtDeliveryreceipt.Text.Trim();
                string remarks = $"Supplier: {cmbSupplier.Text}";

                // Get the correct PartID for this product and supplier
                int partID = InventoryManager.GetPartIDByNameAndSupplier(productName, supplierID);

                // Perform Stock In
                InventoryManager.StockIn(
                    partID,
                    SessionManager.CurrentUser.UserID,
                    supplierID,
                    quantity,
                    deliveryReceipt,
                    remarks
                );

                MessageBox.Show("Stock In successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearFields();
                displayTransactions();
                displayLowStock();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveSO_Click(object sender, EventArgs e)
        {
            if (!ValidateStockOutFields()) return;

            if (SessionManager.CurrentUser == null)
            {
                MessageBox.Show("User not logged in. Please login first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
              //  int partID = Convert.ToInt32(cmbPartN.SelectedValue);
                int quantity = Convert.ToInt32(txtQuanDed.Text.Trim());
                string supplier = cmbSuppli.Text;
                string reason = txtReas.Text.Trim();

                string productName = cmbPartN.Text;
                int supplierID = Convert.ToInt32(cmbSuppli.SelectedValue);
                int partID = InventoryManager.GetPartIDByNameAndSupplier(productName, supplierID);

                // Generate reference number automatically
                string referenceNumber = "SO-" + DateTime.Now.ToString("yyyyMMddHHmmss");

                // Store supplier and reason in remarks
                string remarks = $"Supplier: {supplier} | Reason: {reason}";

                InventoryManager.StockOut(
                    partID,
                    SessionManager.CurrentUser.UserID,
                    quantity,
                    referenceNumber,
                    remarks
                );

                MessageBox.Show("Stock Out successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearStockOutFields();
                displayStockOutTransactions();
                displayLowStock();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveA_Click(object sender, EventArgs e)
        {
            if (!ValidateAdjustmentFields()) return;

            if (SessionManager.CurrentUser == null)
            {
                MessageBox.Show("User not logged in. Please login first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int partID = Convert.ToInt32(cmbPartNa.SelectedValue);
                int quantity = Convert.ToInt32(txtQuantity.Text.Trim());
                int supplierID = Convert.ToInt32(cmbSupplier.SelectedValue);

                string supplier = cmbSupp.Text;
                string reason = txtReason.Text.Trim();

                // Generate reference number for adjustment
                string referenceNumber = "ADJ-" + DateTime.Now.ToString("yyyyMMddHHmmss");

                // Store supplier and reason in remarks
                string remarks = $"Supplier: {supplier} | Adjustment: {reason}";

                // Determine if this is an addition or reduction based on quantity sign
                if (quantity > 0)
                {
                    // Positive adjustment - add stock
                    InventoryManager.StockIn(
                        partID,
                        supplierID,
                        SessionManager.CurrentUser.UserID,
                        quantity,
                        referenceNumber,
                        remarks
                    );
                }
                else
                {
                    // Negative adjustment - remove stock
                    InventoryManager.StockOut(
                        partID,
                        SessionManager.CurrentUser.UserID,
                        Math.Abs(quantity),  // Convert to positive for StockOut
                        referenceNumber,
                        remarks
                    );
                }

                MessageBox.Show("Stock Adjustment successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearAdjustmentFields();
                displayAdjustments();
                displayLowStock();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void displayStockOutTransactions()
        {
            try
            {
                List<InventoryManager> allTransactions = InventoryManager.GetStockOutTransactions();

                DataTable dt = new DataTable();
                dt.Columns.Add("Date", typeof(DateTime));
                dt.Columns.Add("Part Name", typeof(string));
                dt.Columns.Add("Supplier", typeof(string));
                dt.Columns.Add("Quantity Removed", typeof(int));
                dt.Columns.Add("Reason", typeof(string));

                foreach (var transaction in allTransactions)
                {
                    // Extract supplier and reason from remarks
                    string supplier = ExtractSupplierFromRemarks(transaction.Remarks);
                    string reason = ExtractReasonFromRemarks(transaction.Remarks);

                    dt.Rows.Add(
                        transaction.TransactionDate,
                        transaction.PartName,
                        supplier,
                        transaction.Quantity,
                        reason
                    );
                }

                dgvStockOut.Columns.Clear();
                dgvStockOut.DataSource = dt;
                dgvStockOut.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvStockOut.AllowUserToAddRows = false;

                if (dgvStockOut.Columns.Contains("Date"))
                {
                    dgvStockOut.Columns["Date"].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm tt";
                    dgvStockOut.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

                if (dgvStockOut.Columns.Contains("Supplier"))
                    dgvStockOut.Columns["Supplier"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                if (dgvStockOut.Columns.Contains("Quantity Removed"))
                    dgvStockOut.Columns["Quantity Removed"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                foreach (DataGridViewRow row in dgvStockOut.Rows)
                {
                    DateTime transDate = Convert.ToDateTime(row.Cells["Date"].Value);
                    if (transDate >= DateTime.Now.AddHours(-24))
                    {
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Stock Out transactions: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void displayAdjustments()
        {
            try
            {
                // Get Stock In transactions (additions)
                List<InventoryManager> stockInTransactions = InventoryManager.GetStockInTransactions();

                // Get Stock Out transactions (reductions)
                List<InventoryManager> stockOutTransactions = InventoryManager.GetStockOutTransactions();

                // Filter only adjustment transactions (reference number starts with "ADJ-")
                var adjustmentAdditions = stockInTransactions
                    .Where(t => t.ReferenceNumber != null && t.ReferenceNumber.StartsWith("ADJ-"))
                    .ToList();

                var adjustmentReductions = stockOutTransactions
                    .Where(t => t.ReferenceNumber != null && t.ReferenceNumber.StartsWith("ADJ-"))
                    .ToList();

                DataTable dt = new DataTable();
                dt.Columns.Add("Date", typeof(DateTime));
                dt.Columns.Add("Part Name", typeof(string));
                dt.Columns.Add("Supplier", typeof(string));
                dt.Columns.Add("Quantity", typeof(string));  // Changed to string to show +/-
                dt.Columns.Add("Reason", typeof(string));

                // Add Stock In adjustments (positive quantities)
                foreach (var transaction in adjustmentAdditions)
                {
                    string supplier = ExtractSupplierFromRemarks(transaction.Remarks);
                    string reason = ExtractAdjustmentReasonFromRemarks(transaction.Remarks);

                    dt.Rows.Add(
                        transaction.TransactionDate,
                        transaction.PartName,
                        supplier,
                        "+" + transaction.Quantity,  // Prefix with +
                        reason
                    );
                }

                // Add Stock Out adjustments (negative quantities)
                foreach (var transaction in adjustmentReductions)
                {
                    string supplier = ExtractSupplierFromRemarks(transaction.Remarks);
                    string reason = ExtractAdjustmentReasonFromRemarks(transaction.Remarks);

                    dt.Rows.Add(
                        transaction.TransactionDate,
                        transaction.PartName,
                        supplier,
                        "-" + transaction.Quantity,  // Prefix with -
                        reason
                    );
                }

                // Sort by date descending
                DataView dv = dt.DefaultView;
                dv.Sort = "Date DESC";
                DataTable sortedDt = dv.ToTable();

                dgvAdjustments.Columns.Clear();
                dgvAdjustments.DataSource = sortedDt;
                dgvAdjustments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvAdjustments.AllowUserToAddRows = false;

                // Format columns
                if (dgvAdjustments.Columns.Contains("Date"))
                {
                    dgvAdjustments.Columns["Date"].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm tt";
                    dgvAdjustments.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

                if (dgvAdjustments.Columns.Contains("Quantity"))
                    dgvAdjustments.Columns["Quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                // Color code by quantity sign
                foreach (DataGridViewRow row in dgvAdjustments.Rows)
                {
                    DateTime transDate = Convert.ToDateTime(row.Cells["Date"].Value);
                    string quantity = row.Cells["Quantity"].Value.ToString();

                    // Highlight recent adjustments (last 24 hours)
                    if (transDate >= DateTime.Now.AddHours(-24))
                    {
                        if (quantity.StartsWith("+"))
                        {
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                        }
                        else if (quantity.StartsWith("-"))
                        {
                            row.DefaultCellStyle.BackColor = Color.LightSalmon;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading adjustments: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ExtractReasonFromRemarks(string remarks)
        {
            if (string.IsNullOrEmpty(remarks)) return "";

            // Extract reason after "Reason: "
            int reasonIndex = remarks.IndexOf("Reason: ");
            if (reasonIndex >= 0)
            {
                return remarks.Substring(reasonIndex + 8).Trim();
            }

            return "";
        }

        private string ExtractAdjustmentReasonFromRemarks(string remarks)
        {
            if (string.IsNullOrEmpty(remarks)) return "";

            // Extract reason after "Adjustment: "
            int reasonIndex = remarks.IndexOf("Adjustment: ");
            if (reasonIndex >= 0)
            {
                return remarks.Substring(reasonIndex + 12).Trim();
            }

            // Fallback to regular reason extraction
            return ExtractReasonFromRemarks(remarks);
        }

        private void dgvStockOut_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbPartN_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}