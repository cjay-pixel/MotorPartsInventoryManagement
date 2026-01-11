using MotorPartsInventoryManagement.Managers;
using MySql.Data.MySqlClient;
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
    public partial class SupplierForm : UserControl
    {
        public SupplierForm()
        {
            InitializeComponent();
            displaySuppliers();
        }
        int selectedSupplierId = -1;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSupplierName.Text) ||
      string.IsNullOrWhiteSpace(txtFName.Text) ||
      string.IsNullOrWhiteSpace(txtLName.Text) ||
      string.IsNullOrWhiteSpace(txtAddress.Text) ||
      string.IsNullOrWhiteSpace(txtPhone.Text) ||
      string.IsNullOrWhiteSpace(txtEmail.Text) ||
      cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                MySqlParameter[] parameters =
                {
            new MySqlParameter("@p_SupplierName", txtSupplierName.Text.Trim()),
            new MySqlParameter("@p_ContactFirstName", txtFName.Text.Trim()),
            new MySqlParameter("@p_ContactLastName", txtLName.Text.Trim()),
            new MySqlParameter("@p_Address", txtAddress.Text.Trim()),
            new MySqlParameter("@p_Phone", txtPhone.Text.Trim()),
            new MySqlParameter("@p_Email", txtEmail.Text.Trim()),
            new MySqlParameter("@p_Status", cmbStatus.Text)
        };

                Database.DatabaseHelper.ExecuteStoredProcedure(
                    "AddSupplier",
                    parameters
                );

                MessageBox.Show("Supplier added successfully!");

                clearFields();
                displaySuppliers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedSupplierId == -1)
            {
                MessageBox.Show("Please select a supplier to update.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSupplierName.Text) ||
                string.IsNullOrWhiteSpace(txtFName.Text) ||
                string.IsNullOrWhiteSpace(txtLName.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                MySqlParameter[] parameters =
                {
            new MySqlParameter("@p_SupplierID", selectedSupplierId),
            new MySqlParameter("@p_SupplierName", txtSupplierName.Text.Trim()),
            new MySqlParameter("@p_ContactFirstName", txtFName.Text.Trim()),
            new MySqlParameter("@p_ContactLastName", txtLName.Text.Trim()),
            new MySqlParameter("@p_Address", txtAddress.Text.Trim()),
            new MySqlParameter("@p_Phone", txtPhone.Text.Trim()),
            new MySqlParameter("@p_Email", txtEmail.Text.Trim()),
            new MySqlParameter("@p_Status", cmbStatus.Text)
        };

                Database.DatabaseHelper.ExecuteStoredProcedure(
                    "UpdateSupplier",
                    parameters
                );

                MessageBox.Show("Supplier updated successfully!");

                clearFields();
                displaySuppliers();
                selectedSupplierId = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void clearFields()
        {
            txtSupplierName.Clear();
            txtFName.Clear();
            txtLName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            cmbStatus.SelectedIndex = -1;
            selectedSupplierId = -1;
        }

        private void displaySuppliers()
        {
            dgvSupplier.DataSource = SupplierList.GetAll();

            dgvSupplier.Columns["SupplierID"].Visible = false;
            dgvSupplier.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSupplier.AllowUserToAddRows = false;
        }
        private void dgvSupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedSupplierId = Convert.ToInt32(
                    dgvSupplier.Rows[e.RowIndex].Cells["SupplierID"].Value
                );

                txtSupplierName.Text = dgvSupplier.Rows[e.RowIndex].Cells["SupplierName"].Value.ToString();
                txtFName.Text = dgvSupplier.Rows[e.RowIndex].Cells["ContactFirstName"].Value.ToString();
                txtLName.Text = dgvSupplier.Rows[e.RowIndex].Cells["ContactLastName"].Value.ToString();
                txtAddress.Text = dgvSupplier.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                txtPhone.Text = dgvSupplier.Rows[e.RowIndex].Cells["Phone"].Value.ToString();
                txtEmail.Text = dgvSupplier.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                cmbStatus.Text = dgvSupplier.Rows[e.RowIndex].Cells["Status"].Value.ToString();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSupplierName.Clear();
            txtFName.Clear();
            txtLName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            cmbStatus.SelectedIndex = -1;
            selectedSupplierId = -1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedSupplierId == -1)
            {
                MessageBox.Show("Please select a supplier.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Deactivate this supplier?",
                "Confirm",
                MessageBoxButtons.YesNo
            );

            if (confirm != DialogResult.Yes) return;

            try
            {
                MySqlParameter[] parameters =
                {
            new MySqlParameter("@p_SupplierID", selectedSupplierId)
        };

                Database.DatabaseHelper.ExecuteStoredProcedure(
                    "DeactivateSupplier",
                    parameters
                );

                MessageBox.Show("Supplier deactivated.");

                clearFields();
                displaySuppliers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
