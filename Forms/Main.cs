﻿using System;
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

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
            | BindingFlags.Instance | BindingFlags.NonPublic, null,
            listBox1, new object[] { true });



        }




        // the absloute root node.. this node is never drawn (nor its child lines)
        public TreeNode<CircleNode> root =
            new TreeNode<CircleNode>(new CircleNode(), "Root", false);

     

        // buffer node, used for copying and pasting
        private TreeNode<CircleNode> bufferNode = null;
        // The currently selected node.
        private TreeNode<CircleNode> SelectedNode;

        private TreeNode<CircleNode> SelectedLayerNode;

        //Global Vars Private to Form1
        Graphics gr;
        Pen GridPen = new Pen(Color.White);

        //find a solution to scrolling, mousemov?
        int autoScrollMinX = 0;
        int autoScrollMinY = 0;

        bool isBCMLoaded = false;
        //Global Vars Private to Form1



        //Static Vars

        //scrollVars
        public static int scrollMarginX = 0;
        public static int scrollMarginY = 0;

        //draw vars
        public static bool showIndices = false;

        //BcmVars
        static Xv2CoreLib.BCM.Parser bcmInstance;
        static Xv2CoreLib.BCM.Deserializer bcmOut;
        static Xv2CoreLib.BCM.Deserializer bcmOutLocal;
        //Static Vars


        //initite  the main moveset roots
       
    

    




        // Make a tree.
        private void Form1_Load(object sender, EventArgs e)
        {

            
            //test for serliaize
          


            //ComboPanel.BackColor = Color.FromArgb(255, 33, 33, 33);

            ComboPanel.AutoScroll = true;
            ComboPanel.AutoScrollMinSize = new Size(autoScrollMinX, autoScrollMinY);

            ComboPanel.BackColor = Color.FromArgb(255, 51, 51, 51);

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
         
            using (gr = (ComboPanel.CreateGraphics()))
            {



                float xmin = 25;//@
                float ymin =10;

                SelectedLayerNode.Arrange(gr, ref xmin, ref ymin);


            }

            // Arrange the tree.

            //gr = Graphics.FromImage(MainDrawPanel);
            //float xmin = 30;//@
            //float ymin = xmin - 20;
          
            //root.Arrange(gr, ref xmin, ref ymin);

            ComboPanel.Refresh();
       
        }

     


   

        // Set SelectedNode to the node under the mouse.
        private void FindNodeUnderMouse(PointF pt)
        {
            using (gr = (ComboPanel.CreateGraphics()))
            {
                SelectedNode = SelectedLayerNode.NodeAtPoint(gr, pt);
            }

        }

        // Add a child to the selected node.
        private void ctxNodeAddChild_Click(object sender, EventArgs e)
        {
      
            NodeTextDialog dlg = new NodeTextDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                TreeNode<CircleNode> child =
                    new TreeNode<CircleNode>(new CircleNode(), dlg.btnInput, false);
                SelectedNode.isCollpased = false;
                SelectedNode.AddChild(child);



                //handles scrolling
                if (autoScrollMinX + 75 < int.MaxValue)
                    autoScrollMinX += 75;
                if (autoScrollMinY + 75 < int.MaxValue)
                    autoScrollMinY += 75;

                ComboPanel.AutoScrollMinSize = new Size(autoScrollMinX, autoScrollMinY);
                // Rearrange the tree to show the new node.
                ArrangeTree();
            }
        }

        // Delete this node from the tree.
        private void ctxNodeDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this node?",
                "Delete Node?", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Delete the node and its subtree.
                root.DeleteNode(SelectedNode);

                // Rearrange the tree to show the new structure.
                ArrangeTree();
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

         
            
            if (!isNodesPresentToDraw())
                return;

            scrollMarginX = ComboPanel.AutoScrollPosition.X;
            scrollMarginY = ComboPanel.AutoScrollPosition.Y;

            e.Graphics.TranslateTransform(ComboPanel.AutoScrollPosition.X, ComboPanel.AutoScrollPosition.Y);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;


            drawGrid(e.Graphics);
          
            SelectedLayerNode.DrawTree(e.Graphics);

            //ComboPanel.Invalidate();
        
        
            //e.Graphics.DrawImage(MainDrawPanel,0,0);
          
        }

        //dud function.. prob will never use

        private void drawGrid(Graphics gr)
        {
           
            int x = 0;
            int y = 0;
            for(int i = 0; i <= ComboPanel.Height / 60; i++)
            {
                for (int j = 0; j <= ComboPanel.Width / 60; j++)
                {
                    gr.DrawLine(GridPen, x, y + (i * 60), ComboPanel.Width, y + (i * 60));
                    gr.DrawLine(GridPen, x + (j * 60), y, x + (j * 60), ComboPanel.Height);
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
            if (isNodesPresentToDraw() == false)
                return;


            // Find the node under the mouse.
            FindNodeUnderMouse(e.Location);

            // If there is a node under the mouse,
            // display the node's text.
            if (SelectedNode == null)
            {
                lblNodeText.Text = "";
              
            }
            else
            {

                switch (SelectedNode.bd.InputType)
                {

                    case "Root": lblNodeText.Text = "Root"; break;
                    //case "Root": lblNodeText.Text = "Base Moveset Root"; break;

                    case "L": lblNodeText.Text = "Light Attack Input"; break;


                    case "H": lblNodeText.Text = "Heavy Attack Input"; break;

                    case "K": lblNodeText.Text = "Ki Blast Input"; break;

                    case "J": lblNodeText.Text = "Jump Input"; break;


                    default: lblNodeText.Text = SelectedNode.bd.InputType; break;
                }

            }
            ComboPanel.Refresh();
            //ArrangeTree();
        }

        private void ComboPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isNodesPresentToDraw())
                return;

            if (e.Button != MouseButtons.Left && e.Button != MouseButtons.Right) return;

         

            // Find the node under the mouse.
            FindNodeUnderMouse(e.Location);

            // If there is a node under the mouse,
            // display the context menu.
            if (SelectedNode != null)
            {
             

                if (SelectedNode.bd.InputType == "Other")
                    return;
                // Don't let the user delete the root node.
                // (The TreeNode class can't do that.)

                ctxNodeDelete.Enabled = (SelectedNode != root);

                ctxNodeAddChild.Enabled = (SelectedNode != root);

                copyNodeToolStripMenuItem.Enabled = (SelectedNode != root);
                pasteNodeToolStripMenuItem.Enabled = (bufferNode != null) && (SelectedNode != root);
                collapseToolStripMenuItem.Enabled = (SelectedNode.Children.Count > 0);
                collapseToolStripMenuItem.Text = (SelectedNode.isCollpased) ? "Uncollapse" : "Collapse";

                if (e.Button == MouseButtons.Right)
                {
                    Point loc2 = new Point(e.Location.X + 5, e.Location.Y + 20); // +20 to bring the menu down a little bit (coordinate system is left sides)
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
                Point loc = new Point(e.Location.X, e.Location.Y+20); // +20 to bring the menu down a little bit (coordinate system is left sides)
                ctxNode.Show(ComboPanel, loc);
            }
        }

        private void ComboPanel_Scroll(object sender, ScrollEventArgs e)
        {
         
        }

        private void pasteNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
        //TODO : implement a proper paste
           int index =  SelectedNode.AddChild(new TreeNode<CircleNode>(new CircleNode(), bufferNode.bd.InputType, bufferNode.isCollpased));

            int childCount = 0;
            bufferNode.getTotalChildCount(ref childCount);
            MessageBox.Show(childCount.ToString());
            for (int i = 0; i < 1; i++)
            {

             
               // SelectedNode.Children[index].Children.Add(new TreeNode<CircleNode>(new CircleNode(bufferNode.Children[i].Data.Text, bufferNode.Children[i].Data.inputType), bufferNode.Data.inputType));
            }

            
            ArrangeTree();
        }

        private void copyNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO implement a proper paste
            bufferNode = new TreeNode<CircleNode>(new CircleNode(), SelectedNode.bd.InputType, SelectedNode.isCollpased);

        }

        private void collapseToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
        private void AnalyzeCombos(Xv2CoreLib.BCM.BCM_Entry e)
        {
            //first, lay all the BCMentries in a continues array/list to make it easier to track child indices.

            List<Xv2CoreLib.BCM.BCM_Entry> bcmEntries = new List<Xv2CoreLib.BCM.BCM_Entry>();
            traverseAndAppend(e, ref bcmEntries);


            int index = 0;

            //build light string
            //findBACPrimaryEntryandReturnParentBcmIndex(301, bcmEntries, LRoot, ref index);
            //build heavy string
            //findBACPrimaryEntryandReturnParentBcmIndex(335, bcmEntries, HRoot, ref index);


            //for (int i = 0; i < bcmEntries.Count; i++)
            //{
            //    MessageBox.Show(bcmEntries[i].Index.ToString());
            //}

            //bcmEntries[bcmEntries.Count - 1].I_08 = (Xv2CoreLib.BCM.ButtonInput)0x8;



        }

        //public static explicit operator TreeNode<CircleNode>(Xv2CoreLib.BCM.BCM_Entry b)
        //{
        //    //if copy ctor is defined you can call one from the other, else
        //    TreeNode<CircleNode> a = new TreeNode<CircleNode>();
        //    //a.Name = b.Name;
        //    a.Children = new List<TreeNode<CircleNode>>();

        //    foreach (Xv2CoreLib.BCM.BCM_Entry child in b.BCMEntries)
        //    {
        //        a.Children.Add((TreeNode<CircleNode>)child);
        //    }
        //}
     

        private void findBACPrimaryEntryandReturnParentBcmIndex(int BacEntryPrimary, List<Xv2CoreLib.BCM.BCM_Entry> bcmEntries, TreeNode<CircleNode> localRoot, ref int index)
        {
     
            int foundBcmIndex = 0;
            for (int i = 0; i < bcmEntries.Count; i++)
            {
                if(bcmEntries[i].I_32 == BacEntryPrimary)
                {
                    foundBcmIndex = i;
                    break;
                }
            }
            if (foundBcmIndex == 0)
                return;

        
         Int32 parentBcmIndex = GetBcmIndex(Convert.ToInt32(bcmEntries[foundBcmIndex].I_56));

            //MessageBox.Show(parentBcmIndex.ToString());
            //MessageBox.Show(bcmEntries.Count.ToString());
         
         localRoot.Children.AddRange(traverseAndAddChild(bcmEntries[parentBcmIndex], ref index).Children);

      





        }
        private TreeNode<CircleNode> traverseAndAddChild(Xv2CoreLib.BCM.BCM_Entry e, ref int index)
        {

            // MessageBox.Show(e.Index);
           
            string it = "";
            if (e.I_08 == (Xv2CoreLib.BCM.ButtonInput)0x1)
            {
                it = "L";
            }
            else if(e.I_08 == (Xv2CoreLib.BCM.ButtonInput)0x2)
            {
                it = "H";
            }
            else if(e.I_08 == (Xv2CoreLib.BCM.ButtonInput)0x4)
            {
                it = "K";
            }
            else if (e.I_08 == (Xv2CoreLib.BCM.ButtonInput)0x8)
            {
                it = "J";
            }
            TreeNode<CircleNode> f =
            new TreeNode<CircleNode>(new CircleNode(), it, true);
            //FIXTHIS
            f.bd.ID = index;
            index++;


       

            if (e.BCMEntries == null)
            {
                f.isCollpased = false;
                return f;
            }
            bool ChildenAreOnlyJumps = true;
            for (int i = 0; i < e.BCMEntries.Count; i++)
            {
                if (e.BCMEntries[i].I_08 != (Xv2CoreLib.BCM.ButtonInput)0x8)
                {
                    ChildenAreOnlyJumps = false;
                    break;
                }

            }

            if (ChildenAreOnlyJumps)
            {
                f.isCollpased = false;
                return f;
            }
               


            foreach (Xv2CoreLib.BCM.BCM_Entry child in e.BCMEntries)
                    f.AddChild(traverseAndAddChild(child, ref index));

             

            return f;


        }

     
   
        private void compileMovesetBCMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    bcmOut = new Xv2CoreLib.BCM.Deserializer(bcmInstance.bcmFile, saveFileDialog1.FileName);
                    MessageBox.Show("File Saved Successfully");
                    //isBCMLoaded = false;
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error : Xv2CoreLib error during save process." + "\n" + ex.Message);
                    //MessageBox.Show(w.ErrorCode.ToString());
                    //MessageBox.Show(w.NativeErrorCode.ToString());
                    //MessageBox.Show(w.StackTrace);
                    //MessageBox.Show(w.Source);
                    //Exception ee = w.GetBaseException();
                    //MessageBox.Show(ee.Message);
                    Application.Exit();
                }


            }
        }

        private void showIndicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showIndicesToolStripMenuItem.Checked = (!showIndicesToolStripMenuItem.Checked);
            showIndices = showIndicesToolStripMenuItem.Checked;
        }

        private void unleashedTheCitadelToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            LayerDialog dlg = new LayerDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                TreeNode<CircleNode> newLayer = new TreeNode<CircleNode>(new CircleNode(), "J", false);
                newLayer.bd.LayerName = dlg.layerName;
                //newLayer.ID = root.Children.Count;
                root.Children.Add(newLayer);
                listBox1.Items.Add(newLayer.bd.LayerName);
                ArrangeTree();
            }


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                SelectedLayerNode = root.Children[listBox1.SelectedIndex];
                ArrangeTree();


            }
             

          
        }

        private void addRemoteLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
           (new LayerRemoteLink(this)).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                LayerDialog dlg = new LayerDialog();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    root.Children[listBox1.SelectedIndex].bd.LayerName = dlg.layerName;
                    listBox1.Items[listBox1.SelectedIndex] = dlg.layerName;
                    listBox1.Refresh();

                    //this is wrong
                    //create code to repopulate listbox FROM The children list
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

    }
}
