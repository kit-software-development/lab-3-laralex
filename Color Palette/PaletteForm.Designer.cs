namespace ColorPalette
{
    partial class PaletteForm
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
            System.Windows.Forms.TrackBar trbarRed;
            System.Windows.Forms.Label lblRed;
            System.Windows.Forms.Label lblRed0;
            System.Windows.Forms.Label lblRed255;
            this.pnlColorPreview = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            trbarRed = new System.Windows.Forms.TrackBar();
            lblRed = new System.Windows.Forms.Label();
            lblRed0 = new System.Windows.Forms.Label();
            lblRed255 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(trbarRed)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlColorPreview
            // 
            this.pnlColorPreview.Location = new System.Drawing.Point(12, 12);
            this.pnlColorPreview.Name = "pnlColorPreview";
            this.pnlColorPreview.Size = new System.Drawing.Size(150, 150);
            this.pnlColorPreview.TabIndex = 0;
            // 
            // trbarRed
            // 
            trbarRed.Dock = System.Windows.Forms.DockStyle.Top;
            trbarRed.Location = new System.Drawing.Point(0, 0);
            trbarRed.Maximum = 255;
            trbarRed.Name = "trbarRed";
            trbarRed.Size = new System.Drawing.Size(620, 45);
            trbarRed.TabIndex = 1;
            trbarRed.TickFrequency = 20;
            // 
            // lblRed
            // 
            lblRed.AutoSize = true;
            lblRed.Location = new System.Drawing.Point(14, 14);
            lblRed.Name = "lblRed";
            lblRed.Size = new System.Drawing.Size(30, 13);
            lblRed.TabIndex = 2;
            lblRed.Text = "Red:";
            // 
            // lblRed0
            // 
            lblRed0.AutoSize = true;
            lblRed0.Location = new System.Drawing.Point(56, 31);
            lblRed0.Name = "lblRed0";
            lblRed0.Size = new System.Drawing.Size(13, 13);
            lblRed0.TabIndex = 3;
            lblRed0.Text = "0";
            // 
            // lblRed255
            // 
            lblRed255.AutoSize = true;
            lblRed255.Location = new System.Drawing.Point(280, 35);
            lblRed255.Name = "lblRed255";
            lblRed255.Size = new System.Drawing.Size(25, 13);
            lblRed255.TabIndex = 4;
            lblRed255.Text = "255";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(lblRed255);
            this.panel1.Controls.Add(lblRed0);
            this.panel1.Controls.Add(lblRed);
            this.panel1.Controls.Add(trbarRed);
            this.panel1.Location = new System.Drawing.Point(168, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(620, 150);
            this.panel1.TabIndex = 5;
            // 
            // PaletteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlColorPreview);
            this.Controls.Add(this.panel1);
            this.Name = "PaletteForm";
            this.Text = "Color Palette";
            ((System.ComponentModel.ISupportInitialize)(trbarRed)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlColorPreview;
        private System.Windows.Forms.Panel panel1;
    }
}

