namespace MotorPartsInventoryManagement.Forms
{
    partial class CashierForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashierForm));
            this.pnlItems = new System.Windows.Forms.Panel();
            this.pnlItemsInventory = new System.Windows.Forms.FlowLayoutPanel();
            this.PnlItemsSearch = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlOrderTop = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlShadowLeft = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.pnlC = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.btnSales = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.btnAllItems = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.logoBox = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLogout = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlFillR = new System.Windows.Forms.Panel();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.pnlItems.SuspendLayout();
            this.PnlItemsSearch.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlOrder.SuspendLayout();
            this.panel5.SuspendLayout();
            this.PnlOrderBottom.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlOrderTop.SuspendLayout();
            this.pnlShadowLeft.SuspendLayout();
            this.pnlC.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlItems
            // 
            this.pnlItems.Controls.Add(this.pnlItemsInventory);
            this.pnlItems.Controls.Add(this.PnlItemsSearch);
            this.pnlItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlItems.Location = new System.Drawing.Point(408, 0);
            this.pnlItems.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlItems.Name = "pnlItems";
            this.pnlItems.Size = new System.Drawing.Size(527, 1052);
            this.pnlItems.TabIndex = 22;
            // 
            // pnlItemsInventory
            // 
            this.pnlItemsInventory.AutoScroll = true;
            this.pnlItemsInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlItemsInventory.Location = new System.Drawing.Point(0, 89);
            this.pnlItemsInventory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlItemsInventory.Name = "pnlItemsInventory";
            this.pnlItemsInventory.Size = new System.Drawing.Size(527, 963);
            this.pnlItemsInventory.TabIndex = 1;
            // 
            // PnlItemsSearch
            // 
            this.PnlItemsSearch.Controls.Add(this.panel4);
            this.PnlItemsSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlItemsSearch.Location = new System.Drawing.Point(0, 0);
            this.PnlItemsSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PnlItemsSearch.Name = "PnlItemsSearch";
            this.PnlItemsSearch.Size = new System.Drawing.Size(527, 89);
            this.PnlItemsSearch.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Window;
            this.panel4.Controls.Add(this.txtSearch);
            this.panel4.Location = new System.Drawing.Point(29, 12);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(490, 63);
            this.panel4.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(48, 18);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(323, 20);
            this.txtSearch.TabIndex = 0;
            // 
            // pnlOrder
            // 
            this.pnlOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOrder.Controls.Add(this.panel5);
            this.pnlOrder.Controls.Add(this.PnlOrderBottom);
            this.pnlOrder.Controls.Add(this.dataGridView1);
            this.pnlOrder.Controls.Add(this.pnlOrderTop);
            this.pnlOrder.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlOrder.Location = new System.Drawing.Point(935, 0);
            this.pnlOrder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlOrder.Name = "pnlOrder";
            this.pnlOrder.Size = new System.Drawing.Size(574, 1052);
            this.pnlOrder.TabIndex = 21;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblTotal);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.txtDiscountVal);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.cmbDiscountType);
            this.panel5.Controls.Add(this.lblSubtotal);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 596);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(572, 226);
            this.panel5.TabIndex = 3;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(376, 172);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(103, 25);
            this.lblTotal.TabIndex = 8;
            this.lblTotal.Text = "PHP 0.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(35, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 25);
            this.label6.TabIndex = 7;
            this.label6.Text = "Total:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Discount Value:";
            // 
            // txtDiscountVal
            // 
            this.txtDiscountVal.Location = new System.Drawing.Point(368, 120);
            this.txtDiscountVal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDiscountVal.Name = "txtDiscountVal";
            this.txtDiscountVal.Size = new System.Drawing.Size(134, 24);
            this.txtDiscountVal.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 78);
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
            this.cmbDiscountType.Location = new System.Drawing.Point(367, 74);
            this.cmbDiscountType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbDiscountType.Name = "cmbDiscountType";
            this.cmbDiscountType.Size = new System.Drawing.Size(136, 30);
            this.cmbDiscountType.TabIndex = 2;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(374, 14);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(103, 25);
            this.lblSubtotal.TabIndex = 1;
            this.lblSubtotal.Text = "PHP 0.00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(35, 25);
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
            this.PnlOrderBottom.Location = new System.Drawing.Point(0, 822);
            this.PnlOrderBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PnlOrderBottom.Name = "PnlOrderBottom";
            this.PnlOrderBottom.Size = new System.Drawing.Size(572, 228);
            this.PnlOrderBottom.TabIndex = 2;
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnPay.FlatAppearance.BorderSize = 0;
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Location = new System.Drawing.Point(39, 129);
            this.btnPay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(489, 87);
            this.btnPay.TabIndex = 1;
            this.btnPay.Text = "PAY";
            this.btnPay.UseVisualStyleBackColor = false;
            // 
            // pnlTotal
            // 
            this.pnlTotal.Controls.Add(this.txtAmount);
            this.pnlTotal.Controls.Add(this.lblChange);
            this.pnlTotal.Controls.Add(this.label8);
            this.pnlTotal.Controls.Add(this.label4);
            this.pnlTotal.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTotal.Location = new System.Drawing.Point(0, 0);
            this.pnlTotal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Size = new System.Drawing.Size(572, 117);
            this.pnlTotal.TabIndex = 0;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(411, 21);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(114, 24);
            this.txtAmount.TabIndex = 4;
            // 
            // lblChange
            // 
            this.lblChange.AutoSize = true;
            this.lblChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChange.Location = new System.Drawing.Point(410, 69);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(74, 25);
            this.lblChange.TabIndex = 3;
            this.lblChange.Text = "₱ 0.00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(35, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "Change";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(35, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Amount";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeight = 35;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ProdName,
            this.QTY,
            this.Price});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Montserrat", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(0, 89);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(572, 961);
            this.dataGridView1.TabIndex = 1;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            // 
            // ProdName
            // 
            this.ProdName.HeaderText = "ITEM";
            this.ProdName.MinimumWidth = 6;
            this.ProdName.Name = "ProdName";
            // 
            // QTY
            // 
            this.QTY.HeaderText = "QTY";
            this.QTY.MinimumWidth = 6;
            this.QTY.Name = "QTY";
            // 
            // Price
            // 
            this.Price.HeaderText = "COST";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            // 
            // pnlOrderTop
            // 
            this.pnlOrderTop.Controls.Add(this.btnClear);
            this.pnlOrderTop.Controls.Add(this.label5);
            this.pnlOrderTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOrderTop.Location = new System.Drawing.Point(0, 0);
            this.pnlOrderTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlOrderTop.Name = "pnlOrderTop";
            this.pnlOrderTop.Size = new System.Drawing.Size(572, 89);
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
            this.btnClear.Location = new System.Drawing.Point(467, 22);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(87, 47);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear All";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Current Order";
            // 
            // pnlShadowLeft
            // 
            this.pnlShadowLeft.BackColor = System.Drawing.Color.Transparent;
            this.pnlShadowLeft.Controls.Add(this.pnlC);
            this.pnlShadowLeft.Controls.Add(this.pnlFillR);
            this.pnlShadowLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlShadowLeft.FillColor = System.Drawing.Color.White;
            this.pnlShadowLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlShadowLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlShadowLeft.Name = "pnlShadowLeft";
            this.pnlShadowLeft.ShadowColor = System.Drawing.Color.Black;
            this.pnlShadowLeft.ShadowDepth = 5;
            this.pnlShadowLeft.ShadowShift = 8;
            this.pnlShadowLeft.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.ForwardDiagonal;
            this.pnlShadowLeft.Size = new System.Drawing.Size(408, 1052);
            this.pnlShadowLeft.TabIndex = 20;
            // 
            // pnlC
            // 
            this.pnlC.Controls.Add(this.panel3);
            this.pnlC.Controls.Add(this.panel1);
            this.pnlC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlC.Location = new System.Drawing.Point(0, 0);
            this.pnlC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlC.Name = "pnlC";
            this.pnlC.Size = new System.Drawing.Size(397, 1052);
            this.pnlC.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnUser);
            this.panel3.Controls.Add(this.btnReport);
            this.panel3.Controls.Add(this.btnSupplier);
            this.panel3.Controls.Add(this.btnSales);
            this.panel3.Controls.Add(this.btnStock);
            this.panel3.Controls.Add(this.btnAllItems);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 434);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 69, 0, 0);
            this.panel3.Size = new System.Drawing.Size(397, 618);
            this.panel3.TabIndex = 1;
            // 
            // btnUser
            // 
            this.btnUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUser.FlatAppearance.BorderSize = 0;
            this.btnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUser.Image = global::MotorPartsInventoryManagement.Properties.Resources.user;
            this.btnUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUser.Location = new System.Drawing.Point(0, 539);
            this.btnUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUser.Name = "btnUser";
            this.btnUser.Padding = new System.Windows.Forms.Padding(45, 0, 0, 0);
            this.btnUser.Size = new System.Drawing.Size(397, 94);
            this.btnUser.TabIndex = 6;
            this.btnUser.Text = "User Management";
            this.btnUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUser.UseVisualStyleBackColor = true;
            // 
            // btnReport
            // 
            this.btnReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReport.FlatAppearance.BorderSize = 0;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Image = global::MotorPartsInventoryManagement.Properties.Resources.report;
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.Location = new System.Drawing.Point(0, 445);
            this.btnReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReport.Name = "btnReport";
            this.btnReport.Padding = new System.Windows.Forms.Padding(45, 0, 0, 0);
            this.btnReport.Size = new System.Drawing.Size(397, 94);
            this.btnReport.TabIndex = 5;
            this.btnReport.Text = "Reports";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReport.UseVisualStyleBackColor = true;
            // 
            // btnSupplier
            // 
            this.btnSupplier.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSupplier.FlatAppearance.BorderSize = 0;
            this.btnSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupplier.Image = global::MotorPartsInventoryManagement.Properties.Resources.supplier;
            this.btnSupplier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSupplier.Location = new System.Drawing.Point(0, 351);
            this.btnSupplier.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Padding = new System.Windows.Forms.Padding(45, 0, 0, 0);
            this.btnSupplier.Size = new System.Drawing.Size(397, 94);
            this.btnSupplier.TabIndex = 4;
            this.btnSupplier.Text = "Suppliers";
            this.btnSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSupplier.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSupplier.UseVisualStyleBackColor = true;
            // 
            // btnSales
            // 
            this.btnSales.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSales.FlatAppearance.BorderSize = 0;
            this.btnSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSales.Image = global::MotorPartsInventoryManagement.Properties.Resources.sales;
            this.btnSales.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSales.Location = new System.Drawing.Point(0, 257);
            this.btnSales.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSales.Name = "btnSales";
            this.btnSales.Padding = new System.Windows.Forms.Padding(45, 0, 0, 0);
            this.btnSales.Size = new System.Drawing.Size(397, 94);
            this.btnSales.TabIndex = 3;
            this.btnSales.Text = "Accessories";
            this.btnSales.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSales.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSales.UseVisualStyleBackColor = true;
            // 
            // btnStock
            // 
            this.btnStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStock.FlatAppearance.BorderSize = 0;
            this.btnStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStock.Image = global::MotorPartsInventoryManagement.Properties.Resources.packaging;
            this.btnStock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStock.Location = new System.Drawing.Point(0, 163);
            this.btnStock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStock.Name = "btnStock";
            this.btnStock.Padding = new System.Windows.Forms.Padding(45, 0, 0, 0);
            this.btnStock.Size = new System.Drawing.Size(397, 94);
            this.btnStock.TabIndex = 2;
            this.btnStock.Text = "Brake System";
            this.btnStock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStock.UseVisualStyleBackColor = true;
            // 
            // btnAllItems
            // 
            this.btnAllItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAllItems.FlatAppearance.BorderSize = 0;
            this.btnAllItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAllItems.Image = global::MotorPartsInventoryManagement.Properties.Resources.inventory_24;
            this.btnAllItems.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAllItems.Location = new System.Drawing.Point(0, 69);
            this.btnAllItems.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAllItems.Name = "btnAllItems";
            this.btnAllItems.Padding = new System.Windows.Forms.Padding(45, 0, 0, 0);
            this.btnAllItems.Size = new System.Drawing.Size(397, 94);
            this.btnAllItems.TabIndex = 1;
            this.btnAllItems.Text = "All Items";
            this.btnAllItems.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAllItems.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAllItems.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.logoBox);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(397, 434);
            this.panel1.TabIndex = 0;
            // 
            // logoBox
            // 
            this.logoBox.BackColor = System.Drawing.Color.Transparent;
            this.logoBox.BackgroundImage = global::MotorPartsInventoryManagement.Properties.Resources.logo_trans_white;
            this.logoBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.logoBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoBox.InitialImage = null;
            this.logoBox.Location = new System.Drawing.Point(0, 0);
            this.logoBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(397, 346);
            this.logoBox.TabIndex = 1;
            this.logoBox.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnLogout);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 346);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(397, 88);
            this.panel2.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogout.BorderRadius = 9;
            this.btnLogout.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogout.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogout.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogout.FillColor = System.Drawing.Color.LightGray;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.Black;
            this.btnLogout.Location = new System.Drawing.Point(256, 16);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(118, 54);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Logout";
            this.btnLogout.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(20, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cashier";
            // 
            // pnlFillR
            // 
            this.pnlFillR.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFillR.Location = new System.Drawing.Point(397, 0);
            this.pnlFillR.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlFillR.Name = "pnlFillR";
            this.pnlFillR.Size = new System.Drawing.Size(11, 1052);
            this.pnlFillR.TabIndex = 1;
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
            // CashierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1509, 1052);
            this.Controls.Add(this.pnlItems);
            this.Controls.Add(this.pnlOrder);
            this.Controls.Add(this.pnlShadowLeft);
            this.Font = new System.Drawing.Font("Montserrat", 8.25F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CashierForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CashierForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlItems.ResumeLayout(false);
            this.PnlItemsSearch.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnlOrder.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.PnlOrderBottom.ResumeLayout(false);
            this.pnlTotal.ResumeLayout(false);
            this.pnlTotal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlOrderTop.ResumeLayout(false);
            this.pnlOrderTop.PerformLayout();
            this.pnlShadowLeft.ResumeLayout(false);
            this.pnlC.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlItems;
        private System.Windows.Forms.FlowLayoutPanel pnlItemsInventory;
        private System.Windows.Forms.Panel PnlItemsSearch;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel pnlOrder;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel PnlOrderBottom;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.Panel pnlOrderTop;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnlShadowLeft;
        private System.Windows.Forms.Panel pnlC;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.Button btnSales;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnAllItems;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox logoBox;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlFillR;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDiscountVal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDiscountType;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label6;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}