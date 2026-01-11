using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotorPartsInventoryManagement.Forms
{
    public partial class CardProductForm : UserControl
    {
        public CardProductForm()
        {
            InitializeComponent();
        }
        public int id { set; get; }
        public string productID { set; get; }
        public string productName
        {
            get
            {
                return lblProdName.Text;
            }
            set
            {
                lblProdName.Text = value;
            }
        }
        public string productStock
        {
            get
            {
                return lblStock.Text;
            }
            set
            {
                lblStock.Text = value;
            }
        }
        public string productPrice
        {
            get
            {
                return lblPrice.Text;
            }
            set
            {
                lblPrice.Text = value;
            }
        }
        public Image productImage
        {
            get
            {
                return pbProduct.Image;
            }
            set
            {
                if (pbProduct.Image != null)
                {
                    pbProduct.Image.Dispose();
                }
                pbProduct.Image = value;
                pbProduct.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
        public string productQuantity
        {
            get
            {
                return txtQuantity.Text;
            }
            set
            {
                txtQuantity.Text = value;
            }

        }
        public string productBrand
        {
            get { return lblBrand.Text; }
            set { lblBrand.Text = value; }
        }

        public string category { set; get; }

        public event EventHandler AddToCartClicked;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddToCartClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
