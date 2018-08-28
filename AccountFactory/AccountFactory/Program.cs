using System;
using System.Windows.Forms;

namespace AccountFactory
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DialogResult result;
            var loginForm = new LoginForm();
            do
            {
                result = loginForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // login was successful
                    Application.Run(new MainForm());
                    //Application.Run(new BrowserForm());
                    break;
                }
            } while (result == DialogResult.Abort);
        }
    }
}
