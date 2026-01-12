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
using MotorPartsInventoryManagement.Managers;

namespace MotorPartsInventoryManagement.Forms
{
    public partial class CategoryForm : UserControl
    {
        private List<CategoryManager> allCategories; // ✅ ADDED: Store all categories for search

        public CategoryForm()
        {
            InitializeComponent();
            ConfigureDataGridView();
            displayCategories();

            this.VisibleChanged += CategoryForm_VisibleChanged;
        }

        private int getID = 0;

        // ✅ ADDED: New method to configure DataGridView columns
        private void ConfigureDataGridView()
        {
            // Clear any existing columns
            dgvCategory.AutoGenerateColumns = false;
            dgvCategory.Columns.Clear();

            // Add Category ID column (hidden)
            DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
            colID.Name = "CategoryID";
            colID.HeaderText = "ID";
            colID.DataPropertyName = "CategoryID";
            colID.Visible = false; // Hide the ID column
            dgvCategory.Columns.Add(colID);

            // Add Category Name column
            DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn();
            colName.Name = "CategoryName";
            colName.HeaderText = "Category Name";
            colName.DataPropertyName = "CategoryName";
            colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCategory.Columns.Add(colName);

            // Add Parts Count column
            DataGridViewTextBoxColumn colPartsCount = new DataGridViewTextBoxColumn();
            colPartsCount.Name = "PartsCount";
            colPartsCount.HeaderText = "Parts Count";
            colPartsCount.DataPropertyName = "PartsCount";
            colPartsCount.Width = 150;
            dgvCategory.Columns.Add(colPartsCount);

            // Optional: Make the grid read-only
            dgvCategory.ReadOnly = true;
            dgvCategory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategory.MultiSelect = false;
        }

        private void dgvCategory_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dgvCategory.Rows[e.RowIndex];
                getID = (int)row.Cells[0].Value;
                txtCategory.Text = row.Cells[1].Value.ToString();
            }
        }

        public void displayCategories()
        {
            allCategories = CategoryManager.GetAll(); // ✅ CHANGED: Store categories
            dgvCategory.DataSource = allCategories;
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        void clearFields()
        {
            txtCategory.Clear();
            getID = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;

            try
            {
                CategoryManager.Add(txtCategory.Text.Trim());
                MessageBox.Show("Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearFields();
                displayCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (getID == 0)
            {
                MessageBox.Show("Please select a category to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateFields()) return;

            try
            {
                CategoryManager.Update(getID, txtCategory.Text.Trim());
                MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearFields();
                displayCategories();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (getID == 0)
            {
                MessageBox.Show("Please select a category to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this category?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                CategoryManager.Delete(getID);
                MessageBox.Show("Category deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearFields();
                displayCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot delete this category because it is being used.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dgvCategory.Rows[e.RowIndex];
                getID = (int)row.Cells[0].Value;
                txtCategory.Text = row.Cells[1].Value.ToString();
            }
        }

        // ✅ ADDED: Search functionality
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            if (allCategories == null) return;

            if (string.IsNullOrEmpty(searchText))
            {
                // Reset to all categories
                dgvCategory.DataSource = null;
                dgvCategory.DataSource = allCategories;
            }
            else
            {
                // Filter categories
                var filteredCategories = allCategories
                    .Where(cat =>
                        cat.CategoryName.ToLower().Contains(searchText) ||
                        cat.PartsCount.ToString().Contains(searchText)
                    )
                    .ToList();

                dgvCategory.DataSource = null;
                dgvCategory.DataSource = filteredCategories;
            }
        }

        private void CategoryForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                displayCategories(); // refresh every time you return
            }
        }
    }
}