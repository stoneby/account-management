using System.Windows.Forms;

namespace AccountFactory.AutoLogin
{
    public class KuaiChuanAutoLogin : AbstractAutoLogin
    {
        public override void AutoLogin(string username, string password, HtmlDocument doc)
        {
            base.AutoLogin(username, password, doc);

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

        public class ClickLogin : AbstractState
        {
            public override void OnEnter()
            {
                base.OnEnter();

                if (Doc.GetElementsByTagName("a").Count <= 5)
                {
                    NextState = typeof(ClickLogin);
                    return;
                }

                Doc.GetElementsByTagName("a")[5].InvokeMember("click");
                NextState = typeof(ClickAccountState);
                StateMachine.SetNextState(typeof(ClickAccountState));
            }
        }

        public class ClickAccountState : AbstractState
        {
            public override void OnEnter()
            {
                base.OnEnter();

                if (Doc.GetElementsByTagName("a").Count > 33)
                    Doc.GetElementsByTagName("a")[33].InvokeMember("click");

                NextState = typeof(FillContentState);
                StateMachine.SetNextState(typeof(FillContentState));
            }
        }

        public class FillContentState : AbstractState
        {
            public override void OnEnter()
            {
                base.OnEnter();

                Doc.GetElementsByClass("quc-input quc-input-account").SetAttribute("value", Username);
                Doc.GetElementsByClass("quc-input quc-input-password").SetAttribute("value", Password);

                NextState = typeof(SubmitState);
                StateMachine.SetNextState(typeof(SubmitState));
            }
        }

        public class SubmitState : AbstractState
        {
            public override void OnEnter()
            {
                base.OnEnter();

                //var submitButton = Utils.GetHtmlElement(doc, "INPUT", null,
                //    new List<KeyValuePair<string, string>>
                //    {
                //        new KeyValuePair<string, string>("type", "submit")
                //    });
                //submitButton?.InvokeMember("Click");

                NextState = typeof(EndState);
                StateMachine.SetNextState(typeof(EndState));
            }
        }

    }
}