namespace ForTheRecord_Inventory_Manager
{
    partial class frmAlbumType
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
            this.rbCD = new System.Windows.Forms.RadioButton();
            this.rbVinyl = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbCD
            // 
            this.rbCD.AutoSize = true;
            this.rbCD.Location = new System.Drawing.Point(101, 32);
            this.rbCD.Name = "rbCD";
            this.rbCD.Size = new System.Drawing.Size(48, 21);
            this.rbCD.TabIndex = 0;
            this.rbCD.TabStop = true;
            this.rbCD.Text = "CD";
            this.rbCD.UseVisualStyleBackColor = true;
            // 
            // rbVinyl
            // 
            this.rbVinyl.AutoSize = true;
            this.rbVinyl.Location = new System.Drawing.Point(204, 32);
            this.rbVinyl.Name = "rbVinyl";
            this.rbVinyl.Size = new System.Drawing.Size(59, 21);
            this.rbVinyl.TabIndex = 1;
            this.rbVinyl.TabStop = true;
            this.rbVinyl.Text = "Vinyl";
            this.rbVinyl.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 66);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(82, 30);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(271, 66);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmAlbumType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 108);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.rbVinyl);
            this.Controls.Add(this.rbCD);
            this.Name = "frmAlbumType";
            this.Text = "Select Album Type";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbCD;
        private System.Windows.Forms.RadioButton rbVinyl;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}