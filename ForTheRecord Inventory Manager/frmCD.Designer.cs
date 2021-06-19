namespace ForTheRecord_Inventory_Manager
{
    partial class frmCD
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
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numNoOfDiscs = new System.Windows.Forms.NumericUpDown();
            this.cbSingle = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numNoOfDiscs)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 344);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Number Of Discs";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 389);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Single?";
            // 
            // numNoOfDiscs
            // 
            this.numNoOfDiscs.Location = new System.Drawing.Point(144, 339);
            this.numNoOfDiscs.Name = "numNoOfDiscs";
            this.numNoOfDiscs.Size = new System.Drawing.Size(211, 22);
            this.numNoOfDiscs.TabIndex = 18;
            // 
            // cbSingle
            // 
            this.cbSingle.AutoSize = true;
            this.cbSingle.Location = new System.Drawing.Point(144, 389);
            this.cbSingle.Name = "cbSingle";
            this.cbSingle.Size = new System.Drawing.Size(18, 17);
            this.cbSingle.TabIndex = 19;
            this.cbSingle.UseVisualStyleBackColor = true;
            // 
            // frmCD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(367, 531);
            this.Controls.Add(this.cbSingle);
            this.Controls.Add(this.numNoOfDiscs);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Name = "frmCD";
            this.Text = "CD Album Details";
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.numNoOfDiscs, 0);
            this.Controls.SetChildIndex(this.cbSingle, 0);
            ((System.ComponentModel.ISupportInitialize)(this.numNoOfDiscs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numNoOfDiscs;
        private System.Windows.Forms.CheckBox cbSingle;
    }
}
