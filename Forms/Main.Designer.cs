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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.lblNodeText = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ctxNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxNodeAddChild = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxNodeDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteSingleLinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteRemoteLinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collapseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showChildLinkInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readFlowFileflowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFlowFileflowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bCMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decompileExistingBCMExpirementalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compileToBCMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decompileSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showIndicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unleashedTheCitadelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ComboPanel = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1.SuspendLayout();
            this.ctxNode.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNodeText
            // 
            this.lblNodeText.Name = "lblNodeText";
            this.lblNodeText.Size = new System.Drawing.Size(0, 0);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblNodeText});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 575);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1091, 5);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ctxNode
            // 
            this.ctxNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxNodeAddChild,
            this.modifyDataToolStripMenuItem,
            this.copyNodeToolStripMenuItem,
            this.ctxNodeDelete,
            this.pasteNodeToolStripMenuItem,
            this.pasteSingleLinkToolStripMenuItem,
            this.pasteRemoteLinkToolStripMenuItem,
            this.collapseToolStripMenuItem,
            this.showChildLinkInfoToolStripMenuItem});
            this.ctxNode.Name = "ctxNode";
            this.ctxNode.Size = new System.Drawing.Size(217, 224);
            this.ctxNode.Text = "ContextMenuNode";
            this.ctxNode.Opening += new System.ComponentModel.CancelEventHandler(this.ctxNode_Opening);
            // 
            // ctxNodeAddChild
            // 
            this.ctxNodeAddChild.Name = "ctxNodeAddChild";
            this.ctxNodeAddChild.Size = new System.Drawing.Size(216, 22);
            this.ctxNodeAddChild.Text = "&Add New Link (CTRL+A)";
            this.ctxNodeAddChild.Click += new System.EventHandler(this.ctxNodeAddChild_Click);
            // 
            // modifyDataToolStripMenuItem
            // 
            this.modifyDataToolStripMenuItem.Name = "modifyDataToolStripMenuItem";
            this.modifyDataToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.modifyDataToolStripMenuItem.Text = "Modifiy Node (CTRL+E)";
            this.modifyDataToolStripMenuItem.Click += new System.EventHandler(this.modifyDataToolStripMenuItem_Click);
            // 
            // copyNodeToolStripMenuItem
            // 
            this.copyNodeToolStripMenuItem.Name = "copyNodeToolStripMenuItem";
            this.copyNodeToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.copyNodeToolStripMenuItem.Text = "Copy Node (CTRL+C)";
            this.copyNodeToolStripMenuItem.Click += new System.EventHandler(this.copyNodeToolStripMenuItem_Click);
            // 
            // ctxNodeDelete
            // 
            this.ctxNodeDelete.Name = "ctxNodeDelete";
            this.ctxNodeDelete.Size = new System.Drawing.Size(216, 22);
            this.ctxNodeDelete.Text = "&Delete Node";
            this.ctxNodeDelete.Click += new System.EventHandler(this.ctxNodeDelete_Click);
            // 
            // pasteNodeToolStripMenuItem
            // 
            this.pasteNodeToolStripMenuItem.Name = "pasteNodeToolStripMenuItem";
            this.pasteNodeToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.pasteNodeToolStripMenuItem.Text = "Paste With Follow up Links";
            this.pasteNodeToolStripMenuItem.Click += new System.EventHandler(this.pasteNodeToolStripMenuItem_Click);
            // 
            // pasteSingleLinkToolStripMenuItem
            // 
            this.pasteSingleLinkToolStripMenuItem.Name = "pasteSingleLinkToolStripMenuItem";
            this.pasteSingleLinkToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.pasteSingleLinkToolStripMenuItem.Text = "Paste Single Link (CTRL+V)";
            this.pasteSingleLinkToolStripMenuItem.Click += new System.EventHandler(this.pasteSingleLinkToolStripMenuItem_Click);
            // 
            // pasteRemoteLinkToolStripMenuItem
            // 
            this.pasteRemoteLinkToolStripMenuItem.Name = "pasteRemoteLinkToolStripMenuItem";
            this.pasteRemoteLinkToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.pasteRemoteLinkToolStripMenuItem.Text = "Paste Remote Link";
            this.pasteRemoteLinkToolStripMenuItem.Click += new System.EventHandler(this.pasteRemoteLinkToolStripMenuItem_Click);
            // 
            // collapseToolStripMenuItem
            // 
            this.collapseToolStripMenuItem.Name = "collapseToolStripMenuItem";
            this.collapseToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.collapseToolStripMenuItem.Text = "Collapse";
            this.collapseToolStripMenuItem.Click += new System.EventHandler(this.collapseToolStripMenuItem_Click);
            // 
            // showChildLinkInfoToolStripMenuItem
            // 
            this.showChildLinkInfoToolStripMenuItem.Name = "showChildLinkInfoToolStripMenuItem";
            this.showChildLinkInfoToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.showChildLinkInfoToolStripMenuItem.Text = "Show Full Info (CTRL + F)";
            this.showChildLinkInfoToolStripMenuItem.Click += new System.EventHandler(this.showChildLinkInfoToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.bCMToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.unleashedTheCitadelToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1091, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.readFlowFileflowToolStripMenuItem,
            this.saveFlowFileflowToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.fileToolStripMenuItem.Text = "Application";
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.newProjectToolStripMenuItem.Text = "New Project";
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
            // 
            // readFlowFileflowToolStripMenuItem
            // 
            this.readFlowFileflowToolStripMenuItem.Name = "readFlowFileflowToolStripMenuItem";
            this.readFlowFileflowToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.readFlowFileflowToolStripMenuItem.Text = "Open Flow Project (.flp)";
            this.readFlowFileflowToolStripMenuItem.Click += new System.EventHandler(this.readFlowFileflowToolStripMenuItem_Click_1);
            // 
            // saveFlowFileflowToolStripMenuItem
            // 
            this.saveFlowFileflowToolStripMenuItem.Name = "saveFlowFileflowToolStripMenuItem";
            this.saveFlowFileflowToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.saveFlowFileflowToolStripMenuItem.Text = "Save Flow Project (.flp)";
            this.saveFlowFileflowToolStripMenuItem.Click += new System.EventHandler(this.saveFlowFileflowToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // bCMToolStripMenuItem
            // 
            this.bCMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.decompileExistingBCMExpirementalToolStripMenuItem,
            this.compileToBCMToolStripMenuItem,
            this.decompileSettingsToolStripMenuItem});
            this.bCMToolStripMenuItem.Name = "bCMToolStripMenuItem";
            this.bCMToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.bCMToolStripMenuItem.Text = "BCM";
            // 
            // decompileExistingBCMExpirementalToolStripMenuItem
            // 
            this.decompileExistingBCMExpirementalToolStripMenuItem.Name = "decompileExistingBCMExpirementalToolStripMenuItem";
            this.decompileExistingBCMExpirementalToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.decompileExistingBCMExpirementalToolStripMenuItem.Text = "Decompile Existing (.BCM)";
            this.decompileExistingBCMExpirementalToolStripMenuItem.Click += new System.EventHandler(this.decompileExistingBCMExpirementalToolStripMenuItem_Click);
            // 
            // compileToBCMToolStripMenuItem
            // 
            this.compileToBCMToolStripMenuItem.Name = "compileToBCMToolStripMenuItem";
            this.compileToBCMToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.compileToBCMToolStripMenuItem.Text = "Compile to (.BCM)";
            this.compileToBCMToolStripMenuItem.Click += new System.EventHandler(this.compileToBCMToolStripMenuItem_Click);
            // 
            // decompileSettingsToolStripMenuItem
            // 
            this.decompileSettingsToolStripMenuItem.Name = "decompileSettingsToolStripMenuItem";
            this.decompileSettingsToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.decompileSettingsToolStripMenuItem.Text = "Decompile Settings";
            this.decompileSettingsToolStripMenuItem.Click += new System.EventHandler(this.decompileSettingsToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showIndicesToolStripMenuItem,
            this.gridToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // showIndicesToolStripMenuItem
            // 
            this.showIndicesToolStripMenuItem.Name = "showIndicesToolStripMenuItem";
            this.showIndicesToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.showIndicesToolStripMenuItem.Text = "Show Absolute Index";
            this.showIndicesToolStripMenuItem.Visible = false;
            this.showIndicesToolStripMenuItem.Click += new System.EventHandler(this.showIndicesToolStripMenuItem_Click);
            // 
            // gridToolStripMenuItem
            // 
            this.gridToolStripMenuItem.Checked = true;
            this.gridToolStripMenuItem.CheckOnClick = true;
            this.gridToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gridToolStripMenuItem.Name = "gridToolStripMenuItem";
            this.gridToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.gridToolStripMenuItem.Text = "Grid Lines";
            this.gridToolStripMenuItem.Click += new System.EventHandler(this.gridToolStripMenuItem_Click);
            // 
            // unleashedTheCitadelToolStripMenuItem
            // 
            this.unleashedTheCitadelToolStripMenuItem.Name = "unleashedTheCitadelToolStripMenuItem";
            this.unleashedTheCitadelToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.unleashedTheCitadelToolStripMenuItem.Text = "Legend";
            this.unleashedTheCitadelToolStripMenuItem.Visible = false;
            this.unleashedTheCitadelToolStripMenuItem.Click += new System.EventHandler(this.unleashedTheCitadelToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "BCM files|*.bcm";
            this.openFileDialog1.Title = "Decompile BCM";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "BCM files|*.bcm";
            this.saveFileDialog1.Title = "Compile BCM";
            // 
            // ComboPanel
            // 
            this.ComboPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboPanel.AutoScroll = true;
            this.ComboPanel.BackColor = System.Drawing.SystemColors.Control;
            this.ComboPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ComboPanel.Location = new System.Drawing.Point(3, 3);
            this.ComboPanel.Name = "ComboPanel";
            this.ComboPanel.Size = new System.Drawing.Size(761, 516);
            this.ComboPanel.TabIndex = 8;
            this.ComboPanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ComboPanel_Scroll);
            this.ComboPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ComboPanel_Paint);
            this.ComboPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ComboPanel_MouseDown);
            this.ComboPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ComboPanel_MouseMove);
            this.ComboPanel.Resize += new System.EventHandler(this.ComboPanel_Resize);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.Location = new System.Drawing.Point(8, 3);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(210, 516);
            this.listView1.TabIndex = 14;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackgroundImage = global::Flow.Properties.Resources.maximize;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(1046, 473);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(41, 35);
            this.button4.TabIndex = 15;
            this.toolTip1.SetToolTip(this.button4, "Enlarge Grid");
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.BackgroundImage = global::Flow.Properties.Resources.minimize;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.button5.Location = new System.Drawing.Point(1046, 514);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(41, 35);
            this.button5.TabIndex = 16;
            this.toolTip1.SetToolTip(this.button5, "Shrink Grid");
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.BackgroundImage = global::Flow.Properties.Resources.zoom_in;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(1045, 27);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(41, 37);
            this.button6.TabIndex = 17;
            this.toolTip1.SetToolTip(this.button6, "Zoom in");
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.BackgroundImage = global::Flow.Properties.Resources.magnifying_glass;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(1045, 70);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(41, 37);
            this.button7.TabIndex = 18;
            this.toolTip1.SetToolTip(this.button7, "Zoom out");
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button9
            // 
            this.button9.BackgroundImage = global::Flow.Properties.Resources.down;
            this.button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button9.Font = new System.Drawing.Font("Microsoft PhagsPa", 15.75F);
            this.button9.Location = new System.Drawing.Point(6, 243);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(38, 37);
            this.button9.TabIndex = 21;
            this.toolTip1.SetToolTip(this.button9, "Move Selected Layer Down");
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.BackgroundImage = global::Flow.Properties.Resources.up;
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button8.Font = new System.Drawing.Font("Microsoft PhagsPa", 15.75F);
            this.button8.Location = new System.Drawing.Point(6, 200);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(38, 37);
            this.button8.TabIndex = 20;
            this.toolTip1.SetToolTip(this.button8, "Move Selected Layer Up");
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::Flow.Properties.Resources.pen;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Font = new System.Drawing.Font("Microsoft PhagsPa", 15.75F);
            this.button3.Location = new System.Drawing.Point(6, 75);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(38, 37);
            this.button3.TabIndex = 12;
            this.toolTip1.SetToolTip(this.button3, "Rename Selected Layer");
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::Flow.Properties.Resources.delete;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Font = new System.Drawing.Font("Microsoft PhagsPa", 15.75F);
            this.button2.Location = new System.Drawing.Point(6, 118);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(38, 37);
            this.button2.TabIndex = 11;
            this.toolTip1.SetToolTip(this.button2, "Delete Selected Layer");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Flow.Properties.Resources.plus;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("Microsoft PhagsPa", 15.75F);
            this.button1.Location = new System.Drawing.Point(6, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(38, 37);
            this.button1.TabIndex = 10;
            this.toolTip1.SetToolTip(this.button1, "Add New Layer");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(47, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ComboPanel);
            this.splitContainer1.Size = new System.Drawing.Size(995, 522);
            this.splitContainer1.SplitterDistance = 221;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 19;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.Filter = "Flow Project files|*.flp";
            this.openFileDialog2.Title = "Open Flow Project";
            // 
            // saveFileDialog2
            // 
            this.saveFileDialog2.Filter = "Flow Project files|*.flp";
            this.saveFileDialog2.Title = "Save Flow Project";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1091, 580);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1056, 619);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flow";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ctxNode.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showIndicesToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripMenuItem readFlowFileflowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFlowFileflowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bCMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compileToBCMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decompileExistingBCMExpirementalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteRemoteLinkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showChildLinkInfoToolStripMenuItem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ToolStripMenuItem pasteSingleLinkToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem decompileSettingsToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
    }
}

