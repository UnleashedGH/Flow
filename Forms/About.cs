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
    public partial class About : Form
    {
        string version = "0.0.0";
        public About(string tv)
        {
            if (tv.Length > 0)
                version = tv;
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            label1.Text = $"Flow ({version}) by Unleashed";
        }
    }
}
