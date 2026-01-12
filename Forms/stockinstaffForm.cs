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
    public partial class StockInStaffForm : UserControl
    {
        public StockInStaffForm()
        {
            InitializeComponent();
            LoadParts();
            LoadSuppliers();
            displayTransactions();
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
               // displayLowStock();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private string ExtractSupplierFromRemarks(string remarks)
        {
            // Extract supplier name from remarks (format: "Supplier: SupplierName")
            if (string.IsNullOrEmpty(remarks)) return "";

            if (remarks.StartsWith("Supplier: "))
            {
                return remarks.Replace("Supplier: ", "").Trim();
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
    }
}
