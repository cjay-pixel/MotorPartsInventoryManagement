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
        private DamageStaffForm _damageForm;
        private stockinstaffForm _stockinstaffForm;
        private inventorystaffForm _inventorystaffForm;
        public stockadjuForm _stockadjuForm;
        public StockStaffForm()
        {
            InitializeComponent();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            if (_inventorystaffForm == null || _inventorystaffForm.IsDisposed)
            {
                _inventorystaffForm = new inventorystaffForm
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
                _stockinstaffForm = new stockinstaffForm
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

        }
    }
}
