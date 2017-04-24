using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Xml.Serialization;
using System.Security;

namespace BotApplication1
{

    class UserDomain
    {
        private static string appName = "TelenorDashBoard";

        private static void StoreUserNameAndPassword(string userName, string passWord)
        {
            CredentialManager.WriteCredential(appName, userName, passWord);
            AppApiDomain.userName = userName;
            AppApiDomain.userPassword = passWord;
        }

        public static Boolean HasExistingUserNameAndPassword()
        {
            Credential CredentialObj = CredentialManager.ReadCredential(appName);
            if (CredentialObj != null)
            { return true; }
            else
            { return false; }
        }

        public static void ResetUserNameAndPassword()
        {
            CredentialManager.WriteCredential(appName, "", "");
        }

        public static Credential GetCredential()
        {
            return CredentialManager.ReadCredential(appName);
        }

        public static User AuthenticateSavedUser()
        {
            Credential CredentialObj = CredentialManager.ReadCredential(appName);
            if (CredentialObj != null)
            {
                User UserObj = AuthenticateUser(CredentialObj.UserName, CredentialObj.Password);
                if (UserObj != null)
                {
                    AppApiDomain.userName = CredentialObj.UserName;
                    AppApiDomain.userPassword = CredentialObj.Password;
                    return UserObj;
                }
            }

            return null;
        }

        public static string GetApiVersion()
        {
            string CommandString = "/version/test";

            CommandString = AppApiDomain.CompileCommand(CompileOptions.None, CommandString, null);

            HttpWebRequest webRequestObj = AppApiDomain.CreateWebRequest(CommandString, "GET");

            WebResponse webResponceObj = webRequestObj.GetResponse();

            StreamReader reader = new StreamReader(webResponceObj.GetResponseStream());

            return reader.ReadToEnd();
        }

        public static User AuthenticateUser(string UserName, string PassWord)
        {
            try
            {
                AppApiDomain.userName = UserName;
                AppApiDomain.userPassword = PassWord;

                if (string.IsNullOrEmpty(UserName))
                { return null; }

                string CommandString = "/users/{username}";

                CommandString = AppApiDomain.CompileCommand(CompileOptions.UserName, CommandString, null);

                HttpWebRequest webRequestObj = AppApiDomain.CreateWebRequest(CommandString, "GET");

                WebResponse webResponceObj = webRequestObj.GetResponse();

                StreamReader reader = new StreamReader(webResponceObj.GetResponseStream());

                XmlSerializer serializer = new XmlSerializer(typeof(User));
                User UserObj = (User)serializer.Deserialize(reader);

                webResponceObj.Close();

                if (UserObj != null)
                {
                    StoreUserNameAndPassword(UserName, PassWord);
                    UserObj.selectedMsisdn = UserObj.msisdns[0].msisdn;
                    AppApiDomain.CurrentUser = UserObj;
                }
                else
                {
                    UserDomain.ResetUserNameAndPassword();
                }

                return UserObj;
            }
            catch
            {
                UserDomain.ResetUserNameAndPassword();
                AppApiDomain.CurrentUser = null;
                return null;
            }
        }

    }
}
