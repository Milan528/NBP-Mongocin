namespace MongocinDesktop.Forms
{
    partial class HandleTransferRequest
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
            this.listViewTransferProducts = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button3 = new System.Windows.Forms.Button();
            this.buttonHandle = new System.Windows.Forms.Button();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewTransferProducts
            // 
            this.listViewTransferProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader5,
            this.columnHeader3});
            this.listViewTransferProducts.HideSelection = false;
            this.listViewTransferProducts.Location = new System.Drawing.Point(25, 98);
            this.listViewTransferProducts.Name = "listViewTransferProducts";
            this.listViewTransferProducts.Size = new System.Drawing.Size(700, 250);
            this.listViewTransferProducts.TabIndex = 4;
            this.listViewTransferProducts.UseCompatibleStateImageBehavior = false;
            this.listViewTransferProducts.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ShopID";
            this.columnHeader2.Width = 92;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Warehouse ID";
            this.columnHeader5.Width = 110;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(400, 471);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(153, 71);
            this.button3.TabIndex = 8;
            this.button3.Text = "Close";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonHandle
            // 
            this.buttonHandle.Location = new System.Drawing.Point(197, 471);
            this.buttonHandle.Name = "buttonHandle";
            this.buttonHandle.Size = new System.Drawing.Size(153, 71);
            this.buttonHandle.TabIndex = 9;
            this.buttonHandle.Text = "Handle Transfer Request";
            this.buttonHandle.UseVisualStyleBackColor = true;
            this.buttonHandle.Click += new System.EventHandler(this.buttonHandle_Click);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "State";
            // 
            // HandleTransferRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 566);
            this.Controls.Add(this.buttonHandle);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.listViewTransferProducts);
            this.Name = "HandleTransferRequest";
            this.Text = "HandleTransferRequest";
            this.Load += new System.EventHandler(this.HandleTransferRequest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewTransferProducts;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonHandle;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}