using MotorPartsInventoryManagement.Managers;
using MotorPartsInventoryManagement.Models;
using MotorPartsInventoryManagement.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace MotorPartsInventoryManagement.Forms
{
    public partial class SalesForm : UserControl
    {
        private int rowIndex = 0;
        private bool isLastPage = false;
        private List<CartItem> cartItems = new List<CartItem>();
        private int selectedCartIndex = -1;

        public SalesForm()
        {
            InitializeComponent();
            InitializeCartGrid();
            LoadCategories();
            displayProducts();
            this.VisibleChanged += SalesForm_VisibleChanged;
            
            printDocument1.PrintPage += printDocument1_PrintPage;
            printDocument1.BeginPrint += printDocument1_BeginPrint;
        }

        private void InitializeCartGrid()
        {
            dgvCart.Columns.Clear();
            dgvCart.AutoGenerateColumns = false;

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PartName",
                HeaderText = "Product",
                DataPropertyName = "PartName",
                Width = 150
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UnitPrice",
                HeaderText = "Price",
                DataPropertyName = "UnitPrice",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "₱#,##0.00" },
                Width = 80
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Quantity",
                HeaderText = "Qty",
                DataPropertyName = "Quantity",
                Width = 50
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DiscountType",
                HeaderText = "Disc. Type",
                DataPropertyName = "DiscountType",
                Width = 80
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DiscountValue",
                HeaderText = "Disc. Value",
                DataPropertyName = "DiscountValue",
                Width = 80
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Total",
                HeaderText = "Total",
                DataPropertyName = "Total",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "₱#,##0.00" },
                Width = 100
            });

            dgvCart.AllowUserToAddRows = false;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }



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

        //private void displayProducts()
        //{
        //    try
        //    {
        //        // Clear existing cards
        //        flowLayoutPanelProducts.Controls.Clear();

        //        // Get all products (grouped by product name)
        //        List<SalesManager> products = SalesManager.GetAll();

        //        // Create card for each product
        //        foreach (var product in products)
        //        {
        //            CardProductForm card = new CardProductForm();

        //            // Set product data
        //            card.id = product.PartID;
        //            card.productID = product.PartNumber;
        //            card.productName = product.PartName;
        //            card.productBrand = product.Brand;
        //            card.category = product.CategoryName;
        //            card.productStock = product.TotalStock.ToString();
        //            card.productPrice = "₱" + product.SellingPrice.ToString("N2"); // PHP currency format

        //            // Load product image
        //            if (!string.IsNullOrEmpty(product.ImagePath) && File.Exists(product.ImagePath))
        //            {
        //                try
        //                {
        //                    using (FileStream fs = new FileStream(product.ImagePath, FileMode.Open, FileAccess.Read))
        //                    {
        //                        card.productImage = Image.FromStream(fs);
        //                    }
        //                }
        //                catch
        //                {
        //                    card.productImage = null; // Use default image if loading fails
        //                }
        //            }
        //            else
        //            {
        //                card.productImage = null; // Use default image
        //            }

        //            // Add card to flow layout panel
        //            flowLayoutPanelProducts.Controls.Add(card);
        //        }

        //        // Update product count label if you have one
        //        //  lblProductCount.Text = $"Showing {products.Count} product(s)";
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        // ========================================
        // SEARCH AND FILTER
        // ========================================

        private void displayProducts()
        {
            try
            {
                flpProducts.Controls.Clear();
                List<SalesManager> products = SalesManager.GetAll();

                foreach (var product in products)
                {
                    CardProductForm card = new CardProductForm();

                    card.id = product.PartID;
                    card.productID = product.PartNumber;
                    card.productName = product.PartName;
                    card.productCompatibility = product.MotorCompatibility;
                    card.productBrand = product.Brand;
                    card.category = product.CategoryName;
                    card.productStock = product.TotalStock.ToString();
                    card.productPrice = "₱" + product.SellingPrice.ToString("N2");



                    card.productImage = LoadProductImage(product.ImagePath);

                    // Subscribe to add to cart event
                    card.Tag = product; // Store product data in Tag
                    card.AddToCartClicked += Card_Click;



                    flpProducts.Controls.Add(card);
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
        private void Card_Click(object sender, EventArgs e)
        {
            CardProductForm card = sender as CardProductForm;
            if (card == null) return;

            SalesManager product = card.Tag as SalesManager;
            if (product == null) return;

            // Get quantity from card
            int quantity = 1;
            if (!string.IsNullOrWhiteSpace(card.productQuantity))
            {
                int.TryParse(card.productQuantity, out quantity);
            }

            if (quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (quantity > product.TotalStock)
            {
                MessageBox.Show($"Not enough stock! Available: {product.TotalStock}", "Insufficient Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if product already in cart
            CartItem existingItem = cartItems.FirstOrDefault(c => c.PartID == product.PartID);

            if (existingItem != null)
            {
                // Update quantity
                existingItem.Quantity += quantity;
            }
            else
            {
                // Add new item
                CartItem newItem = new CartItem
                {
                    PartID = product.PartID,
                    PartNumber = product.PartNumber,
                    PartName = product.PartName,
                    Brand = product.Brand,
                    UnitPrice = product.SellingPrice,
                    Quantity = quantity,
                    DiscountType = "None",
                    DiscountValue = 0
                };

                cartItems.Add(newItem);
            }

            RefreshCart();
            card.productQuantity = "1"; // Reset quantity
        }

        private void RefreshCart()
        {
            dgvCart.DataSource = null;
            dgvCart.DataSource = cartItems.ToList();

            CalculateTotal();
        }

        private void CalculateTotal()
        {
            decimal subtotal = cartItems.Sum(item => item.Subtotal);
            decimal totalDiscount = cartItems.Sum(item => item.DiscountAmount);
            decimal grandTotal = cartItems.Sum(item => item.Total);

            lblSubtotal.Text = "₱" + subtotal.ToString("N2");
            lblDiscount.Text = "₱" + totalDiscount.ToString("N2");
            lblTotal.Text = "₱" + grandTotal.ToString("N2");
        }

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
                flpProducts.Controls.Clear();

                string searchKeyword = txtSearch.Text.Trim();
            //    string selectedCategory = GetSelectedCategory(); // Get current category filter

                // Get all products
                List<SalesManager> products = SalesManager.GetAll();

                // Apply category filter first
                //if (!string.IsNullOrEmpty(selectedCategory) && selectedCategory != "All")
                //{
                //    products = products.Where(p => p.CategoryName.Equals(selectedCategory, StringComparison.OrdinalIgnoreCase)).ToList();
                //}

                // Apply search filter
                if (!string.IsNullOrWhiteSpace(searchKeyword))
                {
                    searchKeyword = searchKeyword.ToLower();
                    products = products.Where(p =>
                        p.PartName.ToLower().Contains(searchKeyword) ||
                        p.PartNumber.ToLower().Contains(searchKeyword) ||
                        p.MotorCompatibility.ToLower().Contains(searchKeyword) ||
                        p.Brand.ToLower().Contains(searchKeyword) ||
                        p.CategoryName.ToLower().Contains(searchKeyword)
                    ).ToList();
                }

                // Display filtered products
                DisplayProducts(products);

                // Update result count
                //lblResultCount.Text = $"Found {products.Count} product(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DisplayProducts(List<SalesManager> products)
        {
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

                card.productImage = LoadProductImage(product.ImagePath);

                card.Tag = product;
                card.AddToCartClicked += Card_Click;

                flpProducts.Controls.Add(card);
            }
        }

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

        private void btnApplyDiscount_Click(object sender, EventArgs e)
        {
            if (selectedCartIndex == -1)
            {
                MessageBox.Show("Please select a product from the cart first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbDiscountType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a discount type.", "Invalid Discount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal discountValue = 0;
            if (cmbDiscountType.Text != "None")
            {
                if (!decimal.TryParse(txtDiscountVal.Text, out discountValue) || discountValue < 0)
                {
                    MessageBox.Show("Please enter a valid discount value.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Apply discount to selected item
            CartItem selectedItem = cartItems[selectedCartIndex];
            selectedItem.DiscountType = cmbDiscountType.Text;
            selectedItem.DiscountValue = discountValue;

            RefreshCart();

            MessageBox.Show("Discount applied successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    


        private void btnPay_Click(object sender, EventArgs e)
        {
            if (cartItems == null || cartItems.Count == 0)
            {
                MessageBox.Show("Cart is empty. Please add items first.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate amount entered
            if (!check)
            {
                MessageBox.Show("Please enter cash amount and press Enter.", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm payment
            var confirm = MessageBox.Show(
                $"Process payment of {lblTotal.Text}?",
                "Confirm Payment",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                // Get user ID from session
                if (SessionManager.CurrentUser == null)
                {
                    MessageBox.Show("User not logged in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Parse amounts
                decimal totalAmount = decimal.Parse(lblSubtotal.Text.Replace("₱", "").Replace(",", "").Trim());
                decimal discountAmount = decimal.Parse(lblDiscount.Text.Replace("₱", "").Replace(",", "").Trim());

                // Process the sale
                int saleID = SalesManager.ProcessSale(
                    SessionManager.CurrentUser.UserID,
                    totalAmount,
                    discountAmount,
                    cartItems
                );

                // Show success message
                MessageBox.Show($"Sale completed successfully! Sale ID: {saleID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Print receipt
                PrintReceipt();

                // Clear cart after successful sale
                ClearTransaction();

                // Refresh product list to show updated stock
                displayProducts();

                AdminForm main = Application.OpenForms["AdminForm"] as AdminForm;
                main?._inventoryForms?.displayProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing sale: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintReceipt()
        {
            try
            {
                // Show print preview
                printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Receipt", 280, 500);
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();

                // Alternatively, print directly without preview:
                // printDocument1.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing receipt: {ex.Message}", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearTransaction()
        {
            // Clear cart
            cartItems.Clear();
            selectedCartIndex = -1;

            // Clear input fields
            txtAmount.Clear();
            txtDiscountVal.Clear();
            cmbDiscountType.SelectedIndex = -1;

            // Reset labels
            lblSubtotal.Text = "₱0.00";
            lblDiscount.Text = "₱0.00";
            lblTotal.Text = "₱0.00";
            lblChange.Text = "₱0.00";

            // Reset check flag
            check = false;

            // Refresh cart display
            RefreshCart();
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            rowIndex = 0;
            isLastPage = false;
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            Font titleFont = new Font("Courier New", 14, FontStyle.Bold);
            Font textFont = new Font("Courier New", 10);
            Font boldFont = new Font("Courier New", 10, FontStyle.Bold);

            // Center the receipt on the page
            float receiptWidth = 260;
            float x = (e.PageBounds.Width - receiptWidth) / 2;  // Dynamically center the receipt block
            float y = 10;
            float width = x + receiptWidth;  // Right edge of the receipt

            StringFormat center = new StringFormat { Alignment = StringAlignment.Center };
            StringFormat right = new StringFormat { Alignment = StringAlignment.Far };

            // ===== HEADER =====
            g.DrawString("RECEIPT OF SALE", titleFont, Brushes.Black, width / 2, y, center);  // Already centered
            y += 25;

            g.DrawString("CAJ MOTOR PARTS", titleFont, Brushes.Black, width / 2, y, center);  // Already centered
            y += 25;

            g.DrawString("Visayan Village, Tagum City", textFont, Brushes.Black, width / 2, y, center);  // Already centered
            y += 15;
            g.DrawString("Tel: +63 912 345 6789", textFont, Brushes.Black, width / 2, y, center);  // Already centered
            y += 20;

            g.DrawString("------------------------------------------", textFont, Brushes.Black, x, y);
            y += 20;

            // ===== DATE / TIME =====
            g.DrawString(DateTime.Now.ToString("MM/dd/yyyy"), textFont, Brushes.Black, x, y);
            g.DrawString(DateTime.Now.ToString("hh:mm:ss tt"), textFont, Brushes.Black, width, y, right);
            y += 20;

            g.DrawString("------------------------------------------", textFont, Brushes.Black, x, y);
            y += 20;

            // ===== TABLE HEADER =====
            g.DrawString("QTY", boldFont, Brushes.Black, x, y);
            g.DrawString("NAME", boldFont, Brushes.Black, x + 40, y);
            g.DrawString("AMT", boldFont, Brushes.Black, width, y, right);
            y += 15;

            g.DrawString("------------------------------------------", textFont, Brushes.Black, x, y);
            y += 15;

            // ===== ITEMS =====
            while (rowIndex < dgvCart.Rows.Count)
            {
                DataGridViewRow row = dgvCart.Rows[rowIndex];

                if (row.IsNewRow)
                {
                    rowIndex++;
                    continue;
                }

                string qty = row.Cells["Quantity"].Value?.ToString() ?? "0";
                string name = row.Cells["PartName"].Value?.ToString() ?? "";
                string price = row.Cells["UnitPrice"].Value?.ToString() ?? "0.00";

                g.DrawString(qty, textFont, Brushes.Black, x, y);
                g.DrawString(name, textFont, Brushes.Black, x + 40, y);
                g.DrawString($"PHP {Convert.ToDecimal(price):N2}", textFont, Brushes.Black, width, y, right);

                y += 15;
                rowIndex++;

                // PAGE BREAK
                if (y > e.MarginBounds.Bottom - 100)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            // ===== TOTALS =====
            if (!isLastPage)
            {
                isLastPage = true;

                y += 10;
                g.DrawString("------------------------------------------", textFont, Brushes.Black, x, y);
                y += 20;

                g.DrawString("TOTAL", boldFont, Brushes.Black, x, y);
                g.DrawString(lblTotal.Text, boldFont, Brushes.Black, width, y, right);
                y += 20;

                g.DrawString("CASH", textFont, Brushes.Black, x, y);
                g.DrawString(txtAmount.Text, textFont, Brushes.Black, width, y, right);
                y += 15;

                g.DrawString("CHANGE", textFont, Brushes.Black, x, y);
                g.DrawString(lblChange.Text, textFont, Brushes.Black, width, y, right);
                y += 25;

                g.DrawString("------------------------------------------", textFont, Brushes.Black, x, y);
                y += 25;

                g.DrawString("THANK YOU!", boldFont, Brushes.Black, width / 2, y, center);  // Already centered
            }

            e.HasMorePages = false;
        }
        bool check = false;

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            string totalText = lblTotal.Text
              .Replace("₱", "")
              .Replace(",", "")
              .Trim();

            string cashText = txtAmount.Text
                .Replace("₱", "")
                .Replace(",", "")
                .Trim();

            if (!decimal.TryParse(totalText, out decimal total))
            {
                MessageBox.Show("Invalid total amount.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(cashText, out decimal cash))
            {
                MessageBox.Show("Please enter a valid cash amount.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cash < total)
            {
                MessageBox.Show("Insufficient Amount", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            check = true;
            lblChange.Text = $"₱{(cash - total):N2}";
        }

        private void dgvCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedCartIndex = e.RowIndex;
                CartItem selectedItem = cartItems[selectedCartIndex];

                // Display current discount
                cmbDiscountType.Text = selectedItem.DiscountType;
                txtDiscountVal.Text = selectedItem.DiscountValue.ToString();
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (selectedCartIndex == -1)
            {
                MessageBox.Show("Please select an item to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cartItems.RemoveAt(selectedCartIndex);
            selectedCartIndex = -1;

            cmbDiscountType.SelectedIndex = -1;
            txtDiscountVal.Clear();

            RefreshCart();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear all items from cart?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cartItems.Clear();
                selectedCartIndex = -1;
                RefreshCart();
            }
        }
       
        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            SearchAndFilterProducts();
        }

        private void SalesForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                displayProducts(); // refresh every time you return
            }
        }
    }
    }