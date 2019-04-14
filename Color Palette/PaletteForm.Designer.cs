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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            trbarRed = new System.Windows.Forms.TrackBar();
            lblRed = new System.Windows.Forms.Label();
            lblRed0 = new System.Windows.Forms.Label();
            lblRed255 = new System.Windows.Forms.Label();
            this.pnlColorPreview.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(trbarRed)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlColorPreview
            // 
            this.pnlColorPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlColorPreview.Controls.Add(lblRed255);
            this.pnlColorPreview.Location = new System.Drawing.Point(12, 12);
            this.pnlColorPreview.Name = "pnlColorPreview";
            this.pnlColorPreview.Size = new System.Drawing.Size(150, 377);
            this.pnlColorPreview.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(trbarRed, 1, 0);
            this.tableLayoutPanel1.Controls.Add(lblRed, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(168, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(552, 401);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // trbarRed
            // 
            trbarRed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            trbarRed.Location = new System.Drawing.Point(63, 44);
            trbarRed.Maximum = 255;
            trbarRed.Name = "trbarRed";
            trbarRed.Size = new System.Drawing.Size(486, 45);
            trbarRed.TabIndex = 1;
            trbarRed.TickFrequency = 20;
            // 
            // lblRed
            // 
            lblRed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            lblRed.AutoSize = true;
            lblRed.Location = new System.Drawing.Point(3, 60);
            lblRed.Name = "lblRed";
            lblRed.Size = new System.Drawing.Size(54, 13);
            lblRed.TabIndex = 2;
            lblRed.Text = "Red:";
            // 
            // lblRed0
            // 
            lblRed0.AutoSize = true;
            lblRed0.Location = new System.Drawing.Point(224, 205);
            lblRed0.Name = "lblRed0";
            lblRed0.Size = new System.Drawing.Size(13, 13);
            lblRed0.TabIndex = 3;
            lblRed0.Text = "0";
            // 
            // lblRed255
            // 
            lblRed255.AutoSize = true;
            lblRed255.Location = new System.Drawing.Point(66, 167);
            lblRed255.Name = "lblRed255";
            lblRed255.Size = new System.Drawing.Size(25, 13);
            lblRed255.TabIndex = 4;
            lblRed255.Text = "255";
            // 
            // PaletteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 401);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(lblRed0);
            this.Controls.Add(this.pnlColorPreview);
            this.Name = "PaletteForm";
            this.Text = "Color Palette";
            this.pnlColorPreview.ResumeLayout(false);
            this.pnlColorPreview.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(trbarRed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlColorPreview;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

