using System.Collections.Generic;

namespace AccountFactory
{
    public class WebApi
    {
        public string Url;
        
        public enum MethodType
        {
            Get,
            Post
        }

        public MethodType Method;

        public Dictionary<Utils.ParamType, Dictionary<string, string>> Param;

        public static WebApi Login = new WebApi
        {
            Url = "https://api.fxb-team.com/v1/user/login",
            Method = MethodType.Post,
        };

        public static WebApi GetUserInfo = new WebApi
        {
            Url = "https://api.fxb-team.com/v1/user/info",
            Method = MethodType.Get,
        };

        public static WebApi GetAccountList = new WebApi
        {
            Url = "https://api.fxb-team.com/v1/accounts",
            Method = MethodType.Get,
        };

        public static WebApi GetAccountCookie = new WebApi
        {
            Url = "https://api.fxb-team.com/v1/accounts/cookie",
            Method = MethodType.Get,
        };

        public static WebApi GetAccountPassword = new WebApi
        {
            Url = "https://api.fxb-team.com/v1/accounts/password",
            Method = MethodType.Get,
        };
    }
}
