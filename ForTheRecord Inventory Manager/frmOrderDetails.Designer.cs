namespace ForTheRecord_Inventory_Manager
{
    partial class frmOrderDetails
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
            this.lblID = new System.Windows.Forms.Label();
            this.lblAlbumName = new System.Windows.Forms.Label();
            this.lblDateOfOrder = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblAlbumType = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.lblCustomerEmail = new System.Windows.Forms.Label();
            this.lblCustomerAddress = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(22, 27);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(117, 17);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID: ###########";
            // 
            // lblAlbumName
            // 
            this.lblAlbumName.AutoSize = true;
            this.lblAlbumName.Location = new System.Drawing.Point(22, 68);
            this.lblAlbumName.Name = "lblAlbumName";
            this.lblAlbumName.Size = new System.Drawing.Size(184, 17);
            this.lblAlbumName.TabIndex = 1;
            this.lblAlbumName.Text = "Album Name: ###########";
            // 
            // lblDateOfOrder
            // 
            this.lblDateOfOrder.AutoSize = true;
            this.lblDateOfOrder.Location = new System.Drawing.Point(22, 238);
            this.lblDateOfOrder.Name = "lblDateOfOrder";
            this.lblDateOfOrder.Size = new System.Drawing.Size(178, 17);
            this.lblDateOfOrder.TabIndex = 2;
            this.lblDateOfOrder.Text = "Date Of Order: ##/##/####";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(22, 281);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(285, 17);
            this.lblCustomerName.TabIndex = 3;
            this.lblCustomerName.Text = "Customer Name: #####################";
            // 
            // lblAlbumType
            // 
            this.lblAlbumType.AutoSize = true;
            this.lblAlbumType.Location = new System.Drawing.Point(22, 109);
            this.lblAlbumType.Name = "lblAlbumType";
            this.lblAlbumType.Size = new System.Drawing.Size(131, 17);
            this.lblAlbumType.TabIndex = 4;
            this.lblAlbumType.Text = "Album Type: #####";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(22, 150);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(85, 17);
            this.lblQuantity.TabIndex = 5;
            this.lblQuantity.Text = "Quantity: ##";
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Location = new System.Drawing.Point(22, 193);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(124, 17);
            this.lblTotalCost.TabIndex = 6;
            this.lblTotalCost.Text = "Total Cost: $##.##";
            // 
            // lblCustomerEmail
            // 
            this.lblCustomerEmail.AutoSize = true;
            this.lblCustomerEmail.Location = new System.Drawing.Point(22, 379);
            this.lblCustomerEmail.Name = "lblCustomerEmail";
            this.lblCustomerEmail.Size = new System.Drawing.Size(210, 17);
            this.lblCustomerEmail.TabIndex = 7;
            this.lblCustomerEmail.Text = "Customer Email: ############";
            // 
            // lblCustomerAddress
            // 
            this.lblCustomerAddress.AutoSize = true;
            this.lblCustomerAddress.Location = new System.Drawing.Point(22, 331);
            this.lblCustomerAddress.Name = "lblCustomerAddress";
            this.lblCustomerAddress.Size = new System.Drawing.Size(324, 17);
            this.lblCustomerAddress.TabIndex = 9;
            this.lblCustomerAddress.Text = "Customer Address: ########################";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(346, 432);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 36);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmOrderDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 480);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblCustomerAddress);
            this.Controls.Add(this.lblCustomerEmail);
            this.Controls.Add(this.lblTotalCost);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblAlbumType);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.lblDateOfOrder);
            this.Controls.Add(this.lblAlbumName);
            this.Controls.Add(this.lblID);
            this.Name = "frmOrderDetails";
            this.Text = "frmOrderDetails";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblAlbumName;
        private System.Windows.Forms.Label lblDateOfOrder;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblAlbumType;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.Label lblCustomerEmail;
        private System.Windows.Forms.Label lblCustomerAddress;
        private System.Windows.Forms.Button btnClose;
    }
}