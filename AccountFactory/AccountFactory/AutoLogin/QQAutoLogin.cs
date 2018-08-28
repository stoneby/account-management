using System.Windows.Forms;

namespace AccountFactory.AutoLogin
{
    public class QQAutoLogin : AbstractAutoLogin
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

        public class ClickAccountState : AbstractState
        {
            public override void OnEnter()
            {
                base.OnEnter();

                var iframe = Doc.Window.Frames["login_if"];
                if (iframe == null)
                {
                    NextState = typeof(ClickAccountState);
                    return;
                }

                var iframeDoc = iframe.GetDocument();
                iframeDoc.GetElementById("switcher_plogin").InvokeMember("Click");

                NextState = typeof(FillContentState);
                StateMachine.SetNextState(typeof(FillContentState));
            }
        }

        public class FillContentState : AbstractState
        {
            public override void OnEnter()
            {
                base.OnEnter();

                var iframeDoc = Doc.Window.Frames["login_if"].GetDocument();
                iframeDoc.GetElementById("u").SetAttribute("value", Username);
                iframeDoc.GetElementById("p").SetAttribute("value", Password);

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