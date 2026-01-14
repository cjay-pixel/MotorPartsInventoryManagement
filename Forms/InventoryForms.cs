using MotorPartsInventoryManagement.Database;
using MotorPartsInventoryManagement.Managers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotorPartsInventoryManagement.Forms
{
    public partial class InventoryForms : UserControl
    {
       
        private int selectedPartID = -1;
        private string selectedImagePath = "";

        public InventoryForms()
        {
            InitializeComponent();
            LoadCategories();
            LoadSuppliers();
            displayProducts();

            this.VisibleChanged += InventoryForms_VisibleChanged;
        }


        public void LoadCategories()
        {
            List<CategoryManager> categories = CategoryManager.GetAll();
            cmbCategory.DataSource = categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryID";
            cmbCategory.SelectedIndex = -1;
        }

        public void LoadSuppliers()
        {
            List<SupplierManager> suppliers = SupplierManager.GetAll();
            cmbSupplier.DataSource = suppliers;
            cmbSupplier.DisplayMember = "SupplierName";
            cmbSupplier.ValueMember = "SupplierID";
            cmbSupplier.SelectedIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;

            try
            {
                string savedImagePath = SaveProductImage(selectedImagePath);

                MotorPartsManager.Add(
                    txtPartNumber.Text.Trim(),
                    txtProductName.Text.Trim(),
                    txtModelComp.Text.Trim(),
                    txtBrand.Text.Trim(),
                    Convert.ToInt32(cmbCategory.SelectedValue),
                    Convert.ToInt32(cmbSupplier.SelectedValue),
                    Convert.ToDecimal(txtCost.Text.Trim()),
                    Convert.ToDecimal(txtSellingPrice.Text.Trim()),
                    Convert.ToInt32(txtReorder.Text.Trim()),
                    Convert.ToInt32(txtQuantity.Text.Trim()),
                    savedImagePath
                );

                MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                displayProducts();
                clearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedPartID == -1)
            {
                MessageBox.Show("Please select a product to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidateFields()) return;

            try
            {
                string currentImagePath = dgvProducts.CurrentRow.Cells["Image"].Value?.ToString() ?? "";
                string imageToSave = string.IsNullOrEmpty(selectedImagePath) ? currentImagePath : SaveProductImage(selectedImagePath);

                MotorPartsManager.Update(
                    selectedPartID,
                    txtPartNumber.Text.Trim(),
                    txtProductName.Text.Trim(),
                    txtModelComp.Text.Trim(),
                    txtBrand.Text.Trim(),
                    Convert.ToInt32(cmbCategory.SelectedValue),
                    Convert.ToInt32(cmbSupplier.SelectedValue),
                    Convert.ToDecimal(txtCost.Text.Trim()),
                    Convert.ToDecimal(txtSellingPrice.Text.Trim()),
                    Convert.ToInt32(txtReorder.Text.Trim()),
                    Convert.ToInt32(txtQuantity.Text.Trim()),
                    imageToSave
                );

                MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                selectedImagePath = "";
                displayProducts();
                clearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedPartID == -1)
            {
                MessageBox.Show("Please select a product to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirm = MessageBox.Show(
                "Are you sure you want to delete this product?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            try
            {
                MotorPartsManager.Delete(selectedPartID);
                MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                displayProducts();
                clearFields();
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

        private void btnImportImg_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select Product Image";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = ofd.FileName;

                    if (pbProduct.Image != null)
                    {
                        pbProduct.Image.Dispose();
                        pbProduct.Image = null;
                    }

                    pbProduct.Image = Image.FromFile(selectedImagePath);
                    pbProduct.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProducts.Rows[e.RowIndex];

                selectedPartID = Convert.ToInt32(row.Cells["PartID"].Value);
                txtPartNumber.Text = row.Cells["PartNumber"].Value.ToString();
                txtProductName.Text = row.Cells["ProductName"].Value.ToString();
                txtModelComp.Text = row.Cells["ModelCompatibility"].Value.ToString();
                txtBrand.Text = row.Cells["Brand"].Value.ToString();
                cmbCategory.SelectedValue = Convert.ToInt32(row.Cells["CategoryID"].Value);
                cmbSupplier.SelectedValue = Convert.ToInt32(row.Cells["SupplierID"].Value);
                txtReorder.Text = row.Cells["ReorderLevel"].Value.ToString();
                txtCost.Text = row.Cells["CostPrice"].Value.ToString();
                txtSellingPrice.Text = row.Cells["SellingPrice"].Value.ToString();
                txtQuantity.Text = row.Cells["Quantity"].Value.ToString();

                string imagePath = row.Cells["Image"].Value?.ToString();

                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    if (pbProduct.Image != null)
                    {
                        pbProduct.Image.Dispose();
                        pbProduct.Image = null;
                    }

                    using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        pbProduct.Image = Image.FromStream(fs);
                    }

                    pbProduct.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    pbProduct.Image = null;
                }
            }
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Not used - using CellClick instead
        }

        private void dgvProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvProducts.Columns[e.ColumnIndex].Name == "Quantity")
            {
                int qty = Convert.ToInt32(e.Value);
                int reorder = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["ReorderLevel"].Value);

                if (qty == 0)
                    dgvProducts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                else if (qty <= reorder)
                    dgvProducts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Khaki;
                else
                    dgvProducts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }

        public void displayProducts()
        {
            try
            {
                List<MotorPartsManager> listData = MotorPartsManager.GetAll();

                foreach (var product in listData)
                {
                    product.Status = product.Quantity > 0 ? "Available" : "Unavailable";
                }

                dgvProducts.DataSource = null;
                dgvProducts.Columns.Clear();
                dgvProducts.AutoGenerateColumns = true;
                dgvProducts.DataSource = listData;

                if (dgvProducts.Columns.Contains("Image"))
                    dgvProducts.Columns["Image"].Visible = false;

                dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvProducts.AllowUserToAddRows = false;

                dgvProducts.CellFormatting -= dgvProducts_CellFormatting;
                dgvProducts.CellFormatting += dgvProducts_CellFormatting;

                dgvProducts.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clearFields()
        {
            txtPartNumber.Clear();
            txtProductName.Clear();
            txtModelComp.Clear();
            txtBrand.Clear();
            txtReorder.Clear();
            cmbCategory.SelectedIndex = -1;
            cmbSupplier.SelectedIndex = -1;
            txtCost.Clear();
            txtSellingPrice.Clear();
            txtQuantity.Clear();
            pbProduct.Image = null;
            selectedImagePath = "";
            selectedPartID = -1;
        }

        private string SaveProductImage(string sourcePath)
        {
            if (string.IsNullOrEmpty(sourcePath))
                return "";

            string imagesFolder = Path.Combine(Application.StartupPath, "ProductImages");

            if (!Directory.Exists(imagesFolder))
                Directory.CreateDirectory(imagesFolder);

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(sourcePath);
            string destinationPath = Path.Combine(imagesFolder, fileName);

            File.Copy(sourcePath, destinationPath, true);

            return destinationPath;
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtPartNumber.Text) ||
                string.IsNullOrWhiteSpace(txtProductName.Text) ||
                string.IsNullOrWhiteSpace(txtModelComp.Text) ||
                string.IsNullOrWhiteSpace(txtBrand.Text) ||
                string.IsNullOrWhiteSpace(txtReorder.Text) ||
                cmbCategory.SelectedIndex == -1 ||
                cmbSupplier.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtCost.Text) ||
                string.IsNullOrWhiteSpace(txtSellingPrice.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void InventoryForms_Load(object sender, EventArgs e)
        {

        }

        private void InventoryForms_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                displayProducts(); // refresh every time you return
            }
        }

        private void btnImportImg_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select Product Image";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = ofd.FileName;

                    if (pbProduct.Image != null)
                    {
                        pbProduct.Image.Dispose();
                        pbProduct.Image = null;
                    }

                    pbProduct.Image = Image.FromFile(selectedImagePath);
                    pbProduct.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        public void displayProducts(List<MotorPartsManager> listData)
        {
            try
            {
                foreach (var product in listData)
                {
                    product.Status = product.Quantity > 0 ? "Available" : "Unavailable";
                }

                dgvProducts.DataSource = null;
                dgvProducts.Columns.Clear();
                dgvProducts.AutoGenerateColumns = true;
                dgvProducts.DataSource = listData;

                if (dgvProducts.Columns.Contains("Image"))
                    dgvProducts.Columns["Image"].Visible = false;

                dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvProducts.AllowUserToAddRows = false;

                dgvProducts.CellFormatting -= dgvProducts_CellFormatting;
                dgvProducts.CellFormatting += dgvProducts_CellFormatting;

                dgvProducts.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            List<MotorPartsManager> listData = MotorPartsManager.GetAll();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                listData = listData.Where(p =>
                    (!string.IsNullOrEmpty(p.ProductName) && p.ProductName.ToLower().Contains(searchText)) ||
                    (!string.IsNullOrEmpty(p.PartNumber) && p.PartNumber.ToLower().Contains(searchText)) ||
                    (!string.IsNullOrEmpty(p.ModelCompatibility) && p.ModelCompatibility.ToLower().Contains(searchText)) ||
                    (!string.IsNullOrEmpty(p.Brand) && p.Brand.ToLower().Contains(searchText)) ||
                    (!string.IsNullOrEmpty(p.CategoryName) && p.CategoryName.ToLower().Contains(searchText))
                ).ToList();
            }

            displayProducts(listData);
        }

    }
}
