﻿using System;
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
        List<CheckBox> PrimaryActivatorConditionsFlag = new List<CheckBox>();
        List<CheckBox> ActivatorStateFlag = new List<CheckBox>();




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
            //PrimaryActivatorConditionsFlag
            /////////////////////////////

            string s3 = Convert.ToString(bcmEntry.I_24, 2).PadLeft(PrimaryActivatorConditionsFlag.Count, '0');
            StringBuilder binary3 = new StringBuilder(s3);



            for (int i = 0; i < PrimaryActivatorConditionsFlag.Count; i++)
            {
                if (PrimaryActivatorConditionsFlag[i] == null)
                    continue;

                else if (PrimaryActivatorConditionsFlag[i].Checked == false)
                    binary3[i] = '0';

                else if (PrimaryActivatorConditionsFlag[i].Checked == true)
                    binary3[i] = '1';
            }


            bcmEntry.I_24 = Convert.ToUInt32(binary3.ToString(), 2);

            /////////////////////////////
            //ActivatorStateFlag
            /////////////////////////////

            string s4 = Convert.ToString(bcmEntry.I_28, 2).PadLeft(ActivatorStateFlag.Count, '0');
            StringBuilder binary4 = new StringBuilder(s4);



            for (int i = 0; i < ActivatorStateFlag.Count; i++)
            {
                if (ActivatorStateFlag[i] == null)
                    continue;

                else if (ActivatorStateFlag[i].Checked == false)
                    binary4[i] = '0';

                else if (ActivatorStateFlag[i].Checked == true)
                    binary4[i] = '1';
            }


            bcmEntry.I_28 = Convert.ToUInt32(binary4.ToString(), 2);


            /////////////////////////////

            //vars

            //target size conditons
            bcmEntry.I_16 = (uint)numericUpDown1.Value;
            //min loop condtions
            bcmEntry.I_20 = (ushort)numericUpDown2.Value;
            //max loop condtions
            bcmEntry.I_22 = (ushort)numericUpDown3.Value;



            bcmEntry.I_64 = (uint)numericUpDown16.Value;
            bcmEntry.I_84 = (uint)numericUpDown14.Value;
            bcmEntry.I_92 = (uint)numericUpDown11.Value;
            bcmEntry.F_96 = (float)numericUpDown10.Value;
            bcmEntry.I_76 = (uint)numericUpDown13.Value;
            bcmEntry.I_102 = (short)numericUpDown12.Value;
            bcmEntry.I_100 = (short)numericUpDown15.Value;


            //bac


            bcmEntry.I_32 = (short)numericUpDown5.Value;
            bcmEntry.I_34 = (short)numericUpDown4.Value;
            bcmEntry.I_42 = (short)numericUpDown9.Value;
            bcmEntry.I_44 = (ushort)numericUpDown8.Value;
            bcmEntry.I_38 = (short)numericUpDown7.Value;
            bcmEntry.I_40 = (short)numericUpDown6.Value;
        }

        private void NodeTextDialog_Load(object sender, EventArgs e)
        {

            //handle scrollwhell
            foreach (Control ctl in groupBox4.Controls)
                if (ctl.GetType() == typeof(NumericUpDown))
                    ctl.MouseWheel += Ctl_MouseWheel;


            foreach (Control ctl in groupBox11.Controls)
                if (ctl.GetType() == typeof(NumericUpDown))
                    ctl.MouseWheel += Ctl_MouseWheel;
      
            /////////////////////////////////////////
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
            HoldDownConditionsFlag.AddRange(new List<CheckBox> { null, null, checkBox36, null,     null, null, null, null,               null, null, null, null,           null, checkBox34, null, null });
            PrimaryActivatorConditionsFlag.AddRange(new List<CheckBox> { null, checkBox19, null, null,        null, null, checkBox32, null,        null, checkBox27, null, checkBox17,    checkBox28, null, null, null,     checkBox22, checkBox23, null, null,      null, null, null, checkBox1,    checkBox2, checkBox21, checkBox20, checkBox25,    checkBox18, null, checkBox29, checkBox30});
            HoldDownConditionsFlag.AddRange(new List<CheckBox> { null, null, null, null,     checkBox40, checkBox24, checkBox39, checkBox31,    checkBox38, checkBox37, checkBox35, checkBox33 });



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
             
                string binary1 = Convert.ToString(value1, 2).PadLeft(DirectionalInputFlag.Count, '0');
                for (int i = 0; i < DirectionalInputFlag.Count; i++)
                    if (DirectionalInputFlag[i] != null)
                        DirectionalInputFlag[i].Checked = (binary1[i] == '1') ? true : false;

                ///////////////////////////////
                //HoldDownConditionsFlag
                ///////////////////////////////

                uint value2 = bcmEntry.I_12;
            
                string binary2 = Convert.ToString(value2, 2).PadLeft(HoldDownConditionsFlag.Count, '0');
                for (int i = 0; i < HoldDownConditionsFlag.Count; i++)
                    if (HoldDownConditionsFlag[i] != null)
                        HoldDownConditionsFlag[i].Checked = (binary2[i] == '1') ? true : false;


                ///////////////////////////////
                //PrimaryActivatorConditionsFlag
                ///////////////////////////////

                uint value3 = bcmEntry.I_24;
             
                string binary3 = Convert.ToString(value3, 2).PadLeft(PrimaryActivatorConditionsFlag.Count, '0');
                for (int i = 0; i < PrimaryActivatorConditionsFlag.Count; i++)
                    if (PrimaryActivatorConditionsFlag[i] != null)
                        PrimaryActivatorConditionsFlag[i].Checked = (binary3[i] == '1') ? true : false;


                ///////////////////////////////
                //ActivatorStateFlag
                ///////////////////////////////

                uint value4 = bcmEntry.I_28;

                string binary4 = Convert.ToString(value4, 2).PadLeft(ActivatorStateFlag.Count, '0');
                for (int i = 0; i < ActivatorStateFlag.Count; i++)
                    if (ActivatorStateFlag[i] != null)
                        ActivatorStateFlag[i].Checked = (binary4[i] == '1') ? true : false;

            }


            ///////////////////////////////

            //vars

            //target size conditions
            numericUpDown1.Value = bcmEntry.I_16;
            //min loop condtions
            numericUpDown2.Value = bcmEntry.I_20;
            //max loop condtions
            numericUpDown3.Value = bcmEntry.I_22;




            numericUpDown16.Value = bcmEntry.I_64;
            numericUpDown14.Value = bcmEntry.I_84;
            numericUpDown11.Value = bcmEntry.I_92;
            numericUpDown10.Value = (decimal)bcmEntry.F_96;
            numericUpDown13.Value = bcmEntry.I_76;
            numericUpDown12.Value = bcmEntry.I_102;
            numericUpDown15.Value = bcmEntry.I_100;




            //bac
            numericUpDown5.Value = bcmEntry.I_32;
            numericUpDown4.Value = bcmEntry.I_34;
            numericUpDown9.Value = bcmEntry.I_42;
            numericUpDown8.Value = bcmEntry.I_44;
            numericUpDown7.Value = bcmEntry.I_38;
            numericUpDown6.Value = bcmEntry.I_40;









        }

        private void Ctl_MouseWheel(object sender, MouseEventArgs e)
        {
      
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Seperate conditions that be combined to make a new compund condition\nif the first 2 conditions are checked, it will read as 'An Attack has hit target AND the attack belongs to the current running BAC entry'.",
             "Complementary Conditions", MessageBoxButtons.OK,
             MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Seperate conditions that be combined to make a new compund condition\nif the first 2 conditions are checked, it will read as 'An Attack has hit target AND the attack belongs to the current running BAC entry'.",
         "Button Input", MessageBoxButtons.OK,
         MessageBoxIcon.Information);
        }
    }
  
 }
