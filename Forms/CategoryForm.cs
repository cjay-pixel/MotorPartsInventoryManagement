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
        public CategoryForm()
        {
            InitializeComponent();
            displayCategories();
        }

        private int getID = 0;
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
            dgvCategory.DataSource = CategoryManager.GetAll();
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

    }
}
