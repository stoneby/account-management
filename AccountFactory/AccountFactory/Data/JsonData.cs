using System.Collections.Generic;

namespace AccountFactory
{
    /*
    {
        "username": "周路路",
        "password": "123123"
    }
     */
    public class LoginData
    {
        public string username;
        public string password;
    }

    public class HeaderData
    {
        public string AUTHORIZATION;
    }

    public class GetAccountQueryData
    {
        public string filter_model;
    }

    public class GetAccountCookieQueryData
    {
        public string account_id;
    }

    public class GetAccountPasswordQueryData
    {
        public string account_id;
    }

    public class BaseResponse
    {
        public int code;
        public string msg;
    }
    /*
     {
        "code": 0,
        "msg": "login success",
        "data": 
        {
            "access_token": "MQkxMAkxNTM0MTQyNDEwCWQ0ZTU4YTZlYzc3YzhiNGRjYTk0YzRkNDQxYTU2OTk4ODU5ZmI5ZjA="
        }
    }
     */
    public class LoginResponse : BaseResponse
    {
        public LoginResponseData data;
    }

    public class LoginResponseData
    {
        public string access_token;
    }

    /*
    {
        "code": 0,
        "msg": "success",
        "data": 
        {
            "id": 10,
            "name": "周路路",
            "nickname": "周路路",
            "role": "普通用户"
        }
    }
     */
    public class GetUserInfoResponse : BaseResponse
    {
        public GetUserInfoResponseData data;
    }

    public class GetUserInfoResponseData
    {
        public int id;
        public string name;
        public string nickname;
        public string role;
    }

    /*
     {
        "code": 0,
        "msg": "success",
        "data": [
            {
                "id": 7,
                "url": null,
                "username": "15564083222",
                "nickname": "以前那点事",
                "avatar": "https://s1.ax1x.com/2018/06/28/Pi8uQS.png",
                "classify": {
                    "id": 28,
                    "name": "文化"
                },
                "terrace": {
                    "id": 3,
                    "name": "大鱼号",
                    "link": "https://mp.dayu.com/",
                    "hide": null
                }
            }
        ]
    }
     */
    public class GetAccountListResponse : BaseResponse
    {
        public List<GetAccountListResponseData> data;
    }

    public class GetAccountListResponseData
    {
        public int id;
        public string url;
        public string username;
        public string nickname;
        public string avatar;
        public Classify classify;
        public Terrace terrace;
    }

    public class Classify
    {
        public int id;
        public string name;
    }

    public class Terrace
    {
        public int id;
        public string name;
        public string link;
        public string hide;
    }

    /*
     {
        "code": 0,
        "message": "success",
        "data": {
            "cookie": "BAIDUID=9BDC2DB498959D0AC086F2DE14836982:FG=1; BDUSS=X5iNXZsNlhvM3dpYjhFWWR1M0prWlpYRlptYjFnV2hvU3BEYTdBcVRCd2VZZEJhQVFBQUFBJCQAAAAAAAAAAAEAAABh9yRjAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAB7UqFoe1KhaY; FP_UID=98d2e5d2708836f28b676889977c8d75; Hm_lpvt_f2ee7f5c2284ca4c112e62165bc44c75=1521013802; Hm_lvt_f2ee7f5c2284ca4c112e62165bc44c75=1521013802"
        }
    }
     */
    public class GetAccountCookieResponse : BaseResponse
    {
        public GetAccountCookieResponseData data;
    }

    public class GetAccountCookieResponseData
    {
        public string cookie;
    }

    /*
    {
        "code": 0,
        "msg": "success",
        "data": {
            "code": "wk201314"
        }
    }
     */
    public class GetAccountPasswordResponse : BaseResponse
    {
        public GetAccountPasswordResponseData data;
    }

    public class GetAccountPasswordResponseData
    {
        public string code;
    }
}
