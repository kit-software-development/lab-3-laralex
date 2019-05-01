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
    static class Extention
    {
        public static Point Subtract(this Point lhs, Point rhs)
        {
            return new Point(lhs.X - rhs.X, lhs.Y - rhs.Y) ;
        }
    }
    public partial class GameForm : Form
    {
        private Size last_field_size;
        private Point btn_center_location;
        private Point prev_mouse_location;
        private Point prev_top_border_location;
        private Point prev_bottom_border_location;
        private Point prev_left_border_location;
        private Point prev_right_border_location;
        private const float min_distance_px = 100f; 

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
            btn_center_location = new Point
            {
                X = (int)(btn.Location.X + btn.Width / 2f),
                Y = (int)(btn.Location.Y + btn.Height / 2f),
            };
            prev_top_border_location = new Point(btn_center_location.X, 0);
            prev_bottom_border_location = new Point(btn_center_location.X, pnlContent.Size.Height);
            prev_left_border_location = new Point(0, btn_center_location.Y);
            prev_right_border_location = new Point(pnlContent.Size.Width, btn_center_location.Y);
        }

        private void OnFormResize(object sender, EventArgs e)
        {
            PlaceWithoutClipping(btn);
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Поздравляем! Вы смогли нажать на кнопку!", "YOU WIN", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void PlaceWithoutClipping(Control control)
        {
            control.Location = new Point
            {
                X = Math.Min(Math.Max(0, control.Location.X), control.Parent.Size.Width - control.Size.Width),
                Y = Math.Min(Math.Max(0, control.Location.Y), control.Parent.Size.Height - control.Size.Height),
            };
        }

        private void OnMouseOnForm(object sender, MouseEventArgs e)
        {
            Point mouse_location = MousePosition;
            if (mouse_location == prev_mouse_location)
                return;
            btn_center_location = new Point
            {
                X = (int)(btn.Location.X + btn.Width / 2f),
                Y = (int)(btn.Location.Y + btn.Height / 2f),
            };
            Point top_border_location = new Point(btn_center_location.X, 0),
                  bottom_border_location = new Point(btn_center_location.X, pnlContent.Size.Height),
                  left_bottom_location = new Point(0, btn_center_location.Y),
                  right_bottom_location = new Point(pnlContent.Size.Width, btn_center_location.Y);
            Point btn_location = btn.Location;
            btn_location.Offset( CalculateAdjustment(
                ConvertToFormCoordinates(mouse_location),
                ConvertToFormCoordinates(prev_mouse_location),
                is_mouse: true
            ));
            btn_location.Offset( CalculateAdjustment(
                top_border_location, 
                prev_top_border_location) 
            );
            btn_location.Offset( CalculateAdjustment(
                bottom_border_location, 
                prev_bottom_border_location) 
            );
            btn_location.Offset( CalculateAdjustment(
                left_bottom_location,
                prev_left_border_location) 
            );
            btn_location.Offset( CalculateAdjustment(
                right_bottom_location, 
                prev_right_border_location) 
            );
            btn.Location = btn_location;
            PlaceWithoutClipping(btn);

            prev_mouse_location = MousePosition;
            prev_top_border_location = top_border_location;
            prev_bottom_border_location = bottom_border_location;
            prev_left_border_location = left_bottom_location;
            prev_right_border_location = right_bottom_location;

        }

        private void OnMouseEnter(object sender, EventArgs e)
        {
            
            prev_mouse_location = MousePosition;
            
        }

        private Point CalculateAdjustment(Point chaser, Point prev_chaser, bool is_mouse = false)
        {
            Point chaser_move_delta = chaser.Subtract(prev_chaser);
            Point button_delta = btn_center_location.Subtract(chaser);

            float distance_ratio = min_distance_px / (float)PythagoreanLength(button_delta);

            Point new_location = Point.Empty;
            if (distance_ratio > 1)
            {
                if (is_mouse)
                {
                    new_location.Offset(
                       (Math.Sign(button_delta.X) == Math.Sign(chaser_move_delta.X))
                           ? (int)(chaser_move_delta.X * distance_ratio) : 0,
                       (Math.Sign(button_delta.Y) == Math.Sign(chaser_move_delta.Y))
                           ? (int)(chaser_move_delta.Y * distance_ratio) : 0
                    );
                }
                else
                {
                    int offset = (int)((Math.Abs(chaser_move_delta.X) + Math.Abs(chaser_move_delta.Y)));
                    if (chaser_move_delta.X == 0)
                    {
                        new_location.Offset(
                            (int)(Math.Sign(button_delta.X) * offset * distance_ratio),
                            (int)(Math.Sign(chaser_move_delta.Y) * distance_ratio)
                        );
                    }
                    else
                    {
                        new_location.Offset(
                            (int)(Math.Sign(chaser_move_delta.X) * distance_ratio),//offset ,
                            (int)(Math.Sign(button_delta.Y) * offset * distance_ratio)
                        );
                    }
                }
                
            }
            return new_location;
        }

        private double PythagoreanDistance(Point a, Point b)
        {
            int dx = a.X - b.X, dy = a.Y - b.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        private double PythagoreanLength(Point a)
        {
            return Math.Sqrt(a.X * a.X + a.Y * a.Y);
        }

        private Point ConvertToFormCoordinates(Point p)
        {
           p.Offset(
               -this.Location.X - pnlContent.Location.X,
               -this.Location.Y - pnlContent.Location.Y
           );
           return p;
        }

    }
}
