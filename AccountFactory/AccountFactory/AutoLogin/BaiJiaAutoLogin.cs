using System.Windows.Forms;

namespace AccountFactory.AutoLogin
{
    public class BaiJiaAutoLogin : AbstractAutoLogin
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

                var login = Doc.GetElementById("TANGRAM__PSP_4__footerULoginBtn");
                if (login == null || (login.Style != null && login.Style.Contains("display: none;")))
                {
                    NextState = typeof(ClickAccountState);
                    return;
                }

                login.InvokeMember("Click");
                NextState = typeof(FillContentState);
                StateMachine.SetNextState(typeof(FillContentState));
            }
        }

        public class FillContentState : AbstractState
        {
            public override void OnEnter()
            {
                base.OnEnter();

                Doc.GetElementById("TANGRAM__PSP_4__userName").SetAttribute("value", Username);
                Doc.GetElementById("TANGRAM__PSP_4__password").SetAttribute("value", Password);

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
