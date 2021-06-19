namespace ForTheRecord_Inventory_Manager
{
    partial class frmVinyl
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
            this.numNoOfSides = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbLimited = new System.Windows.Forms.CheckBox();
            this.cbBoxSet = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numNoOfSides)).BeginInit();
            this.SuspendLayout();
            // 
            // numNoOfSides
            // 
            this.numNoOfSides.Location = new System.Drawing.Point(144, 340);
            this.numNoOfSides.Name = "numNoOfSides";
            this.numNoOfSides.Size = new System.Drawing.Size(211, 22);
            this.numNoOfSides.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 345);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "Number Of Sides";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 384);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 17);
            this.label8.TabIndex = 20;
            this.label8.Text = "Limited?";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 418);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 17);
            this.label9.TabIndex = 21;
            this.label9.Text = "Box Set?";
            // 
            // cbLimited
            // 
            this.cbLimited.AutoSize = true;
            this.cbLimited.Location = new System.Drawing.Point(144, 380);
            this.cbLimited.Name = "cbLimited";
            this.cbLimited.Size = new System.Drawing.Size(18, 17);
            this.cbLimited.TabIndex = 24;
            this.cbLimited.UseVisualStyleBackColor = true;
            // 
            // cbBoxSet
            // 
            this.cbBoxSet.AutoSize = true;
            this.cbBoxSet.Location = new System.Drawing.Point(144, 418);
            this.cbBoxSet.Name = "cbBoxSet";
            this.cbBoxSet.Size = new System.Drawing.Size(18, 17);
            this.cbBoxSet.TabIndex = 25;
            this.cbBoxSet.UseVisualStyleBackColor = true;
            // 
            // frmVinyl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(367, 531);
            this.Controls.Add(this.cbBoxSet);
            this.Controls.Add(this.cbLimited);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numNoOfSides);
            this.Name = "frmVinyl";
            this.Text = "Vinyl Album Details";
            this.Controls.SetChildIndex(this.numNoOfSides, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.cbLimited, 0);
            this.Controls.SetChildIndex(this.cbBoxSet, 0);
            ((System.ComponentModel.ISupportInitialize)(this.numNoOfSides)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numNoOfSides;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cbLimited;
        private System.Windows.Forms.CheckBox cbBoxSet;
    }
}
