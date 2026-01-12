using ClosedXML.Excel;
using MotorPartsInventoryManagement.Managers;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MotorPartsInventoryManagement.Forms
{
    public partial class ReportsForm : UserControl
    {
        private readonly DateTime WideRangeStart = new DateTime(1970, 1, 1);
        private readonly DateTime WideRangeEnd = new DateTime(2099, 12, 31);

        public ReportsForm()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            // Set default dates
            DateTime today = DateTime.Today;
            dtpFrom.Value = today.AddDays(-30);
            dtpTo.Value = today;
            dtpFrom1.Value = today.AddDays(-30);
            dtpFrom2.Value = today;
            dtpFrom3.Value = today.AddDays(-30);
            dtpTo3.Value = today;
            dtpFrom4.Value = today.AddDays(-30);
            dtpTo4.Value = today;

            // Set default combo box selections
            if (cmbReportType.Items.Count > 0) cmbReportType.SelectedIndex = 0; // Daily
            if (cmbType.Items.Count > 0) cmbType.SelectedIndex = 0; // Damaged / Type

            // Load suppliers for filter
            LoadSuppliersForFilter();

            // Attach event handlers
            btnApply.Click += BtnApplySalesFilter_Click;
            btnSalesExport.Click += BtnExportSalesReport_Click;
            btnInventoryExport.Click += BtnExportInventoryReport_Click;
            btnLowStockExport.Click += BtnExportLowStockReport_Click;
            btnApply2.Click += BtnApplyMovingPartsFilter_Click;
            btnFastSlowExport.Click += BtnExportMovingPartsReport_Click;
            btnApply3.Click += BtnApplySupplierFilter_Click;
            btnDelSuppExport.Click += BtnExportSupplierReport_Click;
            btnApply4.Click += BtnApplyDamagedItemsFilter_Click;
            btnDamLostExport.Click += BtnExportDamagedItemsReport_Click;

            // Load initial data (show ALL data for each report)
            LoadSalesReport();               // show all sales (grouping controlled by cmbReportType)
            LoadInventoryReport();           // inventory summary already returns all
            LoadLowStockReport();            // uses GetLowStockItems() - same as StockOperationForm
            LoadMovingPartsReport();         // show all moving parts (wide date range)
            LoadSupplierReport();            // show all delivery records (wide date range, supplier = All)
            LoadDamagedItemsReport();        // show all damaged/lost items (wide date range, reason = All)
        }

        #region Sales Reports

        private void BtnApplySalesFilter_Click(object sender, EventArgs e)
        {
            // When user clicks APPLY, use the selected date range so date filtering works.
            LoadSalesReport(useSelectedRange: true);
        }

        // useSelectedRange == false => show all (wide range); true => use date pickers
        private void LoadSalesReport(bool useSelectedRange = false)
        {
            try
            {
                string reportType = cmbReportType.SelectedItem?.ToString() ?? "Daily";
                DateTime start = useSelectedRange ? dtpFrom.Value.Date : WideRangeStart;
                DateTime end = useSelectedRange ? dtpTo.Value.Date : WideRangeEnd;

                DataTable dt = InventoryManager.GetSalesReportByDateRange(start, end, reportType);

                dgvSalesReports.Columns.Clear();
                dgvSalesReports.DataSource = dt;
                dgvSalesReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // If the result contains a date column, format it for easier filtering
                if (dgvSalesReports.Columns.Contains("Date"))
                {
                    dgvSalesReports.Columns["Date"].DefaultCellStyle.Format = "yyyy-MM-dd";
                    dgvSalesReports.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

                FormatSalesReportGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading sales report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatSalesReportGrid()
        {
            if (dgvSalesReports.Columns.Count > 0)
            {
                if (dgvSalesReports.Columns.Contains("Date")) dgvSalesReports.Columns["Date"].HeaderText = "Date";
                if (dgvSalesReports.Columns.Contains("TotalSales"))
                {
                    dgvSalesReports.Columns["TotalSales"].HeaderText = "Total Sales";
                    dgvSalesReports.Columns["TotalSales"].DefaultCellStyle.Format = "₱#,##0.00";
                }
                if (dgvSalesReports.Columns.Contains("NumberOfTransactions"))
                    dgvSalesReports.Columns["NumberOfTransactions"].HeaderText = "Number of Transactions";
            }
        }

        #endregion

        #region Inventory Reports

        private void LoadInventoryReport()
        {
            try
            {
                // Inventory summary returns all active inventory already
                DataTable dt = InventoryManager.GetInventorySummaryReport();
                dgvInventoryReports.Columns.Clear();
                dgvInventoryReports.DataSource = dt;
                dgvInventoryReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // If the inventory result contains any date-like column, format it; otherwise leave as-is.
                if (dgvInventoryReports.Columns.Contains("Date"))
                {
                    dgvInventoryReports.Columns["Date"].DefaultCellStyle.Format = "yyyy-MM-dd";
                    dgvInventoryReports.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

                FormatInventoryReportGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading inventory report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatInventoryReportGrid()
        {
            if (dgvInventoryReports.Columns.Count > 0)
            {
                if (dgvInventoryReports.Columns.Contains("PartName")) dgvInventoryReports.Columns["PartName"].HeaderText = "Part Name";
                if (dgvInventoryReports.Columns.Contains("Category")) dgvInventoryReports.Columns["Category"].HeaderText = "Category";
                if (dgvInventoryReports.Columns.Contains("QuantityOnHand")) dgvInventoryReports.Columns["QuantityOnHand"].HeaderText = "Quantity on Hand";
                if (dgvInventoryReports.Columns.Contains("ReorderLevel")) dgvInventoryReports.Columns["ReorderLevel"].HeaderText = "Reorder Level";
                if (dgvInventoryReports.Columns.Contains("StockStatus")) dgvInventoryReports.Columns["StockStatus"].HeaderText = "Stock Status";
            }
        }

        #endregion

        #region Low Stock Reports

        // Mirrors StockOperationForm.displayLowStock()
        private void LoadLowStockReport()
        {
            try
            {
                var lowStockItems = InventoryManager.GetLowStockItems();

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

                dgvLowStockReport.Columns.Clear();
                dgvLowStockReport.DataSource = dt;
                dgvLowStockReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvLowStockReport.AllowUserToAddRows = false;
                dgvLowStockReport.ReadOnly = true;

                if (dgvLowStockReport.Columns.Contains("Quantity On Hand"))
                    dgvLowStockReport.Columns["Quantity On Hand"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                if (dgvLowStockReport.Columns.Contains("Reorder Level"))
                    dgvLowStockReport.Columns["Reorder Level"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                if (dgvLowStockReport.Columns.Contains("Status"))
                    dgvLowStockReport.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                foreach (DataGridViewRow row in dgvLowStockReport.Rows)
                {
                    if (row.Cells["Quantity On Hand"].Value != null && int.TryParse(row.Cells["Quantity On Hand"].Value.ToString(), out int qty))
                    {
                        if (qty == 0)
                        {
                            row.DefaultCellStyle.BackColor = Color.LightCoral;
                            row.DefaultCellStyle.ForeColor = Color.DarkRed;
                        }
                        else
                        {
                            row.DefaultCellStyle.BackColor = Color.Khaki;
                            row.DefaultCellStyle.ForeColor = Color.DarkOrange;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading low stock report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatLowStockReportGrid()
        {
            // kept for compatibility; primary formatting done in LoadLowStockReport
        }

        #endregion

        #region Moving Parts Reports

        private void BtnApplyMovingPartsFilter_Click(object sender, EventArgs e)
        {
            // Use selected date range for actual filtering when user clicks APPLY
            LoadMovingPartsReport(useSelectedRange: true);
        }

        private void LoadMovingPartsReport(bool useSelectedRange = false)
        {
            try
            {
                DateTime start = useSelectedRange ? dtpFrom1.Value.Date : WideRangeStart;
                DateTime end = useSelectedRange ? dtpFrom2.Value.Date : WideRangeEnd;

                DataTable dt = InventoryManager.GetMovingPartsReport(start, end);
                dgvFSParts.Columns.Clear();
                dgvFSParts.DataSource = dt;
                dgvFSParts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // If a date column exists (some implementations might include Date), format it
                if (dgvFSParts.Columns.Contains("Date"))
                {
                    dgvFSParts.Columns["Date"].DefaultCellStyle.Format = "yyyy-MM-dd";
                    dgvFSParts.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

                FormatMovingPartsReportGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading moving parts report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatMovingPartsReportGrid()
        {
            if (dgvFSParts.Columns.Count > 0)
            {
                if (dgvFSParts.Columns.Contains("PartName")) dgvFSParts.Columns["PartName"].HeaderText = "Part Name";
                if (dgvFSParts.Columns.Contains("TotalQuantitySold")) dgvFSParts.Columns["TotalQuantitySold"].HeaderText = "Total Quantity Sold";
                if (dgvFSParts.Columns.Contains("TotalSalesAmount"))
                {
                    dgvFSParts.Columns["TotalSalesAmount"].HeaderText = "Total Sales Amount";
                    dgvFSParts.Columns["TotalSalesAmount"].DefaultCellStyle.Format = "₱#,##0.00";
                }
                if (dgvFSParts.Columns.Contains("MovementStatus")) dgvFSParts.Columns["MovementStatus"].HeaderText = "Movement Status";
            }
        }

        #endregion

        #region Supplier Reports

        private void LoadSuppliersForFilter()
        {
            try
            {
                DataTable dt = InventoryManager.GetActiveSuppliersForFilter();

                // Add "All Suppliers" option
                DataRow allRow = dt.NewRow();
                allRow["SupplierID"] = 0;
                allRow["SupplierName"] = "All Suppliers";
                dt.Rows.InsertAt(allRow, 0);

                cmbSupplier.DataSource = dt;
                cmbSupplier.DisplayMember = "SupplierName";
                cmbSupplier.ValueMember = "SupplierID";
                cmbSupplier.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading suppliers: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnApplySupplierFilter_Click(object sender, EventArgs e)
        {
            // Use selected dates & supplier when APPLY clicked
            LoadSupplierReport(useSelectedRange: true);
        }

        private void LoadSupplierReport(bool useSelectedRange = false)
        {
            try
            {
                int supplierId = 0;
                if (cmbSupplier.SelectedValue != null)
                {
                    int.TryParse(cmbSupplier.SelectedValue.ToString(), out supplierId);
                }

                DateTime start = useSelectedRange ? dtpFrom3.Value.Date : WideRangeStart;
                DateTime end = useSelectedRange ? dtpTo3.Value.Date : WideRangeEnd;

                DataTable dt = InventoryManager.GetDeliverySupplierReport(start, end, supplierId);
                dgvDSReport.Columns.Clear();
                dgvDSReport.DataSource = dt;
                dgvDSReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (dgvDSReport.Columns.Contains("Date"))
                {
                    dgvDSReport.Columns["Date"].DefaultCellStyle.Format = "yyyy-MM-dd";
                    dgvDSReport.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

                FormatSupplierReportGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading supplier report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatSupplierReportGrid()
        {
            if (dgvDSReport.Columns.Count > 0)
            {
                if (dgvDSReport.Columns.Contains("Date")) dgvDSReport.Columns["Date"].HeaderText = "Date";
                if (dgvDSReport.Columns.Contains("SupplierName")) dgvDSReport.Columns["SupplierName"].HeaderText = "Supplier Name";
                if (dgvDSReport.Columns.Contains("PartName")) dgvDSReport.Columns["PartName"].HeaderText = "Part Name";
                if (dgvDSReport.Columns.Contains("QuantityDelivered")) dgvDSReport.Columns["QuantityDelivered"].HeaderText = "Quantity Delivered";
                if (dgvDSReport.Columns.Contains("ReceiptNo")) dgvDSReport.Columns["ReceiptNo"].HeaderText = "Receipt No.";
            }
        }

        #endregion

        #region Damaged & Lost Items Reports

        private void BtnApplyDamagedItemsFilter_Click(object sender, EventArgs e)
        {
            // Use selected dates & type when APPLY clicked
            LoadDamagedItemsReport(useSelectedRange: true);
        }

        private void LoadDamagedItemsReport(bool useSelectedRange = false)
        {
            try
            {
                string reasonType = cmbType.SelectedItem?.ToString() ?? "All";
                DateTime start = useSelectedRange ? dtpFrom4.Value.Date : WideRangeStart;
                DateTime end = useSelectedRange ? dtpTo4.Value.Date : WideRangeEnd;

                DataTable dt = InventoryManager.GetDamagedLostItemsReport(start, end, reasonType);
                dgvDLIReport.Columns.Clear();
                dgvDLIReport.DataSource = dt;
                dgvDLIReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (dgvDLIReport.Columns.Contains("Date"))
                {
                    dgvDLIReport.Columns["Date"].DefaultCellStyle.Format = "yyyy-MM-dd";
                    dgvDLIReport.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

                FormatDamagedItemsReportGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading damaged items report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDamagedItemsReportGrid()
        {
            if (dgvDLIReport.Columns.Count > 0)
            {
                if (dgvDLIReport.Columns.Contains("Date")) dgvDLIReport.Columns["Date"].HeaderText = "Date";
                if (dgvDLIReport.Columns.Contains("PartName")) dgvDLIReport.Columns["PartName"].HeaderText = "Part Name";
                if (dgvDLIReport.Columns.Contains("Type")) dgvDLIReport.Columns["Type"].HeaderText = "Type";
                if (dgvDLIReport.Columns.Contains("Quantity")) dgvDLIReport.Columns["Quantity"].HeaderText = "Quantity";
                if (dgvDLIReport.Columns.Contains("RecordedBy")) dgvDLIReport.Columns["RecordedBy"].HeaderText = "Recorded By";
            }
        }

        #endregion

        #region Export to Excel Functions

        private void BtnExportSalesReport_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgvSalesReports, "Sales_Report");
        }

        private void BtnExportInventoryReport_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgvInventoryReports, "Inventory_Report");
        }

        private void BtnExportLowStockReport_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgvLowStockReport, "Low_Stock_Report");
        }

        private void BtnExportMovingPartsReport_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgvFSParts, "Moving_Parts_Report");
        }

        private void BtnExportSupplierReport_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgvDSReport, "Supplier_Report");
        }

        private void BtnExportDamagedItemsReport_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgvDLIReport, "Damaged_Items_Report");
        }

        private void ExportToExcel(DataGridView dgv, string reportName)
        {
            try
            {
                if (dgv.Rows.Count == 0)
                {
                    MessageBox.Show("No data to export.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    FileName = $"{reportName}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using (XLWorkbook workbook = new XLWorkbook())
                    {
                        DataTable dt = new DataTable();

                        // Add columns
                        foreach (DataGridViewColumn col in dgv.Columns)
                        {
                            if (col.Visible)
                            {
                                dt.Columns.Add(col.HeaderText);
                            }
                        }

                        // Add rows
                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                DataRow dr = dt.NewRow();
                                int colIndex = 0;
                                foreach (DataGridViewColumn col in dgv.Columns)
                                {
                                    if (col.Visible)
                                    {
                                        dr[colIndex] = row.Cells[col.Index].Value ?? "";
                                        colIndex++;
                                    }
                                }
                                dt.Rows.Add(dr);
                            }
                        }

                        var worksheet = workbook.Worksheets.Add(dt, reportName);
                        worksheet.Columns().AdjustToContents();

                        workbook.SaveAs(saveDialog.FileName);

                        MessageBox.Show("Report exported successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}