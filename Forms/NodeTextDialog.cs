using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Flow.Graph;

// Note: At design time, I set Modifiers = Public for the
// textbox so the main program can read its value.
namespace Flow.Forms
{
   
    public partial class NodeTextDialog : Form
    {

        //create list of checkboxes and loop through them
        List<CheckBox> PrimaryButtonInputFlag = new List<CheckBox>();



        //public outputs
       



        //constroctor props
        TreeNode<CircleNode> treeNodeRef;
       public Xv2CoreLib.BCM.BCM_Entry bcmEntry;


        public NodeTextDialog(TreeNode<CircleNode> tnr = null)
        {
            treeNodeRef = tnr;
            InitializeComponent();
        }


        // Replace Show so the program cannot use it.
        private new void Show()
        {
            throw new InvalidOperationException(
                "Use ShowDialog not Show to display this dialog");
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            //save flags and data

            /////////////////////////////
            //PrimaryButtonInputFlag
            /////////////////////////////
            //we prob shouldn't start the bit array from the start, but rather modifiy an existing one so we can keep unknown values
            //and not break a decompiled moveset.
            string binary0 = "";

            for (int i = 0; i < PrimaryButtonInputFlag.Count; i++)
            {
                if (PrimaryButtonInputFlag[i] == null)
                    binary0 += '0';

               else if (PrimaryButtonInputFlag[i].Checked == false)
                    binary0 += '0';

               else if (PrimaryButtonInputFlag[i].Checked == true)
                    binary0 += '1';
            }


            bcmEntry.I_08 = Convert.ToUInt32(binary0, 2);
         

            /////////////////////////////

        }

        private void NodeTextDialog_Load(object sender, EventArgs e)
        {
            //panel props
            ScrollContainer.AutoScroll = false;
            ScrollContainer.HorizontalScroll.Enabled = false;
            ScrollContainer.HorizontalScroll.Visible = false;
            ScrollContainer.HorizontalScroll.Maximum = 0;
            ScrollContainer.AutoScroll = true;

            //numberic up downs props

            numericUpDown1.Maximum = Int32.MaxValue;

            //init bcmentry
            bool canReadFromEntry = false;
            bcmEntry = new Xv2CoreLib.BCM.BCM_Entry();
            if (treeNodeRef != null)
            {
                if (treeNodeRef.bd.bcmentry != null)
                {
                    canReadFromEntry = true;
                    bcmEntry = treeNodeRef.bd.bcmentry.Clone();
                }
            }


            //init checkbox bit arrays
            //extend till all possible bit arrays
                                                     //           0      1           1        0       1             1           1         1
                                                     //                  step         block           jump        kiblast     heavy      light
            PrimaryButtonInputFlag.AddRange(new List<CheckBox> { null, checkBox6, checkBox7, null, checkBox26, checkBox5, checkBox4, checkBox3 });



            //init flags and data

        
            if (canReadFromEntry == true)
            {

                ///////////////////////////////
                //PrimaryButtonInputFlag
                ///////////////////////////////

                uint value0 = bcmEntry.I_08;
                //thepadding is based of how many bits in the checkbox array, it should be the original full size to maintain
                string binary0 = Convert.ToString(value0, 2).PadLeft(PrimaryButtonInputFlag.Count, '0');
                for (int i = 0; i < PrimaryButtonInputFlag.Count; i++)
                if (PrimaryButtonInputFlag[i] != null)
                        PrimaryButtonInputFlag[i].Checked = (binary0[i] == '1') ? true : false;
                
            }
        

            ///////////////////////////////




        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
  
 }
