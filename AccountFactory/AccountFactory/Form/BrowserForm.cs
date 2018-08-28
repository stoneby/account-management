#if CEF
using CefSharp;
using CefSharp.WinForms;
using System;
using System.Windows.Forms;

namespace AccountFactory
{
    public partial class BrowserForm : Form
    {
        private ChromiumWebBrowser browser;

        public BrowserForm()
        {
            InitializeComponent();
        }

        private void BrowserForm_Load(object sender, EventArgs e)
        {
            Cef.Initialize(new CefSettings());
            browser = new ChromiumWebBrowser("www.baidu.com");
            this.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
        }

        private void BrowserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            browser.ShowDevTools();
        }
    }
}
#endif