using System;
using System.IO;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using FarsiLibrary.Win;
using System.Text;
using System.Collections.Generic;
using System.Xml;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MCStudio
{
    public partial class Editor : Form
    {

        #region "WinApi"

        private IntPtr minecraftHandle = IntPtr.Zero;

        [DllImport("kernel32.dll")]
        public static extern uint GetLastError();

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError =true)]
        static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, uint nSize, string lpFileName);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string className, string windowTitle);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, ShowWindowEnum flags);

        [DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hwnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowPlacement(IntPtr hWnd, ref Windowplacement lpwndpl);

        private enum ShowWindowEnum
        {
            Hide = 0,
            ShowNormal = 1, ShowMinimized = 2, ShowMaximized = 3,
            Maximize = 3, ShowNormalNoActivate = 4, Show = 5,
            Minimize = 6, ShowMinNoActivate = 7, ShowNoActivate = 8,
            Restore = 9, ShowDefault = 10, ForceMinimized = 11
        };

        private struct Windowplacement
        {
            public int length;
            public int flags;
            public int showCmd;
            public System.Drawing.Point ptMinPosition;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Rectangle rcNormalPosition;
        }

        #endregion

        #region "Methods"

        private KeyboardHook hook;

        public void LoadEffects()
        {
            string xml = Path.Combine(Directory.GetParent(Application.ExecutablePath).FullName, "data", "effects.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);
            XmlNodeList root = doc.SelectNodes("/list/effect");
            foreach (XmlNode node in root)
            {
                ListViewItem item = new ListViewItem();
                item.Text = node.SelectSingleNode("name").InnerText;
                item.SubItems.Add("minecraft:" + node.SelectSingleNode("id").InnerText);
                item.ToolTipText = node.SelectSingleNode("desc").InnerText;
                lstEffects.Items.Add(item);
            }

            lstEffects.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        public void LoadEnchantments()
        {
            string xml = Path.Combine(Directory.GetParent(Application.ExecutablePath).FullName, "data", "enchantments.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);
            XmlNodeList root = doc.SelectNodes("/list/ench");
            foreach (XmlNode node in root)
            {
                ListViewItem item = new ListViewItem();
                item.Text = node.SelectSingleNode("name").InnerText;
                item.SubItems.Add("minecraft:" + node.SelectSingleNode("id").InnerText);
                item.SubItems.Add(node.SelectSingleNode("max").InnerText);
                item.SubItems.Add(node.SelectSingleNode("version").InnerText);
                item.ToolTipText = node.SelectSingleNode("desc").InnerText;
                lstEnchantments.Items.Add(item);
            }
            lstEnchantments.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        public void LoadAutocomplete(FastColoredTextBox fctb)
        {
            AutocompleteMenu auto = new AutocompleteMenu(fctb);
            auto.ImageList = imagesAutocomplete;
            auto.ShowItemToolTips = true;
            auto.MinFragmentLength = 1;
            List<AutocompleteItem> items = new List<AutocompleteItem>();
            string xml = Path.Combine(Directory.GetParent(Application.ExecutablePath).FullName, "data", "autocomplete.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);
            XmlNodeList root = doc.SelectNodes("/menu/list");
            for (int i = 0; i < root.Count; i++)
            {
                XmlNode node = root.Item(i);
                int index = int.Parse(node.Attributes["image"].InnerText);
                bool sn = bool.Parse(node.Attributes["snippet"].InnerText);
                foreach(XmlNode entry in node.ChildNodes)
                {
                    if (sn)
                    {
                        items.Add(new SnippetAutocompleteItem(entry.InnerText) { ImageIndex = index });
                    } else
                    {
                        items.Add(new AutocompleteItem(entry.InnerText, index));
                    }
                }
            }
            auto.Items.SetAutocompleteItems(items);
        }

        public void UpdateStats(FastColoredTextBox fctb)
        {
            statLine.Text = string.Format("Line: {0}", fctb.Selection.ToLine + 1);
            statChar.Text = string.Format("Character: {0}", fctb.Selection.Start.iChar);
            statLength.Text = string.Format("Length: {0}", fctb.Text.Length);
        }

        public void Save(FastColoredTextBox fctb, bool force)
        {
            if (fctb.Tag == null || force)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Reset();
                save.RestoreDirectory = true;
                save.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                save.Filter = "Function (*.mcfunction)|*.mcfunction|Json (*.json; *.mcmeta)|*.json; *.mcmeta";
                save.AddExtension = true;
                save.SupportMultiDottedExtensions = false;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    fctb.Tag = save.FileName;
                    fctb.SaveToFile(save.FileName, new UTF8Encoding(false));
                    FATabStripItem item = (FATabStripItem)fctb.Parent;
                    item.Title = Path.GetFileName(save.FileName);
                    FileSystem.SaveRecent(save.FileName);
                    lstbRecents.Items.Add(save.FileName);
                }
            } else
            {
                string file = fctb.Tag.ToString();
                fctb.SaveToFile(file, new UTF8Encoding(false));
                FATabStripItem item = (FATabStripItem)fctb.Parent;
                item.Title = Path.GetFileName(file);
            }
        }

        public void LoadPath(string path, TreeNode parent)
        {
            try
            {
                parent.Nodes.Clear();
                DirectoryInfo info = new DirectoryInfo(path);
                foreach (var dir in info.GetDirectories())
                {
                    TreeNode node = new TreeNode(dir.Name);
                    node.Tag = dir.FullName;
                    node.ImageIndex = 3;
                    node.SelectedImageIndex = 3;
                    parent.Nodes.Add(node);
                }
                foreach (var file in info.GetFiles())
                {
                    if (file.Extension.EndsWith("mcfunction") || file.Extension.EndsWith("mcmeta") || file.Extension.EndsWith("json"))
                    {
                        TreeNode node = new TreeNode(file.Name);
                        node.Tag = file.FullName;
                        if (file.Extension.EndsWith("mcfunction"))
                        {
                            node.ImageIndex = 5;
                            node.SelectedImageIndex = 5;
                        }
                        else if (file.Extension.EndsWith("mcmeta"))
                        {
                            node.ImageIndex = 4;
                            node.SelectedImageIndex = 4;
                        }
                        else if (file.Extension.EndsWith("json"))
                        {
                            node.ImageIndex = 6;
                            node.SelectedImageIndex = 6;
                        }
                        parent.Nodes.Add(node);
                    }
                }
                parent.Expand();
            } catch (Exception e)
            {
                FileSystem.WriteLog(e);
            }
        }

        public void CreateEditor(string format, string file = "")
        {
            FastColoredTextBox fctb = new FastColoredTextBox();
            fctb.Language = Language.Custom;
            if (format.Equals("mcmeta"))
            {
                fctb.DescriptionFile = Path.Combine(Directory.GetParent(Application.ExecutablePath).FullName, "data", "json.xml");
            } else
            {
                fctb.DescriptionFile = Path.Combine(Directory.GetParent(Application.ExecutablePath).FullName, "data", format + ".xml");
            }
            fctb.Dock = DockStyle.Fill;
            fctb.HotkeysMapping.Add(Keys.Control | Keys.Y, FCTBAction.Redo);
            fctb.TextChanged += Fctb_TextChanged;
            fctb.SelectionChanged += Fctb_SelectionChanged;
            FATabStripItem item = new FATabStripItem();
            item.Title = "new " + format;
            item.Controls.Add(fctb);
            tabStrip.Items.Add(item);
            tabStrip.SelectedItem = item;
            if (!file.Equals(""))
            {
                fctb.OpenFile(file);
                fctb.Tag = file;
                item.Title = Path.GetFileName(file);
            }
            if (format.Equals("mcfunction"))
            {
                LoadAutocomplete(fctb);
                fctb.CommentPrefix = "#";
            }
        }

        public void LoadDrives()
        {
            foreach (var drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    TreeNode node = new TreeNode(string.Format("{0} {1}", drive.Name, drive.VolumeLabel));
                    node.Tag = drive.Name;
                    switch (drive.DriveType)
                    {
                        case DriveType.CDRom:
                            node.ImageIndex = 1;
                            node.SelectedImageIndex = 1;
                            break;
                        case DriveType.Fixed:
                            node.ImageIndex = 0;
                            node.SelectedImageIndex = 0;
                            break;
                        case DriveType.Removable:
                            node.ImageIndex = 2;
                            node.SelectedImageIndex = 2;
                            break;
                    }
                    explorerTree.Nodes.Add(node);
                }
            }
        }

        public FastColoredTextBox GetSelected()
        {
            if (tabStrip.Items.Count == 0)
                return null;
            else
                return (FastColoredTextBox)tabStrip.SelectedItem.Controls[0];
        }

        private void Fctb_SelectionChanged(object sender, EventArgs e)
        {
            FastColoredTextBox fctb = (FastColoredTextBox)sender;
            if (fctb.Selection.Length == 0)
                statSelection.Text = "Selection: 0 | 0";
            else
                statSelection.Text = string.Format("Selection: {0} | {1}", fctb.Selection.Length, Math.Abs(fctb.Selection.FromLine - fctb.Selection.ToLine) + 1);
            UpdateStats(fctb);
        }

        private void Fctb_TextChanged(object sender, TextChangedEventArgs e)
        {
            FastColoredTextBox fctb = (FastColoredTextBox)sender;
            FATabStripItem item = (FATabStripItem)fctb.Parent;
            item.Title = (item.Title.Contains("*") ? item.Title : item.Title + "*");
            UpdateStats(fctb);
        }

        #endregion

        public Editor()
        {
            InitializeComponent();
        }

        #region "Events"

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewFile nf = new NewFile();
            if (nf.ShowDialog() == DialogResult.OK)
            {
                CreateEditor(nf.FileFormat);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Reset();
            open.RestoreDirectory = true;
            open.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            open.Filter = "Function (*.mcfunction)|*.mcfunction|Json (*.json; *.mcmeta)|*.json; *.mcmeta";
            open.Multiselect = true;
            if (open.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in open.FileNames)
                {
                    FileSystem.SaveRecent(file);
                    lstbRecents.Items.Add(file);
                    CreateEditor(Path.GetExtension(file).Replace(".", ""), file);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save((FastColoredTextBox)tabStrip.SelectedItem.Controls[0], false);
        }

        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            foreach (FATabStripItem item in tabStrip.Items)
            {
                Save((FastColoredTextBox)item.Controls[0], false);
            }
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            Save((FastColoredTextBox)tabStrip.SelectedItem.Controls[0], true);
        }

        private void tabStrip_TabStripItemSelectionChanged(TabStripItemChangedEventArgs e)
        {
            try
            {
                FastColoredTextBox fctb = (FastColoredTextBox)tabStrip.SelectedItem.Controls[0];
                Text = "MCStudio - " + (fctb.Tag == null ? e.Item.Title : fctb.Tag.ToString());
                Fctb_SelectionChanged(fctb, new EventArgs());
            }
            catch (Exception ex)
            {
                FileSystem.WriteLog(ex);
            }
        }

        private void tabStrip_TabStripItemClosing(TabStripItemClosingEventArgs e)
        {
            if (e.Item.Title.Contains("*"))
            {
                DialogResult result = MessageBox.Show(string.Format("\"{0}\" is not saved. Save it now?", e.Item.Title), "Close", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    Save((FastColoredTextBox)e.Item.Controls[0], false);
                } else if(result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void tabStrip_TabStripItemClosed(object sender, EventArgs e)
        {
            statLine.Text = "Line: 0";
            statChar.Text = "Character: 0";
            statLength.Text = "Length: 0";
            statSelection.Text = "Selection: 0 | 0";
            Text = "MCStudio";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            TabStripItemClosingEventArgs ev = new TabStripItemClosingEventArgs(tabStrip.SelectedItem);
            tabStrip_TabStripItemClosing(ev);
            if(!ev.Cancel)
            {
                tabStrip.Items.Remove(tabStrip.SelectedItem);
            }
        }

        private void btnCloseAll_Click(object sender, EventArgs e)
        {
            List<FATabStripItem> remove = new List<FATabStripItem>();
            foreach (FATabStripItem item in tabStrip.Items)
            {
                TabStripItemClosingEventArgs ev = new TabStripItemClosingEventArgs(item);
                tabStrip_TabStripItemClosing(ev);
                if (!ev.Cancel)
                {
                    remove.Add(item);
                }
            }
            foreach (FATabStripItem item in remove)
            {
                tabStrip.Items.Remove(item);
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (GetSelected() != null)
                GetSelected().Undo();
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            if (GetSelected() != null)
                GetSelected().Redo();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (GetSelected() != null)
                GetSelected().Copy();
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            if (GetSelected() != null)
                GetSelected().Cut();
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            if (GetSelected() != null)
                GetSelected().Paste();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (GetSelected() != null)
                GetSelected().ShowFindDialog();
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (GetSelected() != null)
                GetSelected().ShowReplaceDialog();
        }

        private void Editor_Load(object sender, EventArgs e)
        {
            LoadDrives();
            LoadEnchantments();
            LoadEffects();
            lstbRecents.Items.AddRange(FileSystem.GetRecents());
            //bwMCCheck.RunWorkerAsync();
            hook = new KeyboardHook();
            hook.KeyPressed += Hook_KeyPressed;
            hook.Hook(Keys.N, MCStudio.ModifierKeys.Control);
            hook.Hook(Keys.O, MCStudio.ModifierKeys.Control);
            hook.Hook(Keys.S, MCStudio.ModifierKeys.Control | MCStudio.ModifierKeys.Shift);
            hook.Hook(Keys.W, MCStudio.ModifierKeys.Control | MCStudio.ModifierKeys.Shift);
            hook.Hook(Keys.F6);
            hook.Enabled = true;
        }

        private void Hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            if (e.Key == Keys.F6)
            {
                if (btnSwitch.Enabled)
                    btnSwitch.PerformClick();
                return;
            }
            if (e.Modifiers.HasFlag(MCStudio.ModifierKeys.Control))
            {
                switch (e.Key)
                {
                    case Keys.N:
                        Invoke((MethodInvoker) delegate()
                        {
                            btnNew.PerformClick();
                        });
                        break;
                    case Keys.O:
                        Invoke((MethodInvoker)delegate ()
                        {
                            btnOpen.PerformClick();
                        });
                        break;
                    case Keys.S:
                        Invoke((MethodInvoker)delegate ()
                       {
                           if (e.Modifiers.HasFlag(MCStudio.ModifierKeys.Shift))
                               btnSaveAll.PerformClick();
                           else
                               btnSave.PerformClick();
                       });
                        break;
                    case Keys.W:
                        Invoke((MethodInvoker)delegate ()
                        {
                            if (e.Modifiers.HasFlag(MCStudio.ModifierKeys.Shift))
                                btnCloseAll.PerformClick();
                            else
                                btnClose.PerformClick();
                        });
                        break;
                }
            }
        }

        private void explorerTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            FileAttributes attrs = File.GetAttributes(e.Node.Tag.ToString());
            if (attrs.HasFlag(FileAttributes.Directory))
            {
                LoadPath(e.Node.Tag.ToString(), e.Node);
            } else
            {
                FileSystem.SaveRecent(e.Node.Tag.ToString());
                lstbRecents.Items.Add(e.Node.Tag.ToString());
                CreateEditor(Path.GetExtension(e.Node.Tag.ToString()).Replace(".", ""), e.Node.Tag.ToString());
            }
        }

        private void tabControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void lstEnchantments_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstEnchantments.SelectedItems.Count != 0)
            {
                ListViewItem item = lstEnchantments.SelectedItems[0];
                string id = item.SubItems[1].Text;
                Clipboard.SetText(id);
                statCopied.Visible = true;
                timer1.Enabled = true;
            }
        }

        private void lstEffects_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstEffects.SelectedItems.Count != 0)
            {
                ListViewItem item = lstEffects.SelectedItems[0];
                string id = item.SubItems[1].Text;
                Clipboard.SetText(id);
                statCopied.Visible = true;
                timer1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            statCopied.Visible = false;
            timer1.Enabled = false;
        }

        private void bwMCCheck_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            foreach (var p in Process.GetProcesses())
            {
                if (bwMCCheck.CancellationPending)
                    break;
                try
                {
                    if (p.MainModule.ModuleName.ToLower().Contains("java") && p.MainWindowTitle.ToLower().Contains("minecraft"))
                    {
                        e.Result = bool.TrueString;
                        minecraftHandle = p.MainWindowHandle;
                        FileSystem.WriteLog("Found Minecraft window with handle " + minecraftHandle);
                        break;
                    } else
                    {
                        e.Result = bool.FalseString;
                    }
                }
                catch
                {
                    e.Result = bool.FalseString;
                }
            }
        }

        private void bwMCCheck_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            btnSwitch.Enabled = bool.Parse(e.Result.ToString());
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            if (minecraftHandle != IntPtr.Zero)
            {
                Windowplacement placement = new Windowplacement();
                GetWindowPlacement(minecraftHandle, ref placement);
                if (placement.showCmd == 2)
                {
                    ShowWindow(minecraftHandle, ShowWindowEnum.Restore);
                }
                SetForegroundWindow(minecraftHandle);
            }
        }

        private void Editor_Activated(object sender, EventArgs e)
        {
            btnSwitch.Enabled = false;
            minecraftHandle = IntPtr.Zero;
            if (bwMCCheck.IsBusy)
                bwMCCheck.CancelAsync();
            bwMCCheck.RunWorkerAsync();
        }

        private void tabStrip_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void Editor_Deactivate(object sender, EventArgs e)
        {
            if (bwMCCheck.IsBusy)
                bwMCCheck.CancelAsync();
        }

        private void tabStrip_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string file in files)
                    CreateEditor(Path.GetExtension(file).Replace(".", ""), file);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            foreach (var ctrl in toolStrip1.Items)
            {
                if (ctrl.GetType() == typeof(ToolStripButton)) {
                    ToolStripButton btn = (ToolStripButton)ctrl;
                    if ((btn != btnNew) && (btn != btnOpen) && (btn != btnSwitch))
                    {
                        btn.Enabled = (tabStrip.Items.Count != 0);
                    }
                }
            }
        }

        private void lstbRecents_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstbRecents.SelectedItem != null)
            {
                CreateEditor(Path.GetExtension(lstbRecents.SelectedItem.ToString()).Replace(".", ""), lstbRecents.SelectedItem.ToString());
            }
        }

        #region "Context menu"

        private void newDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (explorerTree.SelectedNode != null)
            {
                string direct = InputDialog.ShowDialog("New directory", "Type the name for the new directory:", DialogIcons.Question, "New directory");
                if (!string.IsNullOrEmpty(direct))
                {
                    string parent = explorerTree.SelectedNode.Tag.ToString();
                    FileAttributes attrs = File.GetAttributes(parent);
                    if (attrs.HasFlag(FileAttributes.Directory))
                    {
                        parent = Path.Combine(parent, direct);
                    }
                    else
                    {
                        string p = Directory.GetParent(parent).FullName;
                        parent = Path.Combine(p, direct);
                    }
                    if (!Directory.Exists(parent))
                        Directory.CreateDirectory(parent);
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (explorerTree.SelectedNode != null)
                explorerTree_NodeMouseDoubleClick(explorerTree, new TreeNodeMouseClickEventArgs(explorerTree.SelectedNode, MouseButtons.Left, 2, Cursor.Position.X, Cursor.Position.Y));
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (explorerTree.SelectedNode != null)
            {
                string path = explorerTree.SelectedNode.Tag.ToString();
                FileAttributes attrs = File.GetAttributes(path);
                if (attrs.HasFlag(FileAttributes.Directory))
                {
                    LoadPath(path, explorerTree.SelectedNode);
                }
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstEffects.SelectedItems.Count != 0)
            {
                ListViewItem item = lstEffects.SelectedItems[0];
                string id = item.SubItems[1].Text;
                Clipboard.SetText(id);
            }
            else if (lstEnchantments.SelectedItems.Count != 0)
            {
                ListViewItem item = lstEnchantments.SelectedItems[0];
                string id = item.SubItems[1].Text;
                Clipboard.SetText(id);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstEffects.SelectedItems.Clear();
            lstEnchantments.SelectedItems.Clear();
        }

        #endregion

        #endregion
    }
}
