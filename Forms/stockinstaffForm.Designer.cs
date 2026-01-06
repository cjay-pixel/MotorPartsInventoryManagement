namespace MotorPartsInventoryManagement.Forms
{
    partial class StockInStaffForm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.gbStockInEntry = new System.Windows.Forms.GroupBox();
            this.txtDRN = new Guna.UI2.WinForms.Guna2TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSave = new Guna.UI2.WinForms.Guna2GradientButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtQuantityR = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSupplier = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPart = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gbStockInHistory = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityAdded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.gbStockInEntry.SuspendLayout();
            this.panel3.SuspendLayout();
            this.gbStockInHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gbStockInEntry);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(20);
            this.panel2.Size = new System.Drawing.Size(1252, 253);
            this.panel2.TabIndex = 3;
            // 
            // gbStockInEntry
            // 
            this.gbStockInEntry.Controls.Add(this.txtDRN);
            this.gbStockInEntry.Controls.Add(this.label10);
            this.gbStockInEntry.Controls.Add(this.btnSave);
            this.gbStockInEntry.Controls.Add(this.dateTimePicker1);
            this.gbStockInEntry.Controls.Add(this.txtQuantityR);
            this.gbStockInEntry.Controls.Add(this.label5);
            this.gbStockInEntry.Controls.Add(this.cmbSupplier);
            this.gbStockInEntry.Controls.Add(this.label4);
            this.gbStockInEntry.Controls.Add(this.cmbPart);
            this.gbStockInEntry.Controls.Add(this.label2);
            this.gbStockInEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbStockInEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbStockInEntry.Location = new System.Drawing.Point(20, 20);
            this.gbStockInEntry.Name = "gbStockInEntry";
            this.gbStockInEntry.Size = new System.Drawing.Size(1212, 213);
            this.gbStockInEntry.TabIndex = 0;
            this.gbStockInEntry.TabStop = false;
            this.gbStockInEntry.Text = "Stock In Entry";
            // 
            // txtDRN
            // 
            this.txtDRN.Animated = true;
            this.txtDRN.BorderRadius = 9;
            this.txtDRN.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDRN.DefaultText = "";
            this.txtDRN.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDRN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDRN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDRN.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDRN.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDRN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtDRN.ForeColor = System.Drawing.Color.Black;
            this.txtDRN.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDRN.Location = new System.Drawing.Point(567, 44);
            this.txtDRN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDRN.Name = "txtDRN";
            this.txtDRN.PlaceholderText = "";
            this.txtDRN.SelectedText = "";
            this.txtDRN.Size = new System.Drawing.Size(218, 36);
            this.txtDRN.TabIndex = 39;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label10.Location = new System.Drawing.Point(406, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(141, 17);
            this.label10.TabIndex = 38;
            this.label10.Text = "Delivery Receipt No.:";
            // 
            // btnSave
            // 
            this.btnSave.Animated = true;
            this.btnSave.BorderRadius = 9;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnSave.FillColor2 = System.Drawing.Color.MidnightBlue;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.IndicateFocus = true;
            this.btnSave.Location = new System.Drawing.Point(31, 149);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(267, 37);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "SAVE";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(842, 52);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(267, 22);
            this.dateTimePicker1.TabIndex = 33;
            // 
            // txtQuantityR
            // 
            this.txtQuantityR.Animated = true;
            this.txtQuantityR.BorderRadius = 9;
            this.txtQuantityR.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtQuantityR.DefaultText = "";
            this.txtQuantityR.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtQuantityR.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtQuantityR.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtQuantityR.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtQuantityR.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtQuantityR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtQuantityR.ForeColor = System.Drawing.Color.Black;
            this.txtQuantityR.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtQuantityR.Location = new System.Drawing.Point(567, 87);
            this.txtQuantityR.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtQuantityR.Name = "txtQuantityR";
            this.txtQuantityR.PlaceholderText = "";
            this.txtQuantityR.SelectedText = "";
            this.txtQuantityR.Size = new System.Drawing.Size(218, 36);
            this.txtQuantityR.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.Location = new System.Drawing.Point(406, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 34);
            this.label5.TabIndex = 31;
            this.label5.Text = "Quantity\r\nto Add:";
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.BackColor = System.Drawing.Color.Transparent;
            this.cmbSupplier.BorderRadius = 9;
            this.cmbSupplier.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbSupplier.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmbSupplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbSupplier.ItemHeight = 30;
            this.cmbSupplier.Location = new System.Drawing.Point(131, 91);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(218, 36);
            this.cmbSupplier.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.Location = new System.Drawing.Point(27, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 29;
            this.label4.Text = "Supplier:";
            // 
            // cmbPart
            // 
            this.cmbPart.BackColor = System.Drawing.Color.Transparent;
            this.cmbPart.BorderRadius = 9;
            this.cmbPart.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPart.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbPart.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmbPart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbPart.ItemHeight = 30;
            this.cmbPart.Location = new System.Drawing.Point(131, 44);
            this.cmbPart.Name = "cmbPart";
            this.cmbPart.Size = new System.Drawing.Size(218, 36);
            this.cmbPart.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(27, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "Part Name:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gbStockInHistory);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 253);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(20);
            this.panel3.Size = new System.Drawing.Size(1252, 537);
            this.panel3.TabIndex = 4;
            // 
            // gbStockInHistory
            // 
            this.gbStockInHistory.Controls.Add(this.dataGridView1);
            this.gbStockInHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbStockInHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbStockInHistory.Location = new System.Drawing.Point(20, 20);
            this.gbStockInHistory.Name = "gbStockInHistory";
            this.gbStockInHistory.Padding = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.gbStockInHistory.Size = new System.Drawing.Size(1212, 497);
            this.gbStockInHistory.TabIndex = 1;
            this.gbStockInHistory.TabStop = false;
            this.gbStockInHistory.Text = "Stock In History";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.PartName,
            this.Supplier,
            this.QuantityAdded,
            this.ReceiptNo});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1206, 459);
            this.dataGridView1.TabIndex = 0;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.MinimumWidth = 6;
            this.Date.Name = "Date";
            // 
            // PartName
            // 
            this.PartName.HeaderText = "Part Name";
            this.PartName.MinimumWidth = 6;
            this.PartName.Name = "PartName";
            // 
            // Supplier
            // 
            this.Supplier.HeaderText = "Supplier";
            this.Supplier.MinimumWidth = 6;
            this.Supplier.Name = "Supplier";
            // 
            // QuantityAdded
            // 
            this.QuantityAdded.HeaderText = "Quantity Added";
            this.QuantityAdded.MinimumWidth = 6;
            this.QuantityAdded.Name = "QuantityAdded";
            // 
            // ReceiptNo
            // 
            this.ReceiptNo.HeaderText = "Receipt No.";
            this.ReceiptNo.MinimumWidth = 6;
            this.ReceiptNo.Name = "ReceiptNo";
            // 
            // StockInStaffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "StockInStaffForm";
            this.Size = new System.Drawing.Size(1252, 790);
            this.panel2.ResumeLayout(false);
            this.gbStockInEntry.ResumeLayout(false);
            this.gbStockInEntry.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.gbStockInHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox gbStockInEntry;
        private Guna.UI2.WinForms.Guna2TextBox txtDRN;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2GradientButton btnSave;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private Guna.UI2.WinForms.Guna2TextBox txtQuantityR;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2ComboBox cmbSupplier;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2ComboBox cmbPart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox gbStockInHistory;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityAdded;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptNo;
    }
}
