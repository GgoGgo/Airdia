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
        private FileAgent(RichTextBox EditBox, DateTimePicker DatePicker, Screen Scene, TreeView FileTree)
        {
            rootPath = "C:\\";
            this.EditBox = EditBox;
            this.DatePicker = DatePicker;
            this.Scene = Scene;
            this.FileTree = FileTree;
        }
        public static FileAgent getInstance(RichTextBox EditBox, DateTimePicker DatePicker, Screen Scene, TreeView FileTree)
        {
            if (instance == null)
            {
                instance = new FileAgent( EditBox, DatePicker, Scene, FileTree);
            }
            return instance;
        }

        public string rootPath { set; get; }
        private RichTextBox EditBox;
        private DateTimePicker DatePicker;
        private TreeView FileTree;
        private Screen Scene;

        public void SaveAt(string filePath)
        {
            if (!File.Exists(filePath))
            {
                createFileAt(filePath);

                string text = EditBox.Text;
                System.IO.File.WriteAllText(filePath, text);

                Date curDate = (Date)parseDate(DatePicker.Value);
                Scene.printScreenAt(dateToFilePath(curDate));
                Scene.printTreeAt(FileTree, rootPath);
            }
            else
            {
                string text = EditBox.Text;
                System.IO.File.WriteAllText(filePath, text);
            }
            //Scene.ShowSavedText();
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
