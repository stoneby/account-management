using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountFactory.AutoLogin
{
    public class QutoutiaoAutoLogin : AbstractAutoLogin
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

                var container = Doc.GetElementsByTagName("INPUT");
                if (container.Count < 2)
                {
                    NextState = typeof(FillContentState);
                    return;
                }

                var user = container[0];
                user.SetAttribute("value", Username);
                var password = container[1];
                password.SetAttribute("value", Password);

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
