namespace ForTheRecord_Inventory_Manager
{
    partial class frmOrders
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
            this.components = new System.ComponentModel.Container();
            this.txtLocateOrder = new System.Windows.Forms.TextBox();
            this.btnLocateOrder = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbDate = new System.Windows.Forms.RadioButton();
            this.rbOrderID = new System.Windows.Forms.RadioButton();
            this.btnStatusChange = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlbumName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlbumType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalOrderCost = new System.Windows.Forms.Label();
            this.tmrUpdateDisplay = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLocateOrder
            // 
            this.txtLocateOrder.Location = new System.Drawing.Point(297, 423);
            this.txtLocateOrder.Name = "txtLocateOrder";
            this.txtLocateOrder.Size = new System.Drawing.Size(167, 22);
            this.txtLocateOrder.TabIndex = 9;
            // 
            // btnLocateOrder
            // 
            this.btnLocateOrder.Location = new System.Drawing.Point(297, 451);
            this.btnLocateOrder.Name = "btnLocateOrder";
            this.btnLocateOrder.Size = new System.Drawing.Size(167, 49);
            this.btnLocateOrder.TabIndex = 10;
            this.btnLocateOrder.Text = "Locate Order ID";
            this.btnLocateOrder.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbDate);
            this.groupBox1.Controls.Add(this.rbOrderID);
            this.groupBox1.Location = new System.Drawing.Point(12, 420);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 77);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sort By";
            // 
            // rbDate
            // 
            this.rbDate.AutoSize = true;
            this.rbDate.Location = new System.Drawing.Point(114, 31);
            this.rbDate.Name = "rbDate";
            this.rbDate.Size = new System.Drawing.Size(116, 21);
            this.rbDate.TabIndex = 15;
            this.rbDate.TabStop = true;
            this.rbDate.Text = "Date of Order";
            this.rbDate.UseVisualStyleBackColor = true;
            // 
            // rbOrderID
            // 
            this.rbOrderID.AutoSize = true;
            this.rbOrderID.Location = new System.Drawing.Point(6, 31);
            this.rbOrderID.Name = "rbOrderID";
            this.rbOrderID.Size = new System.Drawing.Size(83, 21);
            this.rbOrderID.TabIndex = 15;
            this.rbOrderID.TabStop = true;
            this.rbOrderID.Text = "Order ID";
            this.rbOrderID.UseVisualStyleBackColor = true;
            // 
            // btnStatusChange
            // 
            this.btnStatusChange.Location = new System.Drawing.Point(850, 448);
            this.btnStatusChange.Name = "btnStatusChange";
            this.btnStatusChange.Size = new System.Drawing.Size(167, 49);
            this.btnStatusChange.TabIndex = 12;
            this.btnStatusChange.Text = "Change Status";
            this.btnStatusChange.UseVisualStyleBackColor = true;
            this.btnStatusChange.Click += new System.EventHandler(this.btnStatusChange_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1023, 448);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(167, 49);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Delete Order";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1196, 448);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(167, 49);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvOrders
            // 
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.AlbumName,
            this.AlbumType,
            this.Quantity,
            this.TotalPrice,
            this.DateTime,
            this.Status,
            this.CustomerName,
            this.CustomerAddress,
            this.CustomerEmail});
            this.dgvOrders.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvOrders.Location = new System.Drawing.Point(12, 12);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvOrders.RowTemplate.Height = 24;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(1351, 402);
            this.dgvOrders.TabIndex = 15;
            this.dgvOrders.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvOrders_MouseDoubleClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "Order ID";
            this.ID.Name = "ID";
            // 
            // AlbumName
            // 
            this.AlbumName.DataPropertyName = "AlbumName";
            this.AlbumName.HeaderText = "Album Name";
            this.AlbumName.Name = "AlbumName";
            // 
            // AlbumType
            // 
            this.AlbumType.DataPropertyName = "AlbumType";
            this.AlbumType.HeaderText = "Album Type";
            this.AlbumType.Name = "AlbumType";
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            // 
            // TotalPrice
            // 
            this.TotalPrice.DataPropertyName = "TotalPrice";
            this.TotalPrice.HeaderText = "Total Cost";
            this.TotalPrice.Name = "TotalPrice";
            // 
            // DateTime
            // 
            this.DateTime.DataPropertyName = "DateTime";
            this.DateTime.HeaderText = "Date";
            this.DateTime.Name = "DateTime";
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.HeaderText = "Name";
            this.CustomerName.Name = "CustomerName";
            // 
            // CustomerAddress
            // 
            this.CustomerAddress.DataPropertyName = "CustomerAddress";
            this.CustomerAddress.HeaderText = "Address";
            this.CustomerAddress.Name = "CustomerAddress";
            // 
            // CustomerEmail
            // 
            this.CustomerEmail.DataPropertyName = "CustomerEmail";
            this.CustomerEmail.HeaderText = "Email";
            this.CustomerEmail.Name = "CustomerEmail";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(847, 420);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Total Cost of All Orders: ";
            // 
            // lblTotalOrderCost
            // 
            this.lblTotalOrderCost.AutoSize = true;
            this.lblTotalOrderCost.Location = new System.Drawing.Point(1016, 420);
            this.lblTotalOrderCost.Name = "lblTotalOrderCost";
            this.lblTotalOrderCost.Size = new System.Drawing.Size(44, 17);
            this.lblTotalOrderCost.TabIndex = 17;
            this.lblTotalOrderCost.Text = "00.00";
            // 
            // tmrUpdateDisplay
            // 
            this.tmrUpdateDisplay.Interval = 5000;
            this.tmrUpdateDisplay.Tick += new System.EventHandler(this.tmrUpdateDisplay_Tick);
            // 
            // frmOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1375, 510);
            this.Controls.Add(this.lblTotalOrderCost);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnStatusChange);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLocateOrder);
            this.Controls.Add(this.txtLocateOrder);
            this.Name = "frmOrders";
            this.Text = "Order Details List";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtLocateOrder;
        private System.Windows.Forms.Button btnLocateOrder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbDate;
        private System.Windows.Forms.RadioButton rbOrderID;
        private System.Windows.Forms.Button btnStatusChange;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalOrderCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlbumName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlbumType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerEmail;
        private System.Windows.Forms.Timer tmrUpdateDisplay;
    }
}