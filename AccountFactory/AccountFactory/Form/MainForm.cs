using mshtml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace AccountFactory
{
    public partial class MainForm : Form
    {
        private readonly JavaScriptSerializer serializer = new JavaScriptSerializer();
        private readonly UserData userData;
        private Uri helpUri;

        private string currentAccountId = string.Empty;

        private AccountData CurrentAccountData => userListView.SelectedItems.Count > 0 &&
                                                  userListView.SelectedItems[0].Tag is AccountData accountData ? accountData : null;
        private AccountData preAccountData;

        private SiteData CurrentSiteData => siteListView.SelectedItems.Count > 0 &&
                                            siteListView.SelectedItems[0].Tag is SiteData siteData ? siteData : null;
        private SiteData preSiteData;

        private Dictionary<string, bool> urlDict = new Dictionary<string, bool>();
        private Timer navigateTimer = new Timer();

        public MainForm()
        {
            InitializeComponent();

            userData = UserData.Instance;

            WindowState = FormWindowState.Maximized;

            //Only perform layout when control has completly finished resizing
            ResizeBegin += (s, e) => SuspendLayout();
            ResizeEnd += (s, e) => ResumeLayout(true);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            GetUserInfo();

            LoadHelpHtml();
            ShowHelpOnBrowser();

            backgroundWorker.RunWorkerAsync();
        }

        private void LoadHelpHtml()
        {
            string curDir = Directory.GetCurrentDirectory();
            helpUri = new Uri($"file:///{curDir}/Html/help.html");
        }

        private void ShowHelpOnBrowser()
        {
            //webBrowser.Url = helpUri;
            webBrowser.Navigate(helpUri);
        }

        private void GetUserInfo()
        {
            var headerData = new HeaderData { AUTHORIZATION = userData.Token };
            var headerDict = Utils.ToDict(headerData);
            var succeed = Utils.HttpGetApi(WebApi.GetUserInfo.Url, headerDict, new Dictionary<string, string>(),
                out var result);

            if (succeed)
            {
                userData.UserInfo = serializer.Deserialize<GetUserInfoResponse>(result);
                userButton.Text = string.Format("你好,{0}", userData.UserInfo.data.nickname);
            }
        }

        private void GetAccountList()
        {
            var headerData = new HeaderData { AUTHORIZATION = userData.Token };
            var headerDict = Utils.ToDict(headerData);
            var queryData = new GetAccountQueryData { filter_model = UserData.Instance.UserConfigManager.AccountMode };
            var queryDict = Utils.ToDict(queryData);
            var succeed = Utils.HttpGetApi(WebApi.GetAccountList.Url, headerDict, queryDict, out var result);

            if (succeed)
            {
                userData.AccountList = serializer.Deserialize<GetAccountListResponse>(result);
                userData.RefreshAccountDict();

                imageBackgroundWorker.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Get account web api is broken with " + WebApi.GetAccountList.Url);
            }
        }

        private void GetAccountCookie(string accountId)
        {
            var headerData = new HeaderData { AUTHORIZATION = userData.Token };
            var headerDict = Utils.ToDict(headerData);
            var queryData = new GetAccountCookieQueryData { account_id = accountId };
            var queryDict = Utils.ToDict(queryData);
            var succeed = Utils.HttpGetApi(WebApi.GetAccountCookie.Url, headerDict, queryDict, out var result);

            if (succeed)
            {
                userData.AccountCookie = serializer.Deserialize<GetAccountCookieResponse>(result);
            }
            else
            {
                MessageBox.Show("Get account cookie web api is broken with " + WebApi.GetAccountList.Url);
            }
        }

        private void GetAccountPassword(string accountId)
        {
            var headerData = new HeaderData { AUTHORIZATION = userData.Token };
            var headerDict = Utils.ToDict(headerData);
            var queryData = new GetAccountPasswordQueryData { account_id = accountId };
            var queryDict = Utils.ToDict(queryData);
            var succeed = Utils.HttpGetApi(WebApi.GetAccountPassword.Url, headerDict, queryDict, out var result);

            if (succeed)
            {
                userData.AccountPassword = serializer.Deserialize<GetAccountPasswordResponse>(result);
            }
            else
            {
                MessageBox.Show("Get password web api is broken with " + WebApi.GetAccountList.Url);
            }
        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            GetAccountList();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            siteListView.Items.Clear();
            var siteIndex = 0;
            var imageCount = siteListView.SmallImageList.Images.Count;
            foreach (var pair in userData.AccountDict)
            {
                var siteData = pair.Key;
                ListViewItem item = new ListViewItem(siteData.Name)
                {
                    Tag = siteData,
                    ImageIndex = siteIndex++ % imageCount
                };
                siteListView.Items.Add(item);
            }
        }

        private void siteListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (siteListView.SelectedItems.Count <= 0)
                return;

            if (CurrentSiteData != null && userData.AccountDict.ContainsKey(CurrentSiteData) && preSiteData != CurrentSiteData)
            {
                FilterContent(CurrentSiteData);

                searchTextBox.TextChanged -= searchTextBox_TextChanged;
                searchTextBox.Text = string.Empty;
                searchTextBox.TextChanged += searchTextBox_TextChanged;

                ShowHelpOnBrowser();

                preSiteData = CurrentSiteData;
            }
        }

        private void userListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (CurrentAccountData == null)
                return;

            if (CurrentSiteData == null)
                return;

            if (preAccountData == CurrentAccountData)
                return;

            preAccountData = CurrentAccountData;

            // get password first.
            GetAccountPassword(CurrentAccountData.Id);
            CurrentAccountData.Password = userData.AccountPassword.data.code;

            if (string.IsNullOrEmpty(CurrentAccountData.Password))
                MessageBox.Show("User " + CurrentAccountData.Username + ", password is empty!");
            else
            {
                // navigate url.
                linkLabel.Text = CurrentSiteData.RealUrl;
                //webBrowser.Url = new Uri(CurrentSiteData.RealUrl);
                if (!urlDict.ContainsKey(CurrentSiteData.RealUrl) || urlDict[CurrentSiteData.RealUrl])
                    urlDict[CurrentSiteData.RealUrl] = false;
                webBrowser.Navigate(CurrentSiteData.RealUrl);

                navigateTimer.Enabled = true;
                navigateTimer.Interval = 2000;
                navigateTimer.Start();
                navigateTimer.Tick += OnNavigateTick;
            }
        }

        private void OnNavigateTick(object sender, EventArgs e)
        {
            navigateTimer.Tick -= OnNavigateTick;
            navigateTimer.Enabled = false;
            navigateTimer.Stop();


            if (CurrentSiteData != null)
            {
                CurrentSiteData.AutoLogin.Reset();
                CurrentSiteData.AutoLogin.AutoLogin(CurrentAccountData.Username, CurrentAccountData.Password,
                    webBrowser.Document);
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            var keyword = searchTextBox.Text;

            if (CurrentSiteData == null)
                return;

            if (userData.AccountDict.ContainsKey(CurrentSiteData))
                FilterContent(CurrentSiteData, keyword);
        }

        private void FilterContent(SiteData siteData, string keyword = "")
        {
            if (siteData == null)
                return;

            userListView.Items.Clear();
            var accountList = userData.AccountDict[siteData];
            accountList.Where(account => account.Nickname.Contains(keyword)).ToList().ForEach(account =>
            {
                ListViewItem item = new ListViewItem(account.Nickname)
                {
                    Tag = account,
                    ImageKey = !string.IsNullOrEmpty(account.Id) && userImageList.Images.ContainsKey(account.Id) ? account.Id : "Default"
                };
                userListView.Items.Add(item);
            });
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (CurrentAccountData == null)
                return;

            if (CurrentSiteData == null)
                return;

            if (urlDict.ContainsKey(CurrentSiteData.RealUrl) && !urlDict[CurrentSiteData.RealUrl])
            {
                //urlDict[CurrentSiteData.RealUrl] = true;

                //CurrentSiteData.AutoLogin.Reset();
                //CurrentSiteData.AutoLogin.AutoLogin(CurrentAccountData.Username, CurrentAccountData.Password,
                //    webBrowser.Document);
            }
        }

        private void JsInjectionExample()
        {
            HtmlElement headElement = webBrowser.Document.GetElementsByTagName("head")[0];
            HtmlElement scriptElement = webBrowser.Document.CreateElement("script");
            IHTMLScriptElement element = (IHTMLScriptElement)scriptElement.DomElement;
            element.text = "function sayHello() { alert('hello') }";
            headElement.AppendChild(scriptElement);
            webBrowser.Document.InvokeScript("sayHello");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void settingButton_Click(object sender, EventArgs e)
        {
            var versionForm = new VersionForm(webBrowser.Version.ToString());
            versionForm.ShowDialog();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void autoLoginButton_Click(object sender, EventArgs e)
        {
            if (CurrentAccountData == null || CurrentSiteData == null)
                return;

            CurrentSiteData.AutoLogin.Reset();
            CurrentSiteData.AutoLogin.AutoLogin(CurrentAccountData.Username, CurrentAccountData.Password, webBrowser.Document);
        }

        private void imageBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            userData.AccountDict.SelectMany(site => site.Value).ToList().ForEach(account =>
            {
                if (account.Icon == null)
                    account.Icon = ImageUtils.LoadImage(account.Avatar);
                if (account.Icon != null)
                {
                    void Image() => userImageList.Images.Add(account.Id, account.Icon);
                    userListView.BeginInvoke((Action) Image);

                    System.Threading.Thread.Sleep(100);
                }
            });
        }

        private void imageBackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            void Content() => FilterContent(siteListView.SelectedItems.Count > 0
                ? siteListView.SelectedItems[0].Tag as SiteData
                : null);
            BeginInvoke((Action) Content);
        }

        private void testIEButton_Click(object sender, EventArgs e)
        {
            webBrowser.Navigate("https://ie.icoa.cn/");
        }
    }
}
