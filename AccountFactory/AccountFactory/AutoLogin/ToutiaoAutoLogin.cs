using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountFactory.AutoLogin
{
    public class ToutiaoAutoLogin : AbstractAutoLogin
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

                var account = Doc.GetElementsByClass("sns  mail-login");
                if (account == null)
                {
                    NextState = typeof(ClickAccountState);
                    return;
                }

                account.InvokeMember("Click");
                NextState = typeof(FillContentState);
                StateMachine.SetNextState(typeof(FillContentState));
            }
        }

        public class FillContentState : AbstractState
        {
            public override void OnEnter()
            {
                base.OnEnter();

                var userElement = Utils.GetHtmlElement(Doc, "INPUT", null,
                    new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("id", "account")
                    });
                if (userElement != null)
                    userElement.SetAttribute("value", Username);

                var passwordElement = Utils.GetHtmlElement(Doc, "INPUT", null,
                    new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("id", "password")
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

                var submitButton = Utils.GetHtmlElement(Doc, "INPUT", null,
                    new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("type", "submit")
                    });
                //submitButton?.InvokeMember("Click");

                NextState = typeof(EndState);
                StateMachine.SetNextState(typeof(EndState));
            }
        }
    }
}
