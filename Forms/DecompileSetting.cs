using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flow.Forms
{
    public partial class DecompileSetting : Form
    {
      public   int compressionType;
      public   bool removeTransformations;
        private Main mainref;
        public DecompileSetting(Main m)
        {
            mainref = m;
            InitializeComponent();
        }

        private void DecompileSetting_Load(object sender, EventArgs e)
        {
            switch (mainref.compressionType)
            {
                case 1: radioButton1.Checked = true; break;
                case 2: radioButton2.Checked = true; break;
                case 3: radioButton3.Checked = true; break;

            }

            checkBox1.Checked = mainref.removeTransformation;
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                compressionType = 1;
            else if (radioButton2.Checked)
                compressionType = 2;
            else if (radioButton3.Checked)
                compressionType = 3;

            removeTransformations = checkBox1.Checked;
        }
    }
}
