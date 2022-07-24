using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Reflection;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Flow.Graph;
using Flow.ClassExtensions;

namespace Flow.Forms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            // this is the invoke the DoubleBuffered property oon ComboPanel without derviing the Combo Class and making my own.
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
            | BindingFlags.Instance | BindingFlags.NonPublic, null,
            ComboPanel, new object[] { true });


            typeof(ListView).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
            | BindingFlags.Instance | BindingFlags.NonPublic, null,
            listView1, new object[] { true });



            gr = (ComboPanel.CreateGraphics());
            drawGrid(gr);


        }


        //ChildCollection class (helper for dict)
        public class ChildCollection
        {


            List<Xv2CoreLib.BCM.BCM_Entry> m_items;
            public ChildCollection(List<Xv2CoreLib.BCM.BCM_Entry> items)
            {
                // DIs = new Xv2CoreLib.BCM.DirectionalInput[itemCount];
                m_items = items;
            }


            public override bool Equals(Object obj)
            {
                //Check for null and compare run-time types.
                if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                {
                    return false;
                }

                else
                {

                    ChildCollection childCol = (ChildCollection)obj;

                    if ((m_items.Count != childCol.m_items.Count))
                        return false;




                    bool flag = true;

                    for (int i = 0; i < m_items.Count; i++)
                    {
                        if (!m_items[i].Compare(childCol.m_items[i]))
                        {
                            flag = false;
                            break;
                        }


                    }

                  
                    
                    

                    return flag;
                }
            }
            public override int GetHashCode()
            {
                unchecked // Overflow is fine, just wrap
                {
                    int hash = (int)2166136261;
                    for (int i = 0; i < m_items.Count; i++)
                    {
                        hash = (hash * 16777619) ^ m_items[i].GetHashCode();
                    }

                    // Suitable nullity checks etc, of course :)


                    return hash;
                }
            }

        }

        // the absloute root node.. this node is never drawn (nor its child lines)
        public TreeNode<CircleNode> root =
            new TreeNode<CircleNode>(new CircleNode(), new BinaryData(), false);

     

        // buffer node, used for copying and pasting
        private TreeNode<CircleNode> bufferNode = null;
        // The currently selected node.
        private TreeNode<CircleNode> SelectedNode;
        //the selected layer in the layer list
        private TreeNode<CircleNode> SelectedLayerNode;

        //Global Vars Private to Form1
        Graphics gr;
        Pen GridPen = new Pen(Color.White);
        Bitmap mBuffer;

        //find a solution to scrolling, mousemov?
        int autoScrollMinX = 1000;
        int autoScrollMinY = 1000;

        bool isBCMLoaded = false;
        //Global Vars Private to Form1



        //Static Vars
        static int extern_index = 0;

        //scrollVars
        public static int scrollMarginX = 0;
        public static int scrollMarginY = 0;

        //mouse scroll vars
        private float mouseOffsetX = 0.0f;
        private float mouseOffsetY = 0.0f;

        //draw vars
        public static bool showIndices = false;
        private bool showGrid = false;
        private float scale = 1.0f;


        //BcmVars
        static Xv2CoreLib.BCM.Parser bcmInstance;
        static Xv2CoreLib.BCM.BCM_File bcmFile;
        static Xv2CoreLib.BCM.Deserializer bcmOut;
        //Static Vars


        //paint
         bool needsClearSelection = false;

        //dbg
        public static float check;
    


       public  void writecheck(float c)
        {
            this.Text = c.ToString();
        }


        // Make a tree.
        private void Form1_Load(object sender, EventArgs e)
        {
   
   
            showGrid = (gridToolStripMenuItem.Checked);
            showIndices = (showIndicesToolStripMenuItem.Checked);

         


            ComboPanel.AutoScroll = true;
            ComboPanel.AutoScrollMinSize = new Size(autoScrollMinX, autoScrollMinY);

            ComboPanel.BackColor = Color.FromArgb(255, 51, 51, 51);

            listView1.Scrollable = true;
            listView1.View = View.Details;

            ColumnHeader header = new ColumnHeader();
            header.Text = "";
            header.Name = "col1";
            //header.Width = listView1.Size.Width;
            listView1.Columns.Add(header);

            //TreeNode<CircleNode> c_node = new TreeNode<CircleNode>(new CircleNode("K" ,"K"), "K", false);
            //TreeNode<CircleNode> d_node = new TreeNode<CircleNode>(new CircleNode("K", "K"), "K" , false);
            //SelectedLayerNode = root;

            //add these to see debug out put
            //root.AddChild(HRoot);
            //root.AddChild(LRoot);

            //LRoot.AddChild(c_node);
            //HRoot.AddChild(d_node);








            // Position the tree.

            // ArrangeTree();

            //lblNodeText.Text = "Loaded";
        }

 

 
        private void ArrangeTree()
        {

            if (SelectedLayerNode == null)
                return;
         
            


                float xmin = 25.0f ;
                float ymin = 10.0f ;
            //using (gr = (ComboPanel.CreateGraphics()))
            //{

            //    SelectedLayerNode.Arrange(gr, ref xmin, ref ymin);
            //}

            SelectedLayerNode.Arrange(gr, ref xmin, ref ymin);


            // Arrange the tree.

            //gr = Graphics.FromImage(MainDrawPanel);
            //float xmin = 30;//@
            //float ymin = xmin - 20;

            //root.Arrange(gr, ref xmin, ref ymin);

            ComboPanel.Refresh();
       
        }

     


   

        // Set SelectedNode to the node under the mouse.
        private void FindNodeUnderMouse(PointF pt, float scale)
        {
            //using (gr = (ComboPanel.CreateGraphics()))
            //{
            //    SelectedNode = SelectedLayerNode.NodeAtPoint(gr, pt, scale);
            //}
            SelectedNode = SelectedLayerNode.NodeAtPoint(gr, pt, scale);

        }

        // Add a child to the selected node.
        private void ctxNodeAddChild_Click(object sender, EventArgs e)
        {
            if (SelectedNode == null)
                return;

            if (SelectedNode.bd.RemoteChildIndex >= 0)
            {
                MessageBox.Show("A Node cannot have any phyiscal links if it has a remote link",
                    "Add Link", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            NodeTextDialog dlg = new NodeTextDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                TreeNode<CircleNode> child =
                    new TreeNode<CircleNode>(new CircleNode(), new BinaryData(), false);

                child.bd.buttonInputFlag = dlg.primarybuttininput;

                SelectedNode.isCollpased = false;
                SelectedNode.AddChild(child);



                //handles scrolling
                //if (autoScrollMinX + (int)(75 * scale) < int.MaxValue)
                //    autoScrollMinX += (int)(75 * scale);
                //if (autoScrollMinY + (int)(75 * scale) < int.MaxValue)
                //    autoScrollMinY += (int)(75 * scale);

                // ComboPanel.AutoScrollMinSize = new Size(autoScrollMinX, autoScrollMinY);

                // Rearrange the tree to show the new node.
                reindex();


                ArrangeTree();
              

                //using (gr = (ComboPanel.CreateGraphics()))
                //{
                //    drawGrid(gr);
                //}
          


            }
        }

        // Delete this node from the tree.
        private void ctxNodeDelete_Click(object sender, EventArgs e)
        {
            if (SelectedNode == null)
                return;

            // ADD DIFFERENT LOGIC IF DELETING A REMOTE LINK!!!
            // THE INDEX FROM THE PREVIOS NODE MUST BE SET TO 1
            if (MessageBox.Show("Are you sure you want to delete this node?",
                "Delete Node?", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (SelectedNode.bd.isRemoteChild)
                {
                    SelectedNode.bd.RemoteChildParentRef.bd.RemoteChildIndex = -1;
                }

                // Delete the node and its subtree.
               root.DeleteNode(SelectedNode);
                // int count = 0;
                //int NumOfChildren = root.getTotalChildCount(ref count);
                //MessageBox.Show(NumOfChildren.ToString());

                //if (autoScrollMinX - 75 >= 0)
                //    autoScrollMinX -= 75;
                //if (autoScrollMinY - 75 >= 0)
                //    autoScrollMinY -= 75;

                // ComboPanel.AutoScrollMinSize = new Size(autoScrollMinX, autoScrollMinY);
                reindex();

                // Rearrange the tree to show the new structure.
                ArrangeTree();


                //using (gr = (ComboPanel.CreateGraphics()))
                //{
                //    drawGrid(gr);
                //}
               // drawGrid(gr);

            }
        }


       
        private bool isNodesPresentToDraw()
        {
            if (SelectedLayerNode == null)
                return false;

        
            return true;
        }

        private void ctxNode_Opening(object sender, CancelEventArgs e)
        {

        }

     

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        //draw the tree
        private void ComboPanel_Paint(object sender, PaintEventArgs e)
        {
            
          

            if (!isNodesPresentToDraw()) return;



          

            scrollMarginX = (ComboPanel.AutoScrollPosition.X );
            scrollMarginY = (ComboPanel.AutoScrollPosition.Y);





            e.Graphics.TranslateTransform(ComboPanel.AutoScrollPosition.X, ComboPanel.AutoScrollPosition.Y );
           // e.Graphics.TranslateTransform(mouseOffsetX, mouseOffsetY);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            if (showGrid)
            {

            
                e.Graphics.DrawImage(mBuffer, 0, 0);

            }

            SelectedLayerNode.DrawTree(e.Graphics, scale);

            //ComboPanel.Invalidate();


            //e.Graphics.DrawImage(MainDrawPanel,0,0);
     
      


        }



        private void drawGrid(Graphics gr)
        {


            mBuffer = new Bitmap(ComboPanel.Width + autoScrollMinX, ComboPanel.Height + autoScrollMinY, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            using (Graphics bg = Graphics.FromImage(mBuffer))
            {
                // Draw your grid into "bg" here...


                //what if you just dump that image and reload it instanly?




                //optimize algo so it draws faster
                int x = 0;
                int y = 0;
                float nodeSize = 60.0f * scale;
         

                for (int i = 0; i <= (ComboPanel.Height + autoScrollMinY) / nodeSize; i++)
                {
                    bg.DrawLine(GridPen, x, y + (i * nodeSize), (ComboPanel.Width + autoScrollMinX), y + (i * nodeSize));
                }
                for (int j = 0; j <= (ComboPanel.Width + autoScrollMinX) / nodeSize; j++)
                {
                   
                    bg.DrawLine(GridPen, x + (j * nodeSize), y, x + (j * nodeSize), (ComboPanel.Height + autoScrollMinY));
                }



            }
        }
        //center  on the form
        private void ComboPanel_Resize(object sender, EventArgs e)
        {
            ArrangeTree();
        }

        private void ComboPanel_MouseMove(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    var relativePoint = ComboPanel.PointToClient(Cursor.Position);
            //    mouseOffsetX = relativePoint.X;
            //    mouseOffsetY = relativePoint.Y;
            //}

            //dbg
            //this.Text = check.ToString();

            if (isNodesPresentToDraw() == false)
                return;

          
            // Find the node under the mouse.
            FindNodeUnderMouse(e.Location, scale);

            // If there is a node under the mouse,
            // display the node's text.
            if (SelectedNode == null)
            {


                lblNodeText.Text = "";

                if (needsClearSelection)
                {
                    ComboPanel.Refresh();
                    needsClearSelection = false;
                    return;
                }

                else
                {
                    return;
                
                }
                   
              
            }

            //selected node is not null
            else
            {
              
                if (SelectedNode.bd.isRemoteChild)
                {
                    //there's 2 ways to get the ID now that we have 2 refs in bd..
                    //might change
                    lblNodeText.Text = "Remote Link for Node with index: " + SelectedNode.bd.RemoteChildParentRef.bd.RemoteChildIndex.ToString();
                }
                //if not remove child
                else
                {


                    lblNodeText.Text = ((Xv2CoreLib.BCM.ButtonInput)SelectedNode.bd.buttonInputFlag).ToString();


                }



            }

         

            //put refresh outside so you clear out the yellow circle line

            ComboPanel.Refresh();
            needsClearSelection = true;



            //ArrangeTree();
        }

        private void ComboPanel_MouseDown(object sender, MouseEventArgs e)
        {

    
            if (!isNodesPresentToDraw())
                return;

            //only left or right mouse buttons are allowed
            if (e.Button != MouseButtons.Left && e.Button != MouseButtons.Right) return;

         

            // Find the node under the mouse.
            FindNodeUnderMouse(e.Location, scale);

            // If there is a node under the mouse,
            // display the context menu.
            if (SelectedNode != null)
            {
             

                if (Utils.Utils.translateButtonInputFlag(SelectedNode.bd.buttonInputFlag) == "Other")
                    return;
                // Don't let the user delete the root node.
                // (The TreeNode class can't do that.)

                ctxNodeDelete.Enabled = ( SelectedNode.bd.isLayerRoot == false );

                ctxNodeAddChild.Enabled = (SelectedNode != root);

                copyNodeToolStripMenuItem.Enabled = (SelectedNode != root) && (SelectedNode.bd.isRemoteChild == false);
                pasteNodeToolStripMenuItem.Enabled = (bufferNode != null)  && (SelectedNode.bd.isRemoteChild == false);
                pasteRemoteLinkToolStripMenuItem.Enabled = (bufferNode != null) && (SelectedNode.bd.isRemoteChild == false);
                pasteSingleLinkToolStripMenuItem.Enabled = (bufferNode != null) && (SelectedNode.bd.isRemoteChild == false);

                modifyDataToolStripMenuItem.Enabled =  (SelectedNode.bd.isRemoteChild == false);

                ctxNodeAddChild.Enabled =  (SelectedNode.bd.isRemoteChild == false);

                collapseToolStripMenuItem.Enabled = (SelectedNode.Children.Count > 0);
                collapseToolStripMenuItem.Text = (SelectedNode.isCollpased) ? "Uncollapse" : "Collapse";

                if (e.Button == MouseButtons.Right)
                {
                    Point loc2 = new Point(e.Location.X + 5, e.Location.Y + 5); // +20 to bring the menu down a little bit (coordinate system is left sides)
                    ctxNode.Show(ComboPanel, loc2);
                    return;
                }

                if (SelectedNode.isCollpased)
                {
                    SelectedNode.isCollpased = false;
                    ArrangeTree();
                    return;
                }
                

                // Display the context menu.
                Point loc = new Point(e.Location.X + 5, e.Location.Y + 5); // +20 to bring the menu down a little bit (coordinate system is left sides)
                ctxNode.Show(ComboPanel, loc);
            }

            else { }

        }

        private void ComboPanel_Scroll(object sender, ScrollEventArgs e)
        {
         
        }

        private void pasteNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (SelectedNode == null || bufferNode == null)
                return;





            if (SelectedNode.bd.RemoteChildIndex >= 0)
            {
                MessageBox.Show("A Node cannot have any phyiscal links if it has a remote link",
                    "Paste Link", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }



            SelectedNode.AddChild(pasterecursive(bufferNode));
            reindex();
            ArrangeTree();
        }

        public TreeNode<CircleNode> pasterecursive( TreeNode<CircleNode> pasteChild)
        {
            TreeNode<CircleNode> newChild = new TreeNode<CircleNode>(new CircleNode(), pasteChild.bd, false);
            newChild.bd.isLayerRoot = false;

            foreach (TreeNode<CircleNode> child in pasteChild.Children)
            {
                //because the contructor of treenode sets child index to -1, this should be safe and not copy remote child
                //but do this too, this feels right
                if (child.bd.isRemoteChild)
                    return newChild;

                newChild.AddChild(pasterecursive(child));
               
            }
            return newChild;
        }

        private void copyNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (SelectedNode == null)
                return;
            //TODO implement a proper paste

            //we need bufferNode because it holds copy, as SelectedNode can change later

            //bufferNode = new TreeNode<CircleNode>(new CircleNode(), SelectedNode.bd.buttonInputFlag, SelectedNode.isCollpased);
            //bufferNode.bd.ID = SelectedNode.bd.ID;
            //bufferNode.bd.isRemoteChild = SelectedNode.bd.isRemoteChild;
            //bufferNode.bd.RemoteChildIndex = SelectedNode.bd.RemoteChildIndex;

            //I THOUGHT THIS WOULDN'T WORK?
            //apparently the selected node reference won't chnagne buffernode when itself changes (recursive ref)
            //its a static ref to the last referenced node? that's very useful

            //before then before node was a NEw node of selected node, which is a new intance and not a ref
            bufferNode = SelectedNode;


            // SelectedNode.Children.CopyTo(bufferNode.Children);
            //  bufferNode.Children = SelectedNode.Children;

        }

        private void collapseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedNode == null)
                return;

            SelectedNode.isCollpased = !SelectedNode.isCollpased;
            ArrangeTree();
        }

        private int GetBcmIndex(int offset)
        {
            if (offset != 0)
            {
                offset -= -16;
                return offset / 112;
            }
            else
            {
                return -1;
            }
        }

        private void traverseAndAppend(Xv2CoreLib.BCM.BCM_Entry e, ref List<Xv2CoreLib.BCM.BCM_Entry> bcmEntries)
        {

         
            bcmEntries.Add(e);
            if (e.BCMEntries == null)
                return;

            foreach (Xv2CoreLib.BCM.BCM_Entry child in e.BCMEntries)
                traverseAndAppend(child, ref bcmEntries);

        }
    



      
        private TreeNode<CircleNode> traverseAndAddChild(Xv2CoreLib.BCM.BCM_Entry e, ref int index)
        {

            // MessageBox.Show(e.Index);
           
       
            TreeNode<CircleNode> f =
            new TreeNode<CircleNode>(new CircleNode(), new BinaryData(), true);
            //FIXTHIS
            f.bd.ID = index;

            f.bd.buttonInputFlag = (uint)e.I_08;

    

            if (e.BCMEntries == null)
            {
               

                if (e.LoopAsChild == null)
                {
                  
                    f.isCollpased = false;
                }
                
                else
                {
                    TreeNode<CircleNode> newChild = new TreeNode<CircleNode>(new CircleNode(), new BinaryData(), false);
                    newChild.bd.isLayerRoot = false;
                    f.bd.RemoteChildIndex = Convert.ToInt32(e.LoopAsChild);

                    newChild.bd.isRemoteChild = true;
                    newChild.bd.RemoteChildParentRef = f;
                    newChild.bd.RemoteChildPointToRef = f;

                    newChild.isCollpased = false;

                    f.AddChild(newChild);
                    f.isCollpased = true;
                }

                index++;
                return f;
            }
          


            index++;
            foreach (Xv2CoreLib.BCM.BCM_Entry child in e.BCMEntries)
                    f.AddChild(traverseAndAddChild(child, ref index));

             

            return f;


        }

        void fillRemoteChildPointToRefGoTo()
        {

        }

     
        void compileBcm(TreeNode<CircleNode> root, ref Xv2CoreLib.BCM.BCM_File bcmFile, ref Xv2CoreLib.BCM.BCM_Entry rootBcmEntry)
        {
            foreach (TreeNode<CircleNode> child in root.Children)
            {

                if (child.bd.isRemoteChild)
                    return;

                Xv2CoreLib.BCM.BCM_Entry cEntry = new Xv2CoreLib.BCM.BCM_Entry();

                cEntry.I_08 = (Xv2CoreLib.BCM.ButtonInput)child.bd.buttonInputFlag;
                cEntry.Index = child.bd.ID.ToString();
                string childGoto = child.bd.RemoteChildIndex.ToString();
                if (childGoto != "-1")
                {
                    MessageBox.Show(childGoto);
                    cEntry.LoopAsChild = child.bd.RemoteChildIndex.ToString();
                }
         

                if (rootBcmEntry.BCMEntries == null)
                    rootBcmEntry.BCMEntries = new List<Xv2CoreLib.BCM.BCM_Entry>();

                rootBcmEntry.BCMEntries.Add(cEntry);

                compileBcm(child,ref  bcmFile, ref cEntry);
            }
        }


        private void compileMovesetBCMToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void showIndicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showIndicesToolStripMenuItem.Checked = (!showIndicesToolStripMenuItem.Checked);
            showIndices = showIndicesToolStripMenuItem.Checked;
            ComboPanel.Refresh();
        }

        private void unleashedTheCitadelToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            LayerDialog dlg = new LayerDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
             
                TreeNode<CircleNode> newLayer = new TreeNode<CircleNode>(new CircleNode(), new BinaryData(), false);
                newLayer.bd.LayerName = dlg.layerName;
                newLayer.bd.isLayerRoot = true;
               
                //newLayer.ID = root.Children.Count;
                root.Children.Add(newLayer);
                populateListBox();
                reindex();


                ArrangeTree();
                
              





            }
       
           
        }

        private void populateListBox(int index = -1)
        {
            //so we don't get scrollbar flickers when deleting and adding items
            listView1.BeginUpdate();

            //find longest layer name length to increase column width
            int longestNameLen = 0;

            int oldselectedindex = -1;

            if (listView1.SelectedIndices.Count > 0)
                oldselectedindex = listView1.SelectedIndices[0];

            listView1.Items.Clear();
            for (int i = 0; i < root.Children.Count;i++)
            {
                listView1.Items.Add(i.ToString() + " - " + root.Children[i].bd.LayerName);
                if (root.Children[i].bd.LayerName.Length > longestNameLen)
                    longestNameLen = root.Children[i].bd.LayerName.Length;
            }

            //when deleting layers and going back to the previous layer, this is an optional param
            if (index >= 0)
            {
                listView1.Items[index].Focused = true;
                listView1.Items[index].Selected = true;
                listView1.Items[index].EnsureVisible();
            }

            //increase the column size that was added in form Load method based of layer name length + the index + the spacing
            listView1.Columns[0].Width = (index.ToString().Length +  longestNameLen + 3) * 14;

            //to maintain scroll index (its not amazing, but its better than going back to index 0
            if (oldselectedindex >= 0)
            {
                listView1.Items[oldselectedindex].Focused = true;
                listView1.Items[oldselectedindex].Selected = true;
                listView1.Items[oldselectedindex].EnsureVisible();
                
            }
            //so we don't get scrollbar flickers when deleting and adding items
            listView1.EndUpdate();

        }
       
        private void reindex()
        {





            Dictionary<int, int> mappings = new Dictionary<int, int>();
            extern_index = 0;
            mappings[root.bd.ID] = extern_index;
       
            reindexID(root, mappings);
            reindexRemote(root, mappings);

        }

        private void reindexID(TreeNode<CircleNode> r,  Dictionary<int, int> mappings)
        {
            
            foreach (TreeNode<CircleNode> child in r.Children)
            {
                if (child.bd.isRemoteChild)
                {
                    //child.bd.ID = 999;
                    return;
                }

                extern_index++;
                mappings[child.bd.ID] = extern_index;
                child.bd.ID = extern_index;
               
                reindexID(child, mappings);
            }
          
        }

        private void reindexRemote(TreeNode<CircleNode> r, Dictionary<int, int> mappings)
        {
            foreach (TreeNode<CircleNode> child in r.Children)
            {
                if (child.bd.isRemoteChild)
                {
                   // child.bd.ID = 666;
                    return;
                }

                if (child.bd.RemoteChildIndex >= 0) { 
                    if (mappings.ContainsKey(child.bd.RemoteChildIndex))
                        child.bd.RemoteChildIndex = mappings[child.bd.RemoteChildIndex];

                    else
                    {
                        child.bd.RemoteChildIndex = -1;
                        //if (child.Children != null)
                        //    if (child.Children.Count() > 0)
                                if (child.Children[0] != null) // should always be true if all went well..
                                    root.DeleteNode(child.Children[0]);
                        
                    
                    }


                }


                reindexRemote(child, mappings);
            }
        }
     
        private void addRemoteLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
           (new LayerRemoteLink(this)).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                LayerDialog dlg = new LayerDialog(root.Children[listView1.SelectedIndices[0]].bd.LayerName);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    root.Children[listView1.SelectedIndices[0]].bd.LayerName = dlg.layerName;
                    populateListBox();

                }
                  


            }

           

        }

        private void saveFlowFileflowToolStripMenuItem_Click(object sender, EventArgs e)
        {

            writeFlowBinary(root);

          
        }

        void writeFlowBinary(TreeNode<CircleNode> r)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
              //  root.Children.RemoveAt(listBox1.SelectedIndex);
                root.DeleteNode(root.Children[listView1.SelectedIndices[0]]);
        
                if ((listView1.SelectedIndices[0] - 1) >= 0)
                {

                    populateListBox(listView1.SelectedIndices[0] - 1);
                }

                else
                {
            
                    SelectedLayerNode = null;
                    populateListBox();
                }

             
                reindex();
                ComboPanel.Refresh();
               // listBox1.SelectedIndex -= 1;
              
           
            }
         
        }

        private void modifyDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedNode == null)
                return;

            NodeTextDialog dlg = new NodeTextDialog(SelectedNode);

            if (dlg.ShowDialog() == DialogResult.OK)
            {
            
                SelectedNode.bd.buttonInputFlag = dlg.primarybuttininput;

                ComboPanel.Refresh();
            }
        }

        private void gridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //boolean trigger
            showGrid = (showGrid == false);
            ComboPanel.Refresh();
        }

     
   


        private void Main_Shown(object sender, EventArgs e)
        {
       
      
         

        }

        private void compileToBCMToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //compile BCM
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                bcmFile = new Xv2CoreLib.BCM.BCM_File();

                Xv2CoreLib.BCM.BCM_Entry rootEntry = new Xv2CoreLib.BCM.BCM_Entry();

                bcmFile.BCMEntries.Add(rootEntry);

                compileBcm(root, ref bcmFile, ref rootEntry);

                bcmOut = new Xv2CoreLib.BCM.Deserializer(bcmFile, saveFileDialog1.FileName);


           
                MessageBox.Show("Compiled Successfully",
                  "Compiled BCM", MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
                //isBCMLoaded = false;





            }
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {

            listView1.Items.Clear();
            root.Children.Clear();
            root = new TreeNode<CircleNode>(new CircleNode(), new BinaryData(), false);

            TreeNode<CircleNode> newLayer = new TreeNode<CircleNode>(new CircleNode(), new BinaryData(), false);
            newLayer.bd.LayerName = "New Layer";
            //newLayer.ID = root.Children.Count;
            root.Children.Add(newLayer);
            populateListBox();
            reindex();
            ArrangeTree();
            listView1.Items[0].Focused = true;
            listView1.Items[0].Selected = true;
            listView1.Items[0].EnsureVisible();





        }

        private void pasteRemoteLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (SelectedNode == null || bufferNode == null)
                return;

            if (SelectedNode.getPhyiscalChildCount() > 0)
            {
                MessageBox.Show("A Node cannot have a remote link if it already has phyiscal links",
                 "Paste Remote Link", MessageBoxButtons.OK,
                 MessageBoxIcon.Error);
                return;
            }

            if (SelectedNode.bd.RemoteChildIndex >= 0)
            {
                MessageBox.Show("A Node cannot have more than 1 remote link",
                    "Paste Remote Link", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }


            TreeNode<CircleNode> newChild = new TreeNode<CircleNode>(new CircleNode(), new BinaryData(), bufferNode.isCollpased);
            newChild.bd.isLayerRoot = false;
        
            newChild.bd.isRemoteChild = true;
            newChild.bd.RemoteChildParentRef = SelectedNode;
            newChild.bd.RemoteChildPointToRef = bufferNode;

            int index = SelectedNode.AddChild(newChild);
            SelectedNode.bd.RemoteChildIndex = bufferNode.bd.ID;

        
      

            reindex();
            ArrangeTree();
        }

        private void listBox1_MouseMove(object sender, MouseEventArgs e)
        {
        
            
        }

        private void showChildLinkInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedNode == null)
                return;
            MessageBox.Show(SelectedNode.bd.RemoteChildIndex.ToString());
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                SelectedLayerNode = root.Children[listView1.SelectedIndices[0]];
                ArrangeTree();



            }
        }

    
    

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new About()).Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (autoScrollMinX + (int)(500 * scale) < int.MaxValue)
                autoScrollMinX += (int)(500 * scale);
            if (autoScrollMinY + (int)(500 * scale) < int.MaxValue)
                autoScrollMinY += (int)(500 * scale);

            ComboPanel.AutoScrollMinSize = new Size(autoScrollMinX, autoScrollMinY);
            drawGrid(gr);
            ComboPanel.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if ((autoScrollMinX - (int)(500 * scale) < int.MaxValue))
                autoScrollMinX -= (int)(500 * scale);
            if ((autoScrollMinY - (int)(500 * scale) < int.MaxValue))
                autoScrollMinY -= (int)(500 * scale);

            ComboPanel.AutoScrollMinSize = new Size(autoScrollMinX, autoScrollMinY);
            drawGrid(gr);
            ComboPanel.Refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (scale + 0.25f <= 2.0f)
            {
                scale += 0.25f;
                drawGrid(gr);
                ComboPanel.Refresh();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (scale - 0.25f > 0)
            {
                scale -= 0.25f;
                drawGrid(gr);
                ComboPanel.Refresh();
            }
           
        }
        public void traverseAndCompress(Xv2CoreLib.BCM.BCM_Entry e, Dictionary<ChildCollection, string> dict)
        {


            if (e.BCMEntries == null)
                return;



            ChildCollection childs = new ChildCollection(e.BCMEntries);

            if (dict.ContainsKey(childs))
            {
                //if the BCM entry has children, delete them
                if (e.BCMEntries != null)
                {
                  
                    e.BCMEntries = null;
                    //set a GoTo Child loop from the previous BCM child index
                    e.LoopAsChild = dict[childs];
                    return;

                }
            }

            //new BacEntryPrimary

            else //if it was children, add the BCM children structure in the dictonary, then add the BCM child index
                if (e.BCMEntries != null)
                dict.Add(childs, e.BCMEntries[0].Index);




            foreach (Xv2CoreLib.BCM.BCM_Entry child in e.BCMEntries)
                traverseAndCompress(child, dict);



        }

        private void decompileExistingBCMExpirementalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {


                listView1.Items.Clear();
                root.Children.Clear();
                root = new TreeNode<CircleNode>(new CircleNode(), new BinaryData(), false);

                bcmInstance = new Xv2CoreLib.BCM.Parser(openFileDialog1.FileName, false);


                //list of all BCM entries non tree
                Xv2CoreLib.BCM.BCM_Entry r = bcmInstance.bcmFile.BCMEntries[0];

                Dictionary<ChildCollection, string> dict =
              new Dictionary<ChildCollection, string>();

                //first, compress a vanilla bcm
                traverseAndCompress(r, dict);

                //sort everything after compress... (need better method)
                // we NEED a function to sort the bcm after deleting entries

                //              MessageBox.Show(bcmInstance.rawBytes.Length.ToString());

                //IS THIS NEEDED?
                bcmOut = new Xv2CoreLib.BCM.Deserializer(bcmInstance.bcmFile);
                bcmInstance = new Xv2CoreLib.BCM.Parser(bcmOut.rawBytesAfterSort);
     
                //   MessageBox.Show(bcmInstance.rawBytes.Length.ToString());

                r = bcmInstance.bcmFile.BCMEntries[0];
                
        


                int index = 0;

                root.Children.AddRange(traverseAndAddChild(r, ref index).Children);


           
                //isBCMLoaded = true;
                reindex();
                ArrangeTree();
                populateListBox();
            }
        }

        private void pasteSingleLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedNode == null || bufferNode == null)
                return;


            if (SelectedNode.bd.RemoteChildIndex >= 0)
            {
                MessageBox.Show("A Node cannot have any phyiscal links if it has a remote link",
                    "Paste Single Link", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            TreeNode<CircleNode> newChild = new TreeNode<CircleNode>(new CircleNode(), bufferNode.bd, bufferNode.isCollpased);

            newChild.bd.isLayerRoot = false;
            SelectedNode.AddChild(newChild);
   


            reindex();
            ArrangeTree();
        }
    }
}
