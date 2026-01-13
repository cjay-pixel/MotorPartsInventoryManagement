using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotorPartsInventoryManagement.Managers;

namespace MotorPartsInventoryManagement.Forms
{
    public partial class UserManagementForm : UserControl
    {
        private int selectedUserID = -1;

        public UserManagementForm()
        {
            InitializeComponent();
            LoadRoles();
            LoadStatuses();
            displayUsers();
        }

        private void LoadRoles()
        {
            cmbRole.Items.Clear();
            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("Cashier");
            cmbRole.Items.Add("StockStaff");
            cmbRole.SelectedIndex = -1;
        }

        private void LoadStatuses()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Active");
            cmbStatus.Items.Add("Inactive");
            cmbStatus.SelectedIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;

            // Validate password
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if username already exists
            if (UserManager.UsernameExists(txtUsername.Text.Trim()))
            {
                MessageBox.Show("Username already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                UserManager.Add(
                    txtUsername.Text.Trim(),
                    txtPassword.Text,
                    txtFName.Text.Trim(),
                    txtLName.Text.Trim(),
                    cmbRole.Text,
                    cmbStatus.Text
                );

                MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearFields();
                displayUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedUserID == -1)
            {
                MessageBox.Show("Please select a user to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidateFields()) return;

            // Check if username exists for another user
            if (UserManager.UsernameExists(txtUsername.Text.Trim(), selectedUserID))
            {
                MessageBox.Show("Username already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                UserManager.Update(
                    selectedUserID,
                    txtUsername.Text.Trim(),
                    txtFName.Text.Trim(),
                    txtLName.Text.Trim(),
                    cmbRole.Text,
                    cmbStatus.Text
                );

                // Update password if provided
                if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    UserManager.UpdatePassword(selectedUserID, txtPassword.Text);
                }

                MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearFields();
                displayUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedUserID == -1)
            {
                MessageBox.Show("Please select a user to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirm = MessageBox.Show(
                "Are you sure you want to deactivate this user?",
                "Confirm Deactivation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            try
            {
                UserManager.Deactivate(selectedUserID);
                MessageBox.Show("User deactivated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearFields();
                displayUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearFields();
        }



        private void displayUsers()
        {
            try
            {
                dgvUsers.DataSource = UserManager.GetAll();

                if (dgvUsers.Columns.Contains("UserID"))
                    dgvUsers.Columns["UserID"].Visible = false;

                // Hide FirstName and LastName columns if they exist
                if (dgvUsers.Columns.Contains("FirstName"))
                    dgvUsers.Columns["FirstName"].Visible = false;

                if (dgvUsers.Columns.Contains("LastName"))
                    dgvUsers.Columns["LastName"].Visible = false;

                dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvUsers.AllowUserToAddRows = false;

                // Color code by status
                foreach (DataGridViewRow row in dgvUsers.Rows)
                {
                    if (row.Cells["Status"].Value?.ToString() == "Inactive")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGray;
                        row.DefaultCellStyle.ForeColor = Color.DarkGray;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clearFields()
        {
            txtUsername.Clear();
            txtFName.Clear();
            txtLName.Clear();
            txtPassword.Clear();
            cmbRole.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
            selectedUserID = -1;
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtFName.Text) ||
                string.IsNullOrWhiteSpace(txtLName.Text) ||
                cmbRole.SelectedIndex == -1 ||
                cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void UserManagementForm_Load(object sender, EventArgs e)
        {
            displayUsers();
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];

                selectedUserID = Convert.ToInt32(row.Cells["UserID"].Value);
                txtUsername.Text = row.Cells["Username"].Value.ToString();

                // Split FullName back into FirstName and LastName
                string fullName = row.Cells["FullName"].Value.ToString();
                string[] nameParts = fullName.Split(new[] { ' ' }, 2); // Split into max 2 parts

                txtFName.Text = nameParts.Length > 0 ? nameParts[0] : "";
                txtLName.Text = nameParts.Length > 1 ? nameParts[1] : "";

                cmbRole.Text = row.Cells["Role"].Value.ToString();
                cmbStatus.Text = row.Cells["Status"].Value.ToString();

                // Clear password fields when selecting a user
                txtPassword.Clear();
            }
        }
    }
}