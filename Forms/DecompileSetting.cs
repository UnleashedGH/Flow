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
        public DecompileSetting()
        {
            InitializeComponent();
        }

        private void DecompileSetting_Load(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
        }
    }
}
