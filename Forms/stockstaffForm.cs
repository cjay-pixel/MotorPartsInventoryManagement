using MotorPartsInventoryManagement.Models;
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

    public partial class StockStaffForm : Form
    {
        private DamageStaffForm _damagestaffForm;
        private StockInStaffForm _stockinstaffForm;
        private InventoryStaffForm _inventorystaffForm;
        public StockAdjuForm _stockadjuForm;
        public StockStaffForm()
        {
            InitializeComponent();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            if (_inventorystaffForm == null || _inventorystaffForm.IsDisposed)
            {
                _inventorystaffForm = new InventoryStaffForm
                {
                    Dock = DockStyle.Fill
                };
            }
            // Replace current content of the right panel with the user control
            this.panel4.Controls.Clear();
            this.panel4.Controls.Add(_inventorystaffForm);
            _inventorystaffForm.BringToFront();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            if (_stockinstaffForm == null || _stockinstaffForm.IsDisposed)
            {
                _stockinstaffForm = new StockInStaffForm
                {
                    Dock = DockStyle.Fill
                };
            }
            // Replace current content of the right panel with the user control
            this.panel4.Controls.Clear();
            this.panel4.Controls.Add(_stockinstaffForm);
            _stockinstaffForm.BringToFront();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            if (_stockadjuForm == null || _stockadjuForm.IsDisposed)
            {
                _stockadjuForm = new StockAdjuForm
                {
                    Dock = DockStyle.Fill
                };
            }
            // Replace current content of the right panel with the user control
            this.panel4.Controls.Clear();
            this.panel4.Controls.Add(_stockadjuForm);
            _stockadjuForm.BringToFront();
        }

        private void inventorystaffForm1_Load(object sender, EventArgs e)
        {

        }

        private void btnDamaged_Click(object sender, EventArgs e)
        {
            if (_damagestaffForm == null || _damagestaffForm.IsDisposed)
            {
                _damagestaffForm = new DamageStaffForm
                {
                    Dock = DockStyle.Fill
                };
            }
            // Replace current content of the right panel with the user control
            this.panel4.Controls.Clear();
            this.panel4.Controls.Add(_damagestaffForm);
            _damagestaffForm.BringToFront();
        }

        private void inventoryStaffForm1_Load_1(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();

                this.Hide();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (_damagestaffForm == null || _damagestaffForm.IsDisposed)
            {
                _damagestaffForm = new DamageStaffForm
                {
                    Dock = DockStyle.Fill
                };
            }
            // Replace current content of the right panel with the user control
            this.panel4.Controls.Clear();
            this.panel4.Controls.Add(_damagestaffForm);
            _damagestaffForm.BringToFront();
        }
    }
}
