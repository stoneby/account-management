
using System.Windows.Forms;

namespace AccountFactory
{
    partial class MainForm
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

        #region Windows MainForm Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.siteImageList = new System.Windows.Forms.ImageList(this.components);
            this.userListView = new AccountFactory.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.userImageList = new System.Windows.Forms.ImageList(this.components);
            this.userButton = new System.Windows.Forms.Button();
            this.settingButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.autoLoginButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.imageBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.siteListView = new AccountFactory.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.testIEButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // siteImageList
            // 
            this.siteImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("siteImageList.ImageStream")));
            this.siteImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.siteImageList.Images.SetKeyName(0, "1.jpg");
            this.siteImageList.Images.SetKeyName(1, "2.jpg");
            this.siteImageList.Images.SetKeyName(2, "3.jpg");
            this.siteImageList.Images.SetKeyName(3, "4.jpg");
            this.siteImageList.Images.SetKeyName(4, "5.jpg");
            this.siteImageList.Images.SetKeyName(5, "6.jpg");
            this.siteImageList.Images.SetKeyName(6, "7.jpg");
            this.siteImageList.Images.SetKeyName(7, "8.jpg");
            // 
            // userListView
            // 
            this.userListView.AllowDrop = true;
            this.userListView.AllowItemDrag = true;
            this.userListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.userListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.userListView.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userListView.FullRowSelect = true;
            this.userListView.LargeImageList = this.userImageList;
            this.userListView.Location = new System.Drawing.Point(170, 49);
            this.userListView.Name = "userListView";
            this.userListView.ShowItemToolTips = true;
            this.userListView.Size = new System.Drawing.Size(203, 630);
            this.userListView.SmallImageList = this.userImageList;
            this.userListView.TabIndex = 1;
            this.userListView.UseCompatibleStateImageBehavior = false;
            this.userListView.View = System.Windows.Forms.View.Details;
            this.userListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.userListView_ItemSelectionChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "公众号";
            this.columnHeader3.Width = 167;
            // 
            // userImageList
            // 
            this.userImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("userImageList.ImageStream")));
            this.userImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.userImageList.Images.SetKeyName(0, "Default");
            // 
            // userButton
            // 
            this.userButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userButton.Location = new System.Drawing.Point(977, 15);
            this.userButton.Name = "userButton";
            this.userButton.Size = new System.Drawing.Size(109, 30);
            this.userButton.TabIndex = 4;
            this.userButton.Text = "你好，用户";
            this.userButton.UseVisualStyleBackColor = true;
            // 
            // settingButton
            // 
            this.settingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.settingButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingButton.Location = new System.Drawing.Point(1092, 15);
            this.settingButton.Name = "settingButton";
            this.settingButton.Size = new System.Drawing.Size(70, 30);
            this.settingButton.TabIndex = 5;
            this.settingButton.Text = "设置";
            this.settingButton.UseVisualStyleBackColor = true;
            this.settingButton.Click += new System.EventHandler(this.settingButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Location = new System.Drawing.Point(1168, 15);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(70, 30);
            this.closeButton.TabIndex = 6;
            this.closeButton.Text = "关闭";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(217, 23);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(156, 20);
            this.searchTextBox.TabIndex = 7;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(167, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "搜索：";
            // 
            // linkLabel
            // 
            this.linkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel.AutoSize = true;
            this.linkLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel.Location = new System.Drawing.Point(421, 23);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(204, 17);
            this.linkLabel.TabIndex = 9;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "www.your_account_site_name.com";
            // 
            // autoLoginButton
            // 
            this.autoLoginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.autoLoginButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLoginButton.Location = new System.Drawing.Point(901, 15);
            this.autoLoginButton.Name = "autoLoginButton";
            this.autoLoginButton.Size = new System.Drawing.Size(70, 30);
            this.autoLoginButton.TabIndex = 10;
            this.autoLoginButton.Text = "填充";
            this.autoLoginButton.UseVisualStyleBackColor = true;
            this.autoLoginButton.Click += new System.EventHandler(this.autoLoginButton_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(378, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "链接：";
            // 
            // imageBackgroundWorker
            // 
            this.imageBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.imageBackgroundWorker_DoWork);
            this.imageBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.imageBackgroundWorker_RunWorkerCompleted);
            // 
            // webBrowser
            // 
            this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser.Location = new System.Drawing.Point(379, 49);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(876, 630);
            this.webBrowser.TabIndex = 2;
            this.webBrowser.Url = new System.Uri("http://www.baidu.com", System.UriKind.Absolute);
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            // 
            // siteListView
            // 
            this.siteListView.AllowDrop = true;
            this.siteListView.AllowItemDrag = true;
            this.siteListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.siteListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.siteListView.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.siteListView.FullRowSelect = true;
            this.siteListView.HideSelection = false;
            this.siteListView.LargeImageList = this.siteImageList;
            this.siteListView.Location = new System.Drawing.Point(6, 49);
            this.siteListView.MultiSelect = false;
            this.siteListView.Name = "siteListView";
            this.siteListView.Size = new System.Drawing.Size(158, 630);
            this.siteListView.SmallImageList = this.siteImageList;
            this.siteListView.TabIndex = 0;
            this.siteListView.UseCompatibleStateImageBehavior = false;
            this.siteListView.View = System.Windows.Forms.View.Details;
            this.siteListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.siteListView_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "站点";
            this.columnHeader1.Width = 158;
            // 
            // testIEButton
            // 
            this.testIEButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.testIEButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testIEButton.Location = new System.Drawing.Point(825, 15);
            this.testIEButton.Name = "testIEButton";
            this.testIEButton.Size = new System.Drawing.Size(70, 30);
            this.testIEButton.TabIndex = 12;
            this.testIEButton.Text = "IE版本";
            this.testIEButton.UseVisualStyleBackColor = true;
            this.testIEButton.Click += new System.EventHandler(this.testIEButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.testIEButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.autoLoginButton);
            this.Controls.Add(this.linkLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.settingButton);
            this.Controls.Add(this.userButton);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.userListView);
            this.Controls.Add(this.siteListView);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "自媒体风向标";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView siteListView;
        private ListView userListView;
        private System.Windows.Forms.Button userButton;
        private System.Windows.Forms.Button settingButton;
        private System.Windows.Forms.Button closeButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ImageList siteImageList;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel;
        //public WebKit.WebKitBrowser webBrowser;
        //public WebBrowserWrapper webBrowser;
        public WebBrowser webBrowser;
        private Button autoLoginButton;
        private Label label2;
        private ImageList userImageList;
        private System.ComponentModel.BackgroundWorker imageBackgroundWorker;
        private Button testIEButton;
    }
}

