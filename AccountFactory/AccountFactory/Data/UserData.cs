using AccountFactory.AutoLogin;
using System.Collections.Generic;
using System.Drawing;

namespace AccountFactory
{
    public class UserData
    {
        public static UserData Instance => singleton ?? (singleton = new UserData());
        private static UserData singleton;

        public UserConfManager UserConfigManager;
        public string Token;

        public GetUserInfoResponse UserInfo;

        public GetAccountListResponse AccountList;
        public GetAccountCookieResponse AccountCookie;
        public GetAccountPasswordResponse AccountPassword;

        public Dictionary<SiteData, List<AccountData>> AccountDict;

        public void RefreshAccountDict()
        {
            AccountDict = new Dictionary<SiteData, List<AccountData>>();
            AccountList.data.ForEach(account =>
            {
                var siteData = new SiteData
                {
                    Id = account.terrace.id,
                    Link = account.terrace.link,
                    Name = account.terrace.name
                };
                if (!AccountDict.ContainsKey(siteData))
                {
                    AccountDict[siteData] = new List<AccountData>();
                }

                AccountDict[siteData].Add(new AccountData
                {
                    Avatar = account.avatar,
                    Id =  account.id.ToString(),
                    Link = account.url,
                    Username = account.username,
                    Nickname = account.nickname
                });
            });
        }
    }

    public class SiteData
    {
        public int Id;
        public string Name;
        public string Link;

        public IAutoLogin AutoLogin => AutoLoginList[Id - 1];

        public static List<IAutoLogin> AutoLoginList = new List<IAutoLogin>
        {
            new BaiJiaAutoLogin(),
            new ToutiaoAutoLogin(),
            new DayuAutoLogin(),
            //new YiDianAutoLogin(),
            //new KuaiChuanAutoLogin(),
            //new QQAutoLogin(),
            new QieAutoLogin(),
            new YiDianAutoLogin(),
            new KuaiChuanAutoLogin(),
            new QutoutiaoAutoLogin(),
            new QQAutoLogin(),
        };

        public string UrlExtention => UrlExtensionList[Id - 1];

        public string RealUrl => (string.IsNullOrEmpty(UrlExtention) ? Link : UrlExtention);

        public static List<string> UrlExtensionList = new List<string>
        {
            "https://baijiahao.baidu.com/builder/app/login",
            "https://sso.toutiao.com/login/",
            "",
            //"https://mp.yidianzixun.com/",
            //"http://kuaichuan.360.cn/",
            //"https://mp.qq.com/",
            "",
            "",
            "",
            "",
            "",
        };

        public override bool Equals(object obj)
        {
            if (obj is SiteData data)
                return Id == data.Id;
            return false;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
    }

    public class AccountData
    {
        public string Id;
        public string Avatar;
        public string Username;
        public string Nickname;
        public string Link;
        public string Password;

        public Image Icon;

        public static string DufaultPassword = "wk201314";
    }
}
