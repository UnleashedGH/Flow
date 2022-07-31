using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Xv2CoreLib;

using System.Drawing;
using System.Windows.Forms;
using Flow.Forms;

namespace Flow.Graph
{
    [Serializable]
    public struct BinaryData
    {
       public Xv2CoreLib.BCM.BCM_Entry bcmentry;
     


        public int ID;  //should be initlized as -1, because its index
        public string LayerName;
        public int LayerIndex;
        public int parentIndex; //should be only used for Reading



        public int RemoteChildIndex; //should be initlized as -1, because its index
        public bool isRemoteChild;
        public TreeNode<CircleNode> RemoteChildParentRef; //the parent node of the remote child
        public TreeNode<CircleNode> RemoteChildPointToRef; // the node the remote child points to





        public bool isLayerRoot;
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
        public float VOffset = 75;

        // Spacing for verticaly orientation.
        public float Indent = 30; //unused, prob should be used in vertical align
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
        public Pen MyPen = new Pen(Color.White);
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
        public TreeNode(T new_data, BinaryData _bd, bool collapse,  string _LayerName = "New Layer")
            : this(new_data, new Font("Arial", 14, FontStyle.Bold), _bd, collapse, _LayerName)
        {
            Data = new_data;
            MyPen.Width = 2.75f;
            localPen.Width = 2.75f;
            isCollpased = collapse;
            Children = new List<TreeNode<T>>();
            bd.bcmentry = new Xv2CoreLib.BCM.BCM_Entry();



        }
        public TreeNode(T new_data, Font fg_font, BinaryData _bd, bool collapse,  string _LayerName = "New Layer")
        {

            Data = new_data;
            MyFont = fg_font;
            MyPen.Width = 2.75f;
            localPen.Width = 2.75f;
            Children = new List<TreeNode<T>>();

            bd = new Graph.BinaryData
            {

                bcmentry = _bd.bcmentry,
                LayerName = _LayerName,
                LayerIndex = _bd.LayerIndex,
                parentIndex = _bd.parentIndex,
                ID = _bd.ID,
                RemoteChildIndex = _bd.RemoteChildIndex,
                isRemoteChild = _bd.isRemoteChild,
                isLayerRoot = _bd.isLayerRoot,
                RemoteChildParentRef = _bd.RemoteChildParentRef,
                RemoteChildPointToRef = _bd.RemoteChildPointToRef,




            };

          
            bd.RemoteChildIndex = -1;
            bd.ID = -1;

            bd.LayerIndex = -1;
            bd.parentIndex = -1;

            bd.isLayerRoot = false;
            bd.isRemoteChild = false;



            isCollpased = collapse;
       
        }

        public TreeNode()
        {

        }

   
        // Add a TreeNode to out Children list.
        public int AddChild(TreeNode<T> child)
        {
            //WARN: what is this?
            //if (child.bd.InputType == "J")
            //    return -1;

            Children.Add(child);
            return 0;
            //return Children.Count-1;
        }

        //TODO : fix
        public int getTotalChildCount(ref int count)
        {
            

          
            foreach (TreeNode<T> child in Children)
            {
                count +=  child.getTotalChildCount(ref count);
            }

            return count;
        }

        //to ignore remote child nodes out of count
        public int getPhyiscalChildCount()
        {
            int count = 0;
            foreach (TreeNode<T> child in Children)
            {
                if (!child.bd.isRemoteChild)
                    count++;
            }
            return count;
        }

        // Arrange the node and its children in the allowed area.
        // Set xmin to indicate the right edge of our subtree.
        // Set ymin to indicate the bottom edge of our subtree.
        //this is called to arrange the tree, this is seperated from drawing the actual tree
        public void Arrange(Graphics gr, ref float xmin, ref float ymin)
        {
       


                ArrangeVertically(gr, xmin, ref ymin);
           
        }

        // Arrange the subtree horizontally. (REMOVED)



