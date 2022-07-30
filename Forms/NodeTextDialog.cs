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
        List<CheckBox> DirectionalInputFlag = new List<CheckBox>();
        List<CheckBox> HoldDownConditionsFlag = new List<CheckBox>();



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


            string s0 = Convert.ToString(bcmEntry.I_08, 2).PadLeft(PrimaryButtonInputFlag.Count, '0');
            StringBuilder binary0 = new StringBuilder(s0);
     


            for (int i = 0; i < PrimaryButtonInputFlag.Count; i++)
            {
                if (PrimaryButtonInputFlag[i] == null)
                    continue;

                else if (PrimaryButtonInputFlag[i].Checked == false)
                    binary0[i] = '0';

               else if (PrimaryButtonInputFlag[i].Checked == true)
                    binary0[i] = '1';
            }

       
            bcmEntry.I_08 = Convert.ToUInt32(binary0.ToString(), 2);
      


            /////////////////////////////
            //DirectionalInputFlag
            /////////////////////////////


            string s1 = Convert.ToString(bcmEntry.I_04, 2).PadLeft(DirectionalInputFlag.Count, '0');
            StringBuilder binary1 = new StringBuilder(s1);



            for (int i = 0; i < DirectionalInputFlag.Count; i++)
            {
                if (DirectionalInputFlag[i] == null)
                    continue;

                else if (DirectionalInputFlag[i].Checked == false)
                    binary1[i] = '0';

                else if (DirectionalInputFlag[i].Checked == true)
                    binary1[i] = '1';
            }


            bcmEntry.I_04 = Convert.ToUInt32(binary1.ToString(), 2);

            /////////////////////////////
            //HoldDownConditionsFlag
            /////////////////////////////

            string s2 = Convert.ToString(bcmEntry.I_12, 2).PadLeft(HoldDownConditionsFlag.Count, '0');
            StringBuilder binary2 = new StringBuilder(s2);



            for (int i = 0; i < HoldDownConditionsFlag.Count; i++)
            {
                if (HoldDownConditionsFlag[i] == null)
                    continue;

                else if (HoldDownConditionsFlag[i].Checked == false)
                    binary2[i] = '0';

                else if (HoldDownConditionsFlag[i].Checked == true)
                    binary2[i] = '1';
            }


            bcmEntry.I_12 = Convert.ToUInt32(binary2.ToString(), 2);


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
                                                                                                
            PrimaryButtonInputFlag.AddRange(new List<CheckBox> {null,null,null,null,     null,null,null,null,                  null, checkBox6, checkBox7,null,                    checkBox26, checkBox5, checkBox4, checkBox3 });
            DirectionalInputFlag.AddRange(new List<CheckBox> { null, null, null, null,    null, null, null, checkBox14,     checkBox13, checkBox10, checkBox11, checkBox12,        checkBox16, checkBox15, checkBox8, checkBox9 });
            DirectionalInputFlag.AddRange(new List<CheckBox> { null, null, checkBox36, null,     null, null, null, null,               null, null, null, null,           null, checkBox34, null, null });



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


                ///////////////////////////////
                //DirectionalInputFlag
                ///////////////////////////////

                uint value1 = bcmEntry.I_04;
                //thepadding is based of how many bits in the checkbox array, it should be the original full size to maintain
                string binary1 = Convert.ToString(value1, 2).PadLeft(DirectionalInputFlag.Count, '0');
                for (int i = 0; i < DirectionalInputFlag.Count; i++)
                    if (DirectionalInputFlag[i] != null)
                        DirectionalInputFlag[i].Checked = (binary1[i] == '1') ? true : false;

                ///////////////////////////////
                //HoldDownConditionsFlag
                ///////////////////////////////

                uint value2 = bcmEntry.I_12;
                //thepadding is based of how many bits in the checkbox array, it should be the original full size to maintain
                string binary2 = Convert.ToString(value2, 2).PadLeft(HoldDownConditionsFlag.Count, '0');
                for (int i = 0; i < HoldDownConditionsFlag.Count; i++)
                    if (HoldDownConditionsFlag[i] != null)
                        HoldDownConditionsFlag[i].Checked = (binary2[i] == '1') ? true : false;

            }


            ///////////////////////////////

            //vars

            



        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
  
 }
