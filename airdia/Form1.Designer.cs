namespace airdia
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.FileTree = new System.Windows.Forms.TreeView();
            this.PathText = new System.Windows.Forms.TextBox();
            this.ModeEdit = new System.Windows.Forms.CheckBox();
            this.DatePicker = new System.Windows.Forms.DateTimePicker();
            this.MarkDownBrowse = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.EditBox = new System.Windows.Forms.RichTextBox();
            this.Saved = new System.Windows.Forms.PictureBox();
            this.NotExist = new System.Windows.Forms.PictureBox();
            this.ExitButton = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SaveButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Saved)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NotExist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExitButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaveButton)).BeginInit();
            this.SuspendLayout();
            // 
            // FileTree
            // 
            this.FileTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.FileTree.BackColor = System.Drawing.Color.Crimson;
            this.FileTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FileTree.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FileTree.ForeColor = System.Drawing.Color.Ivory;
            this.FileTree.Location = new System.Drawing.Point(0, 0);
            this.FileTree.Margin = new System.Windows.Forms.Padding(0);
            this.FileTree.Name = "FileTree";
            this.FileTree.PathSeparator = "/";
            this.FileTree.Size = new System.Drawing.Size(130, 600);
            this.FileTree.TabIndex = 2;
            this.FileTree.TabStop = false;
            this.FileTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.FileTree_AfterSelect);
            // 
            // PathText
            // 
            this.PathText.BackColor = System.Drawing.Color.LightCoral;
            this.PathText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PathText.Font = new System.Drawing.Font("Inconsolata", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PathText.ForeColor = System.Drawing.Color.Ivory;
            this.PathText.Location = new System.Drawing.Point(136, 12);
            this.PathText.Name = "PathText";
            this.PathText.Size = new System.Drawing.Size(230, 18);
            this.PathText.TabIndex = 5;
            this.PathText.TabStop = false;
            this.PathText.Text = "C:/";
            this.PathText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PathText_KeyDown);
            // 
            // ModeEdit
            // 
            this.ModeEdit.AutoSize = true;
            this.ModeEdit.Font = new System.Drawing.Font("Inconsolata", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModeEdit.ForeColor = System.Drawing.Color.Ivory;
            this.ModeEdit.Location = new System.Drawing.Point(424, 12);
            this.ModeEdit.Name = "ModeEdit";
            this.ModeEdit.Size = new System.Drawing.Size(58, 19);
            this.ModeEdit.TabIndex = 6;
            this.ModeEdit.TabStop = false;
            this.ModeEdit.Text = "READ";
            this.ModeEdit.UseVisualStyleBackColor = true;
            this.ModeEdit.CheckedChanged += new System.EventHandler(this.ModeEdit_CheckedChanged);
            // 
            // DatePicker
            // 
            this.DatePicker.CalendarForeColor = System.Drawing.Color.Ivory;
            this.DatePicker.CalendarMonthBackground = System.Drawing.Color.Crimson;
            this.DatePicker.CalendarTitleForeColor = System.Drawing.Color.Ivory;
            this.DatePicker.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DatePicker.Location = new System.Drawing.Point(790, 29);
            this.DatePicker.Margin = new System.Windows.Forms.Padding(0);
            this.DatePicker.Name = "DatePicker";
            this.DatePicker.Size = new System.Drawing.Size(160, 21);
            this.DatePicker.TabIndex = 7;
            this.DatePicker.TabStop = false;
            this.DatePicker.ValueChanged += new System.EventHandler(this.DatePicker_ValueChanged);
            // 
            // MarkDownBrowse
            // 
            this.MarkDownBrowse.Location = new System.Drawing.Point(130, 50);
            this.MarkDownBrowse.Margin = new System.Windows.Forms.Padding(0);
            this.MarkDownBrowse.MinimumSize = new System.Drawing.Size(20, 20);
            this.MarkDownBrowse.Name = "MarkDownBrowse";
            this.MarkDownBrowse.Size = new System.Drawing.Size(870, 550);
            this.MarkDownBrowse.TabIndex = 8;
            this.MarkDownBrowse.TabStop = false;
            this.MarkDownBrowse.Visible = false;
            this.MarkDownBrowse.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.MarkDownBrowse_DocumentCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oslo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Ivory;
            this.label1.Location = new System.Drawing.Point(12, 572);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 19);
            this.label1.TabIndex = 11;
            this.label1.Text = "PATH";
            // 
            // EditBox
            // 
            this.EditBox.BackColor = System.Drawing.Color.FloralWhite;
            this.EditBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EditBox.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.EditBox.Location = new System.Drawing.Point(130, 50);
            this.EditBox.Margin = new System.Windows.Forms.Padding(0);
            this.EditBox.Name = "EditBox";
            this.EditBox.Size = new System.Drawing.Size(870, 550);
            this.EditBox.TabIndex = 13;
            this.EditBox.Text = "";
            this.EditBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditBox_KeyDown);
            // 
            // Saved
            // 
            this.Saved.BackColor = System.Drawing.Color.FloralWhite;
            this.Saved.Image = global::airdia.Properties.Resources.saved;
            this.Saved.Location = new System.Drawing.Point(753, 73);
            this.Saved.Name = "Saved";
            this.Saved.Size = new System.Drawing.Size(167, 50);
            this.Saved.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Saved.TabIndex = 14;
            this.Saved.TabStop = false;
            this.Saved.Visible = false;
            // 
            // NotExist
            // 
            this.NotExist.Image = ((System.Drawing.Image)(resources.GetObject("NotExist.Image")));
            this.NotExist.Location = new System.Drawing.Point(568, 405);
            this.NotExist.Name = "NotExist";
            this.NotExist.Size = new System.Drawing.Size(352, 135);
            this.NotExist.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.NotExist.TabIndex = 10;
            this.NotExist.TabStop = false;
            this.NotExist.Visible = false;
            // 
            // ExitButton
            // 
            this.ExitButton.Image = global::airdia.Properties.Resources.x;
            this.ExitButton.Location = new System.Drawing.Point(965, 12);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(23, 23);
            this.ExitButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ExitButton.TabIndex = 3;
            this.ExitButton.TabStop = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            this.ExitButton.MouseHover += new System.EventHandler(this.ExitButton_MouseHover);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SaveButton
            // 
            this.SaveButton.Image = global::airdia.Properties.Resources.sb2;
            this.SaveButton.Location = new System.Drawing.Point(368, 12);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(50, 18);
            this.SaveButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.SaveButton.TabIndex = 15;
            this.SaveButton.TabStop = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Crimson;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.Saved);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NotExist);
            this.Controls.Add(this.DatePicker);
            this.Controls.Add(this.ModeEdit);
            this.Controls.Add(this.PathText);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.FileTree);
            this.Controls.Add(this.EditBox);
            this.Controls.Add(this.MarkDownBrowse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Saved)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NotExist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExitButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaveButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView FileTree;
        private System.Windows.Forms.PictureBox ExitButton;
        private System.Windows.Forms.TextBox PathText;
        private System.Windows.Forms.CheckBox ModeEdit;
        private System.Windows.Forms.DateTimePicker DatePicker;
        private System.Windows.Forms.PictureBox NotExist;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox EditBox;
        private System.Windows.Forms.PictureBox Saved;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.WebBrowser MarkDownBrowse;
        private System.Windows.Forms.PictureBox SaveButton;
    }
}

