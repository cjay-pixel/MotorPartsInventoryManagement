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
                flowLayoutPanelProducts.Controls.Clear();
                List<SalesManager> products = SalesManager.GetAll();

                foreach (var product in products)
                {
                    CardProductForm card = new CardProductForm();

                    card.id = product.PartID;
                    card.productID = product.PartNumber;
                    card.productName = product.PartName;
                    card.productBrand = product.Brand;
                    card.productCompatibility = product.MotorCompatibility;
                    card.category = product.CategoryName;
                    card.productStock = product.TotalStock.ToString();
                    card.productPrice = "₱" + product.SellingPrice.ToString("N2");



                    card.productImage = LoadProductImage(product.ImagePath);

                    // Subscribe to add to cart event
                    card.Tag = product; // Store product data in Tag
                 //   card.AddToCartClicked += Card_Click;



                    flowLayoutPanelProducts.Controls.Add(card);
                }

                //  lblProductCount.Text = $"Showing {products.Count} product(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private Image LoadProductImage(string imagePath)
        {
            if (string.IsNullOrWhiteSpace(imagePath))
                return null;

            if (!File.Exists(imagePath))
            {
                string alternativePath = Path.Combine(Application.StartupPath, "ProductImages", Path.GetFileName(imagePath));
                if (File.Exists(alternativePath))
                    imagePath = alternativePath;
                else
                    return null;
            }

            try
            {
                using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    Image originalImage = Image.FromStream(fs);
                    Image imageCopy = new Bitmap(originalImage);
                    originalImage.Dispose();
                    return imageCopy;
                }
            }
            catch
            {
                return null;
            }
        }
    }
    }

