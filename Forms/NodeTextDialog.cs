using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Note: At design time, I set Modifiers = Public for the
// textbox so the main program can read its value.
namespace Flow.Forms
{
   
    public partial class NodeTextDialog : Form
    {

        public string btnInput = "L";

        List<CheckBox> btnflags = new List<CheckBox>();

        StringBuilder ButtonInputBinary = new StringBuilder("00000000");
        public NodeTextDialog()
        {
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
            if (radioButton1.Checked)
                btnInput = "L";
            if (radioButton2.Checked)
                btnInput = "H";
            if (radioButton3.Checked)
                btnInput = "K";

            /////////button input///////
            //light
            if (checkBox3.Checked)
                ButtonInputBinary[7] = '1';
            else
                ButtonInputBinary[7] = '0';

            //heavy
            if (checkBox4.Checked)
                ButtonInputBinary[6] = '1';
            else
                ButtonInputBinary[6] = '0';

            //KiBlast
            if (checkBox5.Checked)
                ButtonInputBinary[5] = '1';
            else
                ButtonInputBinary[5] = '0';

            //Jump
            if (checkBox26.Checked)
                ButtonInputBinary[4] = '1';
            else
                ButtonInputBinary[4] = '0';

            //Boost/Step
            if (checkBox7.Checked)
                ButtonInputBinary[2] = '1';
            else
                ButtonInputBinary[2] = '0';

            //Guard
            if (checkBox6.Checked)
                ButtonInputBinary[1] = '1';
            else
                ButtonInputBinary[1] = '0';

            MessageBox.Show(ButtonInputBinary.ToString());
            MessageBox.Show(btnflags[0].Checked.ToString ());




        }

        private void NodeTextDialog_Load(object sender, EventArgs e)
        {
            btnflags.Add(checkBox3);
        }
    }
  
 }
