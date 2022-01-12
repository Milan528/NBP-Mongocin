namespace MongocinDesktop.Forms
{
    partial class EditWarehouse
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.viewOrdersButton = new System.Windows.Forms.Button();
            this.viewProductsButton = new System.Windows.Forms.Button();
            this.saveWarehouseChangesButton = new System.Windows.Forms.Button();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.buttonHandleRequest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Address";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Name";
            // 
            // viewOrdersButton
            // 
            this.viewOrdersButton.Location = new System.Drawing.Point(153, 412);
            this.viewOrdersButton.Name = "viewOrdersButton";
            this.viewOrdersButton.Size = new System.Drawing.Size(201, 43);
            this.viewOrdersButton.TabIndex = 11;
            this.viewOrdersButton.Text = "View Orders";
            this.viewOrdersButton.UseVisualStyleBackColor = true;
            this.viewOrdersButton.Click += new System.EventHandler(this.viewOrdersButton_Click);
            // 
            // viewProductsButton
            // 
            this.viewProductsButton.Location = new System.Drawing.Point(153, 319);
            this.viewProductsButton.Name = "viewProductsButton";
            this.viewProductsButton.Size = new System.Drawing.Size(201, 43);
            this.viewProductsButton.TabIndex = 10;
            this.viewProductsButton.Text = "View Products";
            this.viewProductsButton.UseVisualStyleBackColor = true;
            this.viewProductsButton.Click += new System.EventHandler(this.viewProductsButton_Click);
            // 
            // saveWarehouseChangesButton
            // 
            this.saveWarehouseChangesButton.Location = new System.Drawing.Point(153, 235);
            this.saveWarehouseChangesButton.Name = "saveWarehouseChangesButton";
            this.saveWarehouseChangesButton.Size = new System.Drawing.Size(201, 43);
            this.saveWarehouseChangesButton.TabIndex = 9;
            this.saveWarehouseChangesButton.Text = "Save";
            this.saveWarehouseChangesButton.UseVisualStyleBackColor = true;
            this.saveWarehouseChangesButton.Click += new System.EventHandler(this.saveWarehouseChangesButton_Click);
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(183, 144);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(146, 22);
            this.addressTextBox.TabIndex = 8;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(183, 76);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(146, 22);
            this.nameTextBox.TabIndex = 7;
            // 
            // buttonHandleRequest
            // 
            this.buttonHandleRequest.Location = new System.Drawing.Point(153, 527);
            this.buttonHandleRequest.Name = "buttonHandleRequest";
            this.buttonHandleRequest.Size = new System.Drawing.Size(201, 43);
            this.buttonHandleRequest.TabIndex = 14;
            this.buttonHandleRequest.Text = "Handle Requests";
            this.buttonHandleRequest.UseVisualStyleBackColor = true;
            this.buttonHandleRequest.Click += new System.EventHandler(this.buttonHandleRequest_Click);
            // 
            // EditWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 648);
            this.Controls.Add(this.buttonHandleRequest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.viewOrdersButton);
            this.Controls.Add(this.viewProductsButton);
            this.Controls.Add(this.saveWarehouseChangesButton);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Name = "EditWarehouse";
            this.Text = "EditWarehouse";
            this.Load += new System.EventHandler(this.EditWarehouse_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button viewOrdersButton;
        private System.Windows.Forms.Button viewProductsButton;
        private System.Windows.Forms.Button saveWarehouseChangesButton;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button buttonHandleRequest;
    }
}