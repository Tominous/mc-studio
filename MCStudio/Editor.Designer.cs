namespace MCStudio
{
    partial class Editor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnSaveAll = new System.Windows.Forms.ToolStripButton();
            this.btnSaveAs = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.btnCloseAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUndo = new System.Windows.Forms.ToolStripButton();
            this.btnRedo = new System.Windows.Forms.ToolStripButton();
            this.btnCopy = new System.Windows.Forms.ToolStripButton();
            this.btnCut = new System.Windows.Forms.ToolStripButton();
            this.btnPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.btnReplace = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSwitch = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statLine = new System.Windows.Forms.ToolStripStatusLabel();
            this.statChar = new System.Windows.Forms.ToolStripStatusLabel();
            this.statLength = new System.Windows.Forms.ToolStripStatusLabel();
            this.statSelection = new System.Windows.Forms.ToolStripStatusLabel();
            this.statCopied = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabStrip = new FarsiLibrary.Win.FATabStrip();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.explorerTree = new System.Windows.Forms.TreeView();
            this.fsContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imagesFiles = new System.Windows.Forms.ImageList(this.components);
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.lstbRecents = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lstEffects = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.enchContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lstEnchantments = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imagesAutocomplete = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bwMCCheck = new System.ComponentModel.BackgroundWorker();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabStrip)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.fsContext.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.enchContext.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnOpen,
            this.btnSave,
            this.btnSaveAll,
            this.btnSaveAs,
            this.btnClose,
            this.btnCloseAll,
            this.toolStripSeparator1,
            this.btnUndo,
            this.btnRedo,
            this.btnCopy,
            this.btnCut,
            this.btnPaste,
            this.toolStripSeparator2,
            this.btnFind,
            this.btnReplace,
            this.toolStripSeparator3,
            this.btnSwitch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(915, 39);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNew
            // 
            this.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNew.Image = global::MCStudio.Properties.Resources.document_new;
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(36, 36);
            this.btnNew.Text = "New file (Ctrl+N)";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpen.Image = global::MCStudio.Properties.Resources.document_open;
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(36, 36);
            this.btnOpen.Text = "Open file (Ctrl+O)";
            this.btnOpen.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::MCStudio.Properties.Resources.document_save;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(36, 36);
            this.btnSave.Text = "Save (Ctrl+S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveAll.Image = global::MCStudio.Properties.Resources.document_save_all;
            this.btnSaveAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(36, 36);
            this.btnSaveAll.Text = "Save all (Ctrl+Shift+S)";
            this.btnSaveAll.Click += new System.EventHandler(this.btnSaveAll_Click);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveAs.Image = global::MCStudio.Properties.Resources.document_save_as;
            this.btnSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(36, 36);
            this.btnSaveAs.Text = "Save as...";
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // btnClose
            // 
            this.btnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClose.Image = global::MCStudio.Properties.Resources.document_close;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(36, 36);
            this.btnClose.Text = "Close (Ctrl+W)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCloseAll
            // 
            this.btnCloseAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCloseAll.Image = global::MCStudio.Properties.Resources.list_remove;
            this.btnCloseAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloseAll.Name = "btnCloseAll";
            this.btnCloseAll.Size = new System.Drawing.Size(36, 36);
            this.btnCloseAll.Text = "Close all (Ctrl+Shift+W)";
            this.btnCloseAll.Click += new System.EventHandler(this.btnCloseAll_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // btnUndo
            // 
            this.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUndo.Image = global::MCStudio.Properties.Resources.edit_undo;
            this.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(36, 36);
            this.btnUndo.Text = "Undo (Ctrl+Z)";
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRedo.Image = global::MCStudio.Properties.Resources.edit_redo;
            this.btnRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(36, 36);
            this.btnRedo.Text = "Redo (Ctrl+Y)";
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCopy.Image = global::MCStudio.Properties.Resources.edit_copy;
            this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(36, 36);
            this.btnCopy.Text = "Copy (Ctrl+C)";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnCut
            // 
            this.btnCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCut.Image = global::MCStudio.Properties.Resources.edit_cut;
            this.btnCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCut.Name = "btnCut";
            this.btnCut.Size = new System.Drawing.Size(36, 36);
            this.btnCut.Text = "Cut (Ctrl+X)";
            this.btnCut.Click += new System.EventHandler(this.btnCut_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPaste.Image = global::MCStudio.Properties.Resources.edit_paste;
            this.btnPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(36, 36);
            this.btnPaste.Text = "Paste (Ctrl+V)";
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // btnFind
            // 
            this.btnFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFind.Image = global::MCStudio.Properties.Resources.edit_find;
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(36, 36);
            this.btnFind.Text = "Find (Ctrl+F)";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnReplace
            // 
            this.btnReplace.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReplace.Image = global::MCStudio.Properties.Resources.edit_find_replace;
            this.btnReplace.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(36, 36);
            this.btnReplace.Text = "Replace (Ctrl+H)";
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // btnSwitch
            // 
            this.btnSwitch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSwitch.Enabled = false;
            this.btnSwitch.Image = global::MCStudio.Properties.Resources._153851527699705625;
            this.btnSwitch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(36, 36);
            this.btnSwitch.Text = "Switch to Minecraft (F6)";
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statLine,
            this.statChar,
            this.statLength,
            this.statSelection,
            this.statCopied});
            this.statusStrip1.Location = new System.Drawing.Point(0, 467);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(915, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statLine
            // 
            this.statLine.Name = "statLine";
            this.statLine.Size = new System.Drawing.Size(41, 17);
            this.statLine.Text = "Line: 0";
            // 
            // statChar
            // 
            this.statChar.Name = "statChar";
            this.statChar.Size = new System.Drawing.Size(70, 17);
            this.statChar.Text = "Character: 0";
            // 
            // statLength
            // 
            this.statLength.Name = "statLength";
            this.statLength.Size = new System.Drawing.Size(56, 17);
            this.statLength.Text = "Length: 0";
            // 
            // statSelection
            // 
            this.statSelection.Name = "statSelection";
            this.statSelection.Size = new System.Drawing.Size(82, 17);
            this.statSelection.Text = "Selection: 0 | 0";
            // 
            // statCopied
            // 
            this.statCopied.Name = "statCopied";
            this.statCopied.Size = new System.Drawing.Size(115, 17);
            this.statCopied.Text = "Copied to clipboard!";
            this.statCopied.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 39);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabStrip);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(915, 428);
            this.splitContainer1.SplitterDistance = 573;
            this.splitContainer1.TabIndex = 2;
            // 
            // tabStrip
            // 
            this.tabStrip.AllowDrop = true;
            this.tabStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabStrip.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tabStrip.Location = new System.Drawing.Point(0, 0);
            this.tabStrip.Name = "tabStrip";
            this.tabStrip.Size = new System.Drawing.Size(573, 428);
            this.tabStrip.TabIndex = 0;
            this.tabStrip.Text = "faTabStrip1";
            this.tabStrip.TabStripItemClosing += new FarsiLibrary.Win.TabStripItemClosingHandler(this.tabStrip_TabStripItemClosing);
            this.tabStrip.TabStripItemSelectionChanged += new FarsiLibrary.Win.TabStripItemChangedHandler(this.tabStrip_TabStripItemSelectionChanged);
            this.tabStrip.TabStripItemClosed += new System.EventHandler(this.tabStrip_TabStripItemClosed);
            this.tabStrip.DragDrop += new System.Windows.Forms.DragEventHandler(this.tabStrip_DragDrop);
            this.tabStrip.DragEnter += new System.Windows.Forms.DragEventHandler(this.tabStrip_DragEnter);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(338, 428);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseDoubleClick);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.explorerTree);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(330, 402);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "File Manager";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // explorerTree
            // 
            this.explorerTree.ContextMenuStrip = this.fsContext;
            this.explorerTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.explorerTree.ImageIndex = 0;
            this.explorerTree.ImageList = this.imagesFiles;
            this.explorerTree.Location = new System.Drawing.Point(3, 3);
            this.explorerTree.Name = "explorerTree";
            this.explorerTree.SelectedImageIndex = 0;
            this.explorerTree.Size = new System.Drawing.Size(324, 396);
            this.explorerTree.TabIndex = 0;
            this.explorerTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.explorerTree_NodeMouseDoubleClick);
            // 
            // fsContext
            // 
            this.fsContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.newDirectoryToolStripMenuItem,
            this.toolStripMenuItem1,
            this.refreshToolStripMenuItem});
            this.fsContext.Name = "fsContext";
            this.fsContext.Size = new System.Drawing.Size(149, 76);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // newDirectoryToolStripMenuItem
            // 
            this.newDirectoryToolStripMenuItem.Name = "newDirectoryToolStripMenuItem";
            this.newDirectoryToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.newDirectoryToolStripMenuItem.Text = "New directory";
            this.newDirectoryToolStripMenuItem.Click += new System.EventHandler(this.newDirectoryToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(145, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // imagesFiles
            // 
            this.imagesFiles.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagesFiles.ImageStream")));
            this.imagesFiles.TransparentColor = System.Drawing.Color.Transparent;
            this.imagesFiles.Images.SetKeyName(0, "drive-harddisk.png");
            this.imagesFiles.Images.SetKeyName(1, "drive-optical.png");
            this.imagesFiles.Images.SetKeyName(2, "drive-removable-media-usb.png");
            this.imagesFiles.Images.SetKeyName(3, "folder.png");
            this.imagesFiles.Images.SetKeyName(4, "application-xml.png");
            this.imagesFiles.Images.SetKeyName(5, "application-x-shellscript.png");
            this.imagesFiles.Images.SetKeyName(6, "application-x-srt.png");
            this.imagesFiles.Images.SetKeyName(7, "text-x-java.png");
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.lstbRecents);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(330, 402);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Recent files";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // lstbRecents
            // 
            this.lstbRecents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstbRecents.FormattingEnabled = true;
            this.lstbRecents.Location = new System.Drawing.Point(0, 0);
            this.lstbRecents.Name = "lstbRecents";
            this.lstbRecents.Size = new System.Drawing.Size(330, 402);
            this.lstbRecents.TabIndex = 0;
            this.lstbRecents.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstbRecents_MouseDoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lstEffects);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(330, 402);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Effects";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lstEffects
            // 
            this.lstEffects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.lstEffects.ContextMenuStrip = this.enchContext;
            this.lstEffects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstEffects.FullRowSelect = true;
            this.lstEffects.Location = new System.Drawing.Point(3, 3);
            this.lstEffects.MultiSelect = false;
            this.lstEffects.Name = "lstEffects";
            this.lstEffects.ShowItemToolTips = true;
            this.lstEffects.Size = new System.Drawing.Size(324, 396);
            this.lstEffects.TabIndex = 0;
            this.lstEffects.UseCompatibleStateImageBehavior = false;
            this.lstEffects.View = System.Windows.Forms.View.Details;
            this.lstEffects.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstEffects_MouseDoubleClick);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Name";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "ID";
            // 
            // enchContext
            // 
            this.enchContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem});
            this.enchContext.Name = "enchContext";
            this.enchContext.Size = new System.Drawing.Size(103, 26);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lstEnchantments);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(330, 402);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Enchantments";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lstEnchantments
            // 
            this.lstEnchantments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lstEnchantments.ContextMenuStrip = this.enchContext;
            this.lstEnchantments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstEnchantments.FullRowSelect = true;
            this.lstEnchantments.Location = new System.Drawing.Point(0, 0);
            this.lstEnchantments.MultiSelect = false;
            this.lstEnchantments.Name = "lstEnchantments";
            this.lstEnchantments.ShowItemToolTips = true;
            this.lstEnchantments.Size = new System.Drawing.Size(330, 402);
            this.lstEnchantments.TabIndex = 0;
            this.lstEnchantments.UseCompatibleStateImageBehavior = false;
            this.lstEnchantments.View = System.Windows.Forms.View.Details;
            this.lstEnchantments.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstEnchantments_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ID";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Max";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Version";
            // 
            // imagesAutocomplete
            // 
            this.imagesAutocomplete.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagesAutocomplete.ImageStream")));
            this.imagesAutocomplete.TransparentColor = System.Drawing.Color.Transparent;
            this.imagesAutocomplete.Images.SetKeyName(0, "commands.png");
            this.imagesAutocomplete.Images.SetKeyName(1, "entity.png");
            this.imagesAutocomplete.Images.SetKeyName(2, "modes.png");
            this.imagesAutocomplete.Images.SetKeyName(3, "stats.png");
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bwMCCheck
            // 
            this.bwMCCheck.WorkerSupportsCancellation = true;
            this.bwMCCheck.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwMCCheck_DoWork);
            this.bwMCCheck.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwMCCheck_RunWorkerCompleted);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 489);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Editor";
            this.Text = "MCStudio";
            this.Activated += new System.EventHandler(this.Editor_Activated);
            this.Deactivate += new System.EventHandler(this.Editor_Deactivate);
            this.Load += new System.EventHandler(this.Editor_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabStrip)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.fsContext.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.enchContext.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private FarsiLibrary.Win.FATabStrip tabStrip;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnSaveAll;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripButton btnCloseAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnUndo;
        private System.Windows.Forms.ToolStripButton btnRedo;
        private System.Windows.Forms.ToolStripButton btnCopy;
        private System.Windows.Forms.ToolStripButton btnCut;
        private System.Windows.Forms.ToolStripButton btnPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripButton btnReplace;
        private System.Windows.Forms.ToolStripButton btnSaveAs;
        private System.Windows.Forms.TreeView explorerTree;
        private System.Windows.Forms.ListView lstEffects;
        private System.Windows.Forms.ListView lstEnchantments;
        private System.Windows.Forms.ToolStripStatusLabel statLine;
        private System.Windows.Forms.ToolStripStatusLabel statChar;
        private System.Windows.Forms.ToolStripStatusLabel statLength;
        private System.Windows.Forms.ToolStripStatusLabel statSelection;
        private System.Windows.Forms.ImageList imagesAutocomplete;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ImageList imagesFiles;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ToolStripStatusLabel statCopied;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnSwitch;
        private System.ComponentModel.BackgroundWorker bwMCCheck;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ListBox lstbRecents;
        private System.Windows.Forms.ContextMenuStrip fsContext;
        private System.Windows.Forms.ToolStripMenuItem newDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip enchContext;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
    }
}

