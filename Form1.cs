using System;
using System.Windows.Forms;
using MotorPartsInventoryManagement.Database;
using MotorPartsInventoryManagement.Forms;
using MotorPartsInventoryManagement.Managers;
using MotorPartsInventoryManagement.Models;
using MotorPartsInventoryManagement.Utilities;

namespace MotorPartsInventoryManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Add event handlers
            txtUsername.KeyDown += TxtUsername_KeyDown;
            txtPassword.KeyDown += TxtPassword_KeyDown;
            cmbRole.KeyDown += CmbRole_KeyDown;
            btnLogin.Click += BtnLogin_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Test database connection
            try
            {
                if (DatabaseHelper.TestConnection())
                {
                    this.Text = "Motor Parts Inventory Management System - Connected";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Database Connection Failed!\n\n" + ex.Message,
                    "Connection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                btnLogin.Enabled = false;
                btnLogin.Text = "NO CONNECTION";
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            PerformLogin();
        }

        private void PerformLogin()
        {
            // Validate inputs
            //if (cmbRole.SelectedIndex == -1)
            //{
            //    MessageBox.Show(
            //        "Please select your role.",
            //        "Validation Error",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Warning);
            //    cmbRole.Focus();
            //    return;
            //}

            // Validate Username
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show(
                    "Please enter your username.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            // Validate Password
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show(
                    "Please enter your password.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            // Show loading state
            btnLogin.Enabled = false;
            btnLogin.Text = "LOGGING IN...";
            this.Cursor = Cursors.WaitCursor;

            try
            {
                // Get selected role
                string selectedRole = cmbRole.SelectedItem.ToString();

                // Map UI role names to database role names
                string dbRole = selectedRole;
                if (selectedRole == "Stock Staff")
                {
                    dbRole = "StockStaff";
                }

                // Attempt login using stored procedure
                User user = UserManager.Login(txtUsername.Text.Trim(), txtPassword.Text);

                if (user != null)
                {
                    // Verify the selected role matches the user's actual role
                    if (user.Role != dbRole)
                    {
                        MessageBox.Show(
                            $"Invalid role selection.\nYour account role is: {GetDisplayRole(user.Role)}",
                            "Role Mismatch",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        ResetLoginButton();
                        return;
                    }

                    // Check if user account is active
                    if (user.Status != "Active")
                    {
                        MessageBox.Show(
                            "Your account has been deactivated.\nPlease contact the administrator.",
                            "Account Inactive",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        ResetLoginButton();
                        return;
                    }

                    // Store user in session
                    SessionManager.CurrentUser = user;

                    // Show success message
                    MessageBox.Show(
                        $"Welcome, {user.FullName}!",
                        "Login Successful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Hide login form
                    this.Hide();

                    // TODO: Open appropriate dashboard based on role
                    // For now, just show login again
                    this.Show();
                    ClearLoginForm();
                    ResetLoginButton();

                    //UNCOMMENT THIS WHEN YOU CREATE DASHBOARD FORMS
                    Form dashboardForm = null;

                    switch (user.Role)
                    {
                        case "Admin":
                            dashboardForm = new AdminForm();
                            break;

                        case "Cashier":
                            dashboardForm = new CashierForm();
                            break;

                        case "StockStaff":
                            dashboardForm = new StockStaffForm();
                            break;
                    }

                    if (dashboardForm != null)
                    {
                        dashboardForm.ShowDialog();
                        this.Show();
                        ClearLoginForm();
                        ResetLoginButton();
                    }
                    
                }
                else
                {
                    // Login failed - invalid credentials
                    MessageBox.Show(
                        "Invalid username or password.\nPlease try again.",
                        "Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    txtPassword.Clear();
                    txtUsername.Focus();
                    ResetLoginButton();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Login error:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                ResetLoginButton();
            }
        }

        private void ResetLoginButton()
        {
            btnLogin.Enabled = true;
            btnLogin.Text = "LOGIN";
            this.Cursor = Cursors.Default;
        }

        private void ClearLoginForm()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            cmbRole.SelectedIndex = 0;
            cbShowPass.Checked = false;
        }

        private string GetDisplayRole(string dbRole)
        {
            switch (dbRole)
            {
                case "StockStaff":
                    return "Stock Staff";
                default:
                    return dbRole;
            }
        }

        // Show/Hide Password
        private void cbShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        // Enter key on Role ComboBox moves to Username
        private void CmbRole_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUsername.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // Enter key on Username textbox moves to Password
        private void TxtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // Enter key on Password textbox triggers login
        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformLogin();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit the application?",
                "Exit Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {

        }
    }
}