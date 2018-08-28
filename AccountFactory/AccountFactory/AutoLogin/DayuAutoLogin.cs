using System.Windows.Forms;

namespace AccountFactory.AutoLogin
{
    public class DayuAutoLogin : AbstractAutoLogin
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

                if (Doc.Window.Frames.Count <= 0 || Doc.Window.Frames[0].GetDocument() == null
                    || Doc.Window.Frames[0].GetDocument().GetElementById("login_name") == null)
                {
                    NextState = typeof(FillContentState);
                    return;
                }

                var iframeDoc = Doc.Window.Frames[0].GetDocument();
                iframeDoc.GetElementById("login_name").SetAttribute("value", Username);
                iframeDoc.GetElementById("password").SetAttribute("value", Password);

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
                //        new KeyValuePair<string, string>("id", "submit_btn")
                //    });
                //submitButton?.InvokeMember("Click");

                NextState = typeof(EndState);
                StateMachine.SetNextState(typeof(EndState));
            }
        }

    }
}