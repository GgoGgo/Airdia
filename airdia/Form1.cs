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
        public MainForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            EditBox.AcceptsTab = true;
            Scene = new Screen( NotExist, MarkDownBrowse, EditBox, ModeEdit);
            FileManage = new FileAgent( EditBox, DatePicker, Scene, FileTree);
        }

        Screen Scene;
        FileAgent FileManage;

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

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ExitButton_MouseHover(object sender, EventArgs e)
        {
            
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            Date curDate = (Date)FileManage.parseDate(DatePicker.Value);
            FileManage.SaveAt(FileManage.dateToFilePath(curDate));
        }
        private void DatePicker_ValueChanged(object sender, EventArgs e)
        {
            Date curDate = (Date)FileManage.parseDate(DatePicker.Value);
            Scene.printScreenAt( FileManage.dateToFilePath(curDate) );
        }
        private void PathText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FileManage.rootPath = PathText.Text.Replace("/", "\\");
                if (!FileManage.rootPath.EndsWith("\\"))
                {
                    FileManage.rootPath += "\\";
                }
                if (FileManage.rootPath != "C:\\" && FileManage.rootPath != "c:\\")
                {
                    Date curDate = (Date)FileManage.parseDate(DatePicker.Value);
                    Scene.printScreenAt(FileManage.dateToFilePath(curDate));
                    Scene.printTreeAt(FileTree, FileManage.rootPath);
                }
            }
        }
        private void ModeEdit_CheckedChanged(object sender, EventArgs e)
        {
            Date curDate = (Date)FileManage.parseDate(DatePicker.Value);

            if (ModeEdit.Checked == true)
            {
                FileManage.SaveAt(FileManage.dateToFilePath(curDate));

                MarkDownBrowse.Visible = true;
                EditBox.Visible = false;
                
            }
            else if (ModeEdit.Checked == false)
            {
                MarkDownBrowse.Visible = false;
                EditBox.Visible = true;
            }

            Scene.printScreenAt( FileManage.dateToFilePath(curDate) );
        }
        private void MarkDownBrowse_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            injectCss();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            /*if (count-- <= 0)
            {
                Saved.Visible = false;
                timer1.Stop();
            }*/
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
                Date curDate = (Date)FileManage.parseDate(DatePicker.Value);
                FileManage.SaveAt( FileManage.dateToFilePath( curDate) );
            }
        }
        private void injectCss()
        {
            try
            {
                HTMLDocument docs = (HTMLDocument)MarkDownBrowse.Document.DomDocument;
                IHTMLStyleSheet ss = docs.createStyleSheet("", 0);
                string tmp = Properties.Resources._default;
                ss.cssText = tmp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//get it to Screen class
    }
}
