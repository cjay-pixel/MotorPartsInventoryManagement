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

            this.VisibleChanged += InventoryStaffForm_VisibleChanged;
        }

        private void IN(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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


        //private void displayProducts()
        //{
        //    try
        //    {
        //        flowLayoutPanelProducts.Controls.Clear();
        //        List<SalesManager> products = SalesManager.GetAll();

        //        foreach (var product in products)
        //        {
        //            CardProductForm card = new CardProductForm();

        //            card.id = product.PartID;
        //            card.productID = product.PartNumber;
        //            card.productName = product.PartName;
        //            card.productBrand = product.Brand;
        //            card.productCompatibility = product.MotorCompatibility;
        //            card.category = product.CategoryName;
        //            card.productStock = product.TotalStock.ToString();
        //            card.productPrice = "₱" + product.SellingPrice.ToString("N2");



        //            card.productImage = LoadProductImage(product.ImagePath);

        //            // Subscribe to add to cart event
        //            card.Tag = product; // Store product data in Tag
        //         //   card.AddToCartClicked += Card_Click;



        //            flowLayoutPanelProducts.Controls.Add(card);
        //        }

        //        //  lblProductCount.Text = $"Showing {products.Count} product(s)";
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}


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

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void InventoryStaffForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
                {
                displayProducts();
            }
        }
    }
    }

