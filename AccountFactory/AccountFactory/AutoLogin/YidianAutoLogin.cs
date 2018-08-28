using System.Windows.Forms;

namespace AccountFactory.AutoLogin
{
    public class YiDianAutoLogin : AbstractAutoLogin
    {
        public override void AutoLogin(string username, string password, HtmlDocument doc)
        {
            base.AutoLogin(username, password, doc);

            StateMachine.AddState(new NavigatePageState
            {
                Doc = doc,
                Password = password,
                Username = username,
            });
            StateMachine.AddState(new ClickAccountState
            {
                Doc = doc,
                Password = password,
                Username = username,
            });
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

        public class NavigatePageState : AbstractState
        {
            public override void OnEnter()
            {
                base.OnEnter();

                var container = Doc.GetElementsByTagName("LI");
                if (container.Count <= 1)
                {
                    NextState = typeof(NavigatePageState);
                    return;
                }

                container[1].InvokeMember("Click");
                NextState = typeof(ClickAccountState);
                StateMachine.SetNextState(typeof(ClickAccountState));
            }
        }

        public class ClickAccountState : AbstractState
        {
            public override void OnEnter()
            {
                base.OnEnter();

                Doc.GetElementsByClass("mp-btn mp-btn-cancel login-btn").InvokeMember("Click");

                StateMachine.SetNextState(typeof(FillContentState));
            }
        }

        public class FillContentState : AbstractState
        {
            public override void OnEnter()
            {
                base.OnEnter();

                var loginForm = Doc.Forms.GetElementByClass("status-panel login");
                loginForm.GetElementsByClass("input l-input margin-bottom").SetAttribute("value", Username);
                loginForm.GetElementsByClass("input l-input").SetAttribute("value", Password);

                StateMachine.SetNextState(typeof(SubmitState));
            }
        }

        public class SubmitState : AbstractState
        {
            public override void OnEnter()
            {
                base.OnEnter();

                //var submitButton = Utils.GetHtmlElement(doc, "BUTTON", null,
                //    new List<KeyValuePair<string, string>>
                //    {
                //        new KeyValuePair<string, string>("type", "submit")
                //    });
                //submitButton?.InvokeMember("Click");

                StateMachine.SetNextState(typeof(EndState));
            }
        }
    }
}