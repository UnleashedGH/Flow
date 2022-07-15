namespace Flow.Forms
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblNodeText = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ctxNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxNodeAddChild = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxNodeDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.addRemoteLinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collapseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readFlowFileflowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFlowFileflowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compileMovesetBCMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showIndicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unleashedTheCitadelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ComboPanel = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.ctxNode.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNodeText
            // 
            this.lblNodeText.Name = "lblNodeText";
            this.lblNodeText.Size = new System.Drawing.Size(0, 17);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblNodeText});
            this.statusStrip1.Location = new System.Drawing.Point(0, 558);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1040, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ctxNode
            // 
            this.ctxNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxNodeAddChild,
            this.ctxNodeDelete,
            this.addRemoteLinkToolStripMenuItem,
            this.copyNodeToolStripMenuItem,
            this.pasteNodeToolStripMenuItem,
            this.collapseToolStripMenuItem});
            this.ctxNode.Name = "ctxNode";
            this.ctxNode.Size = new System.Drawing.Size(166, 136);
            this.ctxNode.Text = "ContextMenuNode";
            this.ctxNode.Opening += new System.ComponentModel.CancelEventHandler(this.ctxNode_Opening);
            // 
            // ctxNodeAddChild
            // 
            this.ctxNodeAddChild.Name = "ctxNodeAddChild";
            this.ctxNodeAddChild.Size = new System.Drawing.Size(165, 22);
            this.ctxNodeAddChild.Text = "&Add Child...";
            this.ctxNodeAddChild.Click += new System.EventHandler(this.ctxNodeAddChild_Click);
            // 
            // ctxNodeDelete
            // 
            this.ctxNodeDelete.Name = "ctxNodeDelete";
            this.ctxNodeDelete.Size = new System.Drawing.Size(165, 22);
            this.ctxNodeDelete.Text = "&Delete Node...";
            this.ctxNodeDelete.Click += new System.EventHandler(this.ctxNodeDelete_Click);
            // 
            // addRemoteLinkToolStripMenuItem
            // 
            this.addRemoteLinkToolStripMenuItem.Name = "addRemoteLinkToolStripMenuItem";
            this.addRemoteLinkToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.addRemoteLinkToolStripMenuItem.Text = "Add Remote Link";
            this.addRemoteLinkToolStripMenuItem.Click += new System.EventHandler(this.addRemoteLinkToolStripMenuItem_Click);
            // 
            // copyNodeToolStripMenuItem
            // 
            this.copyNodeToolStripMenuItem.Name = "copyNodeToolStripMenuItem";
            this.copyNodeToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.copyNodeToolStripMenuItem.Text = "Copy Node";
            this.copyNodeToolStripMenuItem.Click += new System.EventHandler(this.copyNodeToolStripMenuItem_Click);
            // 
            // pasteNodeToolStripMenuItem
            // 
            this.pasteNodeToolStripMenuItem.Name = "pasteNodeToolStripMenuItem";
            this.pasteNodeToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.pasteNodeToolStripMenuItem.Text = "Paste Node";
            this.pasteNodeToolStripMenuItem.Click += new System.EventHandler(this.pasteNodeToolStripMenuItem_Click);
            // 
            // collapseToolStripMenuItem
            // 
            this.collapseToolStripMenuItem.Name = "collapseToolStripMenuItem";
            this.collapseToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.collapseToolStripMenuItem.Text = "Collapse";
            this.collapseToolStripMenuItem.Click += new System.EventHandler(this.collapseToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.unleashedTheCitadelToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1040, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readFlowFileflowToolStripMenuItem,
            this.saveFlowFileflowToolStripMenuItem,
            this.compileMovesetBCMToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // readFlowFileflowToolStripMenuItem
            // 
            this.readFlowFileflowToolStripMenuItem.Name = "readFlowFileflowToolStripMenuItem";
            this.readFlowFileflowToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.readFlowFileflowToolStripMenuItem.Text = "Read Flow File (.flow)";
            // 
            // saveFlowFileflowToolStripMenuItem
            // 
            this.saveFlowFileflowToolStripMenuItem.Name = "saveFlowFileflowToolStripMenuItem";
            this.saveFlowFileflowToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.saveFlowFileflowToolStripMenuItem.Text = "Save Flow File (.flow)";
            this.saveFlowFileflowToolStripMenuItem.Click += new System.EventHandler(this.saveFlowFileflowToolStripMenuItem_Click);
            // 
            // compileMovesetBCMToolStripMenuItem
            // 
            this.compileMovesetBCMToolStripMenuItem.Name = "compileMovesetBCMToolStripMenuItem";
            this.compileMovesetBCMToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.compileMovesetBCMToolStripMenuItem.Text = "Compile Moveset to BCM File (.bcm)";
            this.compileMovesetBCMToolStripMenuItem.Click += new System.EventHandler(this.compileMovesetBCMToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showIndicesToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // showIndicesToolStripMenuItem
            // 
            this.showIndicesToolStripMenuItem.Name = "showIndicesToolStripMenuItem";
            this.showIndicesToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.showIndicesToolStripMenuItem.Text = "Show Indices";
            this.showIndicesToolStripMenuItem.Click += new System.EventHandler(this.showIndicesToolStripMenuItem_Click);
            // 
            // unleashedTheCitadelToolStripMenuItem
            // 
            this.unleashedTheCitadelToolStripMenuItem.Name = "unleashedTheCitadelToolStripMenuItem";
            this.unleashedTheCitadelToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.unleashedTheCitadelToolStripMenuItem.Text = "test";
            this.unleashedTheCitadelToolStripMenuItem.Click += new System.EventHandler(this.unleashedTheCitadelToolStripMenuItem_Click);
            // 
            // ComboPanel
            // 
            this.ComboPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboPanel.AutoScroll = true;
            this.ComboPanel.BackColor = System.Drawing.SystemColors.Control;
            this.ComboPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ComboPanel.Location = new System.Drawing.Point(278, 27);
            this.ComboPanel.Name = "ComboPanel";
            this.ComboPanel.Size = new System.Drawing.Size(750, 528);
            this.ComboPanel.TabIndex = 8;
            this.ComboPanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ComboPanel_Scroll);
            this.ComboPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ComboPanel_Paint);
            this.ComboPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ComboPanel_MouseDown);
            this.ComboPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ComboPanel_MouseMove);
            this.ComboPanel.Resize += new System.EventHandler(this.ComboPanel_Resize);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "BCM files|*.bcm";
            this.openFileDialog1.Title = "Open";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "BCM files|*.bcm";
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.Font = new System.Drawing.Font("Microsoft PhagsPa", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 27;
            this.listBox1.Location = new System.Drawing.Point(12, 140);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(260, 382);
            this.listBox1.TabIndex = 9;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft PhagsPa", 15.75F);
            this.button1.Location = new System.Drawing.Point(145, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 71);
            this.button1.TabIndex = 10;
            this.button1.Text = "ADD";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft PhagsPa", 15.75F);
            this.button2.Location = new System.Drawing.Point(12, 98);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 35);
            this.button2.TabIndex = 11;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft PhagsPa", 15.75F);
            this.button3.Location = new System.Drawing.Point(12, 62);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(127, 35);
            this.button3.TabIndex = 12;
            this.button3.Text = "Rename";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft PhagsPa", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 27);
            this.label1.TabIndex = 13;
            this.label1.Text = "Layers";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1040, 580);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.ComboPanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1056, 619);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flow: Pre-Alpha";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ctxNode.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripStatusLabel lblNodeText;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ContextMenuStrip ctxNode;
        private System.Windows.Forms.ToolStripMenuItem ctxNodeAddChild;
        private System.Windows.Forms.ToolStripMenuItem ctxNodeDelete;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unleashedTheCitadelToolStripMenuItem;
        private System.Windows.Forms.Panel ComboPanel;
        private System.Windows.Forms.ToolStripMenuItem copyNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collapseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compileMovesetBCMToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showIndicesToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripMenuItem readFlowFileflowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFlowFileflowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRemoteLinkToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}

