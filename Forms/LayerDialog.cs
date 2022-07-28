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
    public partial class LayerDialog : Form
    {
        public string layerName = "New Layer";
        private string layernameref = "";
        public LayerDialog(string renameStr = "")
        {
            layernameref = renameStr;
            InitializeComponent();
        }

        private void LayerForm_Load(object sender, EventArgs e)
        {
            if (layernameref != "")
            {
                textBox1.Text = layernameref;
                this.Text = "Modify Layer Name";
            }
            else
            {
                this.Text = "Add New Layer";
                textBox1.Text = "New Layer";
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
             
                layerName = textBox1.Text;
            }
    
        }

        private void LayerDialog_Shown(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
    }
}
