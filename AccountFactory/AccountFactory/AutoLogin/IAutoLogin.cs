using System.Windows.Forms;

namespace AccountFactory
{
    public interface IAutoLogin
    {
        void AutoLogin(string username, string password, HtmlDocument doc);
        void Reset();
    }
}
