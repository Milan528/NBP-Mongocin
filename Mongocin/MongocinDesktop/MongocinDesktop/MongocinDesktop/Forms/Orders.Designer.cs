namespace MongocinDesktop.Forms
{
    partial class Orders
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
            this.buttonCreateReceipt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.viewProductsButton = new System.Windows.Forms.Button();
            this.deleteReceiptButton = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.listViewReceipts = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // buttonCreateReceipt
            // 
            this.buttonCreateReceipt.Location = new System.Drawing.Point(561, 528);
            this.buttonCreateReceipt.Name = "buttonCreateReceipt";
            this.buttonCreateReceipt.Size = new System.Drawing.Size(116, 38);
            this.buttonCreateReceipt.TabIndex = 16;
            this.buttonCreateReceipt.Text = "Create Receipt";
            this.buttonCreateReceipt.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(762, -20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "label2";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(646, 18);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(305, 259);
            this.listView1.TabIndex = 14;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, -20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "label1";
            // 
            // viewProductsButton
            // 
            this.viewProductsButton.Location = new System.Drawing.Point(101, 315);
            this.viewProductsButton.Name = "viewProductsButton";
            this.viewProductsButton.Size = new System.Drawing.Size(116, 48);
            this.viewProductsButton.TabIndex = 12;
            this.viewProductsButton.Text = "View Products";
            this.viewProductsButton.UseVisualStyleBackColor = true;
            // 
            // deleteReceiptButton
            // 
            this.deleteReceiptButton.Location = new System.Drawing.Point(101, 392);
            this.deleteReceiptButton.Name = "deleteReceiptButton";
            this.deleteReceiptButton.Size = new System.Drawing.Size(116, 48);
            this.deleteReceiptButton.TabIndex = 11;
            this.deleteReceiptButton.Text = "Delete";
            this.deleteReceiptButton.UseVisualStyleBackColor = true;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(317, 528);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(116, 38);
            this.buttonClose.TabIndex = 10;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // listViewReceipts
            // 
            this.listViewReceipts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewReceipts.HideSelection = false;
            this.listViewReceipts.Location = new System.Drawing.Point(43, 12);
            this.listViewReceipts.Name = "listViewReceipts";
            this.listViewReceipts.Size = new System.Drawing.Size(294, 259);
            this.listViewReceipts.TabIndex = 9;
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
            // Orders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 638);
            this.Controls.Add(this.buttonCreateReceipt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.viewProductsButton);
            this.Controls.Add(this.deleteReceiptButton);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.listViewReceipts);
            this.Name = "Orders";
            this.Text = "Orders";
            this.Load += new System.EventHandler(this.Orders_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCreateReceipt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button viewProductsButton;
        private System.Windows.Forms.Button deleteReceiptButton;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ListView listViewReceipts;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}