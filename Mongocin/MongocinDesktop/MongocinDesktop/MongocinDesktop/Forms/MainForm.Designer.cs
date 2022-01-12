namespace MongocinDesktop.Forms
{
    partial class MainForm
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
            this.listViewShop = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewWarehouse = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonShop = new System.Windows.Forms.Button();
            this.buttonWarehouse = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewShop
            // 
            this.listViewShop.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3});
            this.listViewShop.HideSelection = false;
            this.listViewShop.Location = new System.Drawing.Point(47, 69);
            this.listViewShop.Name = "listViewShop";
            this.listViewShop.Size = new System.Drawing.Size(283, 311);
            this.listViewShop.TabIndex = 0;
            this.listViewShop.UseCompatibleStateImageBehavior = false;
            this.listViewShop.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Id";
            // 
            // listViewWarehouse
            // 
            this.listViewWarehouse.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader4});
            this.listViewWarehouse.HideSelection = false;
            this.listViewWarehouse.Location = new System.Drawing.Point(562, 69);
            this.listViewWarehouse.Name = "listViewWarehouse";
            this.listViewWarehouse.Size = new System.Drawing.Size(294, 311);
            this.listViewWarehouse.TabIndex = 1;
            this.listViewWarehouse.UseCompatibleStateImageBehavior = false;
            this.listViewWarehouse.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 110;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Id";
            this.columnHeader4.Width = 78;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Shops";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(559, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Warehouses";
            // 
            // buttonShop
            // 
            this.buttonShop.Location = new System.Drawing.Point(116, 447);
            this.buttonShop.Name = "buttonShop";
            this.buttonShop.Size = new System.Drawing.Size(139, 58);
            this.buttonShop.TabIndex = 4;
            this.buttonShop.Text = "Edit Shop";
            this.buttonShop.UseVisualStyleBackColor = true;
            this.buttonShop.Click += new System.EventHandler(this.buttonShop_Click);
            // 
            // buttonWarehouse
            // 
            this.buttonWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonWarehouse.Location = new System.Drawing.Point(630, 447);
            this.buttonWarehouse.Name = "buttonWarehouse";
            this.buttonWarehouse.Size = new System.Drawing.Size(139, 58);
            this.buttonWarehouse.TabIndex = 5;
            this.buttonWarehouse.Text = "Edit warehouse";
            this.buttonWarehouse.UseVisualStyleBackColor = true;
            this.buttonWarehouse.Click += new System.EventHandler(this.buttonWarehouse_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(377, 447);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 58);
            this.button1.TabIndex = 6;
            this.button1.Text = "View all products";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 595);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonWarehouse);
            this.Controls.Add(this.buttonShop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewWarehouse);
            this.Controls.Add(this.listViewShop);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewShop;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView listViewWarehouse;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonShop;
        private System.Windows.Forms.Button buttonWarehouse;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button button1;
    }
}