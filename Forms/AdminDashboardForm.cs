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
               // MessageBox.Show("Error loading dashboard statistics: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        }
    }