namespace ForTheRecord_Inventory_Manager
{
    partial class frmAlbum
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAlbumName = new System.Windows.Forms.TextBox();
            this.lstAlbumGenre = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDateLastModified = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.numPricePerUnit = new System.Windows.Forms.NumericUpDown();
            this.numNoOfTracks = new System.Windows.Forms.NumericUpDown();
            this.numAmountInStock = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numPricePerUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNoOfTracks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAmountInStock)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Album Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Album Genre";
            // 
            // txtAlbumName
            // 
            this.txtAlbumName.Location = new System.Drawing.Point(144, 29);
            this.txtAlbumName.Name = "txtAlbumName";
            this.txtAlbumName.Size = new System.Drawing.Size(211, 22);
            this.txtAlbumName.TabIndex = 2;
            // 
            // lstAlbumGenre
            // 
            this.lstAlbumGenre.FormattingEnabled = true;
            this.lstAlbumGenre.ItemHeight = 16;
            this.lstAlbumGenre.Location = new System.Drawing.Point(144, 68);
            this.lstAlbumGenre.Name = "lstAlbumGenre";
            this.lstAlbumGenre.Size = new System.Drawing.Size(211, 100);
            this.lstAlbumGenre.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Price Per Unit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Date Last Modified";
            // 
            // dtpDateLastModified
            // 
            this.dtpDateLastModified.Location = new System.Drawing.Point(144, 223);
            this.dtpDateLastModified.Name = "dtpDateLastModified";
            this.dtpDateLastModified.Size = new System.Drawing.Size(211, 22);
            this.dtpDateLastModified.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Number Of Tracks";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 306);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Amount in Stock";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(15, 465);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 33);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(280, 465);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 33);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // numPricePerUnit
            // 
            this.numPricePerUnit.DecimalPlaces = 2;
            this.numPricePerUnit.Location = new System.Drawing.Point(144, 184);
            this.numPricePerUnit.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            131072});
            this.numPricePerUnit.Name = "numPricePerUnit";
            this.numPricePerUnit.Size = new System.Drawing.Size(211, 22);
            this.numPricePerUnit.TabIndex = 14;
            // 
            // numNoOfTracks
            // 
            this.numNoOfTracks.Location = new System.Drawing.Point(144, 260);
            this.numNoOfTracks.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numNoOfTracks.Name = "numNoOfTracks";
            this.numNoOfTracks.Size = new System.Drawing.Size(211, 22);
            this.numNoOfTracks.TabIndex = 15;
            // 
            // numAmountInStock
            // 
            this.numAmountInStock.Location = new System.Drawing.Point(144, 301);
            this.numAmountInStock.Name = "numAmountInStock";
            this.numAmountInStock.Size = new System.Drawing.Size(211, 22);
            this.numAmountInStock.TabIndex = 16;
            // 
            // frmAlbum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 531);
            this.Controls.Add(this.numAmountInStock);
            this.Controls.Add(this.numNoOfTracks);
            this.Controls.Add(this.numPricePerUnit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpDateLastModified);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstAlbumGenre);
            this.Controls.Add(this.txtAlbumName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmAlbum";
            this.Text = "frmAlbum";
            ((System.ComponentModel.ISupportInitialize)(this.numPricePerUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNoOfTracks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAmountInStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAlbumName;
        private System.Windows.Forms.ListBox lstAlbumGenre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDateLastModified;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown numPricePerUnit;
        private System.Windows.Forms.NumericUpDown numNoOfTracks;
        private System.Windows.Forms.NumericUpDown numAmountInStock;
    }
}