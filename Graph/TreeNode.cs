using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Xv2CoreLib;

using System.Drawing;

namespace Flow.Graph
{
    [Serializable]
    public struct BinaryData
    {
        public string InputType;
        public int ID;
        public string LayerName;
    }
    public class TreeNode<T> where T : IDrawable
    {
        // The data.
        public T Data;

        // binary test
        public BinaryData bd;

        // Child nodes in the tree.
        // public List<TreeNode<T>> Children = new List<TreeNode<T>>();

        public List<TreeNode<T>> Children;

        // Drawing parameters.
        // Space to skip horizontally between siblings
        // and vertically between generations.
        public float HOffset = 5;
        public float VOffset = 10;

        // Spacing for verticaly orientation.
        public float Indent = 20;
        public float SpotRadius = 5;

        //public vars that will help with handling the UI
        //public string InputType = "";
        //public int ID = 0;
       // public string LayerName = "New Layer";

        // The node's center after arranging.
        private PointF DataCenter;

        public bool isCollpased = false;




        // Drawing properties.
        public Font MyFont = null;
        public Pen MyPen = new Pen(Color.Black);
        private Pen localPen = new Pen(Color.Black);
        public Brush FontBrush = Brushes.White;
        public Brush BgBrush = new SolidBrush(Color.FromArgb(255, 33, 33, 33));
        public Brush BgBrushCollapse = new SolidBrush(Color.FromArgb(200, 33, 33, 33));

        // Recursively set the subtree's orientation.
        public void SetTreeDrawingParameters(float h_offset, float v_offset, float indent, float node_radius)
        {
            HOffset = h_offset;
            VOffset = v_offset;
            Indent = indent;
            SpotRadius = node_radius ;
        

            // Recursively sets the properties for the subtree.
            foreach (TreeNode<T> child in Children)
                child.SetTreeDrawingParameters(h_offset, v_offset,
                    indent, node_radius );
        }

        // Constructor.
        public TreeNode(T new_data, string InputTypeReflect, bool collapse, string _LayerName = "New Layer")
            : this(new_data, new Font("Arial", 14,FontStyle.Bold), InputTypeReflect, collapse, _LayerName)
        {
            Data = new_data;
            MyPen.Width = 2.0f;
            localPen.Width = 2.0f;
            isCollpased = collapse;
            Children = new List<TreeNode<T>>();

        }
        public TreeNode(T new_data, Font fg_font, string InputTypeReflect, bool collapse, string _LayerName = "New Layer")
        {
            Data = new_data;
            MyFont = fg_font;
            MyPen.Width = 2.0f;
            localPen.Width = 2.0f;
            Children = new List<TreeNode<T>>();
            bd = new Graph.BinaryData
            {
                InputType = InputTypeReflect,
                LayerName = _LayerName,
                ID = -1

            };
               isCollpased = collapse;
       
        }

        public TreeNode()
        {

        }

   
        // Add a TreeNode to out Children list.
        public int AddChild(TreeNode<T> child)
        {
            if (child.bd.InputType == "J")
                return -1;

            Children.Add(child);
            return Children.Count-1;
        }

        //TODO : fix
        public void getTotalChildCount(ref int count)
        {
            count += 1;

          
            foreach (TreeNode<T> child in Children)
            {
                getTotalChildCount(ref count);
            }
        }
      
        // Arrange the node and its children in the allowed area.
        // Set xmin to indicate the right edge of our subtree.
        // Set ymin to indicate the bottom edge of our subtree.
        public void Arrange(Graphics gr, ref float xmin, ref float ymin)
        {
          
           
                ArrangeVertically(gr, xmin, ref ymin);
           
        }

        // Arrange the subtree horizontally. (REMOVED)

        // Arrange the subtree vertically.
        public void ArrangeVertically(Graphics gr, float xmin, ref float ymin )
        {
            // See how big this node is.
            SizeF my_size = Data.GetSize(gr, MyFont);
            my_size.Width += 3 * SpotRadius;

         
            // Set the position of this node's data.
         
                DataCenter = new PointF(
             (xmin) + SpotRadius,
                ymin + (my_size.Height - 2 * SpotRadius) / 2);
            
         
            

            // Allow vertical room for this node.
            //ymin += my_size.Height + VOffset;
        
             ymin += 55;


            //don't do arragement for child nodes if IsCollpased = true
            if (isCollpased)
                return;
            // Recursively arrange our children.
       
            foreach (TreeNode<T> child in Children)
            {
             
                // Arrange this child's subtree.
                child.ArrangeVertically(gr, xmin + Indent + 30, ref ymin);
           
            }
        }

        // Draw the subtree rooted at this node
        // with the given upper left corner.
        public void DrawTree(Graphics gr, ref float x, float y)
        {
            // Arrange the tree.
            Arrange(gr, ref x, ref y);

            // Draw the tree.
            DrawTree(gr);
        }

