using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace AccountFactory
{
    public class UserConf
    {
        public string Username;
        public string Password;
        public bool IsKept;
    }

    public class UserConfManager
    {
        public List<UserConf> UserConfList;
        public int LastIndex;

        public string AccountMode;

        [ScriptIgnore]
        public UserConf LastUserConf
        {
            get
            {
                if (LastIndex >= 0 && LastIndex < UserConfList.Count)
                    return UserConfList[LastIndex];
                return null;
            }
        }
    }
}
