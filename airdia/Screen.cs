using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace airdia
{
    class Screen
    {
        public Screen(PictureBox NotExist, WebBrowser MarkDownBrowse, RichTextBox EditBox, CheckBox ModeEdit)
        {
            this.NotExist = NotExist;
            this.MarkDownBrowse = MarkDownBrowse;
            this.EditBox = EditBox;
            this.ModeEdit = ModeEdit;
        }

        private PictureBox NotExist;
        private WebBrowser MarkDownBrowse;
        private RichTextBox EditBox;
        private CheckBox ModeEdit;

        public void printScreenAt(string filePath)
        {
            if (File.Exists(filePath))
            {
                NotExist.Visible = false;
                if (ModeEdit.Checked == true)
                {
                    MarkDownBrowse.Navigate(filePath);
                }
                else if (ModeEdit.Checked == false)
                {
                    string text = System.IO.File.ReadAllText(filePath);
                    EditBox.Text = text;
                }
            }
            else
            {
                NotExist.Visible = true;
                MarkDownBrowse.Navigate("about:blank");
                EditBox.Text = "";
            }
        }
        public void printTreeAt(TreeView treeView, string path)
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
        /*
        int count = 0;
        private void ShowSavedText()
        {
            count = 30;
            Saved.Visible = true;
            timer1.Start();
        }
        */
    }
}