        // Draw the subtree rooted at this node.
        public void DrawTree(Graphics gr)
        {
            // Draw the links.
            DrawSubtreeLinks(gr);

            // Draw the nodes.
            DrawSubtreeNodes(gr);
        }

        // Draw the links for the subtree rooted at this node.
        private void DrawSubtreeLinks(Graphics gr)
        {

          
                DrawSubtreeLinksVertical(gr);
          
        }


     

        // Draw the links for the subtree rooted at this node.
        private void DrawSubtreeLinksVertical(Graphics gr)
        {
            //don't draw the child lines if the Parent was set to IsCollapsed = true
            if (isCollpased)
                return;

            int i = 0;

            foreach (TreeNode<T> child in Children)
            {
                //hanldes line colors corruposing to Node color (the horzonial line)
                if (bd.InputType != "Other")
                {
                    if(child.bd.InputType == "L")
                    {

                        // localPen.Color = Color.LightPink;
                        localPen.Color = Color.White;
                        gr.DrawLine(localPen, DataCenter.X, DataCenter.Y, DataCenter.X, child.DataCenter.Y);
                        gr.DrawLine(localPen, DataCenter.X, child.DataCenter.Y, child.DataCenter.X, child.DataCenter.Y);
                    }
                    else if (child.bd.InputType == "H")
                    {
                        // localPen.Color = Color.LimeGreen;
                        localPen.Color = Color.White;

                        gr.DrawLine(localPen, DataCenter.X, DataCenter.Y, DataCenter.X, child.DataCenter.Y);
                        gr.DrawLine(localPen, DataCenter.X, child.DataCenter.Y, child.DataCenter.X, child.DataCenter.Y);
                    }
                    else if (child.bd.InputType == "K")
                    {
                        localPen.Color = Color.White;
                        //localPen.Color = Color.OrangeRed;
                        gr.DrawLine(localPen, DataCenter.X, DataCenter.Y, DataCenter.X, child.DataCenter.Y);
                        gr.DrawLine(localPen, DataCenter.X, child.DataCenter.Y, child.DataCenter.X, child.DataCenter.Y);
                    }

                    else if (child.bd.InputType == "J")
                    {

                        //localPen.Color = Color.SkyBlue;
                        localPen.Color = Color.White;
                        gr.DrawLine(localPen, DataCenter.X, DataCenter.Y, DataCenter.X, child.DataCenter.Y);
                        gr.DrawLine(localPen, DataCenter.X, child.DataCenter.Y, child.DataCenter.X, child.DataCenter.Y);
                    }
                    else
                    {
                        Pen p = new Pen(Color.Black );
                        gr.DrawLine(p, DataCenter.X, child.DataCenter.Y, child.DataCenter.X, child.DataCenter.Y);
                    }
                  
                }





                // Draw the link between this node this child. (the straight line, always black)
                
                gr.DrawLine(MyPen, DataCenter.X, DataCenter.Y, DataCenter.X, child.DataCenter.Y);


                // Recursively make the child draw its subtree nodes.
                child.DrawSubtreeLinksVertical(gr);
                i++;
            }
        }

        // Draw the nodes for the subtree rooted at this node.
        private void DrawSubtreeNodes(Graphics gr)
        {
            // change the Node transpareny depending if it was Collpased or not (IsCollapsed)
            //this is one method of indicaiting collapsed nodes.. might change.
            if (isCollpased)
              Data.Draw(DataCenter.X, DataCenter.Y, gr, MyPen, BgBrush, FontBrush, MyFont, bd.InputType, "+", bd.ID.ToString());
            else
              Data.Draw(DataCenter.X, DataCenter.Y, gr, MyPen, BgBrush, FontBrush, MyFont, bd.InputType, "", bd.ID.ToString());



           
            // don't draw the child nodes if the parent IsCollapsed = true
            if (isCollpased)
                return;
            // Recursively make the child draw its subtree nodes.

            foreach (TreeNode<T> child in Children)
            {
                child.DrawSubtreeNodes(gr);
            }
        }

        // Return the TreeNode at this point (or null if there isn't one there).
        public TreeNode<T> NodeAtPoint(Graphics gr, PointF target_pt)
        {
            // See if the point is under this node.
       
            if (Data.IsAtPoint(gr, MyFont, DataCenter, target_pt)) return this;

          

            if (isCollpased)
                return null;
            // See if the point is under a node in the subtree.
            foreach (TreeNode<T> child in Children)
            {
                TreeNode<T> hit_node = child.NodeAtPoint(gr, target_pt);
                if (hit_node != null) return hit_node;
            }

            return null;
        }

        // Delete a target node from this node's subtree.
        // Return true if we delete the node.
        public bool DeleteNode(TreeNode<T> target)
        {
            // See if the target is in our subtree.
            foreach (TreeNode<T> child in Children)
            {
                // See if it's the child.
                if (child == target)
                {
                    // Delete this child.
                    Children.Remove(child);
                    return true;
                }

                // See if it's in the child's subtree.
                if (child.DeleteNode(target)) return true;
            }

            // It's not in our subtree.
            return false;
        }
    }
}
