namespace MotorPartsInventoryManagement.Forms
{
    partial class SalesForm
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesForm));
            this.pnlOrder = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiscountVal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDiscountType = new System.Windows.Forms.ComboBox();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.PnlOrderBottom = new System.Windows.Forms.Panel();
            this.btnPay = new System.Windows.Forms.Button();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblChange = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.pnlOrderTop = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlItems = new System.Windows.Forms.Panel();
            this.flpProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.PnlItemsSearch = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.btnApplyDiscount = new System.Windows.Forms.Button();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.pnlOrder.SuspendLayout();
            this.panel5.SuspendLayout();
            this.PnlOrderBottom.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.pnlOrderTop.SuspendLayout();
            this.pnlItems.SuspendLayout();
            this.PnlItemsSearch.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOrder
            // 
            this.pnlOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOrder.Controls.Add(this.panel5);
            this.pnlOrder.Controls.Add(this.PnlOrderBottom);
            this.pnlOrder.Controls.Add(this.dgvCart);
            this.pnlOrder.Controls.Add(this.pnlOrderTop);
            this.pnlOrder.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlOrder.Location = new System.Drawing.Point(575, 0);
            this.pnlOrder.Name = "pnlOrder";
            this.pnlOrder.Size = new System.Drawing.Size(510, 812);
            this.pnlOrder.TabIndex = 25;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnApplyDiscount);
            this.panel5.Controls.Add(this.lblDiscount);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.lblTotal);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.txtDiscountVal);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.cmbDiscountType);
            this.panel5.Controls.Add(this.lblSubtotal);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 412);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(508, 232);
            this.panel5.TabIndex = 3;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(334, 196);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(103, 25);
            this.lblTotal.TabIndex = 8;
            this.lblTotal.Text = "PHP 0.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(31, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 25);
            this.label6.TabIndex = 7;
            this.label6.Text = "Total:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Discount Value:";
            // 
            // txtDiscountVal
            // 
            this.txtDiscountVal.Location = new System.Drawing.Point(327, 87);
            this.txtDiscountVal.Name = "txtDiscountVal";
            this.txtDiscountVal.Size = new System.Drawing.Size(120, 22);
            this.txtDiscountVal.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Discount Type:";
            // 
            // cmbDiscountType
            // 
            this.cmbDiscountType.FormattingEnabled = true;
            this.cmbDiscountType.Items.AddRange(new object[] {
            "None",
            "Fixed",
            "Percentage"});
            this.cmbDiscountType.Location = new System.Drawing.Point(326, 54);
            this.cmbDiscountType.Name = "cmbDiscountType";
            this.cmbDiscountType.Size = new System.Drawing.Size(121, 24);
            this.cmbDiscountType.TabIndex = 2;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(332, 10);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(103, 25);
            this.lblSubtotal.TabIndex = 1;
            this.lblSubtotal.Text = "PHP 0.00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(31, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "SubTotal:";
            // 
            // PnlOrderBottom
            // 
            this.PnlOrderBottom.Controls.Add(this.btnPay);
            this.PnlOrderBottom.Controls.Add(this.pnlTotal);
            this.PnlOrderBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlOrderBottom.Location = new System.Drawing.Point(0, 644);
            this.PnlOrderBottom.Name = "PnlOrderBottom";
            this.PnlOrderBottom.Size = new System.Drawing.Size(508, 166);
            this.PnlOrderBottom.TabIndex = 2;
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnPay.FlatAppearance.BorderSize = 0;
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Location = new System.Drawing.Point(35, 94);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(435, 63);
            this.btnPay.TabIndex = 1;
            this.btnPay.Text = "PAY";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // pnlTotal
            // 
            this.pnlTotal.Controls.Add(this.txtAmount);
            this.pnlTotal.Controls.Add(this.lblChange);
            this.pnlTotal.Controls.Add(this.label8);
            this.pnlTotal.Controls.Add(this.label4);
            this.pnlTotal.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTotal.Location = new System.Drawing.Point(0, 0);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Size = new System.Drawing.Size(508, 85);
            this.pnlTotal.TabIndex = 0;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(365, 15);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(102, 22);
            this.txtAmount.TabIndex = 4;
            this.txtAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyDown);
            // 
            // lblChange
            // 
            this.lblChange.AutoSize = true;
            this.lblChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChange.Location = new System.Drawing.Point(364, 50);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(74, 25);
            this.lblChange.TabIndex = 3;
            this.lblChange.Text = "₱ 0.00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(31, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "Change";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Amount";
            // 
            // dgvCart
            // 
            this.dgvCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCart.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCart.ColumnHeadersHeight = 35;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCart.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCart.EnableHeadersVisualStyles = false;
            this.dgvCart.Location = new System.Drawing.Point(0, 65);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.RowHeadersVisible = false;
            this.dgvCart.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvCart.RowTemplate.Height = 24;
            this.dgvCart.Size = new System.Drawing.Size(508, 745);
            this.dgvCart.TabIndex = 1;
            this.dgvCart.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCart_CellClick);
            // 
            // pnlOrderTop
            // 
            this.pnlOrderTop.Controls.Add(this.btnRemoveItem);
            this.pnlOrderTop.Controls.Add(this.btnClear);
            this.pnlOrderTop.Controls.Add(this.label5);
            this.pnlOrderTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOrderTop.Location = new System.Drawing.Point(0, 0);
            this.pnlOrderTop.Name = "pnlOrderTop";
            this.pnlOrderTop.Size = new System.Drawing.Size(508, 65);
            this.pnlOrderTop.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.LightCoral;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(415, 16);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(77, 34);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear All";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Current Order";
            // 
            // pnlItems
            // 
            this.pnlItems.Controls.Add(this.flpProducts);
            this.pnlItems.Controls.Add(this.PnlItemsSearch);
            this.pnlItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlItems.Location = new System.Drawing.Point(0, 0);
            this.pnlItems.Name = "pnlItems";
            this.pnlItems.Size = new System.Drawing.Size(575, 812);
            this.pnlItems.TabIndex = 26;
            // 
            // flpProducts
            // 
            this.flpProducts.AutoScroll = true;
            this.flpProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpProducts.Location = new System.Drawing.Point(0, 65);
            this.flpProducts.Name = "flpProducts";
            this.flpProducts.Size = new System.Drawing.Size(575, 747);
            this.flpProducts.TabIndex = 1;
            // 
            // PnlItemsSearch
            // 
            this.PnlItemsSearch.Controls.Add(this.panel4);
            this.PnlItemsSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlItemsSearch.Location = new System.Drawing.Point(0, 0);
            this.PnlItemsSearch.Name = "PnlItemsSearch";
            this.PnlItemsSearch.Size = new System.Drawing.Size(575, 65);
            this.PnlItemsSearch.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Window;
            this.panel4.Controls.Add(this.txtSearch);
            this.panel4.Location = new System.Drawing.Point(26, 9);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(436, 46);
            this.panel4.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(43, 13);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(287, 20);
            this.txtSearch.TabIndex = 0;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // btnApplyDiscount
            // 
            this.btnApplyDiscount.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnApplyDiscount.FlatAppearance.BorderSize = 0;
            this.btnApplyDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyDiscount.ForeColor = System.Drawing.Color.White;
            this.btnApplyDiscount.Location = new System.Drawing.Point(308, 153);
            this.btnApplyDiscount.Name = "btnApplyDiscount";
            this.btnApplyDiscount.Size = new System.Drawing.Size(150, 31);
            this.btnApplyDiscount.TabIndex = 15;
            this.btnApplyDiscount.Text = "APPLY DISCOUNT";
            this.btnApplyDiscount.UseVisualStyleBackColor = false;
            this.btnApplyDiscount.Click += new System.EventHandler(this.btnApplyDiscount_Click);
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.Location = new System.Drawing.Point(335, 120);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(88, 20);
            this.lblDiscount.TabIndex = 14;
            this.lblDiscount.Text = "PHP 0.00";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(20, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(143, 20);
            this.label9.TabIndex = 13;
            this.label9.Text = "Discount Amount:";
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveItem.BackColor = System.Drawing.Color.LightCoral;
            this.btnRemoveItem.FlatAppearance.BorderSize = 0;
            this.btnRemoveItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveItem.ForeColor = System.Drawing.Color.White;
            this.btnRemoveItem.Location = new System.Drawing.Point(305, 16);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(103, 34);
            this.btnRemoveItem.TabIndex = 3;
            this.btnRemoveItem.Text = "Remove Item";
            this.btnRemoveItem.UseVisualStyleBackColor = false;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // SalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlItems);
            this.Controls.Add(this.pnlOrder);
            this.Name = "SalesForm";
            this.Size = new System.Drawing.Size(1085, 812);
            this.pnlOrder.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.PnlOrderBottom.ResumeLayout(false);
            this.pnlTotal.ResumeLayout(false);
            this.pnlTotal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.pnlOrderTop.ResumeLayout(false);
            this.pnlOrderTop.PerformLayout();
            this.pnlItems.ResumeLayout(false);
            this.PnlItemsSearch.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlOrder;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDiscountVal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDiscountType;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel PnlOrderBottom;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Panel pnlOrderTop;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlItems;
        private System.Windows.Forms.FlowLayoutPanel flpProducts;
        private System.Windows.Forms.Panel PnlItemsSearch;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button btnApplyDiscount;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnRemoveItem;
    }
}
