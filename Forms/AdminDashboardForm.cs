using MotorPartsInventoryManagement.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MotorPartsInventoryManagement.Managers.InventoryManager;

namespace MotorPartsInventoryManagement.Forms
{
    public partial class AdminDashboardForm : UserControl
    {
        public AdminDashboardForm()
        {
            InitializeComponent();
            LoadDashboardStats();
            LoadTodaysSales();
        }

        private void LoadTodaysSales()
        {
            try
            {
                dgvTodaysSale.DataSource = SalesManager.GetTodaysSales();
                FormatTodaysSalesGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load today's sales:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormatTodaysSalesGrid()
        {
            dgvTodaysSale.Columns["SaleItemID"].Visible = false;
            dgvTodaysSale.Columns["SaleID"].Visible = false;

            dgvTodaysSale.Columns["PartName"].HeaderText = "Product";
            dgvTodaysSale.Columns["Quantity"].HeaderText = "Qty";
            dgvTodaysSale.Columns["UnitPrice"].HeaderText = "Price";
            dgvTodaysSale.Columns["Subtotal"].HeaderText = "Subtotal";
            dgvTodaysSale.Columns["DateSold"].HeaderText = "Time";

            dgvTodaysSale.Columns["UnitPrice"].DefaultCellStyle.Format = "₱#,##0.00";
            dgvTodaysSale.Columns["Subtotal"].DefaultCellStyle.Format = "₱#,##0.00";
            dgvTodaysSale.Columns["FinalAmount"].DefaultCellStyle.Format = "₱#,##0.00";
            dgvTodaysSale.Columns["DateSold"].DefaultCellStyle.Format = "hh:mm tt";

            dgvTodaysSale.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTodaysSale.ReadOnly = true;
            dgvTodaysSale.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadDashboardStats()
        {
            try
            {
                // Option 1: Get all stats at once (more efficient - single query)
                DashboardStats stats = InventoryManager.GetDashboardStats();

                lblLowStock.Text = stats.LowStockCount.ToString();
                lblTotalProducts.Text = stats.TotalProducts.ToString();
                lblTotalRev.Text = "₱" + stats.TotalRevenue.ToString("N2");
                lblTransactions.Text = stats.TotalTransactions.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard statistics: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        }
    }