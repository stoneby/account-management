using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountFactory.AutoLogin
{
    public class QieAutoLogin : AbstractAutoLogin
    {
        public override void AutoLogin(string username, string password, HtmlDocument doc)
        {
            base.AutoLogin(username, password, doc);

            StateMachine.AddState(new FillContentState
            {
                Doc = doc,
                Password = password,
                Username = username,
            });
            StateMachine.AddState(new SubmitState
            {
                Doc = doc,
                Password = password,
                Username = username,
            });
            StateMachine.AddState(new EndState());
        }

        public class FillContentState : AbstractState
        {
            public override void OnEnter()
            {
                base.OnEnter();

                var userElement = Utils.GetHtmlElement(Doc, "INPUT", new List<string> { "placeholder" },
                    new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("type", "text")
                    });
                if (userElement != null)
                    userElement.SetAttribute("value", Username);
                else
                {
                    NextState = typeof(FillContentState);
                    return;
                }

                var passwordElement = Utils.GetHtmlElement(Doc, "INPUT", new List<string> { "placeholder" },
                    new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("type", "password")
                    });
                if (passwordElement != null)
                    passwordElement.SetAttribute("value", Password);

                NextState = typeof(SubmitState);
                StateMachine.SetNextState(typeof(SubmitState));
            }
        }

        public class SubmitState : AbstractState
        {
            public override void OnEnter()
            {
                base.OnEnter();

                //var submitButton = Utils.GetHtmlElement(doc, "INPUT", null, new List<KeyValuePair<string, string>>
                //{
                //    new KeyValuePair<string, string>("id", "TANGRAM__PSP_4__submit")
                //});
                //submitButton?.InvokeMember("Click");

                NextState = typeof(EndState);
                StateMachine.SetNextState(typeof(EndState));
            }
        }
    }
}
