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
    
        }

        private void NodeTextDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
