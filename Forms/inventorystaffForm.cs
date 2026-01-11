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
    public partial class InventoryStaffForm : UserControl
    {
        public InventoryStaffForm()
        {
            InitializeComponent();
            displayProducts();
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
    }
}
