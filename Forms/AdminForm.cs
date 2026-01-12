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
    public partial class AdminForm : Form
    {
        public InventoryForms _inventoryForms;
        private AdminDashboardForm _adminDashboardForms;
        private StockOperationForm _stockOperationForm;
        private SupplierForm _supplierForm;
        private CategoryForm _categoryForm;
        private ReportsForm _reportsForm;
        private UserManagementForm _usermanagementForm;
        private SalesForm _salesForm;
        //private CashierForm _cashierForm;
        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            if (_inventoryForms == null || _inventoryForms.IsDisposed)
            {
                _inventoryForms = new InventoryForms
                {
                    Dock = DockStyle.Fill
                };
            }

            // Replace current content of the right panel with the user control
            this.panel4.Controls.Clear();
            this.panel4.Controls.Add(_inventoryForms);
            _inventoryForms.BringToFront();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            if (_adminDashboardForms == null || _adminDashboardForms.IsDisposed)
            {
                _adminDashboardForms = new AdminDashboardForm
                {
                    Dock = DockStyle.Fill
                };
            }

            // Replace current content of the right panel with the user control
            this.panel4.Controls.Clear();
            this.panel4.Controls.Add(_adminDashboardForms);
            _adminDashboardForms.BringToFront();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            if (_stockOperationForm == null || _stockOperationForm.IsDisposed)
            {
                _stockOperationForm = new StockOperationForm
                {
                    Dock = DockStyle.Fill
                };
            }

            // Replace current content of the right panel with the user control
            this.panel4.Controls.Clear();
            this.panel4.Controls.Add(_stockOperationForm);
            _stockOperationForm.BringToFront();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            if (_supplierForm == null || _supplierForm.IsDisposed)
            {
                _supplierForm = new SupplierForm
                {
                    Dock = DockStyle.Fill
                };
            }

            // Replace current content of the right panel with the user control
            this.panel4.Controls.Clear();
            this.panel4.Controls.Add(_supplierForm);
            _supplierForm.BringToFront();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            if (_categoryForm == null || _categoryForm.IsDisposed)
            {
                _categoryForm = new CategoryForm
                {
                    Dock = DockStyle.Fill
                };
            }

            // Replace current content of the right panel with the user control
            this.panel4.Controls.Clear();
            this.panel4.Controls.Add(_categoryForm);
            _categoryForm.BringToFront();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (_reportsForm == null || _reportsForm.IsDisposed)
            {
                _reportsForm = new ReportsForm
                {
                    Dock = DockStyle.Fill
                };
            }

            // Replace current content of the right panel with the user control
            this.panel4.Controls.Clear();
            this.panel4.Controls.Add(_reportsForm);
            _reportsForm.BringToFront();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            if (_usermanagementForm == null || _usermanagementForm.IsDisposed)
            {
                _usermanagementForm = new UserManagementForm
                {
                    Dock = DockStyle.Fill
                };
            }

            // Replace current content of the right panel with the user control
            this.panel4.Controls.Clear();
            this.panel4.Controls.Add(_usermanagementForm);
            _usermanagementForm.BringToFront();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            if (_salesForm == null || _salesForm.IsDisposed)
            {
                _salesForm = new SalesForm
                {
                    Dock = DockStyle.Fill
                };
            }

            // Replace current content of the right panel with the user control
            this.panel4.Controls.Clear();
            this.panel4.Controls.Add(_salesForm);
            _salesForm.BringToFront();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //var result = MessageBox.Show(
            //"Are you sure you want to logout?",
            //"Confirm Logout",
            //MessageBoxButtons.YesNo,
            //MessageBoxIcon.Question);

            //if (result == DialogResult.Yes)
            //{
            //    this.FindForm().Close();
            //}
            if (MessageBox.Show("Are you sure you want to logout?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.FindForm().Close();
            }
        }
    }
}
