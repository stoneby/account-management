using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace AccountFactory
{
    public partial class LoginForm : Form
    {
        private string username;
        private string password;

        private UserData userData;
        private UserConfManager userConfManager;

        private readonly JavaScriptSerializer serializer = new JavaScriptSerializer();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            userData = UserData.Instance;
            ReadConfig();

            keepCheckBox.Checked = userData.UserConfigManager.LastUserConf?.IsKept ?? false;
        }

        private void ReadConfig()
        {
            if (File.Exists(Utils.ConfPath))
            {
                var input = File.ReadAllText(Utils.ConfPath);
                userConfManager = serializer.Deserialize<UserConfManager>(input);
                var currentUserConf = userConfManager.LastUserConf;
                if (currentUserConf != null)
                {
                    userTextBox.Text = currentUserConf.Username;
                    passwordTextBox.Text = currentUserConf.IsKept ? currentUserConf.Password : string.Empty;
                }
            }
            else
            {
                userConfManager = new UserConfManager {LastIndex = -1, UserConfList = new List<UserConf>()};
            }

            UserData.Instance.UserConfigManager = userConfManager;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            var userConf = new UserConf
            {
                Username = userTextBox.Text,
                Password = passwordTextBox.Text,
                IsKept = keepCheckBox.Checked
            };

            // save to http web request.
            var jsonStr = serializer.Serialize(new LoginData
            {
                username = userConf.Username,
                password = userConf.Password,
            });
            var query = serializer.Deserialize<Dictionary<string, string>>(jsonStr);

            var succeed = Utils.HttpPostApi(WebApi.Login.Url, Utils.MethodType.Post, query, out var response);
            if (succeed)
            {
                var loginResponse = serializer.Deserialize<LoginResponse>(response);
                userData.Token = loginResponse.data.access_token;

                // save to local user config within json format.
                var currentIndex = userConfManager.UserConfList.FindIndex(conf => conf.Username.Equals(userConf.Username));
                if (currentIndex == -1)
                    userConfManager.UserConfList.Add(userConf);
                userConfManager.LastIndex = (currentIndex == -1) ? userConfManager.UserConfList.Count - 1 : currentIndex;

                var userConfManagerJson = serializer.Serialize(userConfManager);
                File.WriteAllText(Utils.ConfPath, userConfManagerJson);
            }
            else
                MessageBox.Show(response);

            DialogResult = succeed ? DialogResult.OK : DialogResult.Abort;
        }

        private bool ValidateInput()
        {
            return !string.IsNullOrEmpty(userTextBox.Text) && !string.IsNullOrEmpty(passwordTextBox.Text);
        }

        private void userTextBox_TextChanged(object sender, EventArgs e)
        {
            var userName = userTextBox.Text;
            var confIndex = userConfManager.UserConfList.FindIndex(conf => conf.Username.Contains(userName));
            if (confIndex != -1)
            {
                userTextBox.Text = userConfManager.UserConfList[confIndex].Username;
                passwordTextBox.Text = userConfManager.UserConfList[confIndex].Password;
                userConfManager.LastIndex = confIndex;
            }
            else
            {
                passwordTextBox.Text = string.Empty;
            }
        }
    }
}
