using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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
        #region Write
        public void writeFlowBinary(string path, short vmj, short vmi, short vs)
        {

            int counter = 0;

            bytes.AddRange(BitConverter.GetBytes(vmj));
            bytes.AddRange(BitConverter.GetBytes(vmi));
            bytes.AddRange(BitConverter.GetBytes(vs));
            bytes.AddRange(BitConverter.GetBytes((int)0)); //adjust count later

            write(root, -1, ref counter);

            bytes = ReplaceRange(bytes, BitConverter.GetBytes(counter), 11); //num of nodes


            File.WriteAllBytes(path, bytes.ToArray());
        }
        private void write(TreeNode<CircleNode> node, int parentIndex, ref int counter)
        {
            //write node

            /////////tree node params
            //public int ID;  //should be initlized as -1, because its index
            //public string LayerName;
            //public int LayerIndex; ---- don't need, is calculated automatic



            //public int RemoteChildIndex; -- don't need
            //public bool isRemoteChild;
            //public TreeNode<CircleNode> RemoteChildParentRef; -- don't need
            //public TreeNode<CircleNode> RemoteChildPointToRef; -- don't need





            //public bool isLayerRoot;

            /////////tree node params
            bytes.AddRange(BitConverter.GetBytes(parentIndex));
            bytes.AddRange(BitConverter.GetBytes(node.bd.ID));
            bytes.AddRange(BitConverter.GetBytes(node.bd.RemoteChildIndex));
            bytes.AddRange(BitConverter.GetBytes(node.bd.LayerName.Count()));
            bytes.AddRange(Encoding.ASCII.GetBytes(node.bd.LayerName));
            WriteBcmEntry(node.bd.bcmentry);


            counter++;
            foreach (TreeNode<CircleNode> child in node.Children)
            {
                write(child, parentIndex + 1, ref counter);
            }
        }


        //xv2corelib bcm modified functions
        public static List<byte> ReplaceRange(List<byte> list, byte[] insertedData, int startIndex)
        {
            if (insertedData.Count() >= list.Count())
            {
                throw new InvalidOperationException("Cannot insert more data than is in the original list");
            }

            for (int i = 0; i < insertedData.Count(); i++)
            {
                list[i + startIndex] = insertedData[i];
            }
            return list;
        }
       
        private void WriteBcmEntry(Xv2CoreLib.BCM.BCM_Entry bcmEntry)
        {
    

            bytes.AddRange(BitConverter.GetBytes(bcmEntry.I_00));
            bytes.AddRange(BitConverter.GetBytes((uint)bcmEntry.I_04));
            bytes.AddRange(BitConverter.GetBytes((uint)bcmEntry.I_08));
            bytes.AddRange(BitConverter.GetBytes(bcmEntry.I_12));
            bytes.AddRange(BitConverter.GetBytes(bcmEntry.I_16));
            bytes.AddRange(BitConverter.GetBytes(bcmEntry.I_20));
            bytes.AddRange(BitConverter.GetBytes(bcmEntry.I_22));
            bytes.AddRange(BitConverter.GetBytes(bcmEntry.I_24));
            bytes.AddRange(BitConverter.GetBytes((uint)bcmEntry.I_28));
            bytes.AddRange(BitConverter.GetBytes(bcmEntry.I_32));
            bytes.AddRange(BitConverter.GetBytes(bcmEntry.I_34));
            bytes.AddRange(BitConverter.GetBytes(bcmEntry.I_36));
            bytes.AddRange(BitConverter.GetBytes(bcmEntry.I_38));
            bytes.AddRange(BitConverter.GetBytes(bcmEntry.I_40));
            bytes.AddRange(BitConverter.GetBytes(bcmEntry.I_42));
            bytes.AddRange(BitConverter.GetBytes(bcmEntry.I_44));
            bytes.AddRange(BitConverter.GetBytes(bcmEntry.I_46));

    


            bytes.AddRange(BitConverter.GetBytes(bcmEntry.I_64));
            bytes.AddRange(BitConverter.GetBytes(bcmEntry.I_68));
            bytes.AddRange(BitConverter.GetBytes(bcmEntry.I_72));
            bytes.AddRange(BitConverter.GetBytes((int)bcmEntry.I_76));
            bytes.AddRange(BitConverter.GetBytes(bcmEntry.I_80));
            bytes.AddRange(BitConverter.GetBytes(bcmEntry.I_84));
            bytes.AddRange(BitConverter.GetBytes(bcmEntry.I_88));
            bytes.AddRange(BitConverter.GetBytes(bcmEntry.I_92));
            bytes.AddRange(BitConverter.GetBytes(bcmEntry.F_96));
            bytes.AddRange(BitConverter.GetBytes(bcmEntry.I_100));
            bytes.AddRange(BitConverter.GetBytes(bcmEntry.I_102));
            bytes.AddRange(BitConverter.GetBytes(bcmEntry.I_104));
            bytes.AddRange(BitConverter.GetBytes(bcmEntry.I_108));



       
        }
        #endregion
        #region Read
        public bool readFlowBinary(string path, string toolVersionFull)
        {

            byte[] rawBytes = File.ReadAllBytes(path);


            string binaryName;
            string toolVersion;
            short toolVersionMajor, toolVersionMinor, toolVersionSub = -1;
            int counter = -1;
     


            binaryName = Encoding.ASCII.GetString(rawBytes, 0, 5);
            toolVersionMajor = BitConverter.ToInt16(rawBytes, 5);
            toolVersionMinor = BitConverter.ToInt16(rawBytes, 9);
            toolVersionSub = BitConverter.ToInt16(rawBytes, 6);
            toolVersion = getToolVersion(toolVersionMajor, toolVersionMinor, toolVersionSub);


            if (binaryName != "#FLOW")
                return false;

            //need to handle read different versions later (if needed)
            //if (toolVersion != toolVersionFull)
            //    return false;


            counter = BitConverter.ToInt32(rawBytes, 0xB);

            if (counter == -1)
                return false;



            return true;
        }
        public string getToolVersion(short toolVersionMajor, short toolVersionMinor, short toolVersionSub)
        {
            return $"{toolVersionMajor}.{toolVersionMinor}.{toolVersionSub}";
        }


        #endregion
    }
}
