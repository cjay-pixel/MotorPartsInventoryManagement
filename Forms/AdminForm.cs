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
        private InventoryForms _inventoryForms;
        private AdminDashboardForm _adminDashboardForms;
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
    }
}
