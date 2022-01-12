namespace MongocinDesktop.Forms
{
    partial class EditShop
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
            this.shopNameTextBox = new System.Windows.Forms.TextBox();
            this.shopAddressTextBox = new System.Windows.Forms.TextBox();
            this.saveShopChangesButton = new System.Windows.Forms.Button();
            this.viewProductsButton = new System.Windows.Forms.Button();
            this.viewReceiptsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonTransfer = new System.Windows.Forms.Button();
            this.buttonViewRequest = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // shopNameTextBox
            // 
            this.shopNameTextBox.Location = new System.Drawing.Point(155, 80);
            this.shopNameTextBox.Name = "shopNameTextBox";
            this.shopNameTextBox.Size = new System.Drawing.Size(146, 22);
            this.shopNameTextBox.TabIndex = 0;
            // 
            // shopAddressTextBox
            // 
            this.shopAddressTextBox.Location = new System.Drawing.Point(155, 143);
            this.shopAddressTextBox.Name = "shopAddressTextBox";
            this.shopAddressTextBox.Size = new System.Drawing.Size(146, 22);
            this.shopAddressTextBox.TabIndex = 1;
            // 
            // saveShopChangesButton
            // 
            this.saveShopChangesButton.Location = new System.Drawing.Point(91, 262);
            this.saveShopChangesButton.Name = "saveShopChangesButton";
            this.saveShopChangesButton.Size = new System.Drawing.Size(201, 43);
            this.saveShopChangesButton.TabIndex = 2;
            this.saveShopChangesButton.Text = "Save";
            this.saveShopChangesButton.UseVisualStyleBackColor = true;
            this.saveShopChangesButton.Click += new System.EventHandler(this.saveShopChangesButton_Click);
            // 
            // viewProductsButton
            // 
            this.viewProductsButton.Location = new System.Drawing.Point(91, 349);
            this.viewProductsButton.Name = "viewProductsButton";
            this.viewProductsButton.Size = new System.Drawing.Size(201, 43);
            this.viewProductsButton.TabIndex = 3;
            this.viewProductsButton.Text = "View Products";
            this.viewProductsButton.UseVisualStyleBackColor = true;
            this.viewProductsButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // viewReceiptsButton
            // 
            this.viewReceiptsButton.Location = new System.Drawing.Point(91, 432);
            this.viewReceiptsButton.Name = "viewReceiptsButton";
            this.viewReceiptsButton.Size = new System.Drawing.Size(201, 43);
            this.viewReceiptsButton.TabIndex = 4;
            this.viewReceiptsButton.Text = "View Receipts";
            this.viewReceiptsButton.UseVisualStyleBackColor = true;
            this.viewReceiptsButton.Click += new System.EventHandler(this.viewReceiptsButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Address";
            // 
            // buttonTransfer
            // 
            this.buttonTransfer.Location = new System.Drawing.Point(91, 513);
            this.buttonTransfer.Name = "buttonTransfer";
            this.buttonTransfer.Size = new System.Drawing.Size(201, 43);
            this.buttonTransfer.TabIndex = 7;
            this.buttonTransfer.Text = "Create transfer request";
            this.buttonTransfer.UseVisualStyleBackColor = true;
            this.buttonTransfer.Click += new System.EventHandler(this.buttonTransfer_Click);
            // 
            // buttonViewRequest
            // 
            this.buttonViewRequest.Location = new System.Drawing.Point(91, 583);
            this.buttonViewRequest.Name = "buttonViewRequest";
            this.buttonViewRequest.Size = new System.Drawing.Size(201, 43);
            this.buttonViewRequest.TabIndex = 8;
            this.buttonViewRequest.Text = "View transfer request";
            this.buttonViewRequest.UseVisualStyleBackColor = true;
            this.buttonViewRequest.Click += new System.EventHandler(this.buttonViewRequest_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(91, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(201, 43);
            this.button1.TabIndex = 9;
            this.button1.Text = "ShopFullValue";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EditShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 638);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonViewRequest);
            this.Controls.Add(this.buttonTransfer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.viewReceiptsButton);
            this.Controls.Add(this.viewProductsButton);
            this.Controls.Add(this.saveShopChangesButton);
            this.Controls.Add(this.shopAddressTextBox);
            this.Controls.Add(this.shopNameTextBox);
            this.Name = "EditShop";
            this.Text = "EditShop";
            this.Load += new System.EventHandler(this.EditShop_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox shopNameTextBox;
        private System.Windows.Forms.TextBox shopAddressTextBox;
        private System.Windows.Forms.Button saveShopChangesButton;
        private System.Windows.Forms.Button viewProductsButton;
        private System.Windows.Forms.Button viewReceiptsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonTransfer;
        private System.Windows.Forms.Button buttonViewRequest;
        private System.Windows.Forms.Button button1;
    }
}