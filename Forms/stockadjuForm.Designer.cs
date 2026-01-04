namespace MotorPartsInventoryManagement.Forms
{
    partial class stockadjuForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.inventory_clearBtn = new System.Windows.Forms.Button();
            this.inventory_updateBtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.inventory_status = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.inventory_price = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.inventory_stock = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.inventory_category = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.inventory_productName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.inventory_productID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.inventory_clearBtn);
            this.panel2.Controls.Add(this.inventory_updateBtn);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.inventory_status);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.inventory_price);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.inventory_stock);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.inventory_category);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.inventory_productName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.inventory_productID);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(14, 447);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(899, 273);
            this.panel2.TabIndex = 3;
            // 
            // inventory_clearBtn
            // 
            this.inventory_clearBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(46)))));
            this.inventory_clearBtn.FlatAppearance.BorderSize = 0;
            this.inventory_clearBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(76)))), ((int)(((byte)(65)))));
            this.inventory_clearBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(76)))), ((int)(((byte)(65)))));
            this.inventory_clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inventory_clearBtn.ForeColor = System.Drawing.Color.White;
            this.inventory_clearBtn.Location = new System.Drawing.Point(362, 199);
            this.inventory_clearBtn.Name = "inventory_clearBtn";
            this.inventory_clearBtn.Size = new System.Drawing.Size(122, 30);
            this.inventory_clearBtn.TabIndex = 18;
            this.inventory_clearBtn.Text = "CLEAR";
            this.inventory_clearBtn.UseVisualStyleBackColor = false;
            this.inventory_clearBtn.Click += new System.EventHandler(this.inventory_clearBtn_Click);
            // 
            // inventory_updateBtn
            // 
            this.inventory_updateBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(46)))));
            this.inventory_updateBtn.FlatAppearance.BorderSize = 0;
            this.inventory_updateBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(76)))), ((int)(((byte)(65)))));
            this.inventory_updateBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(76)))), ((int)(((byte)(65)))));
            this.inventory_updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inventory_updateBtn.ForeColor = System.Drawing.Color.White;
            this.inventory_updateBtn.Location = new System.Drawing.Point(215, 199);
            this.inventory_updateBtn.Name = "inventory_updateBtn";
            this.inventory_updateBtn.Size = new System.Drawing.Size(122, 30);
            this.inventory_updateBtn.TabIndex = 16;
            this.inventory_updateBtn.Text = "UPDATE";
            this.inventory_updateBtn.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Location = new System.Drawing.Point(742, 70);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(122, 129);
            this.panel3.TabIndex = 13;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // inventory_status
            // 
            this.inventory_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventory_status.FormattingEnabled = true;
            this.inventory_status.Items.AddRange(new object[] {
            "Available",
            "Unavailble"});
            this.inventory_status.Location = new System.Drawing.Point(474, 101);
            this.inventory_status.Name = "inventory_status";
            this.inventory_status.Size = new System.Drawing.Size(218, 30);
            this.inventory_status.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(412, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Status:";
            // 
            // inventory_price
            // 
            this.inventory_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventory_price.Location = new System.Drawing.Point(474, 64);
            this.inventory_price.Name = "inventory_price";
            this.inventory_price.Size = new System.Drawing.Size(218, 28);
            this.inventory_price.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(383, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Price (Php):";
            // 
            // inventory_stock
            // 
            this.inventory_stock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventory_stock.Location = new System.Drawing.Point(474, 26);
            this.inventory_stock.Name = "inventory_stock";
            this.inventory_stock.Size = new System.Drawing.Size(218, 28);
            this.inventory_stock.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(413, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Stock:";
            // 
            // inventory_category
            // 
            this.inventory_category.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventory_category.FormattingEnabled = true;
            this.inventory_category.Location = new System.Drawing.Point(139, 101);
            this.inventory_category.Name = "inventory_category";
            this.inventory_category.Size = new System.Drawing.Size(218, 30);
            this.inventory_category.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Category:";
            // 
            // inventory_productName
            // 
            this.inventory_productName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventory_productName.Location = new System.Drawing.Point(139, 64);
            this.inventory_productName.Name = "inventory_productName";
            this.inventory_productName.Size = new System.Drawing.Size(218, 28);
            this.inventory_productName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Product Name:";
            // 
            // inventory_productID
            // 
            this.inventory_productID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventory_productID.Location = new System.Drawing.Point(139, 26);
            this.inventory_productID.Name = "inventory_productID";
            this.inventory_productID.Size = new System.Drawing.Size(218, 28);
            this.inventory_productID.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product ID:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(14, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(899, 381);
            this.panel1.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(83, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(238, 22);
            this.txtSearch.TabIndex = 5;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(20, 47);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(861, 315);
            this.dataGridView1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(742, 70);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(122, 129);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // stockadjuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "stockadjuForm";
            this.Size = new System.Drawing.Size(929, 790);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button inventory_clearBtn;
        private System.Windows.Forms.Button inventory_updateBtn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox inventory_status;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox inventory_price;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox inventory_stock;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox inventory_category;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox inventory_productName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inventory_productID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
