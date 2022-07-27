using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flow.Graph;

namespace Flow.Forms
{
    public partial class LayerRemoteLink : Form
    {
        Main mainref = null;
        public LayerRemoteLink(Main _mainref)
        {
            mainref = _mainref;
            InitializeComponent();
        }

        private new void Show()
        {
            throw new InvalidOperationException(
                "Use ShowDialog not Show to display this dialog");
        }

        void addNodesFromGraph(TreeNode<CircleNode> rootGraphNode, TreeNode rootTreeNode, TreeView tv) 
        {
            foreach (TreeNode<CircleNode> child in rootGraphNode.Children)
            {
                TreeNode tn = new TreeNode();
               // tn.Text = child.bd.bcmentry.I_08.ToString();
                tn.Tag = child.bd.ID;
               

                rootTreeNode.Nodes.Add(tn);
                addNodesFromGraph(child, tn, tv);
            }
  
        }

        private void LayerRemoteLink_Load(object sender, EventArgs e)
        {
           for (int i = 0; i < mainref.fb.root.Children.Count; i++)
            {
                listBox1.Items.Add(mainref.fb.root.Children[i].bd.LayerName);
      
            }

    
        }

      
     
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                //SelectedLayerNode = root.Children[listBox1.SelectedIndex];
                //ArrangeTree();
                treeView1.Nodes.Clear();
                treeView1.Nodes.Add(mainref.fb.root.Children[listBox1.SelectedIndex].bd.bcmentry.I_08.ToString());
                addNodesFromGraph(mainref.fb.root.Children[listBox1.SelectedIndex], treeView1.Nodes[0], treeView1);


            }

        }
    }
}
