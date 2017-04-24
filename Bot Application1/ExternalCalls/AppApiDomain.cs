using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace BotApplication1
{
    public enum CompileOptions {None, UserName, UserNameAndMsisdn };

    class AppApiDomain
    {
        private static string uri = "https://api.telenor.se/c";
        //private static string uri = "https://apitest1.telenor.se/c";
        //private static string appUserName = "johan";
        //private static string appPassWord = "b2fpC3wfPxkJMCobRL9x";
        //private static string appUserName = "intelecom";
        //private static string appPassWord = "58JSgel23kl88";
        //private static string appUserName = "softphone";
        //private static string appPassWord = "soft_phone";
        private static string appUserName = "frontcelltest";
        private static string appPassWord = "MtC7ZwO08kvrSYvDyviV";
        //#define API_USERNAME_PROD       "vnqchk7ufg9r7qit" Telenor One App
        //#define API_PASSWORD_PROD      "LHatL3JIPORxMMBP"

        public static string userName="0709614660";
        public static string userPassword = "summer2000";

        public static User CurrentUser { get; set; }

        public static HttpWebRequest CreateWebRequest(string CommandString, string Method)
        {
            HttpWebRequest webRequestObj = WebRequest.Create(uri + CommandString) as HttpWebRequest;

            string userName_ = appUserName + "|" + userName;
            string passWord_ = appPassWord + "|" + userPassword;

            webRequestObj.Credentials = new NetworkCredential(userName_, passWord_);
            webRequestObj.ContentType = "application/xml";
            webRequestObj.Accept = "application/xml";
            webRequestObj.Headers.Add("X-version", "1");
            webRequestObj.Headers.Add("Accept-Language", "sv");

            webRequestObj.Method = Method;

            return webRequestObj;
        }

        public static string CompileCommand(CompileOptions options, string cmd, params string[] args)
        {
            string returnStr=null;

            switch (options)
            {
                case CompileOptions.None:

                case CompileOptions.UserName:
                    returnStr = cmd.Replace("{username}", userName);
                    break;
                case CompileOptions.UserNameAndMsisdn:
                    returnStr = cmd.Replace("{username}", userName);
                    returnStr = returnStr.Replace("{msisdn}",CurrentUser.selectedMsisdn); 
                    break;
            }

            if (args != null)
            {
                foreach (string arg in args)
                {
                    int start = returnStr.IndexOf("{");
                    int end = returnStr.IndexOf("}");
                    string item = returnStr.Substring(start, end - start + 1);

                    returnStr = returnStr.Replace(item, arg);
                }
            }

            return returnStr;
        }

    }
}
