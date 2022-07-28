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
        public uint primarybuttininput = 0x0;



        //constroctor props
        TreeNode<CircleNode> treeNodeRef;


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

         
            primarybuttininput = Convert.ToUInt32(binary0, 2);
         

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

            //init flags and data

            //////////////////////////////////////
            //PrimaryButtonInputFlag
            //////////////////////////////////////


                                                             // 0      1           1        0       1             1           1         1
                                                             //       step         block           jump        kiblast     heavy      light
            PrimaryButtonInputFlag.AddRange(new List<CheckBox>{ null ,checkBox6, checkBox7, null, checkBox26, checkBox5, checkBox4,checkBox3});




        
            if (treeNodeRef != null)
            {
                uint value0 = treeNodeRef.bd.bcmentry.I_08;
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
