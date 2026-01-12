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
    public partial class StockAdjuForm : UserControl
    {
        public StockAdjuForm()
        {
            InitializeComponent();
            LoadParts();
            LoadSuppliers();
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

            cmbPartName.DataSource = uniqueParts;
            cmbPartName.DisplayMember = "ProductName";
            cmbPartName.ValueMember = "PartID";
            cmbPartName.SelectedIndex = -1;
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
                int partID = Convert.ToInt32(cmbPartName.SelectedValue);
                int quantity = Convert.ToInt32(txtQuantity.Text.Trim()); // can be + or -
                string supplier = cmbSupplier.Text;
                string reason = txtReason.Text.Trim();

                string referenceNumber = "ADJ-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                string remarks = $"Supplier: {supplier} | Adjustment: {reason}";

                if (quantity > 0)
                {
                    InventoryManager.StockIn(
                        partID,
                        SessionManager.CurrentUser.UserID,
                        quantity,
                        referenceNumber,
                        remarks
                    );
                }
                else
                {
                    InventoryManager.StockOut(
                        partID,
                        SessionManager.CurrentUser.UserID,
                        Math.Abs(quantity),
                        referenceNumber,
                        remarks
                    );
                }

                MessageBox.Show("Stock Adjustment successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearFields();
                displayAdjustments();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void displayAdjustments()
        {
            try
            {
                var stockIn = InventoryManager.GetStockInTransactions();
                var stockOut = InventoryManager.GetStockOutTransactions();

                var adds = stockIn.Where(t => t.ReferenceNumber.StartsWith("ADJ-")).ToList();
                var subs = stockOut.Where(t => t.ReferenceNumber.StartsWith("ADJ-")).ToList();

                DataTable dt = new DataTable();
                dt.Columns.Add("Date", typeof(DateTime));
                dt.Columns.Add("Part Name", typeof(string));
                dt.Columns.Add("Supplier", typeof(string));
                dt.Columns.Add("Quantity", typeof(string));
                dt.Columns.Add("Reason", typeof(string));

                foreach (var t in adds)
                {
                    dt.Rows.Add(
                        t.TransactionDate,
                        t.PartName,
                        ExtractSupplierFromRemarks(t.Remarks),
                        "+" + t.Quantity,
                        ExtractReasonFromRemarks(t.Remarks)
                    );
                }

                foreach (var t in subs)
                {
                    dt.Rows.Add(
                        t.TransactionDate,
                        t.PartName,
                        ExtractSupplierFromRemarks(t.Remarks),
                        "-" + t.Quantity,
                        ExtractReasonFromRemarks(t.Remarks)
                    );
                }

                DataView dv = dt.DefaultView;
                dv.Sort = "Date DESC";

                dgvAdju.Columns.Clear();
                dgvAdju.DataSource = dv.ToTable();
                dgvAdju.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvAdju.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading adjustments: " + ex.Message);
            }
        }


        private bool ValidateFields()
        {
            if (cmbPartName.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a part.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbSupplier.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a supplier.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                MessageBox.Show("Please enter the new quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validate quantity is a non-negative number
            if (!int.TryParse(txtQuantity.Text, out int qty) || qty == 0)
            {
                MessageBox.Show("Quantity must be a non-negative number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtReason.Text))
            {
                MessageBox.Show("Please enter a reason for the adjustment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private string ExtractSupplierFromRemarks(string remarks)
        {
            // Extract supplier name from remarks (format: "Supplier: SupplierName | Reason: X")
            if (string.IsNullOrEmpty(remarks)) return "";

            if (remarks.Contains("|"))
            {
                int pipeIndex = remarks.IndexOf("|");
                string supplierPart = remarks.Substring(0, pipeIndex).Trim();

                if (supplierPart.StartsWith("Supplier: "))
                {
                    return supplierPart.Replace("Supplier: ", "").Trim();
                }
            }
            else if (remarks.StartsWith("Supplier: "))
            {
                return remarks.Replace("Supplier: ", "").Trim();
            }

            return remarks;
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

        private void clearFields()
        {
            cmbPartName.SelectedIndex = -1;
            cmbSupplier.SelectedIndex = -1;
            txtQuantity.Clear();
            txtReason.Clear();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void inventory_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }
    }
}