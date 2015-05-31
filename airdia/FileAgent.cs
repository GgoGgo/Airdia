using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace airdia
{
    class FileAgent
    {
        // Singleton ( Design Pattern )
        private static FileAgent instance;
        private FileAgent( TreeView FileTree, Screen screen)
        {
            rootPath = "C:\\";
            this.FileTree = FileTree;
            this.screen = screen;
        }
        public static FileAgent getInstance(TreeView FileTree, Screen screen)
        {
            if (instance == null)
            {
                instance = new FileAgent(FileTree, screen);
            }
            return instance;
        }

        public string rootPath { set; get; }
        private TreeView FileTree;
        private Screen screen;

        public void SaveAt(string filePath, string editedText, Boolean showMode, DateTime date)
        {
            if (!File.Exists(filePath))
            {
                createFileAt(filePath);

                string text = editedText;
                System.IO.File.WriteAllText(filePath, text);

                Date curDate = (Date)parseDate(date);
                screen.printScreenAt(dateToFilePath(curDate), showMode);
                screen.printTreeAt(FileTree, rootPath);
            }
            else
            {
                string text = editedText;
                System.IO.File.WriteAllText(filePath, text);
            }
            screen.ShowSavedText();
        }
        public void createFileAt(string path)
        {
            Directory.CreateDirectory(path.Substring(0, path.LastIndexOf("\\") + 1));
            File.Create(path).Close();
        }
        public string dateToFilePath(Date curDate)
        {
            return rootPath + curDate.y + "\\" + curDate.m + "\\" + curDate.d + ".html";
        }
        public Date parseDate(DateTime curDate)
        {
            string date = curDate.ToString("yyyy-MM-dd");
            string y = date.Substring(0, 4);
            string m = date.Substring(5, 2);
            string d = date.Substring(8, 2);
            return Date.getInstance(y, m, d);
        }
    }
}
