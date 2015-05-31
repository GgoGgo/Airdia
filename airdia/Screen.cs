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
        // Singleton ( Design Pattern )
        private static Screen instance;
        private Screen(WebBrowser MarkDownBrowse, RichTextBox EditBox, LinkedList<Image> images)
        {
            this.MarkDownBrowse = MarkDownBrowse;
            this.EditBox = EditBox;
            this.images = images;
        }
        public static Screen getInstance(WebBrowser MarkDownBrowse, RichTextBox EditBox, LinkedList<Image> images)
        {
            if (instance == null)
            {
                instance = new Screen(MarkDownBrowse, EditBox, images);
            }
            return instance;
        }

        private WebBrowser MarkDownBrowse;
        private RichTextBox EditBox;
        private LinkedList<Image> images;

        public void printScreenAt(string filePath, Boolean showMode)
        {
            if (File.Exists(filePath))
            {
                images.ElementAt(1).setVisible(false);
                if (showMode == true)
                {
                    MarkDownBrowse.Navigate(filePath);
                }
                else if (showMode == false)
                {
                    string text = System.IO.File.ReadAllText(filePath);
                    EditBox.Text = text;
                }
            }
            else
            {
                images.ElementAt(1).setVisible(true);
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

        public void ShowSavedText()
        {
            images.ElementAt(0).timeToShow = 30;
            images.ElementAt(0).setVisible(true);
        }
    }
}
