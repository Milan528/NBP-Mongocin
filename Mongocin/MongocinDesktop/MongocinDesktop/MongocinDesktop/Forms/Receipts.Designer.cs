namespace MongocinDesktop.Forms
{
    partial class Receipts
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
            this.listViewReceipts = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonClose = new System.Windows.Forms.Button();
            this.deleteReceiptButton = new System.Windows.Forms.Button();
            this.viewProductsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCreateReceipt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewReceipts
            // 
            this.listViewReceipts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewReceipts.HideSelection = false;
            this.listViewReceipts.Location = new System.Drawing.Point(37, 57);
            this.listViewReceipts.Name = "listViewReceipts";
            this.listViewReceipts.Size = new System.Drawing.Size(294, 259);
            this.listViewReceipts.TabIndex = 0;
            this.listViewReceipts.UseCompatibleStateImageBehavior = false;
            this.listViewReceipts.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Full Cost";
            this.columnHeader1.Width = 111;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Date & time";
            this.columnHeader2.Width = 116;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ID";
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(344, 555);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(116, 38);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // deleteReceiptButton
            // 
            this.deleteReceiptButton.Location = new System.Drawing.Point(116, 427);
            this.deleteReceiptButton.Name = "deleteReceiptButton";
            this.deleteReceiptButton.Size = new System.Drawing.Size(116, 48);
            this.deleteReceiptButton.TabIndex = 3;
            this.deleteReceiptButton.Text = "Delete";
            this.deleteReceiptButton.UseVisualStyleBackColor = true;
            this.deleteReceiptButton.Click += new System.EventHandler(this.deleteReceiptButton_Click);
            // 
            // viewProductsButton
            // 
            this.viewProductsButton.Location = new System.Drawing.Point(116, 352);
            this.viewProductsButton.Name = "viewProductsButton";
            this.viewProductsButton.Size = new System.Drawing.Size(116, 48);
            this.viewProductsButton.TabIndex = 4;
            this.viewProductsButton.Text = "View Products";
            this.viewProductsButton.UseVisualStyleBackColor = true;
            this.viewProductsButton.Click += new System.EventHandler(this.viewProductsButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(152, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Shop Receipts";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(706, 57);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(305, 259);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Id";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Quantity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(822, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Receipt Products";
            // 
            // buttonCreateReceipt
            // 
            this.buttonCreateReceipt.Location = new System.Drawing.Point(562, 555);
            this.buttonCreateReceipt.Name = "buttonCreateReceipt";
            this.buttonCreateReceipt.Size = new System.Drawing.Size(116, 38);
            this.buttonCreateReceipt.TabIndex = 8;
            this.buttonCreateReceipt.Text = "Create Receipt";
            this.buttonCreateReceipt.UseVisualStyleBackColor = true;
            this.buttonCreateReceipt.Click += new System.EventHandler(this.buttonCreateReceipt_Click);
            // 
            // Receipts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 630);
            this.Controls.Add(this.buttonCreateReceipt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.viewProductsButton);
            this.Controls.Add(this.deleteReceiptButton);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.listViewReceipts);
            this.Name = "Receipts";
            this.Text = "Receipts";
            this.Load += new System.EventHandler(this.Receipts_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewReceipts;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button deleteReceiptButton;
        private System.Windows.Forms.Button viewProductsButton;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCreateReceipt;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}