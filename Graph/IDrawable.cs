using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Flow.Graph
{
    // Represents something that a TreeNode can draw.
 
    public interface IDrawable
    {
        // Return the object's needed size.
        SizeF GetSize(Graphics gr, Font font);

        // Return true if the node is above this point.
        bool IsAtPoint(Graphics gr, Font font, PointF center_pt, PointF target_pt, float scale);

        // Draw the object centered at (x, y).
        void Draw(float x, float y, Graphics gr, Pen pen,
            Brush bg_brush, Brush text_brush, Font font, uint btnInputFlag, string extra, string extra2, float scale, bool isRemoteChild, bool isRemoteSibling, bool isGrabEntry);
    }
}
