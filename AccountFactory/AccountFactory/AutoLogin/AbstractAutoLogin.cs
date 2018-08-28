using System;
using System.Windows.Forms;

namespace AccountFactory
{
    public abstract class AbstractAutoLogin : IAutoLogin
    {
        protected static Timer AutoTimer = new Timer();
        protected static StateMachine StateMachine = new StateMachine();

        protected HtmlDocument Doc;
        protected string Username;
        protected string Password;

        public virtual void AutoLogin(string username, string password, HtmlDocument doc)
        {
            Doc = doc;
            Username = username;
            Password = password;

            AutoTimer.Enabled = true;
            AutoTimer.Interval = 500;
            AutoTimer.Tag = Doc;
            AutoTimer.Start();
            AutoTimer.Tick += AutoTimerOnTick;

            StateMachine.Clear();

            Console.WriteLine("Start Timer: " + this + ", " + DateTime.Now.ToLongTimeString());
        }

        protected void AutoTimerOnTick(object sender, EventArgs e)
        {
            if (StateMachine.CurrentState == typeof(EndState))
            {
                Reset();
                return;
            }

            StateMachine.Execute();
        }

        public void Reset()
        {
            Console.WriteLine("Stop timer: " + this + ", " + DateTime.Now.ToLongTimeString());

            AutoTimer.Enabled = false;
            AutoTimer.Tick -= AutoTimerOnTick;
            AutoTimer.Stop();
        }
    }
}
