using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RunningButton
{
    public partial class GameForm : Form
    {
        private Size last_form_size; 
        public GameForm()
        {
            InitializeComponent();
        }


        private void OnFormLoad(object sender, EventArgs e)
        {
            // Place button at center of window
            /*var btn_size = btn.Size;
            var content_size = pnlContent.Size;
            btn.Location = new Point(
                content_size.Width - btn_size.Width >> 2, 
                content_size.Height - btn_size.Height >> 2
            );
            this.last_form_size = content_size;
            */
        }

        private void OnFormResize(object sender, EventArgs e)
        {
            // Move button, proportionally to resize
            /*var prev_btn_loc = btn.Location;
            btn.Location = new Point(
                 (int)(prev_btn_loc.X * (this.Size.Width / (float)last_form_size.Width)),
                 (int)(prev_btn_loc.Y * (this.Size.Height / (float)last_form_size.Height))
            );
            this.last_form_size = this.Size;
            */
        }
    }
}
