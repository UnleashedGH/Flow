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
        //create list of checkboxes and loop through them

        List<CheckBox> btnInputflags = new List<CheckBox>();



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
          



        }

        private void NodeTextDialog_Load(object sender, EventArgs e)
        {
            ScrollContainer.AutoScroll = false;
            ScrollContainer.HorizontalScroll.Enabled = false;
            ScrollContainer.HorizontalScroll.Visible = false;
            ScrollContainer.HorizontalScroll.Maximum = 0;
            ScrollContainer.AutoScroll = true;

            numericUpDown1.Maximum = Int32.MaxValue;
        }

    }
  
 }
