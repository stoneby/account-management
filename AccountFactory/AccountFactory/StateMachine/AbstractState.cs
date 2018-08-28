using System;
using System.Windows.Forms;

namespace AccountFactory
{
    public abstract class AbstractState
    {
        public Type NextState;

        public string Username;
        public string Password;
        public HtmlDocument Doc;

        public virtual void OnEnter()
        {
            Console.WriteLine("OnEnter:" + this);
        }

        public virtual void OnExit()
        {
            Console.WriteLine("OnExit: " + this);
        }
    }

    public class EndState:AbstractState
    {
    }
}
