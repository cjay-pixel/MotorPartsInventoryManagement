using MotorPartsInventoryManagement.Managers;
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
    public partial class SalesForm : UserControl
    {
        public SalesForm()
        {
            InitializeComponent();
            LoadCategories();
            displayProducts();
        }

        // ========================================
        // LOAD METHODS
        // ========================================

        private void LoadCategories()
        {
            //try
            //{
            //    // Load categories into filter combobox
            //    List<CategoryManager> categories = CategoryManager.GetAll();

            //    cmbCategoryFilter.Items.Clear();
            //    cmbCategoryFilter.Items.Add("All");

            //    foreach (var cat in categories)
            //    {
            //        cmbCategoryFilter.Items.Add(cat.CategoryName);
            //    }

            //    cmbCategoryFilter.SelectedIndex = 0;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error loading categories: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void displayProducts()
        {
            try
            {
                // Clear existing cards
                flowLayoutPanelProducts.Controls.Clear();

                // Get all products (grouped by product name)
                List<SalesManager> products = SalesManager.GetAll();

                // Create card for each product
                foreach (var product in products)
                {
                    CardProductForm card = new CardProductForm();

                    // Set product data
                    card.id = product.PartID;
                    card.productID = product.PartNumber;
                    card.productName = product.PartName;
                    card.productBrand = product.Brand;
                    card.category = product.CategoryName;
                    card.productStock = product.TotalStock.ToString();
                    card.productPrice = "₱" + product.SellingPrice.ToString("N2"); // PHP currency format

                    // Load product image
                    if (!string.IsNullOrEmpty(product.ImagePath) && File.Exists(product.ImagePath))
                    {
                        try
                        {
                            using (FileStream fs = new FileStream(product.ImagePath, FileMode.Open, FileAccess.Read))
                            {
                                card.productImage = Image.FromStream(fs);
                            }
                        }
                        catch
                        {
                            card.productImage = null; // Use default image if loading fails
                        }
                    }
                    else
                    {
                        card.productImage = null; // Use default image
                    }

                    // Add card to flow layout panel
                    flowLayoutPanelProducts.Controls.Add(card);
                }

                // Update product count label if you have one
                //  lblProductCount.Text = $"Showing {products.Count} product(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========================================
        // SEARCH AND FILTER
        // ========================================

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchAndFilterProducts();
        }

        private void cmbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchAndFilterProducts();
        }

        private void SearchAndFilterProducts()
        {
            try
            {
                flowLayoutPanelProducts.Controls.Clear();

                // Get search keyword
                string searchKeyword = txtSearch.Text.Trim();

                // Get selected category
                //    string selectedCategory = cmbCategoryFilter.SelectedItem?.ToString() ?? "All";

                // Get all products
                List<SalesManager> products = SalesManager.GetAll();

                // Apply search filter
                if (!string.IsNullOrWhiteSpace(searchKeyword))
                {
                    searchKeyword = searchKeyword.ToLower();
                    products = products.Where(p =>
                        p.PartName.ToLower().Contains(searchKeyword) ||
                        p.PartNumber.ToLower().Contains(searchKeyword) ||
                        p.Brand.ToLower().Contains(searchKeyword) ||
                        p.CategoryName.ToLower().Contains(searchKeyword)
                    ).ToList();
                }

                // Apply category filter
                //if (selectedCategory != "All")
                //{
                //    products = products.Where(p => p.CategoryName == selectedCategory).ToList();
                //}

                // Display filtered products
                foreach (var product in products)
                {
                    CardProductForm card = new CardProductForm();

                    card.id = product.PartID;
                    card.productID = product.PartNumber;
                    card.productName = product.PartName;
                    card.productBrand = product.Brand;
                    card.category = product.CategoryName;
                    card.productStock = product.TotalStock.ToString();
                    card.productPrice = "₱" + product.SellingPrice.ToString("N2");

                    // Load image
                    if (!string.IsNullOrEmpty(product.ImagePath) && File.Exists(product.ImagePath))
                    {
                        try
                        {
                            using (FileStream fs = new FileStream(product.ImagePath, FileMode.Open, FileAccess.Read))
                            {
                                card.productImage = Image.FromStream(fs);
                            }
                        }
                        catch
                        {
                            card.productImage = null;
                        }
                    }
                    else
                    {
                        card.productImage = null;
                    }

                    flowLayoutPanelProducts.Controls.Add(card);
                }

                // Update count
                //    lblProductCount.Text = $"Showing {products.Count} product(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========================================
        // BUTTON EVENTS
        // ========================================

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            //    cmbCategoryFilter.SelectedIndex = 0;
            displayProducts();
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            SearchAndFilterProducts();
        }

        // ========================================
        // FORM LOAD
        // ========================================

        private void SalesForm_Load(object sender, EventArgs e)
        {
            displayProducts();
        }
    }
}