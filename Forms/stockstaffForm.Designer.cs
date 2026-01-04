namespace MotorPartsInventoryManagement.Forms
{
    partial class StockStaffForm
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
            this.pnlShadowLeft = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.pnlC = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnSales = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.logoBox = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlFillR = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.inventorystaffForm1 = new MotorPartsInventoryManagement.Forms.InventoryStaffForm();
            this.pnlShadowLeft.SuspendLayout();
            this.pnlC.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlShadowLeft
            // 
            this.pnlShadowLeft.BackColor = System.Drawing.Color.Transparent;
            this.pnlShadowLeft.Controls.Add(this.pnlC);
            this.pnlShadowLeft.Controls.Add(this.pnlFillR);
            this.pnlShadowLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlShadowLeft.FillColor = System.Drawing.Color.White;
            this.pnlShadowLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlShadowLeft.Name = "pnlShadowLeft";
            this.pnlShadowLeft.ShadowColor = System.Drawing.Color.Black;
            this.pnlShadowLeft.ShadowDepth = 5;
            this.pnlShadowLeft.ShadowShift = 8;
            this.pnlShadowLeft.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.ForwardDiagonal;
            this.pnlShadowLeft.Size = new System.Drawing.Size(398, 790);
            this.pnlShadowLeft.TabIndex = 1;
            // 
            // pnlC
            // 
            this.pnlC.Controls.Add(this.panel3);
            this.pnlC.Controls.Add(this.panel1);
            this.pnlC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlC.Location = new System.Drawing.Point(0, 0);
            this.pnlC.Name = "pnlC";
            this.pnlC.Size = new System.Drawing.Size(388, 790);
            this.pnlC.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnReport);
            this.panel3.Controls.Add(this.btnSales);
            this.panel3.Controls.Add(this.btnStock);
            this.panel3.Controls.Add(this.btnInventory);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 316);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 50, 0, 0);
            this.panel3.Size = new System.Drawing.Size(388, 474);
            this.panel3.TabIndex = 1;
            // 
            // btnReport
            // 
            this.btnReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReport.FlatAppearance.BorderSize = 0;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Image = global::MotorPartsInventoryManagement.Properties.Resources.report;
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.Location = new System.Drawing.Point(0, 254);
            this.btnReport.Name = "btnReport";
            this.btnReport.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnReport.Size = new System.Drawing.Size(388, 68);
            this.btnReport.TabIndex = 5;
            this.btnReport.Text = "Damaged/Missing";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReport.UseVisualStyleBackColor = true;
            // 
            // btnSales
            // 
            this.btnSales.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSales.FlatAppearance.BorderSize = 0;
            this.btnSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSales.Image = global::MotorPartsInventoryManagement.Properties.Resources.sales;
            this.btnSales.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSales.Location = new System.Drawing.Point(0, 186);
            this.btnSales.Name = "btnSales";
            this.btnSales.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnSales.Size = new System.Drawing.Size(388, 68);
            this.btnSales.TabIndex = 3;
            this.btnSales.Text = "Stock Adjustment";
            this.btnSales.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSales.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSales.UseVisualStyleBackColor = true;
            this.btnSales.Click += new System.EventHandler(this.btnSales_Click);
            // 
            // btnStock
            // 
            this.btnStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStock.FlatAppearance.BorderSize = 0;
            this.btnStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStock.Image = global::MotorPartsInventoryManagement.Properties.Resources.packaging;
            this.btnStock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStock.Location = new System.Drawing.Point(0, 118);
            this.btnStock.Name = "btnStock";
            this.btnStock.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnStock.Size = new System.Drawing.Size(388, 68);
            this.btnStock.TabIndex = 2;
            this.btnStock.Text = "Stock In";
            this.btnStock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStock.UseVisualStyleBackColor = true;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInventory.FlatAppearance.BorderSize = 0;
            this.btnInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventory.Image = global::MotorPartsInventoryManagement.Properties.Resources.inventory_24;
            this.btnInventory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventory.Location = new System.Drawing.Point(0, 50);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnInventory.Size = new System.Drawing.Size(388, 68);
            this.btnInventory.TabIndex = 1;
            this.btnInventory.Text = "Inventory Management";
            this.btnInventory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInventory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInventory.UseVisualStyleBackColor = true;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.logoBox);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 316);
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
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(388, 252);
            this.logoBox.TabIndex = 1;
            this.logoBox.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.guna2Button1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 252);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(388, 64);
            this.panel2.TabIndex = 1;
            // 
            // guna2Button1
            // 
            this.guna2Button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2Button1.BorderRadius = 9;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.LightGray;
            this.guna2Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.Location = new System.Drawing.Point(246, 12);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(105, 39);
            this.guna2Button1.TabIndex = 1;
            this.guna2Button1.Text = "Logout";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(36, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stock Staff";
            // 
            // pnlFillR
            // 
            this.pnlFillR.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFillR.Location = new System.Drawing.Point(388, 0);
            this.pnlFillR.Name = "pnlFillR";
            this.pnlFillR.Size = new System.Drawing.Size(10, 790);
            this.pnlFillR.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.inventorystaffForm1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(398, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(929, 790);
            this.panel4.TabIndex = 2;
            // 
            // inventorystaffForm1
            // 
            this.inventorystaffForm1.Location = new System.Drawing.Point(0, 0);
            this.inventorystaffForm1.Name = "inventorystaffForm1";
            this.inventorystaffForm1.Size = new System.Drawing.Size(929, 790);
            this.inventorystaffForm1.TabIndex = 0;
            // 
            // stockstaffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1327, 790);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pnlShadowLeft);
            this.Name = "stockstaffForm";
            this.Text = "stockstaffForm";
            this.pnlShadowLeft.ResumeLayout(false);
            this.pnlC.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel pnlShadowLeft;
        private System.Windows.Forms.Panel pnlC;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnSales;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox logoBox;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlFillR;
        private System.Windows.Forms.Panel panel4;
        private InventoryStaffForm inventorystaffForm1;
    }
}