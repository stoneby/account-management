using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using Microsoft.Win32;

namespace AccountFactory
{
    public class Utils
    {
        public enum MethodType
        {
            Get,
            Post,
        }

        public enum ParamType
        {
            Header,
            Query,
            Post,
        }

        private static readonly JavaScriptSerializer serializer = new JavaScriptSerializer();
        public static string ConfPath = "conf.txt";

        public static bool HttpPostApi(string url, MethodType type, Dictionary<string, string> queryDict,
            out string result)
        {
            return HttpApiHelper(url, MethodType.Post, new Dictionary<ParamType, Dictionary<string, string>>
            {
                {ParamType.Post, queryDict},
            }, out result);
        }

        public static bool HttpGetApi(string url, Dictionary<string, string> header,
            Dictionary<string, string> queryDict, out string result)
        {
            return HttpApiHelper(url, MethodType.Get, new Dictionary<ParamType, Dictionary<string, string>>
            {
                {ParamType.Header, header},
                {ParamType.Query, queryDict},
            }, out result);
        }

        public static bool HttpApiHelper(string url, MethodType method,
            Dictionary<ParamType, Dictionary<string, string>> paramDict, out string result)
        {
            Encoding encoding = Encoding.UTF8;

            if (paramDict.ContainsKey(ParamType.Query))
            {
                var queryStr = string.Empty;
                if (paramDict[ParamType.Query].Count > 0)
                {
                    foreach (var pair in paramDict[ParamType.Query])
                    {
                        queryStr +=
                            $"{HttpUtility.UrlEncode(pair.Key, encoding)}={HttpUtility.UrlEncode(pair.Value, encoding)}&";
                    }

                    queryStr = queryStr.Remove(queryStr.Length - 1);
                }

                url = method == MethodType.Get ? $"{url}?{queryStr}" : url;
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "text/html,application/xhtml+xml,*/*";
            request.ContentType = "application/json";
            request.Method = method.ToString().ToUpper();
            if (paramDict.ContainsKey(ParamType.Header))
            {
                foreach (var pair in paramDict[ParamType.Header])
                {
                    request.Headers.Add(pair.Key, pair.Value);
                }
            }

            var succeed = false;
            try
            {
                if (method == MethodType.Post)
                {
                    var serializer = new JavaScriptSerializer();
                    var postJson = serializer.Serialize(paramDict[ParamType.Post]);
                    byte[] buffer = encoding.GetBytes(postJson);
                    request.ContentLength = buffer.Length;
                    request.GetRequestStream().Write(buffer, 0, buffer.Length);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                    succeed = true;
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return succeed;
        }

        public static Dictionary<string, string> ToDict<T>(T theType)
        {
            var json = serializer.Serialize(theType);
            return serializer.Deserialize<Dictionary<string, string>>(json);
        }

        public static HtmlElement GetHtmlElement(HtmlDocument doc, string tag, List<string> attribteConditionList = null, List<KeyValuePair<string, string>> attributePairList = null)
        {
            for (var i = 0; i < doc.All.Count; i++)
                if (string.IsNullOrEmpty(tag) || doc.All[i].TagName.ToUpper().Equals(tag))
                    if (attribteConditionList == null || attribteConditionList.All(condition =>
                        string.IsNullOrEmpty(doc.All[i].GetAttribute(condition))))
                        if (attributePairList == null || attributePairList.All(pair => doc.All[i].GetAttribute(pair.Key).Equals(pair.Value)))
                            return doc.All[i];
            return null;
        }

        public static void EnsureBrowserEmulationEnabled(string exename = "MarkdownMonster.exe", bool uninstall = false)
        {
            try
            {
                using (
                    var rk = Registry.CurrentUser.OpenSubKey(
                        @"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true)
                )
                {
                    if (!uninstall)
                    {
                        dynamic value = rk.GetValue(exename);
                        if (value == null)
                            rk.SetValue(exename, (uint)11001, RegistryValueKind.DWord);
                    }
                    else
                        rk.DeleteValue(exename);
                }
            }
            catch
            {
            }
        }
    }
}
