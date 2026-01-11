using MotorPartsInventoryManagement.Managers;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MotorPartsInventoryManagement.Forms
{
    public partial class UserManagementForm : UserControl
    {
        private int selectedUserID = 0;
        private DataTable allUsersTable; // holds all users


        public UserManagementForm()
        {
            InitializeComponent();
            SetupComboBoxes();
            SetupDataGridView();
            LoadUsers();
            UpdateButtonStates();
        }

        private void SetupComboBoxes()
        {
            //cmbRole.Items.Clear();
            //cmbRole.Items.AddRange(new string[] { "Admin", "Cashier", "Stock Staff" });
            //cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new string[] { "Active", "Inactive" });
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.SelectedIndex = 0;
        }

        private void SetupDataGridView()
        {
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.ReadOnly = true;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect = false;

            dgvUsers.Columns.Clear();

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "UserID", DataPropertyName = "UserID", Visible = false });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Username", DataPropertyName = "Username", HeaderText = "Username" });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "FullName", DataPropertyName = "FullName", HeaderText = "Full Name" });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "ROLE", DataPropertyName = "ROLE", HeaderText = "Role" });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "STATUS", DataPropertyName = "STATUS", HeaderText = "Status" });
        }

        private void LoadUsers()
        {
            try
            {
                allUsersTable = UserManager.GetAllUsers(); // keep original
                dgvUsers.DataSource = UserManager.GetAllUsers();
                dgvUsers.ClearSelection();
                selectedUserID = 0;
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateButtonStates()
        {
            btnUpdate.Enabled = selectedUserID > 0;
            btnDelete.Enabled = selectedUserID > 0;
        }

        private void ClearInputs()
        {
            txtUsername.Clear();
            txtFName.Clear();
            txtLName.Clear();
            txtPassword.Clear();
            cmbRole.SelectedIndex = -1;
            cmbStatus.SelectedIndex = 0;
            dgvUsers.ClearSelection();
            selectedUserID = 0;
            UpdateButtonStates();
        }

        private bool ValidateInputs(bool isUpdate = false)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text)) { MessageBox.Show("Enter username"); txtUsername.Focus(); return false; }
            if (string.IsNullOrWhiteSpace(txtFName.Text)) { MessageBox.Show("Enter first name"); txtFName.Focus(); return false; }
            if (string.IsNullOrWhiteSpace(txtLName.Text)) { MessageBox.Show("Enter last name"); txtLName.Focus(); return false; }
            if (!isUpdate && string.IsNullOrWhiteSpace(txtPassword.Text)) { MessageBox.Show("Enter password"); txtPassword.Focus(); return false; }
            if (cmbRole.SelectedIndex == -1) { MessageBox.Show("Select role"); cmbRole.Focus(); return false; }
            if (cmbStatus.SelectedIndex == -1) { MessageBox.Show("Select status"); cmbStatus.Focus(); return false; }
            return true;
        }

        // Add User
        private bool isAddingNewUser = false;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!isAddingNewUser)
            {
                // First click → start Add mode
                ClearInputs();
                isAddingNewUser = true;
                MessageBox.Show("Fill the form to add a new user.", "Add New User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Second click → actually add the user
            if (!ValidateInputs()) return;

            if (UserManager.UsernameExists(txtUsername.Text.Trim()))
            {
                MessageBox.Show("Username already exists!", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            try
            {
                UserManager.AddUser(
                    txtUsername.Text.Trim(),
                    txtPassword.Text,
                    txtFName.Text.Trim(),
                    txtLName.Text.Trim(),
                    cmbRole.SelectedItem.ToString(),
                    cmbStatus.SelectedItem.ToString()
                );

                MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadUsers();
                ClearInputs();
                isAddingNewUser = false; // Reset flag after adding
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding user:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Select a user to edit
        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                selectedUserID = 0;
                UpdateButtonStates();
                return;
            }

            var drv = dgvUsers.SelectedRows[0].DataBoundItem as DataRowView;
            if (drv == null) return;

            selectedUserID = Convert.ToInt32(drv["UserID"]);
            txtUsername.Text = drv["Username"].ToString();

            var names = drv["FullName"].ToString().Split(' ');
            txtFName.Text = names[0];
            txtLName.Text = names.Length > 1 ? string.Join(" ", names.Skip(1)) : "";

            cmbRole.SelectedItem = drv["ROLE"].ToString();
            cmbStatus.SelectedItem = drv["STATUS"].ToString();

            txtPassword.Clear();
            UpdateButtonStates();
        }

        private void cbShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = cbShowPass.Checked ? '\0' : '*';
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Make sure a user is selected
            if (selectedUserID == 0)
            {
                MessageBox.Show("Please select a user to update.", "No User Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate inputs (allow skipping password if not changing)
            if (!ValidateInputs(isUpdate: true))
                return;

            try
            {
                // Update user
                UserManager.UpdateUser(
                    userID: selectedUserID,
                    username: txtUsername.Text.Trim(),
                    password: string.IsNullOrWhiteSpace(txtPassword.Text) ? null : txtPassword.Text, // keep existing if empty
                    firstName: txtFName.Text.Trim(),
                    lastName: txtLName.Text.Trim(),
                    role: cmbRole.SelectedItem.ToString(),
                    status: cmbStatus.SelectedItem.ToString()
                );

                MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload table and clear selection
                LoadUsers();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating user:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                "Are you sure you want to delete this user?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DataRowView drv = dgvUsers.SelectedRows[0].DataBoundItem as DataRowView;
                int userID = Convert.ToInt32(drv["UserID"]);

                try
                {
                    UserManager.DeleteUser(userID);
                    MessageBox.Show("User deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadUsers(); // Refresh DataGridView
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting user:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }


        // Search

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            if (allUsersTable == null) return;

            if (string.IsNullOrEmpty(searchText))
            {
                dgvUsers.DataSource = allUsersTable; // reset to all users
            }
            else
            {
                var filteredRows = allUsersTable.AsEnumerable()
                    .Where(row =>
                        row["Username"].ToString().ToLower().Contains(searchText) ||
                        row["FullName"].ToString().ToLower().Contains(searchText) ||
                        row["ROLE"].ToString().ToLower().Contains(searchText) ||
                        row["STATUS"].ToString().ToLower().Contains(searchText)
                    );

                dgvUsers.DataSource = filteredRows.Any() ? filteredRows.CopyToDataTable() : allUsersTable.Clone();
            }
        }


    }
}
