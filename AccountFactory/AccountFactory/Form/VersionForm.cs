using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace AccountFactory
{
    public partial class VersionForm : Form
    {
        private readonly List<RadioButton> radioList = new List<RadioButton>();
        private string version;

        public VersionForm(string version)
        {
            InitializeComponent();
            this.version = version;
        }

        private void VersionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var selectedRadio = radioList.Where(radio => radio.Checked).Select(radio => (string) radio.Tag).ToList();
            UserData.Instance.UserConfigManager.AccountMode = selectedRadio[0];
            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(UserData.Instance.UserConfigManager);
            File.WriteAllText(Utils.ConfPath, json);
        }

        private void VersionForm_Load(object sender, EventArgs e)
        {
            radioList.Add(allAccountRadioButton);
            radioList.Add(bussinessAccountRadioButton);

            var index = int.Parse(UserData.Instance.UserConfigManager.AccountMode);
            var selectedRadio = radioList[index].Checked = true;

            versionLabel.Text = version;
        }
    }
}
