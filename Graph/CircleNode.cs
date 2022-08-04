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
            SizeF sizeReturn = new SizeF(50,50);
           
            return sizeReturn;

        }

        // Draw the object centered at (x, y).
        void IDrawable.Draw(float x, float y, Graphics gr, Pen pen, Brush bg_brush, Brush text_brush, Font font, uint btnInputFlag,  string extra, string extra2, float scale, bool isRemoteChild, bool isRemoteSibling, bool isGrabEntry)
        {
            // Fill and draw an ellipse at our location.
            // SizeF my_size = GetSize(gr, font);

            string btnInput = Utils.Utils.translateButtonInputFlag(btnInputFlag);

            SizeF txtSize = GetSize(gr, font); // calculate rectSize by string
            RectangleF rectText = new RectangleF(
                (x - txtSize.Width / 2)  * scale,
                (y - txtSize.Height / 2) * scale,
                (txtSize.Width) * scale,(txtSize.Height) * scale);

            RectangleF rectText2 = new RectangleF(
           ((x - txtSize.Width / 2) * scale) + (11 * scale),
           ((y - txtSize.Height / 2) * scale) + (11 * scale),
           (txtSize.Width * (0.55f )) * scale, (txtSize.Height * (0.55f )) * scale);


            Brush text_brush2 = Brushes.White;


            //colors
            Color light;
            Color heavy;
            Color kiblast;
            Color jump;
            Color multiinput;
            Color noinput;

      

            //light
            if (!isRemoteChild && !isRemoteSibling)
            {
                light = Utils.Utils.Light;
            }
            else
            {
                light = Utils.Utils.LightTransparent;
            }

            //heavy
            if (!isRemoteChild && !isRemoteSibling)
            {
                heavy = Utils.Utils.heavy;
            }
            else
            {
                heavy = Utils.Utils.heavyTransparent;
            }
            //ki blast
            if (!isRemoteChild && !isRemoteSibling)
            {
                kiblast = Utils.Utils.kiblast;
            }
            else
            {
                kiblast = Utils.Utils.kiblastTransparent; 
            }
            //jump
            if (!isRemoteChild && !isRemoteSibling)
            {
                jump = Utils.Utils.jump;
            }
            else
            {
                jump = Utils.Utils.jumpTransparent;
            }
            //multi-input
            if (!isRemoteChild && !isRemoteSibling)
            {
                multiinput = Utils.Utils.multiinput;
            }
            else
            {
                multiinput = Utils.Utils.multiinputTransparent;
            }
            //noinput
            if (!isRemoteChild && !isRemoteSibling)
            {
                noinput = Utils.Utils.noinput;
            }
            else
            {
                noinput = Utils.Utils.noinputTransparent;
            }


            //brushes

            SolidBrush brush_light = new SolidBrush(light);
            SolidBrush brush_heavy = new SolidBrush(heavy);
            SolidBrush brush_kiblast = new SolidBrush(kiblast);
            SolidBrush brush_jump = new SolidBrush(jump);
            SolidBrush brush_multiinput = new SolidBrush(multiinput);
            SolidBrush brush_noinput = new SolidBrush(noinput);


            switch (btnInput)
            {
                case "L": pen.Color = light; break;
                case "H": pen.Color = heavy; break;
                case "K": pen.Color = kiblast; break;
                case "J": pen.Color = jump; break;
                case "M": pen.Color = multiinput; break;
                case "N": pen.Color = noinput; break;

            }

            if (isOnNode){
                pen.Color = Color.Yellow;
               
            }
            if(btnInput != "Other")
            {
             if (isGrabEntry)
                {
                    gr.FillEllipse(bg_brush, rectText);
                    gr.DrawEllipse(pen, rectText);
                    gr.FillEllipse(bg_brush, rectText2);
                    gr.DrawEllipse(pen, rectText2);

                }
                else
                {
                    gr.FillEllipse(bg_brush, rectText);
                    gr.DrawEllipse(pen, rectText);
                }
  
            }
        


            // Draw the text.
            using (StringFormat string_format = new StringFormat())
            {
                string_format.Alignment = StringAlignment.Center;
                string_format.LineAlignment = StringAlignment.Center;
            


             switch (btnInput)
                {
                    case "L": text_brush = brush_light; break;
                    case "H": text_brush = brush_heavy; break;
                    case "K": text_brush = brush_kiblast; break;
                    case "J": text_brush = brush_jump; break;
                    case "M": text_brush = brush_multiinput; break;
                    case "N": text_brush = brush_noinput; break;

                }
                if (btnInput != "Root")
                    gr.DrawString(btnInput, font, text_brush, x * scale , y * scale, string_format);
                    
                if (extra != "")
                    gr.DrawString(extra, font, text_brush, (x + 13) * scale, (y + 13) * scale, string_format);

               
                        if (isRemoteChild || isRemoteSibling)
                            gr.DrawString("", font, text_brush2, (x + 40) * scale, (y + 2) * scale, string_format);
                        else
                            gr.DrawString(extra2, font, text_brush2, (x + 40 + (extra2.Length * 4)) * scale, (y + 2) * scale, string_format);

                
                 



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

            //all i had to do is flip the operation... wow
            //as objects get smaller, the scroll margin need to get bigger (because more reletive distance travelled)
            //and vice versa
            //i thought i had to flip the float value and keep the multiply operation
            //but its faster to just divide instead
            center_pt.X += (float)(Main.scrollMarginX / scale);
            center_pt.Y += (float)(Main.scrollMarginY / scale );

      

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
            //Main.check = check;
            isOnNode = (check  ) <= 1.0f;
            
            return isOnNode;
        }
    }
}
