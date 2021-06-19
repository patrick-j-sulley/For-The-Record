namespace ForTheRecord_Inventory_Manager
{
    partial class frmMain
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
            this.lstArtists = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtLocateArtist = new System.Windows.Forms.TextBox();
            this.btnViewOrder = new System.Windows.Forms.Button();
            this.btnLocateArtist = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.lblArtistStock = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstArtists
            // 
            this.lstArtists.FormattingEnabled = true;
            this.lstArtists.ItemHeight = 16;
            this.lstArtists.Location = new System.Drawing.Point(15, 29);
            this.lstArtists.Name = "lstArtists";
            this.lstArtists.Size = new System.Drawing.Size(234, 292);
            this.lstArtists.TabIndex = 0;
            this.lstArtists.SelectedIndexChanged += new System.EventHandler(this.lstArtists_SelectedIndexChanged);
            this.lstArtists.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstArtists_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Artist";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(267, 29);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(122, 33);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add Artist";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(267, 107);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(122, 33);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete Artist";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // txtLocateArtist
            // 
            this.txtLocateArtist.Location = new System.Drawing.Point(267, 174);
            this.txtLocateArtist.Name = "txtLocateArtist";
            this.txtLocateArtist.Size = new System.Drawing.Size(122, 22);
            this.txtLocateArtist.TabIndex = 4;
            // 
            // btnViewOrder
            // 
            this.btnViewOrder.Location = new System.Drawing.Point(267, 241);
            this.btnViewOrder.Name = "btnViewOrder";
            this.btnViewOrder.Size = new System.Drawing.Size(122, 33);
            this.btnViewOrder.TabIndex = 5;
            this.btnViewOrder.Text = "View Orders";
            this.btnViewOrder.UseVisualStyleBackColor = true;
            this.btnViewOrder.Click += new System.EventHandler(this.btnViewOrder_Click);
            // 
            // btnLocateArtist
            // 
            this.btnLocateArtist.Location = new System.Drawing.Point(267, 202);
            this.btnLocateArtist.Name = "btnLocateArtist";
            this.btnLocateArtist.Size = new System.Drawing.Size(122, 33);
            this.btnLocateArtist.TabIndex = 6;
            this.btnLocateArtist.Text = "Locate Artist";
            this.btnLocateArtist.UseVisualStyleBackColor = true;
            this.btnLocateArtist.Click += new System.EventHandler(this.btnLocateArtist_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(267, 317);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(122, 33);
            this.btnQuit.TabIndex = 7;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // lblArtistStock
            // 
            this.lblArtistStock.AutoSize = true;
            this.lblArtistStock.Location = new System.Drawing.Point(12, 333);
            this.lblArtistStock.Name = "lblArtistStock";
            this.lblArtistStock.Size = new System.Drawing.Size(132, 17);
            this.lblArtistStock.TabIndex = 8;
            this.lblArtistStock.Text = "Stock for Artist: ###";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(267, 68);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(122, 33);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Edit Artist";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 360);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lblArtistStock);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnLocateArtist);
            this.Controls.Add(this.btnViewOrder);
            this.Controls.Add(this.txtLocateArtist);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstArtists);
            this.Name = "frmMain";
            this.Text = "ForTheRecord Inventory Manager";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstArtists;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtLocateArtist;
        private System.Windows.Forms.Button btnViewOrder;
        private System.Windows.Forms.Button btnLocateArtist;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Label lblArtistStock;
        private System.Windows.Forms.Button btnEdit;
    }
}