        // Arrange the subtree vertically.
        public void ArrangeVertically(Graphics gr, float xmin, ref float ymin)
        {
            // See how big this node is.
            SizeF my_size = Data.GetSize(gr, MyFont);
            my_size.Width +=  (3 ) * SpotRadius ;



            // Set the position of this node's data.

            DataCenter = new PointF(
            (xmin) + SpotRadius,
            ymin + (my_size.Height - (2 * SpotRadius)) / 2);




            // Allow vertical room for this node.
            //ymin += my_size.Height + VOffset;


            //vertical position
            ymin += (60 );


            //don't do arragement for child nodes if IsCollpased = true
            if (isCollpased)
                return;
            // Recursively arrange our children.
       
            foreach (TreeNode<T> child in Children)
            {
                //because of indent + 30, indent is now horz position
                // Arrange this child's subtree.
                child.ArrangeVertically(gr, (xmin) + (60 ), ref ymin);
           
            }
        }

        // Draw the subtree rooted at this node
        // with the given upper left corner.
        //this is called when ComboPanel is refrshed
        public void DrawTree(Graphics gr, ref float x, float y, float s, int reletiveID)
        {

       


            // Arrange the tree.
            Arrange(gr, ref x, ref y);

            // Draw the tree.
            DrawTree(gr, s, reletiveID);
        }

        // Draw the subtree rooted at this node.
        public void DrawTree(Graphics gr, float s, int reletiveID)
        {



            //font size
           // MessageBox.Show((14 * s).ToString());
           //MyFont = new Font("Arial", 14 * s, FontStyle.Bold);
       


            //change the draw order where Nodes are drown first, and when Remote changes its input, links get alerted and color
            //is drawn properly 


            // Draw the nodes.
            DrawSubtreeNodes(gr, s,  reletiveID);


            // Draw the links.
            DrawSubtreeLinks(gr, s);
        }

        // Draw the links for the subtree rooted at this node.
        private void DrawSubtreeLinks(Graphics gr, float s)
        {

          
                DrawSubtreeLinksVertical(gr, s);
          
        }


     

        // Draw the links for the subtree rooted at this node.
        private void DrawSubtreeLinksVertical(Graphics gr, float s)
        {
            //don't draw the child lines if the Parent was set to IsCollapsed = true
            if (isCollpased)
                return;

            int i = 0;

            foreach (TreeNode<T> child in Children)
            {
                string childBtnInput = Utils.Utils.translateButtonInputFlag(child.bd.bcmentry.I_08);
                //hanldes line colors corruposing to Node color (the horzonial line)

                if (Utils.Utils.translateButtonInputFlag(bd.bcmentry.I_08) != "Other")
                {

                    if(childBtnInput == "L")
                    {

                         localPen.Color = Utils.Utils.Light;
                        //localPen.Color = Color.White;
                
                    }
                    else if (childBtnInput == "H")
                    {
                         localPen.Color = Utils.Utils.heavy;
                        //localPen.Color = Color.White;


                    }
                    else if (childBtnInput == "K")
                    {
                       // localPen.Color = Color.White;
                        localPen.Color = Utils.Utils.kiblast;

                    }

                    else if (childBtnInput == "J")
                    {

                        localPen.Color = Utils.Utils.jump;
                        // localPen.Color = Color.White;

                    }

                    else if (childBtnInput == "M")
                    {

                        localPen.Color = Utils.Utils.multiinput;
                        // localPen.Color = Color.White;

                    }
                    else if (childBtnInput == "N")
                    {

                        localPen.Color = Utils.Utils.noinput;
                        // localPen.Color = Color.White;

                    }
                    else
                    {
                        //NoInputType Type
                        localPen.Color = Color.White;
                       // gr.DrawLine(p, DataCenter.X * s, child.DataCenter.Y * s, child.DataCenter.X * s, child.DataCenter.Y * s);
              
                       
                    }

                    //this seems unneeded, its the vertical line that gets overriden by the outer white line anywy
                    //gr.DrawLine(localPen, DataCenter.X * s, DataCenter.Y * s, DataCenter.X * s, child.DataCenter.Y * s);

                    //once the color is decided, draw the unique horz line color
                    //-25 so that it doesn't pass the circle, 25 is half of 50 when is the fake font size set in Circle Node
                    gr.DrawLine(localPen, DataCenter.X * s, child.DataCenter.Y * s, (child.DataCenter.X - 25) * s, child.DataCenter.Y * s);

                }





                // Draw the vertical link between this node this child. (the straight line, always white)
                //+25 so that it doesn't pass the circle, 25 is half of 50 when is the fake font size set in Circle Node
                gr.DrawLine(MyPen, (DataCenter.X) * s, (DataCenter.Y + 25) * s, DataCenter.X * s, child.DataCenter.Y * s);


                // Recursively make the child draw its subtree nodes.
                child.DrawSubtreeLinksVertical(gr, s);
                i++;
            }
        }

