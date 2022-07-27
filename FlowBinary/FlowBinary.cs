using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flow.Graph;

namespace Flow.FlowBinary
{
   public class FlowBinary
   {


        public TreeNode<CircleNode> root;
        private List<byte> bytes = new List<byte>() { 0x23, 0x46, 0x4C, 0x4F, 0x57 };
        public FlowBinary()
        {
            root = new TreeNode<CircleNode>(new CircleNode(), new BinaryData(), false);
        }

        public void writeFlowBinary(string path)
        {
            
        }
        private void write(TreeNode<CircleNode> node)
        {
            //write node

            foreach (TreeNode<CircleNode> child in node.Children)
            {
                write(child);
            }
        }
   }
}
