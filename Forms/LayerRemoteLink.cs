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
    public partial class LayerRemoteLink : Form
    {
        Main mainref = null;
        public LayerRemoteLink(Main _mainref)
        {
            mainref = _mainref;
            InitializeComponent();
        }

        private new void Show()
        {
            throw new InvalidOperationException(
                "Use ShowDialog not Show to display this dialog");
        }

        private void LayerRemoteLink_Load(object sender, EventArgs e)
        {
           for (int i = 0; i < mainref.root.Children.Count; i++)
            {
                listBox1.Items.Add(mainref.root.Children[i].bd.LayerName);
            }
        }
    }
}