        // Draw the nodes for the subtree rooted at this node.
        private void DrawSubtreeNodes(Graphics gr, float s, int reletiveID)
        {
            // i guess i have to redefine this everytime?
            MyFont.Dispose();
            MyFont = new Font("Arial", 14 * s, FontStyle.Bold);



            //is there a better way to do this
            //the other way i had was adding an EXTRA ref to the "parentPointTo" node that points to the remote child and update
            //it when its own input change, but that will leave 2 extra refs unused inside it. this is better right now
            if (bd.isRemoteChild)
                bd.bcmentry.I_08 = bd.RemoteChildPointToRef.bd.bcmentry.I_08;

            //for auto expand
            if (DataCenter.Y * s + (50 ) > Main.ComboPanelTotalY - (1000  ) || DataCenter.X * s + (50  ) > Main.ComboPanelTotalX - (1000 ))
                Main.shouldExpandAuto = true;


            //this should have no need
            //if (Children.Count == 0)
            //    isCollpased = false;

            // change the Node transpareny depending if it was Collpased or not (IsCollapsed)
            //this is one method of indicaiting collapsed nodes.. might change.

            //might wanna include iscollapsed as a bool to draw instead of extra string...

            int tmpID = bd.ID;
            if (!Main.showIndices)
            {
                tmpID = (tmpID - reletiveID + 1);
            }

            bool isGrabEntry = (bd.bcmentry.I_38 != 0 || bd.bcmentry.I_40 != 0) ? true : false;
       
            if (isCollpased)
                Data.Draw(DataCenter.X, DataCenter.Y, gr, MyPen, BgBrush, FontBrush, MyFont, bd.bcmentry.I_08, "+", tmpID.ToString(), s, bd.isRemoteChild, isGrabEntry);
            else

                Data.Draw(DataCenter.X, DataCenter.Y, gr, MyPen, BgBrush, FontBrush, MyFont, bd.bcmentry.I_08, "", tmpID.ToString(), s, bd.isRemoteChild, isGrabEntry);
            





           
            // don't draw the child nodes if the parent IsCollapsed = true
            if (isCollpased)
                return;
            // Recursively make the child draw its subtree nodes.

            foreach (TreeNode<T> child in Children)
            {
                child.DrawSubtreeNodes(gr, s, reletiveID);
            }
        }

        // Return the TreeNode at this point (or null if there isn't one there).
        public TreeNode<T> NodeAtPoint(Graphics gr, PointF target_pt, float scale)
        {
            // See if the point is under this node.
       
            if (Data.IsAtPoint(gr, MyFont, DataCenter, target_pt, scale)) return this;

          

            if (isCollpased)
                return null;
            // See if the point is under a node in the subtree.
            foreach (TreeNode<T> child in Children)
            {
                TreeNode<T> hit_node = child.NodeAtPoint(gr, target_pt, scale);
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
