using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Flow.Graph;
using Xv2CoreLib.BCM;
using System.Windows.Forms;


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
            //root.bd.ID = 0;
            //for (int i = 0; i < root.Children.Count; i++)
                //MessageBox.Show(root.Children[i].bd.LayerName);
            write(root, -1, ref counter);

            bytes = ReplaceRange(bytes, BitConverter.GetBytes(counter), 11); //num of nodes


            File.WriteAllBytes(path, bytes.ToArray());
        }
        private void write(TreeNode<CircleNode> r, int parentIndex, ref int counter)
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

            if (r.bd.isRemoteChild)
            {
               
              //  MessageBox.Show(counter.ToString());
                return;
            }




            //public bool isLayerRoot;

            /////////tree node params

            bytes.AddRange(BitConverter.GetBytes(parentIndex));
            bytes.AddRange(BitConverter.GetBytes(r.bd.ID));
            bytes.AddRange(BitConverter.GetBytes(r.bd.RemoteChildIndex));

         

            if (parentIndex == 0) //if the parent is root, write layer names
            {
                bytes.AddRange(BitConverter.GetBytes(r.bd.LayerName.Count()));
                bytes.AddRange(Encoding.ASCII.GetBytes(r.bd.LayerName));
            }else
            {
                bytes.AddRange(BitConverter.GetBytes((int)0));
            }
         
            WriteBcmEntry(r.bd.bcmentry);


            counter++;
            parentIndex = r.bd.ID;
            foreach (TreeNode<CircleNode> child in r.Children)
            {
                write(child, parentIndex, ref counter);
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

            bytes.AddRange(BitConverter.GetBytes((int)0));
            bytes.AddRange(BitConverter.GetBytes((int)0));
            bytes.AddRange(BitConverter.GetBytes((int)0));
            bytes.AddRange(BitConverter.GetBytes((int)0));



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
        public TreeNode<CircleNode> readFlowBinary(string path, string toolVersionFull)
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
                return null;

            //need to handle read different versions later (if needed)
            //if (toolVersion != toolVersionFull)
            //    return false;


            counter = BitConverter.ToInt32(rawBytes, 0xB);

            if (counter == -1)
                return null;

            int nodeOffset = 0;
            int baseNodeOffset = 0xF;
            List<TreeNode<CircleNode>> nodeEntries = new List<TreeNode<CircleNode>>();
            
            //build node entries
            for (int i = 0; i < counter; i++)
            {
                int offsetCounter = 0;
                TreeNode<CircleNode> newNode = new TreeNode<CircleNode>(new CircleNode(), new BinaryData(), false);
           
                newNode.bd.parentIndex = BitConverter.ToInt32(rawBytes, baseNodeOffset + offsetCounter + nodeOffset);
                //MessageBox.Show(newNode.bd.parentIndex.ToString());
                offsetCounter += 4;
                newNode.bd.ID = BitConverter.ToInt32(rawBytes, baseNodeOffset + offsetCounter + nodeOffset);
                offsetCounter += 4;
                newNode.bd.RemoteChildIndex = BitConverter.ToInt32(rawBytes, baseNodeOffset + offsetCounter + nodeOffset);
                offsetCounter += 4;
                int stringCount = BitConverter.ToInt32(rawBytes, baseNodeOffset + offsetCounter + nodeOffset);
                offsetCounter += 4;

             
                //MessageBox.Show(newNode.bd.ID.ToString());
                //MessageBox.Show((baseNodeOffset + offsetCounter + nodeOffset).ToString());

                if (stringCount != 0)
                {
                   
                        newNode.bd.LayerName = Encoding.ASCII.GetString(rawBytes, baseNodeOffset + offsetCounter + nodeOffset, stringCount);
                   
                }
                
                offsetCounter += stringCount;
             
                //write bcm
                newNode.bd.bcmentry = ParseBcmEntry(rawBytes, baseNodeOffset + offsetCounter + nodeOffset);
                
                //MessageBox.Show(((Xv2CoreLib.BCM.ButtonInput)newNode.bd.bcmentry.I_08).ToString());
                offsetCounter += 112;

                
                nodeEntries.Add(newNode);
            
                nodeOffset += offsetCounter;
            }

            //resolve tree
           
            for (int i = 0; i < nodeEntries.Count; i++)
            {
                if (nodeEntries[i].bd.parentIndex != -1)
                {

              

                    //MessageBox.Show(nodeEntries[i].bd.LayerName);
                    //MessageBox.Show(nodeEntries[i].bd.parentIndex.ToString());
           

                    nodeEntries[nodeEntries[i].bd.parentIndex].AddChild(nodeEntries[i]);
                    nodeEntries[nodeEntries[i].bd.parentIndex].isCollpased = true;
                }

                if (nodeEntries[i].bd.RemoteChildIndex != -1)
                {
                    TreeNode<CircleNode> newNode = new TreeNode<CircleNode>(new CircleNode(), new BinaryData(), false);
                    //newNode.bd.bcmentry = nodeEntries[i].bd.bcmentry.Clone();
                    //newNode.bd.LayerName = nodeEntries[i].bd.LayerName;

                    newNode.bd.isRemoteChild = true;
                    newNode.bd.RemoteChildParentRef = nodeEntries[i];
                    newNode.bd.RemoteChildPointToRef = nodeEntries[nodeEntries[i].bd.RemoteChildIndex];
                    newNode.isCollpased = false;

                    nodeEntries[i].AddChild(newNode);
                    nodeEntries[i].isCollpased = true;


                }
            }



            //end

      

            for (int i = 0; i < nodeEntries[0].Children.Count; i++)
                nodeEntries[0].Children[i].bd.isLayerRoot = true;
            


            if (nodeEntries.Count > 0)
                return nodeEntries[0];
            else
                return null;

        }
        public string getToolVersion(short toolVersionMajor, short toolVersionMinor, short toolVersionSub)
        {
            return $"{toolVersionMajor}.{toolVersionMinor}.{toolVersionSub}";
        }

        private BCM_Entry ParseBcmEntry(byte[] rawBytes ,int offset)
        {
           // totalTestCount++;

            BCM_Entry bcmEntry = new BCM_Entry()
            {
                
                I_00 = BitConverter.ToUInt32(rawBytes, offset + 0),
                I_04 = BitConverter.ToUInt32(rawBytes, offset + 4),
                I_08 = BitConverter.ToUInt32(rawBytes, offset + 8),
                I_12 = BitConverter.ToUInt32(rawBytes, offset + 12),
                I_16 = BitConverter.ToUInt32(rawBytes, offset + 16),
                I_20 = BitConverter.ToUInt16(rawBytes, offset + 20),
                I_22 = BitConverter.ToUInt16(rawBytes, offset + 22),
                I_24 = BitConverter.ToUInt32(rawBytes, offset + 24),
                I_28 = (ActivatorState)BitConverter.ToUInt32(rawBytes, offset + 28),
                I_32 = BitConverter.ToInt16(rawBytes, offset + 32),
                I_34 = BitConverter.ToInt16(rawBytes, offset + 34),
                I_36 = BitConverter.ToInt16(rawBytes, offset + 36),
                I_38 = BitConverter.ToInt16(rawBytes, offset + 38),
                I_40 = BitConverter.ToInt16(rawBytes, offset + 40),
                I_42 = BitConverter.ToInt16(rawBytes, offset + 42),
                I_44 = BitConverter.ToUInt16(rawBytes, offset + 44),
                I_46 = BitConverter.ToUInt16(rawBytes, offset + 46),
                I_48 = BitConverter.ToUInt32(rawBytes, offset + 48),
                I_52 = BitConverter.ToUInt32(rawBytes, offset + 52),
                I_56 = BitConverter.ToUInt32(rawBytes, offset + 56),
                I_60 = BitConverter.ToUInt32(rawBytes, offset + 60),
                I_64 = BitConverter.ToUInt32(rawBytes, offset + 64),
                I_68 = BitConverter.ToUInt32(rawBytes, offset + 68),
                I_72 = BitConverter.ToUInt32(rawBytes, offset + 72),
                I_76 = (BacCases)BitConverter.ToUInt32(rawBytes, offset + 76),
                I_80 = BitConverter.ToUInt32(rawBytes, offset + 80),
                I_84 = BitConverter.ToUInt32(rawBytes, offset + 84),
                I_88 = BitConverter.ToUInt32(rawBytes, offset + 88),
                I_92 = BitConverter.ToUInt32(rawBytes, offset + 92),
                F_96 = BitConverter.ToSingle(rawBytes, offset + 96),
                I_100 = BitConverter.ToInt16(rawBytes, offset + 100),
                I_102 = BitConverter.ToInt16(rawBytes, offset + 102),
                I_104 = BitConverter.ToUInt32(rawBytes, offset + 104),
                I_108 = BitConverter.ToUInt32(rawBytes, offset + 108),

            };

   

            return bcmEntry;
        }


        #endregion
    }
}
