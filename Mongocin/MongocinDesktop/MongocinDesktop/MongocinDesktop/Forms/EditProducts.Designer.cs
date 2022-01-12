namespace MongocinDesktop.Forms
{
    partial class EditProducts
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
            this.Quantity = new System.Windows.Forms.Label();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.saveProductButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Quantity
            // 
            this.Quantity.AutoSize = true;
            this.Quantity.Location = new System.Drawing.Point(60, 99);
            this.Quantity.Name = "Quantity";
            this.Quantity.Size = new System.Drawing.Size(61, 17);
            this.Quantity.TabIndex = 1;
            this.Quantity.Text = "Quantity";
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Location = new System.Drawing.Point(180, 99);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(144, 22);
            this.quantityTextBox.TabIndex = 2;
            // 
            // saveProductButton
            // 
            this.saveProductButton.Location = new System.Drawing.Point(145, 269);
            this.saveProductButton.Name = "saveProductButton";
            this.saveProductButton.Size = new System.Drawing.Size(103, 44);
            this.saveProductButton.TabIndex = 9;
            this.saveProductButton.Text = "Save";
            this.saveProductButton.UseVisualStyleBackColor = true;
            // 
            // EditProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 431);
            this.Controls.Add(this.saveProductButton);
            this.Controls.Add(this.quantityTextBox);
            this.Controls.Add(this.Quantity);
            this.Name = "EditProducts";
            this.Text = "EditProducts";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Quantity;
        private System.Windows.Forms.TextBox quantityTextBox;
        private System.Windows.Forms.Button saveProductButton;
    }
}