using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Flow.Forms;
using System.Drawing;

namespace Flow.Graph
{
   
    public class CircleNode : IDrawable
    {
        // The string we will draw.
       // public string Text;
       // public string inputType = "L";


        private bool isOnNode = false;

        // Constructor.
        public CircleNode()
        {
            //Text = new_text;
           // inputType = it;
        }

        // Return the size of the string plus a 10 pixel margin.
        public SizeF GetSize(Graphics gr, Font font)
        {
            //static size, not actually using the font set size by TreeNode (works for now)
            SizeF sizeReturn = new SizeF(50, 50);
           
            return sizeReturn;

        }

        // Draw the object centered at (x, y).
        void IDrawable.Draw(float x, float y, Graphics gr, Pen pen, Brush bg_brush, Brush text_brush, Font font, string inputType,  string extra, string extra2, float scale, bool RemoteLink)
        {
            // Fill and draw an ellipse at our location.
           // SizeF my_size = GetSize(gr, font);
          

            SizeF txtSize = GetSize(gr, font); // calculate rectSize by string
            RectangleF rectText = new RectangleF(
                (x - txtSize.Width / 2)  * scale,
                (y - txtSize.Height / 2) * scale,
                (txtSize.Width) * scale,(txtSize.Height) * scale);

            Brush text_brush2 = Brushes.Black;


            //colors
            Color light;
            Color heavy;
            Color kiblast;
            Color jump;
            Color multiinput;
            Color na;

      

            //light
            if (!RemoteLink)
            {
                 light = Color.FromArgb(255, 255, 136, 174);
            }
            else
            {
                 light = Color.FromArgb(127, 255, 136, 174);
            }

            //heavy
            if (!RemoteLink)
            {
                heavy = Color.FromArgb(255, 57, 244, 1);
            }
            else
            {
                heavy = Color.FromArgb(127, 57, 244, 1);
            }
            //ki blast
            if (!RemoteLink)
            {
                kiblast = Color.FromArgb(255, 255, 0, 0);
            }
            else
            {
                kiblast = Color.FromArgb(127, 255, 0, 0);
            }
            //jump
            if (!RemoteLink)
            {
                jump = Color.FromArgb(255, 0, 164, 255);
            }
            else
            {
                jump = Color.FromArgb(127, 0, 164, 255);
            }
            //brushes

            SolidBrush brush_light = new SolidBrush(light);
            SolidBrush brush_heavy = new SolidBrush(heavy);
            SolidBrush brush_kiblast = new SolidBrush(kiblast);
            SolidBrush brush_jump = new SolidBrush(jump);
        

            switch (inputType)
            {
                case "L": pen.Color = light; break;
                case "H": pen.Color = heavy; break;
                case "K": pen.Color = kiblast; break;
                case "J": pen.Color = jump; break;

            }

            if (isOnNode){
                pen.Color = Color.Yellow;
               
            }
            if(inputType != "Other")
            {
                gr.FillEllipse(bg_brush, rectText);
                gr.DrawEllipse(pen, rectText);
            }
        


            // Draw the text.
            using (StringFormat string_format = new StringFormat())
            {
                string_format.Alignment = StringAlignment.Center;
                string_format.LineAlignment = StringAlignment.Center;
            


             switch (inputType)
                {
                    case "L": text_brush = brush_light; break;
                    case "H": text_brush = brush_heavy; break;
                    case "K": text_brush = brush_kiblast; break;
                    case "J": text_brush = brush_jump; break;

                }
                if (inputType != "Root")
                    gr.DrawString(inputType, font, text_brush, x * scale , y * scale, string_format);
                    
                if (extra != "")
                    gr.DrawString(extra, font, text_brush, (x + 13) * scale, (y + 13) * scale, string_format);
                if (Main.showIndices)
                    if (extra2 != "")
                         gr.DrawString(extra2, font, text_brush2, (x + 35) * scale, (y + 2) * scale, string_format);



            }
            pen.Color = Color.White;
        }

        // Return true if the node is above this point.
        // Note: The equation for an ellipse with half
        // width w and half height h centered at the origin is:
        //      x*x/w/w + y*y/h/h <= 1.
        bool IDrawable.IsAtPoint(Graphics gr, Font font, PointF center_pt, PointF target_pt, float scale)
        {
            // Get our size.
            SizeF my_size = GetSize(gr, font);
            my_size.Width *= scale;
            my_size.Height *= scale;

            // translate so we can assume the
            // ellipse is centered at the origin.

            center_pt.X += (Main.scrollMarginX * (scale * 2 ));
            center_pt.Y += (Main.scrollMarginY *( scale * 2) );

           center_pt.X *= scale;
           center_pt.Y *= scale;


            target_pt.X -= (center_pt.X );
            target_pt.Y -= (center_pt.Y );

     

            // target_pt.X *= scale;
            // target_pt.Y *= scale;

            // Determine whether the target point is under our ellipse.
            float w = (my_size.Width / 2) ;
            float h = (my_size.Height / 2) ;

           // gr.DrawEllipse(Pens.Red, target_pt.X * target_pt.X / w / w, target_pt.Y * target_pt.Y / h / h, 50, 50);
           
            float check = ((target_pt.X * target_pt.X / w / w)  + (target_pt.Y * target_pt.Y / h / h) );
            Main.check = check;
            isOnNode = (check  ) <= 1.0f;
            
            return isOnNode;
        }
    }
}
