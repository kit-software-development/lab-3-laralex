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
        private Size last_field_size;
        private Point last_btn_location;
        public GameForm()
        {
            InitializeComponent();
        }


        private void OnFormLoad(object sender, EventArgs e)
        {
            // Place button at center of window
            Size content_size = pnlContent.Size;
            btn.Location = new Point(
                content_size.Width  - btn.Size.Width  >> 1,
                content_size.Height - btn.Size.Height >> 1
            );
            this.last_field_size = content_size;
            this.last_btn_location = btn.Location;
            
        }

        private void OnFormResize(object sender, EventArgs e)
        {
            // Move button, proportionally to resize
            /*Point offset = new Point
            {
                X = (int)((pnlContent.Size.Width  - last_field_size.Width) / 2f),
                Y = (int)((pnlContent.Size.Height - last_field_size.Height) / 2f)
            };
            
            if (offset != Point.Empty)
            {
                this.last_field_size = pnlContent.Size;
                
                this.last_btn_location = btn.Location;
            }
              */
            LocateNoClipping(btn);
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Поздравляем! Вы смогли нажать на кнопку!", "YOU WIN", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void LocateNoClipping(Control control)
        {
            control.Location = new Point
            {
                X = Math.Min(Math.Max(0, control.Location.X), control.Parent.Size.Width - control.Size.Width),
                Y = Math.Min(Math.Max(0, control.Location.Y), control.Parent.Size.Height - control.Size.Height),
            };
        }

        private void OnMouseOnForm(object sender, MouseEventArgs e)
        {
            Point mouse = MousePosition;
            mouse.Offset(-this.Location.X - pnlContent.Location.X, - this.Location.Y - pnlContent.Location.Y);
            btn.Location = new Point
            {
                X = mouse.X,
                Y = mouse.Y
            };
            LocateNoClipping(btn);
        }
    }
}
