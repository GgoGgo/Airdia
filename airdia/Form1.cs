using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using mshtml;

namespace airdia
{
    public partial class MainForm : Form
    {
        string curPath = "C:\\";
        string curSubPath = "";
        string date = "";
        int count = 0;

        public MainForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            EditBox.AcceptsTab = true;
        }

        private void injectCss()
        {
            try
            {
                HTMLDocument docs = (HTMLDocument)MarkDownBrowse.Document.DomDocument;
                IHTMLStyleSheet ss = docs.createStyleSheet("", 0);
                string tmp = File.ReadAllText("CSS\\default.css");
                ss.cssText = tmp;
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ExitButton_MouseHover(object sender, EventArgs e)
        {
            
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            save();
        }
        private void DatePicker_ValueChanged(object sender, EventArgs e)
        {
            refreshDocs();
        }

        private void PathText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                curPath = PathText.Text.Replace("/", "\\");
                if (!curPath.EndsWith("\\"))
                {
                    curPath += "\\";
                }
                if (curPath != "C:\\" && curPath != "c:\\")
                {
                    refreshTree();
                }
            }
            refreshDocs();
        }

        private void ModeEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (ModeEdit.Checked == true)
            {
                save();
                MarkDownBrowse.Visible = true;
                EditBox.Visible = false;
                
            }
            else if (ModeEdit.Checked == false)
            {
                MarkDownBrowse.Visible = false;
                EditBox.Visible = true;
            }
            refreshDocs();
        }

        private void refreshDocs()
        {
            date = DatePicker.Value.ToString("yyyy-MM-dd");
            string y = date.Substring(0, 4);
            string m = date.Substring(5, 2);
            string d = date.Substring(8, 2);

            curSubPath = y + "\\" + m + "\\" + d + ".html";
            if (File.Exists(curPath + curSubPath))
            {
                NotExist.Visible = false;
                if (ModeEdit.Checked == true)
                {
                    //MarkDownBrowse.Url = new Uri(curPath + curSubPath);
                    MarkDownBrowse.Navigate(curPath + curSubPath);
                }
                else if (ModeEdit.Checked == false)
                {
                    string text = System.IO.File.ReadAllText(curPath+curSubPath);
                    EditBox.Text = text;
                }
            }
            else
            {
                NotExist.Visible = true;
                EditBox.Text = "";
            }
        }
        private void refreshTree()
        {
            ListDirectory(FileTree, curPath);
        }

        private void save()
        {
            date = DatePicker.Value.ToString("yyyy-MM-dd");
            string y = date.Substring(0, 4);
            string m = date.Substring(5, 2);
            string d = date.Substring(8, 2);

            curSubPath = y + "\\" + m + "\\" + d + ".html";
            if (!File.Exists(curPath + curSubPath))
            {
                Directory.CreateDirectory(curPath + y + "\\" + m);
                File.Create(curPath + curSubPath).Close();
                string text = EditBox.Text;
                System.IO.File.WriteAllText(curPath + curSubPath, text);
                refreshDocs();
                refreshTree();
            }
            else
            {
                string text = EditBox.Text;
                System.IO.File.WriteAllText(curPath + curSubPath, text);
            }
            ShowSavedText();
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }
        private static void ListDirectory(TreeView treeView, string path)
        {
            treeView.Nodes.Clear();

            var stack = new Stack<TreeNode>();
            var rootDirectory = new DirectoryInfo(path);
            var node = new TreeNode(rootDirectory.Name) { Tag = rootDirectory };
            stack.Push(node);

            while (stack.Count > 0)
            {
                var currentNode = stack.Pop();
                var directoryInfo = (DirectoryInfo)currentNode.Tag;
                foreach (var directory in directoryInfo.GetDirectories())
                {
                    var childDirectoryNode = new TreeNode(directory.Name) { Tag = directory };
                    currentNode.Nodes.Add(childDirectoryNode);
                    stack.Push(childDirectoryNode);
                }
                foreach (var file in directoryInfo.GetFiles())
                    currentNode.Nodes.Add(new TreeNode(file.Name));
            }

            treeView.Nodes.Add(node);
        }
        
        private void FileTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent != null && e.Node.Parent.Parent != null && e.Node.Parent.Parent.GetType() == typeof(TreeNode))
            {
                string y = e.Node.Parent.Parent.Text;
                string m = e.Node.Parent.Text;
                string d = e.Node.Text.Substring(0, 2);
                try
                {
                    DatePicker.Value = new DateTime(Convert.ToInt32(y), Convert.ToInt32(m), Convert.ToInt32(d));
                }
                catch (FormatException exception)
                {
                    return;
                }
            }
        }

        private void EditBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                save();
            }
        }

        private void ShowSavedText(){
            count = 0;
            Saved.Visible = true;
            timer1.Start();
        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (count++ > 30)
            {
                Saved.Visible = false;
                timer1.Stop();
            }
        }

        private void MarkDownBrowse_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            injectCss();
        }
    }
}
